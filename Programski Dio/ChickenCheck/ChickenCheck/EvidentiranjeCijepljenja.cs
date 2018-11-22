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
    public partial class FormaEvidencijaCijepljenja : Form
    {
        Cjepivo cjepivo;
        KokosiTurnus turnus;
        ChickenCheckEntiteti kontekstZaEvidentiranjeCjepiva;
        
        public FormaEvidencijaCijepljenja()
        {
            InitializeComponent();
        }

        private void FormaEvidencijaCijepljenja_Load(object sender, EventArgs e)
        {
            kontekstZaEvidentiranjeCjepiva = new ChickenCheckEntiteti();
            cjepivo = new Cjepivo();
            turnus = new KokosiTurnus();
            KokosiTurnus aktivniTurnus = turnus.DohvatiAktivanTurnus();

            BindingList<Cjepivo> listaCjepiva = cjepivo.ispisiCjepiva();
            inputFormaEvidencijaCijepljenjaCjepivo.DataSource = listaCjepiva;
            inputFormaEvidencijaCijepljenjaCjepivo.DisplayMember = "nazivCjepiva";

            
            inputFormaEvidencijaCjepljenjaTurnus.Text = aktivniTurnus.idTurnusa.ToString();
        }

        private void actionFormaEvidencijaCijepljenjaUnesiCijepljenje_Click(object sender, EventArgs e)
        {
            cjepivo = inputFormaEvidencijaCijepljenjaCjepivo.SelectedItem as Cjepivo;
            if (cjepivo != null)
            {
                KokosiTurnus aktivniTurnus = turnus.DohvatiAktivanTurnus();
                Cijepljenje cijepljenje = new Cijepljenje();
                var odabranoCjepivo = kontekstZaEvidentiranjeCjepiva.Cjepivo.Where(c => c.idCjepiva == cjepivo.idCjepiva).SingleOrDefault();
                var odabraniTurnus = kontekstZaEvidentiranjeCjepiva.KokosiTurnus.Where(kt => kt.idTurnusa == aktivniTurnus.idTurnusa).SingleOrDefault();

                if (odabranoCjepivo != null && odabraniTurnus != null)
                {

                    cijepljenje.EvidentirajCijepljenje(odabranoCjepivo, odabraniTurnus);
                    kontekstZaEvidentiranjeCjepiva.Cijepljenje.Add(cijepljenje);
                    kontekstZaEvidentiranjeCjepiva.SaveChanges();
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("Niste odabrali cjepivo!");
            }
            
        }

 
    }
}
