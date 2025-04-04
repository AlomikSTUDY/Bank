using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Symulacja działania kont bankowych ===");

        Konto konto = new Konto("Jan Kowalski", 500 );
        Console.WriteLine($"Utworzono Konto: {konto.Nazwa}, Bilans: {konto.Bilans}");


        konto.Wplata(200);
        Console.WriteLine($"Po wpłacie 200: {konto.Bilans}");

        konto.Wyplata(100);
        Console.WriteLine($"Po wypłacie 100: {konto.Bilans}");

        // Konwersja Konto → KontoPlus
        KontoPlus kontoPlus = new KontoPlus("Jan Kowalski", 500, 200);
        Konto noweKonto = kontoPlus.KonwertujNaKonto();

        Console.WriteLine($"Konwersja na Konto: {noweKonto.Nazwa}, Bilans: {noweKonto.Bilans}");


        kontoPlus.Wyplata(700); // Wchodzimy na debet
        Console.WriteLine($"Po wypłacie 700: {kontoPlus.Bilans}, Zablokowane: {kontoPlus.Zablokowane}");

        kontoPlus.Wplata(400);
        Console.WriteLine($"Po wpłacie 400: {kontoPlus.Bilans}, Zablokowane: {kontoPlus.Zablokowane}");

        // Konwersja KontoPlus → Konto
        noweKonto = kontoPlus.KonwertujNaKonto();

        Console.WriteLine($"Konwersja na Konto: {noweKonto.Nazwa}, Bilans: {noweKonto.Bilans}");

        // KontoLimit
        KontoLimit kontoLimit = new KontoLimit("Piotr Zalewski", 400, 150);
        Console.WriteLine($"Utworzono KontoLimit: {kontoLimit.Nazwa}, Bilans dostępny: {kontoLimit.Bilans}, Limit: {kontoLimit.Limit}");

        kontoLimit.Wyplata(500);
        Console.WriteLine($"Po wypłacie 500: {kontoLimit.Bilans}, Zablokowane: {kontoLimit.Zablokowane}");

        kontoLimit.Wplata(200);
        Console.WriteLine($"Po wpłacie 200: {kontoLimit.Bilans}, Zablokowane: {kontoLimit.Zablokowane}");

        Console.WriteLine("\nSymulacja zakończona.");
    }
}
