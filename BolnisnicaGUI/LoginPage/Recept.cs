using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginPage
{
    class Recept
    {
        private string emso_pacienta;
        public enum vrsta_doktorja {osebni, pooblasceni, nadomestni};
        public vrsta_doktorja trenutni;
        private int razlog_obravnave;
        private int nacin_doplacila;
        private string enota_zzzs;
        private string tuji_zavarovanec;
        
        
        public string Emso_pacienta
        {            
            set 
            { 
                DateTime dateValue;
                if (value.Length == 13 && DateTime.TryParse(value.Substring(0, 7).Insert(4, "-").Insert(2, "-"), out dateValue)) { emso_pacienta = value; }                   
            }
            get
            {
                return Emso_pacienta;
            }
        }

        public string Datum_rojstva
        {
            get { return emso_pacienta.Substring(0, 7).Insert(4, "-").Insert(2, "-"); }
        }

        public char Spol
        {
            get
            {
                if(int.Parse(Emso_pacienta.Substring(9,1)) < 5) return 'M';
                else return 'Ž';
            }
        }

        public int Razlog_obravnave 
        {
            get { return razlog_obravnave; }
            set
            {
                if (value < 6) razlog_obravnave = value;
            } 
        }

        public int Nacin_doplacila
        {
            get { return nacin_doplacila; }
            set { if (value < 4) nacin_doplacila = value; }
        }

        public string Enota_zzzs
        {
            get { return enota_zzzs; }
            set { if (value.Length == 6) enota_zzzs = value; }
        }

        public string Tuji_zavarovanec
        {
            get { return tuji_zavarovanec; }
            set { if (value.Length == 3) tuji_zavarovanec = value; }
        }
    }
}
