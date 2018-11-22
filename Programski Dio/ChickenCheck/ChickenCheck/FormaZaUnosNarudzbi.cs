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
    public partial class FormaZaUnosNarudzbi : Form
    {
        private Button dodajNovuNarudzbu;
        private Label odabirDatumaIsporuka;
        private DateTimePicker odabirdatumaIsporuke;
        private Button actionOdustani;
        private Kupac proslijeđeniKupac;

        public FormaZaUnosNarudzbi(Kupac odabraniKupac)
        {
            InitializeComponent();
            proslijeđeniKupac = odabraniKupac;
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormaZaUnosNarudzbi));
            this.odabirdatumaIsporuke = new System.Windows.Forms.DateTimePicker();
            this.dodajNovuNarudzbu = new System.Windows.Forms.Button();
            this.odabirDatumaIsporuka = new System.Windows.Forms.Label();
            this.actionOdustani = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // odabirdatumaIsporuke
            // 
            this.odabirdatumaIsporuke.Location = new System.Drawing.Point(100, 34);
            this.odabirdatumaIsporuke.Name = "odabirdatumaIsporuke";
            this.odabirdatumaIsporuke.Size = new System.Drawing.Size(200, 20);
            this.odabirdatumaIsporuke.TabIndex = 0;
            // 
            // dodajNovuNarudzbu
            // 
            this.dodajNovuNarudzbu.Location = new System.Drawing.Point(12, 79);
            this.dodajNovuNarudzbu.Name = "dodajNovuNarudzbu";
            this.dodajNovuNarudzbu.Size = new System.Drawing.Size(134, 29);
            this.dodajNovuNarudzbu.TabIndex = 1;
            this.dodajNovuNarudzbu.Text = "Dodaj Narudžbu";
            this.dodajNovuNarudzbu.UseVisualStyleBackColor = true;
            this.dodajNovuNarudzbu.Click += new System.EventHandler(this.dodajNovuNarudzbu_Click);
            // 
            // odabirDatumaIsporuka
            // 
            this.odabirDatumaIsporuka.AutoSize = true;
            this.odabirDatumaIsporuka.Location = new System.Drawing.Point(12, 34);
            this.odabirDatumaIsporuka.Name = "odabirDatumaIsporuka";
            this.odabirDatumaIsporuka.Size = new System.Drawing.Size(82, 13);
            this.odabirDatumaIsporuka.TabIndex = 2;
            this.odabirDatumaIsporuka.Text = "Datum Isporuke";
            // 
            // actionOdustani
            // 
            this.actionOdustani.Location = new System.Drawing.Point(167, 79);
            this.actionOdustani.Name = "actionOdustani";
            this.actionOdustani.Size = new System.Drawing.Size(117, 29);
            this.actionOdustani.TabIndex = 3;
            this.actionOdustani.Text = "Odustani";
            this.actionOdustani.UseVisualStyleBackColor = true;
            this.actionOdustani.Click += new System.EventHandler(this.actionOdustani_Click);
            // 
            // FormaZaUnosNarudzbi
            // 
            this.ClientSize = new System.Drawing.Size(329, 159);
            this.Controls.Add(this.actionOdustani);
            this.Controls.Add(this.odabirDatumaIsporuka);
            this.Controls.Add(this.dodajNovuNarudzbu);
            this.Controls.Add(this.odabirdatumaIsporuke);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormaZaUnosNarudzbi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Unos narudžbe";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        /// <summary>
        /// Dodavanje nove narudzbe na temelju stanja "naruceno"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dodajNovuNarudzbu_Click(object sender, EventArgs e)
        {
            DateTime datumIsporuke = odabirdatumaIsporuke.Value.Date;
            StanjeNarudzbe novoStanje = new StanjeNarudzbe
            {
                idStanja = 1,
                nazivStanja = "Naručeno"
            };
            DateTime datumNarudzbe = DateTime.Now;
  
            Narudzba nova = new Narudzba(datumNarudzbe, novoStanje, proslijeđeniKupac,datumIsporuke);
            nova.DodajNarudzbuUBazu();
            this.Close();

        }

        private void actionDodajKorisnika_Click(object sender, EventArgs e)
        {
            FormaZaUnosNovogKupca formaUnosKupca = new FormaZaUnosNovogKupca();
            formaUnosKupca.ShowDialog();
        }

        private void actionOdustani_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
