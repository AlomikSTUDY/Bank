public class KontoPlus : Konto
{
    private decimal limit;

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

    public KontoPlus(string klient, decimal bilans, decimal limit)
        : base(klient, bilans)
    {
        this.Limit = limit;
    }

    public new void Wyplata(decimal kwota)
    {
        if (kwota <= 0)
            throw new ArgumentException("Wypłata musi być większa niż 0.");
        if (Zablokowane)
            throw new InvalidOperationException("Konto jest zablokowane.");
        if (Bilans + Limit < kwota)
            throw new InvalidOperationException("Przekroczono limit debetowy.");

        WymuszonaWyplata(kwota); 

        if (Bilans < 0)
            BlokujKonto();
    }

    public new void Wplata(decimal kwota)
    {
        if (kwota <= 0)
            throw new ArgumentException("Wpłata musi być większa niż 0.");

        if (Zablokowane)
            WplataZablokowane(kwota); 
        else
            base.Wplata(kwota);

        if (Bilans >= 0)
            OdblokujKonto();
    }


    public Konto KonwertujNaKonto()
    {
        return new Konto(this.Nazwa, this.Bilans);
    }




}
