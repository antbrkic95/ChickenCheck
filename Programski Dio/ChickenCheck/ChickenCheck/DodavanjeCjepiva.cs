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
    public partial class FormaDodavanjeCjepiva : Form
    {
        Cjepivo cjepivo;
        ChickenCheckEntiteti kontekstZaUnosCjepiva;
        public FormaDodavanjeCjepiva()
        {
            InitializeComponent();
            cjepivo = new Cjepivo();
            kontekstZaUnosCjepiva = new ChickenCheckEntiteti();
        }

        private void actionUnesiCjepivo_Click(object sender, EventArgs e)
        {
            string naziv = inputFormaDodavanjeCjepivaNaziv.Text;
            string vrsta = inputFormaDodavanjeCjepivaVrsta.Text;
            string opis = inputFormaDodavanjeCjepivaOpis.Text;

            cjepivo.dodajCjepivo(naziv, vrsta, opis);

            if(naziv!="" && vrsta != "" && opis != "" && opis.Length<=10)
            {
                kontekstZaUnosCjepiva.Cjepivo.Add(cjepivo);
                kontekstZaUnosCjepiva.SaveChanges();
                this.Close();
            }
            
        }
    }
}
