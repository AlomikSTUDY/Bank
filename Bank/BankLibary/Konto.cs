public class Konto
{
    private string klient;
    private decimal bilans;
    private bool zablokowane = false;

    public string Nazwa => klient;
    public decimal Bilans => bilans;
    public bool Zablokowane => zablokowane;

    public Konto(string klient, decimal bilansNaStart = 0)
    {
        if (bilansNaStart < 0)
            throw new ArgumentException("Bilans nie może być ujemny.");

        this.klient = klient;
        this.bilans = bilansNaStart;
    }

    public void Wplata(decimal kwota)
    {
        if (kwota <= 0)
            throw new ArgumentException("Wpłata musi być większa niż 0.");


        if (zablokowane && bilans + kwota <= 0)
            throw new InvalidOperationException("Konto jest zablokowane.");

        bilans += kwota;
    }


    public void Wyplata(decimal kwota)
    {
        if (kwota <= 0)
            throw new ArgumentException("Wypłata musi być większa niż 0.");
        if (zablokowane)
            throw new InvalidOperationException("Konto jest zablokowane.");
        if (bilans < kwota)
            throw new InvalidOperationException("Brak środków na koncie.");

        bilans -= kwota;
    }

    protected void WymuszonaWyplata(decimal kwota)
    {
        bilans -= kwota;
    }

    public void WplataZablokowane(decimal kwota)
    {
        if (kwota <= 0)
            throw new ArgumentException("Wpłata musi być większa niż 0.");

        bilans += kwota;
    }



    public void BlokujKonto() => zablokowane = true;
    public void OdblokujKonto() => zablokowane = false;

}
