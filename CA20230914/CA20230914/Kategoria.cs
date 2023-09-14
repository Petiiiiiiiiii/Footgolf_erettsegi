using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CA20230914
{
    class Versenyzo
    {
        public string Nev { get; set; }
        public bool Kategoria { get; set; }
        public string EgyesuletNeve { get; set; }
        public int[] Pontszamok { get; set; }
        
        public int Oszpont
        {
            get 
            {
                var rendezett = Pontszamok.OrderBy(x => x).ToArray();
                int op = 0;

                if (rendezett[0] > 0)
                    op += 10;
                if (rendezett[1] > 0)
                    op += 10;

                for (int i = 2; i < rendezett.Length; i++)
                {
                    op += rendezett[i];
                }

                return op;
            }
        }

        public Versenyzo(string sor)
        {
            string[] k = sor.Split(';');
            Nev = k[0];
            Kategoria = k[1] == "Felnott ferfi";
            EgyesuletNeve = k[2] == "n.a." ? null : k[2];
            Pontszamok = new int[8];
            for (int i = 0; i < Pontszamok.Length; i++)
            {
                Pontszamok[i] = int.Parse(k[i + 3]);
            }
            
        }
    }
}
