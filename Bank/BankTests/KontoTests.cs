using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class KontoTests
{
    [TestMethod]
    public void Konto_Inicjalizacja_PoprawneWartosci()
    {
        // Arrange & Act
        var konto = new Konto("Jan Kowalski", 100);

        // Assert
        Assert.AreEqual("Jan Kowalski", konto.Nazwa);
        Assert.AreEqual(100, konto.Bilans);
        Assert.IsFalse(konto.Zablokowane);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Konto_Inicjalizacja_NegatywnyBilans_ThrowException()
    {
        new Konto("Jan Kowalski", -50);
    }

    [TestMethod]
    public void Wplata_PrawidlowaKwota_ZwiekszaBilans()
    {
        var konto = new Konto("Jan Kowalski", 100);
        konto.Wplata(50);
        Assert.AreEqual(150, konto.Bilans);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Wplata_UjemnaKwota_ThrowException()
    {
        var konto = new Konto("Jan Kowalski", 100);
        konto.Wplata(-20);
    }

    [TestMethod]
    public void Wyplata_PrawidlowaKwota_OdejmowanieBilansu()
    {
        var konto = new Konto("Jan Kowalski", 100);
        konto.Wyplata(50);
        Assert.AreEqual(50, konto.Bilans);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Wyplata_BrakSrodkow_ThrowException()
    {
        var konto = new Konto("Jan Kowalski", 50);
        konto.Wyplata(100);
    }

    [TestMethod]
    public void BlokowanieOdblokowanieKonta_DzialaPoprawnie()
    {
        var konto = new Konto("Jan Kowalski", 100);
        konto.BlokujKonto();
        Assert.IsTrue(konto.Zablokowane);

        konto.OdblokujKonto();
        Assert.IsFalse(konto.Zablokowane);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Wplata_NaZablokowaneKonto_ThrowException()
    {
        var konto = new Konto("Jan", 100);
        konto.BlokujKonto();
        konto.Wplata(50);
    }

}
