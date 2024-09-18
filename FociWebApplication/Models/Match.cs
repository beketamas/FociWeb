using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace FociWebApplication.Models
{
    public class Match
    {
        
        int id;
        int fordulo;
        int hazaGolok;
        int vendegGolok;
        int hazaiElsoFelidoGolok;
        int vendegElsoFelidoGolok;
        string hazaiCsapat;
        string vendegCsapat;
        string vegEredmeny;

        public Match(string[] tomb)
        {
            fordulo = int.Parse(tomb[0]);
            hazaGolok = int.Parse(tomb[1]);
            vendegGolok = int.Parse(tomb[2]);
            hazaiElsoFelidoGolok = int.Parse(tomb[3]);
            this.vendegElsoFelidoGolok = int.Parse(tomb[4]);
            hazaiCsapat = tomb[5];
            vendegCsapat = tomb[6];
        }
        public Match()
        {
            
        }

        public int Id { get => id; set => id = value; }

        public string VegEredmeny => HazaGolok > VendegGolok ? $"{HazaGolok}-{VendegGolok}" : $"{VendegGolok}-{HazaGolok}";

        public int Fordulo { get => fordulo; set => fordulo = value; }
        public int HazaGolok { get => hazaGolok; set => hazaGolok = value; }
        public int VendegGolok { get => vendegGolok; set => vendegGolok = value; }
        public int HazaiElsoFelidoGolok { get => hazaiElsoFelidoGolok; set => hazaiElsoFelidoGolok = value; }
        public int VendegElsoFelidoGolok { get => vendegElsoFelidoGolok; set => vendegElsoFelidoGolok = value; }
        public string HazaiCsapat { get => hazaiCsapat; set => hazaiCsapat = value; }
        public string VendegCsapat { get => vendegCsapat; set => vendegCsapat = value; }
        public string VegEredmeny1 { get => vegEredmeny; set => vegEredmeny = value; }
    }
}
