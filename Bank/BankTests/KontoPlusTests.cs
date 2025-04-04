[TestClass]
public class KontoPlusTests
{
    [TestMethod]
    public void KontoPlus_Inicjalizacja_PoprawneWartosci()
    {
        var konto = new KontoPlus("Jan Kowalski", 100, 200);

        Assert.AreEqual("Jan Kowalski", konto.Nazwa);
        Assert.AreEqual(100, konto.Bilans);
        Assert.AreEqual(200, konto.Limit);
        Assert.IsFalse(konto.Zablokowane);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void KontoPlus_Inicjalizacja_NegatywnyLimit_ThrowException()
    {
        new KontoPlus("Jan Kowalski", 100, -50);
    }

    [TestMethod]
    public void Wyplata_ZuzycieDebetu_KontoZostajeZablokowane()
    {
        var konto = new KontoPlus("Jan Kowalski", 100, 200);
        konto.Wyplata(250);

        Assert.IsTrue(konto.Zablokowane);
    }

    [TestMethod]
    public void Wplata_SplacenieDebetu_KontoZostajeOdblokowane()
    {
        var konto = new KontoPlus("Jan Kowalski", 100, 200);
        konto.Wyplata(250);
        konto.Wplata(200);

        Assert.IsFalse(konto.Zablokowane);
    }

    [TestMethod]
    public void Konwersja_KontoPlusNaKonto_Sukces()
    {
        var kontoPlus = new KontoPlus("Jan Kowalski", 100, 200);
        var zwykleKonto = kontoPlus.KonwertujNaKonto();

        Assert.IsInstanceOfType(zwykleKonto, typeof(Konto));
        Assert.AreEqual(kontoPlus.Nazwa, zwykleKonto.Nazwa);
        Assert.AreEqual(kontoPlus.Bilans, zwykleKonto.Bilans);
    }
}
