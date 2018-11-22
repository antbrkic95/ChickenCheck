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
    public partial class FormaDodavanjeHrane : Form
    {
        Sirovina hrana;
        ChickenCheckEntiteti kontekstZaDodavanjeHrane;
        BindingList<Sirovina> listaSirovina;
        public FormaDodavanjeHrane()
        {
            InitializeComponent();
        }

        private void FormaDodavanjeHrane_Load(object sender, EventArgs e)
        {
            hrana = new Sirovina();
            kontekstZaDodavanjeHrane = new ChickenCheckEntiteti();
            OsvjeziListuSastojaka();
          
        }

        private void actionFormaDodavanjeHraneDodajSastojak_Click(object sender, EventArgs e)
        {

            Sirovina sirovina = new Sirovina();
            sirovina = inputFormaDodavanjeHraneSirovine.SelectedItem as Sirovina;
            int kolicina;
            if(sirovina != null)
            {
                bool uspjesno = int.TryParse(inputFormaDodavanjeHranePostotak.Text, out kolicina) && kolicina > 0;
                if (uspjesno)
                {
                    hrana.dodajSirovinuZaHranu(sirovina, kolicina);

                    OsvjeziListuSastojaka();
                    outputFormaDodavanjeHraneListaSastojakaHrane.Items.Clear();
                    foreach (Sirovina s in Sirovina.recept)
                    {
                        outputFormaDodavanjeHraneListaSastojakaHrane.Items.Add(s);
                    }
                    outputFormaDodavanjeHraneListaSastojakaHrane.Items[0] = outputFormaDodavanjeHraneListaSastojakaHrane.Items[0];
                }
                else
                {
                    MessageBox.Show("Niste unjeli broj!");
                }
                
            }
            else
            {
                MessageBox.Show("Niste odabrali sirovinu!");
            }
            

        }

        private void actionFormaDodavanjeHraneDodajHranu_Click(object sender, EventArgs e)
        {
            string nazivHrane = inputFormaDodavanjeHraneNaziv.Text;
            string opisHrane = inputFormaDodavanjeHraneOpis.Text;
            bool uspjesno = true;

            if (nazivHrane.Count() < 255 && opisHrane.Count() < 255 && nazivHrane != "" && opisHrane != "")
            {

                foreach (Sirovina s in Sirovina.recept)
                {
                    var odabranaSirovina = kontekstZaDodavanjeHrane.Sirovina.Where(si => si.idSirovine == s.idSirovine).SingleOrDefault();
                    if (odabranaSirovina != null)
                    {
                        if(odabranaSirovina.kolicina < s.kolicina)
                        {
                            uspjesno = false;
                        }
                    }
                }
                if (uspjesno)
                {
                    hrana.dodajHranu(nazivHrane, opisHrane);

                    kontekstZaDodavanjeHrane.Sirovina.Add(hrana);
                    kontekstZaDodavanjeHrane.SaveChanges();

                    var odabranaHrana = kontekstZaDodavanjeHrane.Sirovina.Where(c => c.idSirovine == hrana.idSirovine).SingleOrDefault();
                    foreach (Sirovina s in Sirovina.recept)
                    {
                        var odabranaSirovina = kontekstZaDodavanjeHrane.Sirovina.Where(si => si.idSirovine == s.idSirovine).SingleOrDefault();
                        if (odabranaHrana != null && odabranaSirovina != null)
                        {
                            Recept recept = new Recept();
                            recept.UnesiRecept(odabranaHrana, odabranaSirovina, s.kolicina);
                            kontekstZaDodavanjeHrane.Recept.Add(recept);
                            kontekstZaDodavanjeHrane.Sirovina.Attach(odabranaSirovina);
                            odabranaSirovina.oduzmiHranu(s.kolicina);
                            kontekstZaDodavanjeHrane.SaveChanges();
                        }
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error message");
                }
  
            }
            else
            {
                MessageBox.Show("Niste unjeli sve podatke!");
            }
           
        }

        public void OsvjeziListuSastojaka()
        {
            listaSirovina = hrana.ispisiSirovine();
            inputFormaDodavanjeHraneSirovine.DataSource = listaSirovina;
            inputFormaDodavanjeHraneSirovine.DisplayMember = "nazivSirovine";

           
           
        }
    }
}
