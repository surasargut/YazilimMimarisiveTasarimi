//ConcreteMediator yapısı
class EsenbogaKule : IKule
{
    //Kule kendisine bağlı olan uçakların bilgisini tutmak zorunda ki isteklere buna göre cevap verebilsin.
    private List<AbsUcak> _UcakListe = new List<AbsUcak>();
    public void UcakKayit(AbsUcak _ucak)
    {
        _UcakListe.Add(_ucak);
        //Listeye eklenen AbsUcak nesnesine yöneticisinin bu sınıf olduğunu bildiriyoruz.
        _ucak.IliskiliKule = this;
    }
    public void InisIzniCevap(string UcusNo)
    {
        bool izin = true;
        // eğer başka bir uçağa iniş izni verilmedi ise ilk izin isteyen uçağa izin ver
        if (_UcakListe.Where(u => u.InisIzni == true).Count() > 0)
            izin = false;
        //uçağın cevap alması için barındırdığı metoda cevap verilir.
        _UcakListe.Where(u => u.UcusNo == UcusNo).Single().SetInisIzni(izin);
    }
}