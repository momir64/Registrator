using iText.Kernel.Pdf.Canvas.Parser.Listener;
using iText.Kernel.Pdf.Canvas.Parser;
using System.Collections.Generic;
using iText.Kernel.Pdf;
using System.Linq;
using System;

namespace Registrator {
    public static class RegistratorFactory {
        static readonly char[] nepLat = { 'c', 'k', 'r', 'v' };
        static readonly char[] nepCir = { 'ц', 'к', 'р', 'в' };

        public static List<int>[] MakeRegistar(string pdfPath, string[] pojmovi, float procenat, float opseg, List<int> ignoreStranice, IProgress<int> progress) {
            PdfDocument pdfDocument = new PdfDocument(new PdfReader(pdfPath));
            List<int>[] stranice = new List<int>[pojmovi.Length];
            var pageNumbers = pdfDocument.GetNumberOfPages();
            for (int i = 0; i < stranice.Length; i++)
                stranice[i] = new List<int>();
            for (int pageIndex = 1; pageIndex <= pageNumbers; pageIndex++) {
                progress.Report((int)Math.Round(pageIndex * 100f / pageNumbers));
                SimpleTextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                new PdfCanvasProcessor(strategy).ProcessPageContent(pdfDocument.GetPage(pageIndex));
                string page = strategy.GetResultantText().RemoveWrap();

                for (int p = 0; p < pojmovi.Length; p++) {
                    pojmovi[p] = pojmovi[p].Replace('-', ' ');                                                 //briše crte
                    pojmovi[p] = new string(pojmovi[p].Where(c => char.IsLetter(c) ||
                                 new char[] { ' ', '.', '(', '/', '\\' }.Contains(c)).ToArray()).Trim();       //ostavlja samo slova, razmake i tačke
                    string[] podpojmovi = pojmovi[p].Split(new char[] { '(', '/', '\\' });
                    foreach (string podpojam in podpojmovi) {
                        List<string> pojam = podpojam.Split(' ').Where(str => str.Trim() != "").ToList();      //deli pojam na reči
                        List<string> pojamNep = new List<string>();                                            //lista reči bez nepostojanog a
                        List<int> brNep = new List<int>();                                                     //lista brojeva reči bez nepostojanog a
                        for (int i = 0; i < pojam.Count; i++) {
                            if (pojam[i].Length > 3 && pojam[i].Length < 9 &&
                                (nepLat.Contains(pojam[i].Last()) ||
                                nepCir.Contains(pojam[i].Last())) && (pojam[i][pojam[i].Length - 2] == 'a' ||
                                pojam[i][pojam[i].Length - 2] == 'а')) {
                                pojamNep.Add(pojam[i].Substring(0, pojam[i].Length - 2));
                                brNep.Add(i);
                            }
                            if ((pojam.Count > 1 || pojam[i].Length > 3) &&
                                pojam[i].Substring(Math.Max(0, pojam[i].Length - 2)) != "ић")
                                pojam[i] = pojam[i].Remove(pojam[i].Length - (pojam[i].Length > 8 ? 2 : 1));   //briše poslednje slovo sa reči ako pojam ima
                                                                                                               //više od jedne reči ili reč ima više od 3 slova
                            if (pojam[i].Length < 3) {
                                pojam.RemoveAt(i);
                                i--;
                            }
                        }
                        int minIma = Math.Max(pojam.Count == 1 ? 1 : 2,
                                             (int)Math.Round(pojam.Count * procenat));                         //minimalan broj reči da bi pojam bio nađen
                        int brBezNep = pojam.Count;
                        pojam.AddRange(pojamNep);

                        for (int r = 0; r < pojam.Count; r++) {                                                //za svaku reč u pojmu
                            if (page.Contains(pojam[r])) {                                                     //ako stranica sadrži reč
                                int where = page.IndexOf(pojam[r]);                                            //gde reč počinje na stranici
                                while (where != -1 && where < page.Length) {                                   //dokle god ima još takvih reči na stranici
                                    int ima = 1;                                                               //trenutno nađeno reči
                                    List<string> pojamBez = new List<string>(pojam);
                                    pojamBez.RemoveAt(r);                                                      //lista bez nađene reči
                                    if (r < brBezNep && brNep.IndexOf(r) != -1)
                                        pojamBez.RemoveAt(brBezNep + brNep.IndexOf(r) - 1);                    //lista bez nađene reči bez nepostojanog a
                                    else if (r >= brBezNep)
                                        pojamBez.RemoveAt(brNep[r - brBezNep]);                                //lista bez nađene reči sa nepostojanim a

                                    int min = Math.Max(0, where - (int)Math.Round(podpojam.Length * opseg));   //početak opsega je početak reči minus dužina pojma
                                    int max = Math.Min(page.Length - min,
                                                       (int)Math.Round(podpojam.Length * (1.5 + opseg)));      //dužina opsega je tri puta veća od dužine pojma
                                    foreach (string reč in pojamBez) {                                         //za svaku ostalu reč
                                        if (page.Substring(min, max).Contains(reč))                            //da li se druga reč nalazi u opsegu prve reči
                                            ima++;                                                             //nađena druga reč
                                        if (ima >= minIma)
                                            break;                                                             //nađen pojam
                                    }
                                    if (ima >= minIma && !stranice[p].Contains(pageIndex) &&
                                        !ignoreStranice.Contains(pageIndex)) {                                 //ako je pojam nađen i ako već nije nađen na ovoj stranici
                                        stranice[p].Add(pageIndex);                                            //dodaj broj stranice na spisak
                                        break;                                                                 //ne traži više tu reč na stranici
                                    }
                                    int newWhere = page.Substring(where + pojam[r].Length).IndexOf(pojam[r]);
                                    where = newWhere != -1 ? newWhere + where + 1 : -1;                        //traži da li ima još takve reči na stranici
                                }
                            }
                        }
                    }
                }
            }

            return stranice;
        }

        static string RemoveWrap(this string text) {
            int pos = 0;
            while (pos != -1) {
                int start = text.IndexOf("-\n");
                if (start == -1) break;
                pos = text.IndexOf(' ', start);
                if (pos != -1)
                    text = text.Substring(0, pos) + "\n" + text.Substring(pos + 1);
                text = text.ReplaceFirst("-\n", "");
            }
            text = text.Replace("-\n", "");
            for (int i = 0; i < text.Length - 1; i++)
                if (char.IsUpper(text[i]) && (i == 0 || text[i - 1] == '\n'))
                    if (text[i + 1] == '\n')
                        text = text.Remove(i + 1, 1);
                    else if (i + 2 < text.Length && text[i + 1] == ' ' && text[i + 2] == '\n')
                        text = text.Remove(i + 2, 1);
            pos = text.IndexOf("СРПСКИ СЛИКАРИ");
            if (pos != -1) {
                pos = Math.Max(0, text.Substring(0, pos).LastIndexOf('\n'));
                int end = text.Substring(pos).IndexOf('\n');
                if (end != -1)
                    text = text.Remove(pos, end + 1);
                else
                    text = text.Remove(pos);
            }
            return text;
        }

        static string ReplaceFirst(this string text, string search, string replace) {
            int pos = text.IndexOf(search);
            if (pos < 0) return text;
            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }
    }
}
