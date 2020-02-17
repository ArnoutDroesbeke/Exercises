﻿namespace KlantOberKok
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            Klant klant1 = new Klant("Piet");
            Klant klant2 = new Klant("Jef");
            BestellingsSysteem bestellingsSysteem = new BestellingsSysteem();
            //Bel bel = new Bel();
            Ober ober = new Ober("Jan")
            {
                BestellingsSysteem = bestellingsSysteem,
                //Bel = bel,
            };

            // kok en ober weten niet van elkaar!
            Kok kok = new Kok("Marie")
            {
                BestellingsSysteem = bestellingsSysteem,
                //Bel = bel,
            };

            klant1.Bestel(ober, "Hoegaarden");
            klant2.Bestel(ober, "Koffie");

            Console.ReadKey();
        }
    }
}
