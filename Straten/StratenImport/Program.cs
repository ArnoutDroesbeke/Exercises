﻿using StratenImport.Exporters;
using StratenImport.Providers;
using System;
using System.Collections.Generic;

namespace Straten
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Usage: StratenImport.exe <nl|fr>");
                return 1; // OS: 0 == ok, != 0 == failure
            }
            string taalCode = args[0];

            // Ctor verdient voorkeur: schrijf om
            Land land = new Land { Id = 1, Naam = "Belgie", TaalCode = taalCode };

            var regio = new Regio { Id = 1, Naam = "Vlaanderen", Land = land };
            land.Regios.Add(regio.Naam, regio); // SortedList

            LandProvider landProvider = new LandProvider(land);
            landProvider.Read(); // Lees .csv bestanden in en stop resultaat in SortedList<> op elk niveau

            LandExporter landExporter = new LandExporter(land);
            landExporter.Persist(); // Zet [Serializable] boven classes Land, Regio, Provincie, ... en gebruik BinaryFormatter om ingelezen gegevens naar een file te schrijven

            return 0;
        }
    }
}