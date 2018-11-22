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
    public partial class FormaDodajSirovinu : Form
    {
        ChickenCheckEntiteti kontekstZaUnosSirovine;
        public FormaDodajSirovinu()
        {
            InitializeComponent();
        }

        private void FormaDodajSirovinu_Load(object sender, EventArgs e)
        {
            kontekstZaUnosSirovine = new ChickenCheckEntiteti();
        }
        private void actionFormaDodavanjeSirovineDodajSirovinu_Click(object sender, EventArgs e)
        {
            string nazivSirovine = inputFormaDodavanjeSirovineNaziv.Text;
            string opisSirovine = inputFormaDodavanjeSirovineOpis.Text;
            int kolicina;
            if(opisSirovine != "" && nazivSirovine != "" && opisSirovine.Count() < 255 && nazivSirovine.Count() < 255)
            {
                bool uspjesno = int.TryParse(inputFormaDodavanjeSirovineKolicina.Text, out kolicina) && kolicina > 0;
                if (uspjesno)
                {
                    Sirovina sirovina = new Sirovina();
                    sirovina.dodajSirovinu(nazivSirovine, opisSirovine, kolicina);
                    kontekstZaUnosSirovine.Sirovina.Add(sirovina);
                    kontekstZaUnosSirovine.SaveChanges();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Niste unjeli broj!");
                }

            }
            else
            {
                MessageBox.Show("Morate unjeti sve podatke ili smanjite unesene!");
            }

        }
    }
}
