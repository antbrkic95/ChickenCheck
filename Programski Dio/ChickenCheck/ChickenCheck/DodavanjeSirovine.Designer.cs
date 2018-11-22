namespace ChickenCheck
{
    partial class FormaDodajSirovinu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormaDodajSirovinu));
            this.label1 = new System.Windows.Forms.Label();
            this.inputFormaDodavanjeSirovineNaziv = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.inputFormaDodavanjeSirovineOpis = new System.Windows.Forms.TextBox();
            this.kolicina = new System.Windows.Forms.Label();
            this.inputFormaDodavanjeSirovineKolicina = new System.Windows.Forms.TextBox();
            this.actionFormaDodavanjeSirovineDodajSirovinu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Naziv sirovine: ";
            // 
            // inputFormaDodavanjeSirovineNaziv
            // 
            this.inputFormaDodavanjeSirovineNaziv.Location = new System.Drawing.Point(98, 27);
            this.inputFormaDodavanjeSirovineNaziv.Name = "inputFormaDodavanjeSirovineNaziv";
            this.inputFormaDodavanjeSirovineNaziv.Size = new System.Drawing.Size(128, 20);
            this.inputFormaDodavanjeSirovineNaziv.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Opis sirovine: ";
            // 
            // inputFormaDodavanjeSirovineOpis
            // 
            this.inputFormaDodavanjeSirovineOpis.Location = new System.Drawing.Point(98, 60);
            this.inputFormaDodavanjeSirovineOpis.Multiline = true;
            this.inputFormaDodavanjeSirovineOpis.Name = "inputFormaDodavanjeSirovineOpis";
            this.inputFormaDodavanjeSirovineOpis.Size = new System.Drawing.Size(128, 93);
            this.inputFormaDodavanjeSirovineOpis.TabIndex = 3;
            // 
            // kolicina
            // 
            this.kolicina.AutoSize = true;
            this.kolicina.Location = new System.Drawing.Point(18, 184);
            this.kolicina.Name = "kolicina";
            this.kolicina.Size = new System.Drawing.Size(50, 13);
            this.kolicina.TabIndex = 4;
            this.kolicina.Text = "Količina: ";
            // 
            // inputFormaDodavanjeSirovineKolicina
            // 
            this.inputFormaDodavanjeSirovineKolicina.Location = new System.Drawing.Point(98, 181);
            this.inputFormaDodavanjeSirovineKolicina.Name = "inputFormaDodavanjeSirovineKolicina";
            this.inputFormaDodavanjeSirovineKolicina.Size = new System.Drawing.Size(128, 20);
            this.inputFormaDodavanjeSirovineKolicina.TabIndex = 5;
            // 
            // actionFormaDodavanjeSirovineDodajSirovinu
            // 
            this.actionFormaDodavanjeSirovineDodajSirovinu.Location = new System.Drawing.Point(53, 236);
            this.actionFormaDodavanjeSirovineDodajSirovinu.Name = "actionFormaDodavanjeSirovineDodajSirovinu";
            this.actionFormaDodavanjeSirovineDodajSirovinu.Size = new System.Drawing.Size(132, 40);
            this.actionFormaDodavanjeSirovineDodajSirovinu.TabIndex = 6;
            this.actionFormaDodavanjeSirovineDodajSirovinu.Text = "Unesi sirovinu";
            this.actionFormaDodavanjeSirovineDodajSirovinu.UseVisualStyleBackColor = true;
            this.actionFormaDodavanjeSirovineDodajSirovinu.Click += new System.EventHandler(this.actionFormaDodavanjeSirovineDodajSirovinu_Click);
            // 
            // FormaDodajSirovinu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 300);
            this.Controls.Add(this.actionFormaDodavanjeSirovineDodajSirovinu);
            this.Controls.Add(this.inputFormaDodavanjeSirovineKolicina);
            this.Controls.Add(this.kolicina);
            this.Controls.Add(this.inputFormaDodavanjeSirovineOpis);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.inputFormaDodavanjeSirovineNaziv);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormaDodajSirovinu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DodavanjeSirovine";
            this.Load += new System.EventHandler(this.FormaDodajSirovinu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox inputFormaDodavanjeSirovineNaziv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox inputFormaDodavanjeSirovineOpis;
        private System.Windows.Forms.Label kolicina;
        private System.Windows.Forms.TextBox inputFormaDodavanjeSirovineKolicina;
        private System.Windows.Forms.Button actionFormaDodavanjeSirovineDodajSirovinu;
    }
}