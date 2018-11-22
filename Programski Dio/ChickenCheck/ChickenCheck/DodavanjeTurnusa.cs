using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChickenCheck
{
    public partial class FormaDodajTurnus : Form
    {
        KokosiTurnus turnus;
        ChickenCheckEntiteti kontekstZaUnosTurnusa;
        public FormaDodajTurnus()
        {
            InitializeComponent();
            turnus = new KokosiTurnus();
            kontekstZaUnosTurnusa = new ChickenCheckEntiteti();
        }

        private void actionFormaDodajTurnusUnesiTurnus_Click(object sender, EventArgs e)
        {
            bool uspjesno1 = false;
            bool uspjesno2 = false;
            bool uspjesno3 = false;
            string datumNabaveTurnusaString = "";
            DateTime datumNabaveTurnusa = new DateTime();
            BaterijeKaveza baterijaKaveza;
            KokosiTurnus prijasnjiAktivniTurnus = new KokosiTurnus();
            int brojKaveza = 0;
            int brojBaterija = 0;
            int brojKokosi = 0;
            datumNabaveTurnusa = inputFormaDodajTurnusDatumNabave.Value;
            datumNabaveTurnusaString = datumNabaveTurnusa.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            uspjesno1 = int.TryParse(inputFormaDodajTurnusBrojKavezaBaterije.Text, out brojKaveza) && brojKaveza > 0;
            uspjesno2 = int.TryParse(inputFormaDodajTurnusBrojBaterija.Text, out brojBaterija) && brojBaterija > 0;
            uspjesno3 = int.TryParse(inputFormaDodajTurnusBrojKokosi.Text, out brojKokosi) && brojKokosi > 0;

            if ( uspjesno1 && uspjesno2 && uspjesno3)
            {
                prijasnjiAktivniTurnus = turnus.DohvatiAktivanTurnus();
                turnus.IzmjenaAktivnogTurnusaUNeaktivni(prijasnjiAktivniTurnus);
                turnus.dodajTurnus(datumNabaveTurnusaString);

                if (brojKokosi % brojBaterija > 0)
                {
                    for (int i = 0; i < brojBaterija - 1; i++)
                    {
                        baterijaKaveza = new BaterijeKaveza(brojKokosi / brojBaterija, brojKaveza);
                        turnus.dodajBaterije(baterijaKaveza);
                    }
                    baterijaKaveza = new BaterijeKaveza(brojKokosi % brojBaterija, brojKaveza);
                    turnus.dodajBaterije(baterijaKaveza);
                }
                else
                {
                    for (int i = 0; i < brojBaterija; i++)
                    {
                        baterijaKaveza = new BaterijeKaveza(brojKokosi / brojBaterija, brojKaveza);
                        turnus.dodajBaterije(baterijaKaveza);
                    }
                }

                turnus.UnosBaterija();
                this.Close();
            }
            else
            {
                MessageBox.Show("Niste unjeli pravilne podatke");
            }

            
        }
    }


}
