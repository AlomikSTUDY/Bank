public interface IKonwersjaKonta
{
    Konto KonwertujNaKonto();
    KontoPlus KonwertujNaKontoPlus(decimal nowyLimit);
    KontoLimit KonwertujNaKontoLimit(decimal nowyLimit);
}
