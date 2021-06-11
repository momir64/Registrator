using static Registrator.RegistratorFactory;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Forms;
using iText.Kernel.Pdf;
using Xceed.Words.NET;
using System.Drawing;
using ScintillaNET;
using System.Linq;
using System.IO;
using System;

namespace Registrator {
    public partial class Registrator : Form {
        List<int> ignoreStranice;
        string formatRegistra;
        List<int>[] stranice;
        string[] pojmovi;
        string fileName;
        string registar;
        float procenat;
        float opseg;

        public Registrator() {
            InitializeComponent();
            SetupBox(pojmoviText);
            SetupBox(registarText);
        }

        private void OpenBtn_Click(object sender, EventArgs e) {
            openFileDialog.FileName = "";
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                openText.Text = openFileDialog.FileName;
                openText.SelectionStart = openText.Text.Length;
                openText.SelectionLength = 0;
            }
        }

        private async void SaveBtn_Click(object sender, EventArgs e) {
            try {
                await CreateRegistarAsync();
                saveFileDialog.FileName = "registar";
                if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                    if (Path.GetExtension(saveFileDialog.FileName).ToLower() == ".docx") {
                        DocX doc = DocX.Create(saveFileDialog.FileName);
                        doc.InsertParagraph(registar);
                        doc.Save();
                    }
                    else
                        File.WriteAllText(saveFileDialog.FileName, registar);
                    gotovoBar.Visible = false;
                }
            }
            catch (Exception ex) when (ex.Message == "Empty file name") {
                MessageBox.Show("Otvori knjigu u kojoj se traže pojmovi!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) when (ex.Message.Contains("not found as file or resource.")) {
                MessageBox.Show("Izabrana knjiga više ne postoji!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) when (ex.Message == "Empty format") {
                MessageBox.Show("Polje format registra ne može biti prazno!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) when (ex.Message == "Empty pojmovi") {
                MessageBox.Show("Potrebno je uneti pojmove koji se traže!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) when (ex.Message == "Stranice format error") {
                MessageBox.Show("Stranice koje se preskaču su unete u lošem formatu!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) when (ex.Message == "Registar format error") {
                MessageBox.Show("Format registra je neispravan!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void MakeBtn_Click(object sender, EventArgs e) {
            try {
                await CreateRegistarAsync();
                registarText.ReadOnly = false;
                registarText.Text = registar;
                registarText.ReadOnly = true;
                tabControl.SelectedTab = tabControl.TabPages["tabRegistar"];
                gotovoBar.Visible = false;
            }
            catch (Exception ex) when (ex.Message == "Empty file name") {
                MessageBox.Show("Otvori knjigu u kojoj se traže pojmovi!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) when (ex.Message.Contains("not found as file or resource.")) {
                MessageBox.Show("Izabrana knjiga više ne postoji!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) when (ex.Message == "Empty format") {
                MessageBox.Show("Polje format registra ne može biti prazno!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) when (ex.Message == "Empty pojmovi") {
                MessageBox.Show("Potrebno je uneti pojmove koji se traže!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) when (ex.Message == "Stranice format error") {
                MessageBox.Show("Stranice koje se preskaču su unete u lošem formatu!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) when (ex.Message == "Registar format error") {
                MessageBox.Show("Format registra je neispravan!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CreateRegistarAsync() {
            if (formatText.Text.Trim() == "")
                throw new Exception("Empty format");
            if (pojmoviText.Text.Trim() == "")
                throw new Exception("Empty pojmovi");
            string formatStart, delimeter, end;
            List<int> razmaci = new List<int>();
            try {
                formatRegistra = specijalniBox.Checked ? Regex.Unescape(formatText.Text) : formatText.Text;
                formatRegistra = Regex.Replace(formatRegistra, "\r\n|\n|\r", "\r\n");
                if (specijalniBox.Checked)
                    foreach (Match match in Regex.Matches(formatRegistra, @"(?<=%)(\d+)"))
                        razmaci.Add(int.Parse(match.Value));
                formatRegistra = Regex.Replace(formatRegistra, "[0-9]{1,}", "0");
                int pojamIndex = formatRegistra.IndexOf("pojam");
                end = formatRegistra.Substring(pojamIndex);
                int granica = (specijalniBox.Checked ? Regex.Match(end, "(?<!%)0").Index : end.IndexOf('0')) + pojamIndex;
                formatStart = formatRegistra.Substring(0, granica);
                end = formatRegistra.Substring(granica + 1);
                delimeter = end.Substring(0, end.IndexOf('0'));
                end = formatRegistra.Substring(formatRegistra.LastIndexOf('0') + 1);
            }
            catch (Exception) {
                throw new Exception("Registar format error");
            }
            var progress = new Progress<int>(v => { gotovoBar.Value = v; });
            if (DifferentInput()) {
                SetInput();
                gotovoBar.Value = 0;
                gotovoBar.Visible = true;
                await Task.Run(() => stranice = MakeRegistar(fileName, (string[])pojmovi.Clone(), procenat, opseg, ignoreStranice, progress));
            }
            registar = "";
            for (int i = 0; i < pojmovi.Length; i++) {
                string line = formatStart.Replace("pojam", pojmovi[i].Trim());
                if (specijalniBox.Checked) {
                    line = Regex.Replace(line, "(?<!%)0", (i + 1).ToString());
                    foreach (int razmak in razmaci) {
                        int ima = line.IndexOf("%0");
                        line = new Regex("%0").Replace(line, new string(' ', Math.Max(0, razmak - ima)), 1);
                    }
                }
                else
                    line = line.Replace("0", (i + 1).ToString());
                foreach (int stranica in stranice[i])
                    line += stranica + (stranica != stranice[i].Last() ? delimeter : end);
                registar += line + (i != pojmovi.Length - 1 ? "\r\n" : "");
            }
        }

        private void SetInput() {
            fileName = openText.Text;
            if (fileName.Trim() == "") {
                passInput = true;
                throw new Exception("Empty file name");
            }
            ignoreStranice = StraniceArray(straniceText.Text, fileName);
            pojmovi = pojmoviText.Lines.Select(line => line.Text).ToArray();
            procenat = procenatBar.Value / 100f;
            opseg = opsegBar.Value / 10f;
        }

        bool passInput = true;
        private bool DifferentInput() {
            if (passInput) {
                passInput = false;
                return true;
            }
            return fileName != openText.Text ||
                   !StraniceArray(straniceText.Text, fileName).All(ignoreStranice.Contains) ||
                   string.Join("", pojmovi) != pojmoviText.Text ||
                   Math.Abs(procenatBar.Value / 100f - procenat) >= 0.01f ||
                   Math.Abs(opsegBar.Value / 10f - opseg) >= 0.1f;
        }

        int Min(string br) => br.Trim() == "" ? 1 : int.Parse(br);
        int Max(string br, int max) => br.Trim() == "" ? max : int.Parse(br);
        private List<int> StraniceArray(string stranice, string pdfPath) {
            List<int> lista = new List<int>();
            string[] segmenti = stranice.Split(',');
            int pages = new PdfDocument(new PdfReader(pdfPath)).GetNumberOfPages();
            foreach (string segment in segmenti)
                try {
                    if (segment.Contains('-'))
                        lista.AddRange(Enumerable.Range(Min(segment.Split('-')[0]), Max(segment.Split('-')[1], pages) - Min(segment.Split('-')[0]) + 1));
                    else if (segment.Trim() != "")
                        lista.Add(int.Parse(segment));
                }
                catch (Exception) {
                    throw new Exception("Stranice format error");
                }
            return lista;
        }

        private void ClearBtn_Click(object sender, EventArgs e) {
            openText.Text = "";
            procenatBar.Value = 58;
            procenatText.Text = "58%";
            opsegBar.Value = 15;
            opsegText.Text = "1.5";
            pojmoviText.Text = "";
            registarText.ReadOnly = false;
            registarText.Text = "";
            registarText.ReadOnly = true;
            straniceText.Text = "";
            specijalniBox.Checked = false;
            formatText.Text = "pojam 1, 2, 3";
            tabControl.SelectedTab = tabControl.TabPages["tabPojmovi"];
            openBox.Focus();
        }

        private void SetupBox(Scintilla scintellaBox) {
            scintellaBox.StyleResetDefault();
            scintellaBox.Styles[Style.Default].Font = "Consolas";
            scintellaBox.Styles[Style.Default].Size = 11;
            scintellaBox.Styles[Style.Default].BackColor = Color.White;
            scintellaBox.Styles[Style.Default].ForeColor = Color.Black;
            scintellaBox.StyleClearAll();
            scintellaBox.Styles[Style.LineNumber].ForeColor = Color.FromArgb(120, 120, 120);
            scintellaBox.Styles[Style.LineNumber].BackColor = Color.FromArgb(230, 230, 230);
            scintellaBox.Styles[Style.LineNumber].Size = 10;
            scintellaBox.Margins[1].Type = MarginType.Number;
            scintellaBox.Margins[1].Width = 50;
        }

        private void OpsegBar_Scroll(object sender, EventArgs e) =>
            opsegText.Text = (opsegBar.Value / 10.0).ToString(CultureInfo.InvariantCulture);

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e) =>
            tabControl.SelectedTab?.Controls.OfType<Scintilla>().First().Focus();

        private void ProcenatBar_Scroll(object sender, EventArgs e) =>
            procenatText.Text = procenatBar.Value + "%";

        private void OpenText_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == '') {
                openText.Text = "";
                e.Handled = true;
            }
        }

        private void Registrator_Load(object sender, EventArgs e) {
            if (!Properties.Settings.Default.firstStart) {
                Location = Properties.Settings.Default.Location;
                Size = Properties.Settings.Default.Size;
                WindowState = Properties.Settings.Default.State == FormWindowState.Minimized ?
                    FormWindowState.Normal : Properties.Settings.Default.State;
            }
        }

        private void Registrator_FormClosing(object sender, FormClosingEventArgs e) {
            Properties.Settings.Default.State = WindowState;
            if (WindowState == FormWindowState.Normal) {
                Properties.Settings.Default.Location = Location;
                Properties.Settings.Default.Size = Size;
            }
            else {
                Properties.Settings.Default.Location = RestoreBounds.Location;
                Properties.Settings.Default.Size = RestoreBounds.Size;
            }
            Properties.Settings.Default.firstStart = false;
            Properties.Settings.Default.Save();
        }
    }
}
