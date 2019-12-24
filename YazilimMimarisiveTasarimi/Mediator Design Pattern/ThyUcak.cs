//ConcreteColleague1
class ThyUcak : AbsUcak
{
    //InisIzniIste metotu AbsUcak abstract sınıfından gelir.
    //Kule cevabı mu metot ile verir.
    public override void SetInisIzni(bool Izin)
    {
        Console.WriteLine("Thy Uçuş No:{0} iniş izni istiyor...", UcusNo );
        base.SetInisIzni(Izin);
    }
}