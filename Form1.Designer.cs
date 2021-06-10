
namespace Registrator {
    partial class Registrator {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Registrator));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.gotovoBar = new System.Windows.Forms.ProgressBar();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPojmovi = new System.Windows.Forms.TabPage();
            this.pojmoviText = new ScintillaNET.Scintilla();
            this.tabRegistar = new System.Windows.Forms.TabPage();
            this.registarText = new ScintillaNET.Scintilla();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.straniceBox = new System.Windows.Forms.GroupBox();
            this.straniceText = new System.Windows.Forms.TextBox();
            this.clearBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.makeBtn = new System.Windows.Forms.Button();
            this.formatBox = new System.Windows.Forms.GroupBox();
            this.formatText = new System.Windows.Forms.ComboBox();
            this.openBox = new System.Windows.Forms.GroupBox();
            this.openText = new System.Windows.Forms.TextBox();
            this.openBtn = new System.Windows.Forms.Button();
            this.opsegBox = new System.Windows.Forms.GroupBox();
            this.opsegBar = new System.Windows.Forms.TrackBar();
            this.opsegText = new System.Windows.Forms.Label();
            this.procenatBox = new System.Windows.Forms.GroupBox();
            this.procenatBar = new System.Windows.Forms.TrackBar();
            this.procenatText = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.tableLayoutPanel.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPojmovi.SuspendLayout();
            this.tabRegistar.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.straniceBox.SuspendLayout();
            this.formatBox.SuspendLayout();
            this.openBox.SuspendLayout();
            this.opsegBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opsegBar)).BeginInit();
            this.procenatBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.procenatBar)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.AutoSize = true;
            this.tableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 600F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.Controls.Add(this.panelRight, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.panelLeft, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.Padding = new System.Windows.Forms.Padding(0, 0, 5, 5);
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(1478, 794);
            this.tableLayoutPanel.TabIndex = 9999;
            // 
            // panelRight
            // 
            this.panelRight.AutoSize = true;
            this.panelRight.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelRight.Controls.Add(this.gotovoBar);
            this.panelRight.Controls.Add(this.tabControl);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(603, 4);
            this.panelRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(972, 781);
            this.panelRight.TabIndex = 1;
            // 
            // gotovoBar
            // 
            this.gotovoBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gotovoBar.Location = new System.Drawing.Point(670, 4);
            this.gotovoBar.Margin = new System.Windows.Forms.Padding(0);
            this.gotovoBar.Name = "gotovoBar";
            this.gotovoBar.Size = new System.Drawing.Size(200, 30);
            this.gotovoBar.Step = 1;
            this.gotovoBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.gotovoBar.TabIndex = 99999;
            this.gotovoBar.Visible = false;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPojmovi);
            this.tabControl.Controls.Add(this.tabRegistar);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl.Name = "tabControl";
            this.tabControl.Padding = new System.Drawing.Point(30, 6);
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(972, 781);
            this.tabControl.TabIndex = 99999;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.TabControl_SelectedIndexChanged);
            // 
            // tabPojmovi
            // 
            this.tabPojmovi.Controls.Add(this.pojmoviText);
            this.tabPojmovi.Location = new System.Drawing.Point(4, 40);
            this.tabPojmovi.Name = "tabPojmovi";
            this.tabPojmovi.Size = new System.Drawing.Size(964, 737);
            this.tabPojmovi.TabIndex = 0;
            this.tabPojmovi.Text = "Pojmovi";
            this.tabPojmovi.UseVisualStyleBackColor = true;
            // 
            // pojmoviText
            // 
            this.pojmoviText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pojmoviText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pojmoviText.HScrollBar = false;
            this.pojmoviText.Location = new System.Drawing.Point(0, 0);
            this.pojmoviText.Name = "pojmoviText";
            this.pojmoviText.ScrollWidth = 74;
            this.pojmoviText.ScrollWidthTracking = false;
            this.pojmoviText.Size = new System.Drawing.Size(964, 737);
            this.pojmoviText.TabIndex = 7;
            this.pojmoviText.WrapMode = ScintillaNET.WrapMode.Word;
            // 
            // tabRegistar
            // 
            this.tabRegistar.Controls.Add(this.registarText);
            this.tabRegistar.Location = new System.Drawing.Point(4, 40);
            this.tabRegistar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabRegistar.Name = "tabRegistar";
            this.tabRegistar.Size = new System.Drawing.Size(964, 737);
            this.tabRegistar.TabIndex = 1;
            this.tabRegistar.Text = "Registar";
            this.tabRegistar.UseVisualStyleBackColor = true;
            // 
            // registarText
            // 
            this.registarText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.registarText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.registarText.HScrollBar = false;
            this.registarText.Location = new System.Drawing.Point(0, 0);
            this.registarText.Name = "registarText";
            this.registarText.ScrollWidth = 74;
            this.registarText.ScrollWidthTracking = false;
            this.registarText.Size = new System.Drawing.Size(964, 737);
            this.registarText.TabIndex = 8;
            this.registarText.WrapMode = ScintillaNET.WrapMode.Word;
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.straniceBox);
            this.panelLeft.Controls.Add(this.clearBtn);
            this.panelLeft.Controls.Add(this.saveBtn);
            this.panelLeft.Controls.Add(this.makeBtn);
            this.panelLeft.Controls.Add(this.formatBox);
            this.panelLeft.Controls.Add(this.openBox);
            this.panelLeft.Controls.Add(this.opsegBox);
            this.panelLeft.Controls.Add(this.procenatBox);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLeft.Location = new System.Drawing.Point(3, 3);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(594, 783);
            this.panelLeft.TabIndex = 2;
            // 
            // straniceBox
            // 
            this.straniceBox.Controls.Add(this.straniceText);
            this.straniceBox.Location = new System.Drawing.Point(14, 402);
            this.straniceBox.Margin = new System.Windows.Forms.Padding(5);
            this.straniceBox.Name = "straniceBox";
            this.straniceBox.Size = new System.Drawing.Size(564, 101);
            this.straniceBox.TabIndex = 3;
            this.straniceBox.TabStop = false;
            this.straniceBox.Text = "Stranice koje se preskaču";
            // 
            // straniceText
            // 
            this.straniceText.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.straniceText.Location = new System.Drawing.Point(15, 42);
            this.straniceText.Name = "straniceText";
            this.straniceText.Size = new System.Drawing.Size(535, 31);
            this.straniceText.TabIndex = 3;
            // 
            // clearBtn
            // 
            this.clearBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.clearBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.clearBtn.Location = new System.Drawing.Point(398, 703);
            this.clearBtn.Margin = new System.Windows.Forms.Padding(6);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(180, 60);
            this.clearBtn.TabIndex = 7;
            this.clearBtn.Text = "Očisti sva polja";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.saveBtn.Location = new System.Drawing.Point(206, 703);
            this.saveBtn.Margin = new System.Windows.Forms.Padding(6);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(180, 60);
            this.saveBtn.TabIndex = 6;
            this.saveBtn.Text = "Sačuvaj";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // makeBtn
            // 
            this.makeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.makeBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.makeBtn.Location = new System.Drawing.Point(14, 703);
            this.makeBtn.Margin = new System.Windows.Forms.Padding(6);
            this.makeBtn.Name = "makeBtn";
            this.makeBtn.Size = new System.Drawing.Size(180, 60);
            this.makeBtn.TabIndex = 5;
            this.makeBtn.Text = "Napravi registar";
            this.makeBtn.UseVisualStyleBackColor = true;
            this.makeBtn.Click += new System.EventHandler(this.MakeBtn_Click);
            // 
            // formatBox
            // 
            this.formatBox.Controls.Add(this.formatText);
            this.formatBox.Location = new System.Drawing.Point(14, 513);
            this.formatBox.Margin = new System.Windows.Forms.Padding(5);
            this.formatBox.Name = "formatBox";
            this.formatBox.Size = new System.Drawing.Size(564, 101);
            this.formatBox.TabIndex = 4;
            this.formatBox.TabStop = false;
            this.formatBox.Text = "Format registra";
            // 
            // formatText
            // 
            this.formatText.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.formatText.FormattingEnabled = true;
            this.formatText.Items.AddRange(new object[] {
            "1. pojam 1, 2, 3",
            "1. pojam: 1 2 3",
            "pojam: 1, 2, 3.",
            "pojam 1, 2, 3",
            "pojam 1 2 3"});
            this.formatText.Location = new System.Drawing.Point(15, 40);
            this.formatText.Name = "formatText";
            this.formatText.Size = new System.Drawing.Size(535, 33);
            this.formatText.TabIndex = 4;
            this.formatText.Text = "pojam 1, 2, 3";
            // 
            // openBox
            // 
            this.openBox.Controls.Add(this.openText);
            this.openBox.Controls.Add(this.openBtn);
            this.openBox.Location = new System.Drawing.Point(14, 11);
            this.openBox.Margin = new System.Windows.Forms.Padding(5);
            this.openBox.Name = "openBox";
            this.openBox.Size = new System.Drawing.Size(564, 115);
            this.openBox.TabIndex = 0;
            this.openBox.TabStop = false;
            this.openBox.Text = "Otvori knjigu";
            // 
            // openText
            // 
            this.openText.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.openText.Location = new System.Drawing.Point(15, 46);
            this.openText.Name = "openText";
            this.openText.Size = new System.Drawing.Size(413, 31);
            this.openText.TabIndex = 0;
            this.openText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OpenText_KeyPress);
            // 
            // openBtn
            // 
            this.openBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.openBtn.Location = new System.Drawing.Point(434, 42);
            this.openBtn.Name = "openBtn";
            this.openBtn.Size = new System.Drawing.Size(116, 38);
            this.openBtn.TabIndex = 0;
            this.openBtn.Text = "Otvori";
            this.openBtn.UseVisualStyleBackColor = true;
            this.openBtn.Click += new System.EventHandler(this.OpenBtn_Click);
            // 
            // opsegBox
            // 
            this.opsegBox.Controls.Add(this.opsegBar);
            this.opsegBox.Controls.Add(this.opsegText);
            this.opsegBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.opsegBox.Location = new System.Drawing.Point(14, 269);
            this.opsegBox.Margin = new System.Windows.Forms.Padding(5);
            this.opsegBox.Name = "opsegBox";
            this.opsegBox.Size = new System.Drawing.Size(564, 123);
            this.opsegBox.TabIndex = 2;
            this.opsegBox.TabStop = false;
            this.opsegBox.Text = "Opseg reči oko pronađenog pojma";
            // 
            // opsegBar
            // 
            this.opsegBar.AutoSize = false;
            this.opsegBar.Location = new System.Drawing.Point(6, 45);
            this.opsegBar.Maximum = 30;
            this.opsegBar.Name = "opsegBar";
            this.opsegBar.Size = new System.Drawing.Size(495, 54);
            this.opsegBar.TabIndex = 2;
            this.opsegBar.Value = 15;
            this.opsegBar.Scroll += new System.EventHandler(this.OpsegBar_Scroll);
            // 
            // opsegText
            // 
            this.opsegText.Location = new System.Drawing.Point(497, 43);
            this.opsegText.Name = "opsegText";
            this.opsegText.Size = new System.Drawing.Size(60, 40);
            this.opsegText.TabIndex = 2;
            this.opsegText.Text = "1.5";
            this.opsegText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // procenatBox
            // 
            this.procenatBox.Controls.Add(this.procenatBar);
            this.procenatBox.Controls.Add(this.procenatText);
            this.procenatBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.procenatBox.Location = new System.Drawing.Point(14, 136);
            this.procenatBox.Margin = new System.Windows.Forms.Padding(5);
            this.procenatBox.Name = "procenatBox";
            this.procenatBox.Size = new System.Drawing.Size(564, 123);
            this.procenatBox.TabIndex = 1;
            this.procenatBox.TabStop = false;
            this.procenatBox.Text = "Procenat reči koji je potrebno naći";
            // 
            // procenatBar
            // 
            this.procenatBar.AutoSize = false;
            this.procenatBar.LargeChange = 10;
            this.procenatBar.Location = new System.Drawing.Point(6, 45);
            this.procenatBar.Maximum = 100;
            this.procenatBar.Name = "procenatBar";
            this.procenatBar.Size = new System.Drawing.Size(495, 54);
            this.procenatBar.TabIndex = 1;
            this.procenatBar.TickFrequency = 5;
            this.procenatBar.Value = 58;
            this.procenatBar.Scroll += new System.EventHandler(this.ProcenatBar_Scroll);
            // 
            // procenatText
            // 
            this.procenatText.Location = new System.Drawing.Point(497, 43);
            this.procenatText.Name = "procenatText";
            this.procenatText.Size = new System.Drawing.Size(60, 40);
            this.procenatText.TabIndex = 1;
            this.procenatText.Text = "58%";
            this.procenatText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "PDF (*.pdf)|*.pdf";
            this.openFileDialog.RestoreDirectory = true;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Word dokument (*.docx)|*.docx|Word 97-2003 dokument (*.doc)|*.doc|Čisti tekst (*." +
    "txt)|*.txt";
            this.saveFileDialog.RestoreDirectory = true;
            // 
            // Registrator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1478, 794);
            this.Controls.Add(this.tableLayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(1350, 850);
            this.Name = "Registrator";
            this.Text = "Registrator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Registrator_FormClosing);
            this.Load += new System.EventHandler(this.Registrator_Load);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.panelRight.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPojmovi.ResumeLayout(false);
            this.tabRegistar.ResumeLayout(false);
            this.panelLeft.ResumeLayout(false);
            this.straniceBox.ResumeLayout(false);
            this.straniceBox.PerformLayout();
            this.formatBox.ResumeLayout(false);
            this.openBox.ResumeLayout(false);
            this.openBox.PerformLayout();
            this.opsegBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.opsegBar)).EndInit();
            this.procenatBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.procenatBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPojmovi;
        private System.Windows.Forms.TabPage tabRegistar;
        private System.Windows.Forms.Panel panelRight;
        private ScintillaNET.Scintilla pojmoviText;
        private ScintillaNET.Scintilla registarText;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Button openBtn;
        private System.Windows.Forms.TextBox openText;
        private System.Windows.Forms.TrackBar procenatBar;
        private System.Windows.Forms.Label procenatText;
        private System.Windows.Forms.GroupBox procenatBox;
        private System.Windows.Forms.GroupBox opsegBox;
        private System.Windows.Forms.TrackBar opsegBar;
        private System.Windows.Forms.Label opsegText;
        private System.Windows.Forms.ComboBox formatText;
        private System.Windows.Forms.GroupBox openBox;
        private System.Windows.Forms.GroupBox formatBox;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button makeBtn;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ProgressBar gotovoBar;
        private System.Windows.Forms.GroupBox straniceBox;
        private System.Windows.Forms.TextBox straniceText;
    }
}

