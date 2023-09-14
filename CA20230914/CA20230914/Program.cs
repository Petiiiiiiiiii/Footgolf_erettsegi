using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace CA20230914
{
    class Program
    {
        static void Main()
        {
            var versenyzok = new List<Versenyzo>();
           using var sr = new StreamReader(
                path:"fob2016.txt",
                encoding: Encoding.UTF8
                );

            while (!sr.EndOfStream)
            {
                versenyzok.Add(new Versenyzo(sr.ReadLine()));
            }

            sr.Close();

            Console.WriteLine($"3. feladat: Versenyzők száma: {versenyzok.Count}");

            int nokSzama = versenyzok.Count(v => !v.Kategoria);
            float nokAranya = nokSzama / (float)versenyzok.Count * 100;
            Console.WriteLine($"4. feladat: Női versenyzők aránya: {nokAranya:0.00}%");

            var noiBajnok = versenyzok
                .Where(x => !x.Kategoria)
                .OrderBy(v => v.Oszpont)
                .Last();

            Console.WriteLine("6.feladat: A bajnok női versenyző: ");
            Console.WriteLine($"\tNév: {noiBajnok.Nev}");
            Console.WriteLine($"\tEgyesület: {noiBajnok.EgyesuletNeve}");
            Console.WriteLine($"\tÖsszpont: {noiBajnok.Oszpont}");

            var sw = new StreamWriter(
                path: "osszpontFF.txt",
                append: false,
                encoding: Encoding.UTF8
                );

            foreach (var v in versenyzok)
            {
                if (v.Kategoria) sw.WriteLine($"{v.Nev};{v.Oszpont}");
            }

            sw.Close();

            Console.ReadKey();
        }
    }
}
