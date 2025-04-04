[TestClass]
public class KontoLimitTests
{
    [TestMethod]
    public void KontoLimit_Inicjalizacja_PoprawneWartosci()
    {
        var konto = new KontoLimit("Jan Kowalski", 100, 200);

        Assert.AreEqual("Jan Kowalski", konto.Nazwa);
        Assert.AreEqual(300, konto.Bilans); // Uwzględnia limit
        Assert.AreEqual(200, konto.Limit);
        Assert.IsFalse(konto.Zablokowane);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void KontoLimit_Inicjalizacja_NegatywnyLimit_ThrowException()
    {
        new KontoLimit("Jan Kowalski", 100, -50);
    }

    [TestMethod]
    public void Wyplata_ZuzycieDebetu_KontoZostajeZablokowane()
    {
        var konto = new KontoLimit("Jan Kowalski", 100, 200);
        konto.Wyplata(250); // Wchodzimy na debet

        Assert.IsTrue(konto.Zablokowane);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Wyplata_PonadLimit_ThrowException()
    {
        var konto = new KontoLimit("Jan Kowalski", 100, 200);
        konto.Wyplata(350); // Przekracza dostępne środki (100 + 200)
    }

    [TestMethod]
    public void Wplata_SplacenieDebetu_KontoZostajeOdblokowane()
    {
        var konto = new KontoLimit("Jan Kowalski", 100, 200);
        konto.Wyplata(250); // Wchodzimy na debet
        konto.Wplata(200); // Spłacamy debet

        Assert.IsFalse(konto.Zablokowane);
    }
}
