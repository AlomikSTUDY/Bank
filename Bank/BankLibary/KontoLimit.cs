public class KontoLimit
{
    private Konto konto;
    private decimal limit;

    public string Nazwa => konto.Nazwa;
    public decimal Bilans => konto.Bilans + limit;
    public bool Zablokowane => konto.Zablokowane;

    public decimal Limit
    {
        get => limit;
        set
        {
            if (value < 0)
                throw new ArgumentException("Limit nie może być ujemny.");
            limit = value;
        }
    }

    public KontoLimit(string klient, decimal bilans, decimal limit)
    {
        konto = new Konto(klient, bilans);
        this.Limit = limit;
    }

    public void Wplata(decimal kwota)
    {
        konto.Wplata(kwota);
        if (konto.Bilans > 0)
            konto.OdblokujKonto();
    }

    public void Wyplata(decimal kwota)
    {
        if (kwota <= 0)
            throw new ArgumentException("Wypłata musi być większa niż 0.");
        if (konto.Zablokowane)
            throw new InvalidOperationException("Konto jest zablokowane.");
        if (konto.Bilans + Limit < kwota)
            throw new InvalidOperationException("Przekroczono limit debetowy.");

        typeof(Konto)
    .GetMethod("WymuszonaWyplata", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
    ?.Invoke(konto, new object[] { kwota });


        if (konto.Bilans < 0)
            konto.BlokujKonto();
    }
}
