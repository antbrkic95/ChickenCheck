using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenCheck
{
    partial class KokosiTurnus
    {
        public BindingList<Cjepivo> listaNazivaCjepiva;
        public BindingList<BaterijeKaveza> baterijeKaveza;
        public BindingList<Cijepljenje> listaCjepiva;

        public void dodajTurnus(string datumNabavke)
        {
            this.datumNabavkeTurnusa = datumNabavke;
        }

        public BindingList<BaterijeKaveza> ispisSvihBaterija(KokosiTurnus turnus)
        {
            BindingList<BaterijeKaveza> listaBaterijaKaveza = null;
            using (ChickenCheckEntiteti kontekstZaIspisBaterijaKaveza = new ChickenCheckEntiteti())
            {
                kontekstZaIspisBaterijaKaveza.KokosiTurnus.Attach(turnus);
                listaBaterijaKaveza = new BindingList<BaterijeKaveza>(turnus.BaterijeKaveza.ToList());
            }
            return listaBaterijaKaveza;
        }

        public void dodajBaterije(BaterijeKaveza baterije)
        {
            this.baterijeKaveza.Add(baterije);
        }

        public void UnosBaterija()
        {
            foreach (BaterijeKaveza baterija in baterijeKaveza)
            {
                this.BaterijeKaveza.Add(baterija);
            }
            using (ChickenCheckEntiteti kontekstZaUnosBaterijaKaveza = new ChickenCheckEntiteti())
            {
                kontekstZaUnosBaterijaKaveza.KokosiTurnus.Add(this);
                kontekstZaUnosBaterijaKaveza.SaveChanges();
            }
        }

        public void dodajCjepivo(Cijepljenje cijepljenje)
        {
            this.listaCjepiva.Add(cijepljenje);
        }

        public void UnosCjepiva()
        {
            foreach (Cijepljenje cijepljenje in listaCjepiva)
            {
                this.Cijepljenje.Add(cijepljenje);
            }
            using (ChickenCheckEntiteti kontekstZaEvidentiranjeCjepljenja = new ChickenCheckEntiteti())
            {

            }
        }

        public KokosiTurnus DohvatiAktivanTurnus()
        {
            using (ChickenCheckEntiteti kontekstZaDohvacanjeAktivnogTurnusa = new ChickenCheckEntiteti())
            {
                KokosiTurnus turnus;
                var upitAktivniTurnus = (from t in kontekstZaDohvacanjeAktivnogTurnusa.KokosiTurnus where t.zapisNeaktivan != true select t).First<KokosiTurnus>();
                turnus = upitAktivniTurnus;
                return turnus;
            }
        }

        public void IzmjenaAktivnogTurnusaUNeaktivni(KokosiTurnus turnus)
        {
            using (ChickenCheckEntiteti kontekstZaPromjenuAktivnogZapisa = new ChickenCheckEntiteti())
            {
                kontekstZaPromjenuAktivnogZapisa.KokosiTurnus.Attach(turnus);
                turnus.zapisNeaktivan = true;
                kontekstZaPromjenuAktivnogZapisa.SaveChanges();
            }
        }
    }
}
