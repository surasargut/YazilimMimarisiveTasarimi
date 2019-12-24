//ConcreteColleague2
class UsaUcak : AbsUcak
{
    //ConcreteColleague1 yapısı için geçerli olanlar bu yapı için de geçerlidir.
    public override void SetInisIzni(bool Izin)
    {
        Console.WriteLine("Usa Uçuş No:{0} iniş izni istiyor...", UcusNo);
        base.SetInisIzni(Izin);
    }
}