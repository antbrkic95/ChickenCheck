using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChickenCheck
{
    public partial class FormaZaUnosNovogKupca : Form
    {
        private TextBox inputImeKupca;
        private TextBox inputMailKupca;
        private TextBox inputOpisKupca;
        private Button actionDodajNovogKupca;
        private Label lblImeKupca;
        private Label lblOpisKupca;
        private Button actionOdustani;
        private Label lblMailKupca;

        private Kupac odabraniKupac;
        public FormaZaUnosNovogKupca(Kupac noviKupac)
        {
            InitializeComponent();
            odabraniKupac = noviKupac;
        }
        public FormaZaUnosNovogKupca()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.inputImeKupca = new System.Windows.Forms.TextBox();
            this.inputMailKupca = new System.Windows.Forms.TextBox();
            this.inputOpisKupca = new System.Windows.Forms.TextBox();
            this.actionDodajNovogKupca = new System.Windows.Forms.Button();
            this.lblImeKupca = new System.Windows.Forms.Label();
            this.lblOpisKupca = new System.Windows.Forms.Label();
            this.lblMailKupca = new System.Windows.Forms.Label();
            this.actionOdustani = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // inputImeKupca
            // 
            this.inputImeKupca.Location = new System.Drawing.Point(80, 36);
            this.inputImeKupca.Name = "inputImeKupca";
            this.inputImeKupca.Size = new System.Drawing.Size(184, 20);
            this.inputImeKupca.TabIndex = 0;
            // 
            // inputMailKupca
            // 
            this.inputMailKupca.Location = new System.Drawing.Point(80, 146);
            this.inputMailKupca.Name = "inputMailKupca";
            this.inputMailKupca.Size = new System.Drawing.Size(184, 20);
            this.inputMailKupca.TabIndex = 1;
            // 
            // inputOpisKupca
            // 
            this.inputOpisKupca.Location = new System.Drawing.Point(80, 77);
            this.inputOpisKupca.Multiline = true;
            this.inputOpisKupca.Name = "inputOpisKupca";
            this.inputOpisKupca.Size = new System.Drawing.Size(184, 53);
            this.inputOpisKupca.TabIndex = 2;
            // 
            // actionDodajNovogKupca
            // 
            this.actionDodajNovogKupca.Location = new System.Drawing.Point(80, 200);
            this.actionDodajNovogKupca.Name = "actionDodajNovogKupca";
            this.actionDodajNovogKupca.Size = new System.Drawing.Size(75, 23);
            this.actionDodajNovogKupca.TabIndex = 4;
            this.actionDodajNovogKupca.Text = "Spremi";
            this.actionDodajNovogKupca.UseVisualStyleBackColor = true;
            this.actionDodajNovogKupca.Click += new System.EventHandler(this.actionDodajNovogKupca_Click);
            // 
            // lblImeKupca
            // 
            this.lblImeKupca.AutoSize = true;
            this.lblImeKupca.Location = new System.Drawing.Point(13, 36);
            this.lblImeKupca.Name = "lblImeKupca";
            this.lblImeKupca.Size = new System.Drawing.Size(60, 13);
            this.lblImeKupca.TabIndex = 5;
            this.lblImeKupca.Text = "Ime kupca:";
            // 
            // lblOpisKupca
            // 
            this.lblOpisKupca.AutoSize = true;
            this.lblOpisKupca.Location = new System.Drawing.Point(12, 90);
            this.lblOpisKupca.Name = "lblOpisKupca";
            this.lblOpisKupca.Size = new System.Drawing.Size(31, 13);
            this.lblOpisKupca.TabIndex = 6;
            this.lblOpisKupca.Text = "Opis:";
            // 
            // lblMailKupca
            // 
            this.lblMailKupca.AutoSize = true;
            this.lblMailKupca.Location = new System.Drawing.Point(12, 149);
            this.lblMailKupca.Name = "lblMailKupca";
            this.lblMailKupca.Size = new System.Drawing.Size(38, 13);
            this.lblMailKupca.TabIndex = 7;
            this.lblMailKupca.Text = "E-mail:";
            // 
            // actionOdustani
            // 
            this.actionOdustani.Location = new System.Drawing.Point(170, 200);
            this.actionOdustani.Name = "actionOdustani";
            this.actionOdustani.Size = new System.Drawing.Size(75, 23);
            this.actionOdustani.TabIndex = 8;
            this.actionOdustani.Text = "Odustani";
            this.actionOdustani.UseVisualStyleBackColor = true;
            this.actionOdustani.Click += new System.EventHandler(this.actionOdustani_Click);
            // 
            // FormaZaUnosNovogKupca
            // 
            this.ClientSize = new System.Drawing.Size(301, 266);
            this.Controls.Add(this.actionOdustani);
            this.Controls.Add(this.lblMailKupca);
            this.Controls.Add(this.lblOpisKupca);
            this.Controls.Add(this.lblImeKupca);
            this.Controls.Add(this.actionDodajNovogKupca);
            this.Controls.Add(this.inputOpisKupca);
            this.Controls.Add(this.inputMailKupca);
            this.Controls.Add(this.inputImeKupca);
            this.Name = "FormaZaUnosNovogKupca";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Unos kupca";
            this.Load += new System.EventHandler(this.FormaZaUnosNovogKupca_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void actionDodajNovogKupca_Click(object sender, EventArgs e)
        {
            using (var kontekstZaUnosKupca = new ChickenCheckEntiteti())
            {
                if (odabraniKupac == null)
                {
                    Kupac noviKupac = new Kupac
                    {
                        naziv = inputImeKupca.Text,
                        kontakt = inputMailKupca.Text,
                        opis = inputOpisKupca.Text

                    };
                    kontekstZaUnosKupca.Kupac.Add(noviKupac);
                    kontekstZaUnosKupca.SaveChanges();

                }
                else {
                    kontekstZaUnosKupca.Kupac.Attach(odabraniKupac);
                    odabraniKupac.naziv = inputImeKupca.Text;
                    odabraniKupac.opis = inputOpisKupca.Text;
                    odabraniKupac.kontakt = inputMailKupca.Text;
                    kontekstZaUnosKupca.SaveChanges();

                }
            }
            Close();
            
        }

        private void actionOdustani_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void FormaZaUnosNovogKupca_Load(object sender, EventArgs e)
        {
            if (odabraniKupac != null)
            {
                inputImeKupca.Text = odabraniKupac.naziv;
                inputOpisKupca.Text = odabraniKupac.opis;
                inputMailKupca.Text = odabraniKupac.kontakt;

            }
        }
    }
}
