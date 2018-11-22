namespace ChickenCheck
{
    partial class FormaDodavanjeHrane
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormaDodavanjeHrane));
            this.outputFormaDodavanjeHraneListaSastojakaHrane = new System.Windows.Forms.ListBox();
            this.inputFormaDodavanjeHraneNaziv = new System.Windows.Forms.TextBox();
            this.inputFormaDodavanjeHraneOpis = new System.Windows.Forms.TextBox();
            this.inputFormaDodavanjeHraneSirovine = new System.Windows.Forms.ComboBox();
            this.inputFormaDodavanjeHranePostotak = new System.Windows.Forms.TextBox();
            this.actionFormaDodavanjeHraneDodajSastojak = new System.Windows.Forms.Button();
            this.actionFormaDodavanjeHraneDodajHranu = new System.Windows.Forms.Button();
            this.outputFormaDodavanjeHraneNaziv = new System.Windows.Forms.Label();
            this.outputFormaDodavanjeHraneOpis = new System.Windows.Forms.Label();
            this.outputFormaDodavanjeHraneSirovina = new System.Windows.Forms.Label();
            this.outputFormaDodavanjeHranePostotak = new System.Windows.Forms.Label();
            this.outputFormaDodavanjeHraneSastojciHrane = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // outputFormaDodavanjeHraneListaSastojakaHrane
            // 
            this.outputFormaDodavanjeHraneListaSastojakaHrane.FormattingEnabled = true;
            this.outputFormaDodavanjeHraneListaSastojakaHrane.Location = new System.Drawing.Point(418, 38);
            this.outputFormaDodavanjeHraneListaSastojakaHrane.Name = "outputFormaDodavanjeHraneListaSastojakaHrane";
            this.outputFormaDodavanjeHraneListaSastojakaHrane.Size = new System.Drawing.Size(201, 290);
            this.outputFormaDodavanjeHraneListaSastojakaHrane.TabIndex = 0;
            // 
            // inputFormaDodavanjeHraneNaziv
            // 
            this.inputFormaDodavanjeHraneNaziv.Location = new System.Drawing.Point(26, 38);
            this.inputFormaDodavanjeHraneNaziv.Name = "inputFormaDodavanjeHraneNaziv";
            this.inputFormaDodavanjeHraneNaziv.Size = new System.Drawing.Size(371, 20);
            this.inputFormaDodavanjeHraneNaziv.TabIndex = 1;
            // 
            // inputFormaDodavanjeHraneOpis
            // 
            this.inputFormaDodavanjeHraneOpis.Location = new System.Drawing.Point(26, 75);
            this.inputFormaDodavanjeHraneOpis.Multiline = true;
            this.inputFormaDodavanjeHraneOpis.Name = "inputFormaDodavanjeHraneOpis";
            this.inputFormaDodavanjeHraneOpis.Size = new System.Drawing.Size(371, 120);
            this.inputFormaDodavanjeHraneOpis.TabIndex = 2;
            // 
            // inputFormaDodavanjeHraneSirovine
            // 
            this.inputFormaDodavanjeHraneSirovine.DisplayMember = "idSirovine";
            this.inputFormaDodavanjeHraneSirovine.FormattingEnabled = true;
            this.inputFormaDodavanjeHraneSirovine.Location = new System.Drawing.Point(26, 234);
            this.inputFormaDodavanjeHraneSirovine.Name = "inputFormaDodavanjeHraneSirovine";
            this.inputFormaDodavanjeHraneSirovine.Size = new System.Drawing.Size(169, 21);
            this.inputFormaDodavanjeHraneSirovine.TabIndex = 3;
            this.inputFormaDodavanjeHraneSirovine.ValueMember = "idSirovine";
            // 
            // inputFormaDodavanjeHranePostotak
            // 
            this.inputFormaDodavanjeHranePostotak.Location = new System.Drawing.Point(201, 234);
            this.inputFormaDodavanjeHranePostotak.Name = "inputFormaDodavanjeHranePostotak";
            this.inputFormaDodavanjeHranePostotak.Size = new System.Drawing.Size(25, 20);
            this.inputFormaDodavanjeHranePostotak.TabIndex = 4;
            // 
            // actionFormaDodavanjeHraneDodajSastojak
            // 
            this.actionFormaDodavanjeHraneDodajSastojak.Location = new System.Drawing.Point(257, 225);
            this.actionFormaDodavanjeHraneDodajSastojak.Name = "actionFormaDodavanjeHraneDodajSastojak";
            this.actionFormaDodavanjeHraneDodajSastojak.Size = new System.Drawing.Size(140, 36);
            this.actionFormaDodavanjeHraneDodajSastojak.TabIndex = 5;
            this.actionFormaDodavanjeHraneDodajSastojak.Text = "Dodaj sastojak u hranu";
            this.actionFormaDodavanjeHraneDodajSastojak.UseVisualStyleBackColor = true;
            this.actionFormaDodavanjeHraneDodajSastojak.Click += new System.EventHandler(this.actionFormaDodavanjeHraneDodajSastojak_Click);
            // 
            // actionFormaDodavanjeHraneDodajHranu
            // 
            this.actionFormaDodavanjeHraneDodajHranu.Location = new System.Drawing.Point(26, 294);
            this.actionFormaDodavanjeHraneDodajHranu.Name = "actionFormaDodavanjeHraneDodajHranu";
            this.actionFormaDodavanjeHraneDodajHranu.Size = new System.Drawing.Size(371, 34);
            this.actionFormaDodavanjeHraneDodajHranu.TabIndex = 6;
            this.actionFormaDodavanjeHraneDodajHranu.Text = "Dodaj hranu";
            this.actionFormaDodavanjeHraneDodajHranu.UseVisualStyleBackColor = true;
            this.actionFormaDodavanjeHraneDodajHranu.Click += new System.EventHandler(this.actionFormaDodavanjeHraneDodajHranu_Click);
            // 
            // outputFormaDodavanjeHraneNaziv
            // 
            this.outputFormaDodavanjeHraneNaziv.AutoSize = true;
            this.outputFormaDodavanjeHraneNaziv.Location = new System.Drawing.Point(23, 22);
            this.outputFormaDodavanjeHraneNaziv.Name = "outputFormaDodavanjeHraneNaziv";
            this.outputFormaDodavanjeHraneNaziv.Size = new System.Drawing.Size(67, 13);
            this.outputFormaDodavanjeHraneNaziv.TabIndex = 7;
            this.outputFormaDodavanjeHraneNaziv.Text = "Naziv hrane:";
            // 
            // outputFormaDodavanjeHraneOpis
            // 
            this.outputFormaDodavanjeHraneOpis.AutoSize = true;
            this.outputFormaDodavanjeHraneOpis.Location = new System.Drawing.Point(23, 59);
            this.outputFormaDodavanjeHraneOpis.Name = "outputFormaDodavanjeHraneOpis";
            this.outputFormaDodavanjeHraneOpis.Size = new System.Drawing.Size(61, 13);
            this.outputFormaDodavanjeHraneOpis.TabIndex = 8;
            this.outputFormaDodavanjeHraneOpis.Text = "Opis hrane:";
            // 
            // outputFormaDodavanjeHraneSirovina
            // 
            this.outputFormaDodavanjeHraneSirovina.AutoSize = true;
            this.outputFormaDodavanjeHraneSirovina.Location = new System.Drawing.Point(23, 218);
            this.outputFormaDodavanjeHraneSirovina.Name = "outputFormaDodavanjeHraneSirovina";
            this.outputFormaDodavanjeHraneSirovina.Size = new System.Drawing.Size(48, 13);
            this.outputFormaDodavanjeHraneSirovina.TabIndex = 9;
            this.outputFormaDodavanjeHraneSirovina.Text = "Sirovina:";
            // 
            // outputFormaDodavanjeHranePostotak
            // 
            this.outputFormaDodavanjeHranePostotak.AutoSize = true;
            this.outputFormaDodavanjeHranePostotak.Location = new System.Drawing.Point(232, 237);
            this.outputFormaDodavanjeHranePostotak.Name = "outputFormaDodavanjeHranePostotak";
            this.outputFormaDodavanjeHranePostotak.Size = new System.Drawing.Size(19, 13);
            this.outputFormaDodavanjeHranePostotak.TabIndex = 10;
            this.outputFormaDodavanjeHranePostotak.Text = "kg";
            // 
            // outputFormaDodavanjeHraneSastojciHrane
            // 
            this.outputFormaDodavanjeHraneSastojciHrane.AutoSize = true;
            this.outputFormaDodavanjeHraneSastojciHrane.Location = new System.Drawing.Point(415, 22);
            this.outputFormaDodavanjeHraneSastojciHrane.Name = "outputFormaDodavanjeHraneSastojciHrane";
            this.outputFormaDodavanjeHraneSastojciHrane.Size = new System.Drawing.Size(77, 13);
            this.outputFormaDodavanjeHraneSastojciHrane.TabIndex = 11;
            this.outputFormaDodavanjeHraneSastojciHrane.Text = "Sastojci hrane:";
            // 
            // FormaDodavanjeHrane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 356);
            this.Controls.Add(this.outputFormaDodavanjeHraneSastojciHrane);
            this.Controls.Add(this.outputFormaDodavanjeHranePostotak);
            this.Controls.Add(this.outputFormaDodavanjeHraneSirovina);
            this.Controls.Add(this.outputFormaDodavanjeHraneOpis);
            this.Controls.Add(this.outputFormaDodavanjeHraneNaziv);
            this.Controls.Add(this.actionFormaDodavanjeHraneDodajHranu);
            this.Controls.Add(this.actionFormaDodavanjeHraneDodajSastojak);
            this.Controls.Add(this.inputFormaDodavanjeHranePostotak);
            this.Controls.Add(this.inputFormaDodavanjeHraneSirovine);
            this.Controls.Add(this.inputFormaDodavanjeHraneOpis);
            this.Controls.Add(this.inputFormaDodavanjeHraneNaziv);
            this.Controls.Add(this.outputFormaDodavanjeHraneListaSastojakaHrane);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormaDodavanjeHrane";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dodavanje nove hrane";
            this.Load += new System.EventHandler(this.FormaDodavanjeHrane_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox outputFormaDodavanjeHraneListaSastojakaHrane;
        private System.Windows.Forms.TextBox inputFormaDodavanjeHraneNaziv;
        private System.Windows.Forms.TextBox inputFormaDodavanjeHraneOpis;
        private System.Windows.Forms.ComboBox inputFormaDodavanjeHraneSirovine;
        private System.Windows.Forms.TextBox inputFormaDodavanjeHranePostotak;
        private System.Windows.Forms.Button actionFormaDodavanjeHraneDodajSastojak;
        private System.Windows.Forms.Button actionFormaDodavanjeHraneDodajHranu;
        private System.Windows.Forms.Label outputFormaDodavanjeHraneNaziv;
        private System.Windows.Forms.Label outputFormaDodavanjeHraneOpis;
        private System.Windows.Forms.Label outputFormaDodavanjeHraneSirovina;
        private System.Windows.Forms.Label outputFormaDodavanjeHranePostotak;
        private System.Windows.Forms.Label outputFormaDodavanjeHraneSastojciHrane;
    }
}