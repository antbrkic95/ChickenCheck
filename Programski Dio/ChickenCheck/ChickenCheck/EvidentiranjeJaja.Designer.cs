namespace ChickenCheck
{
    partial class FormaZaUnosJaja
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormaZaUnosJaja));
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.inputFormaZaUnosJajaKolicinaDodanihJaja = new System.Windows.Forms.TextBox();
            this.inputFormaZaUnosJajaKlasaJaja = new System.Windows.Forms.ComboBox();
            this.outputFormaZaUnosJajaKolicina = new System.Windows.Forms.Label();
            this.outputFormaZaUnosJajaKlasa = new System.Windows.Forms.Label();
            this.actionFormaZaUnosJajaDodajJaja = new System.Windows.Forms.Button();
            this.kokosiTurnusBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kokosiTurnusBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // inputFormaZaUnosJajaKolicinaDodanihJaja
            // 
            this.inputFormaZaUnosJajaKolicinaDodanihJaja.Location = new System.Drawing.Point(153, 12);
            this.inputFormaZaUnosJajaKolicinaDodanihJaja.Name = "inputFormaZaUnosJajaKolicinaDodanihJaja";
            this.inputFormaZaUnosJajaKolicinaDodanihJaja.Size = new System.Drawing.Size(199, 20);
            this.inputFormaZaUnosJajaKolicinaDodanihJaja.TabIndex = 2;
            // 
            // inputFormaZaUnosJajaKlasaJaja
            // 
            this.inputFormaZaUnosJajaKlasaJaja.FormattingEnabled = true;
            this.inputFormaZaUnosJajaKlasaJaja.Location = new System.Drawing.Point(153, 38);
            this.inputFormaZaUnosJajaKlasaJaja.Name = "inputFormaZaUnosJajaKlasaJaja";
            this.inputFormaZaUnosJajaKlasaJaja.Size = new System.Drawing.Size(199, 21);
            this.inputFormaZaUnosJajaKlasaJaja.TabIndex = 3;
            // 
            // outputFormaZaUnosJajaKolicina
            // 
            this.outputFormaZaUnosJajaKolicina.AutoSize = true;
            this.outputFormaZaUnosJajaKolicina.Location = new System.Drawing.Point(12, 19);
            this.outputFormaZaUnosJajaKolicina.Name = "outputFormaZaUnosJajaKolicina";
            this.outputFormaZaUnosJajaKolicina.Size = new System.Drawing.Size(44, 13);
            this.outputFormaZaUnosJajaKolicina.TabIndex = 7;
            this.outputFormaZaUnosJajaKolicina.Text = "Količina";
            // 
            // outputFormaZaUnosJajaKlasa
            // 
            this.outputFormaZaUnosJajaKlasa.AutoSize = true;
            this.outputFormaZaUnosJajaKlasa.Location = new System.Drawing.Point(12, 41);
            this.outputFormaZaUnosJajaKlasa.Name = "outputFormaZaUnosJajaKlasa";
            this.outputFormaZaUnosJajaKlasa.Size = new System.Drawing.Size(33, 13);
            this.outputFormaZaUnosJajaKlasa.TabIndex = 8;
            this.outputFormaZaUnosJajaKlasa.Text = "Klasa";
            // 
            // actionFormaZaUnosJajaDodajJaja
            // 
            this.actionFormaZaUnosJajaDodajJaja.Location = new System.Drawing.Point(70, 89);
            this.actionFormaZaUnosJajaDodajJaja.Name = "actionFormaZaUnosJajaDodajJaja";
            this.actionFormaZaUnosJajaDodajJaja.Size = new System.Drawing.Size(195, 41);
            this.actionFormaZaUnosJajaDodajJaja.TabIndex = 9;
            this.actionFormaZaUnosJajaDodajJaja.Text = "Unesi podatke";
            this.actionFormaZaUnosJajaDodajJaja.UseVisualStyleBackColor = true;
            this.actionFormaZaUnosJajaDodajJaja.Click += new System.EventHandler(this.actionFormaZaUnosJajaDodajJaja_Click);
            // 
            // kokosiTurnusBindingSource
            // 
            this.kokosiTurnusBindingSource.DataSource = typeof(KokosiTurnus);
            // 
            // FormaZaUnosJaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 157);
            this.Controls.Add(this.actionFormaZaUnosJajaDodajJaja);
            this.Controls.Add(this.outputFormaZaUnosJajaKlasa);
            this.Controls.Add(this.outputFormaZaUnosJajaKolicina);
            this.Controls.Add(this.inputFormaZaUnosJajaKlasaJaja);
            this.Controls.Add(this.inputFormaZaUnosJajaKolicinaDodanihJaja);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormaZaUnosJaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Evidentiranje jaja";
            this.Load += new System.EventHandler(this.FormaZaUnosJaja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kokosiTurnusBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Button actionFormaZaUnosJajaDodajJaja;
        private System.Windows.Forms.Label outputFormaZaUnosJajaKlasa;
        private System.Windows.Forms.Label outputFormaZaUnosJajaKolicina;
        private System.Windows.Forms.ComboBox inputFormaZaUnosJajaKlasaJaja;
        private System.Windows.Forms.TextBox inputFormaZaUnosJajaKolicinaDodanihJaja;
        private System.Windows.Forms.BindingSource kokosiTurnusBindingSource;
    }
}