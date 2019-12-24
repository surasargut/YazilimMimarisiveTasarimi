//Colleague yapısı
abstract class AbsUcak
{
    //Uçağın hangi kule ile irtibata geçmesi gerektiğini tutması gerekir.
    public IKule IliskiliKule { get; set; }
    public string UcusNo { get; set; }
    public bool InisIzni { get; set; }
    public void InisIzniIste()
    {
        //uçağın bağlı olduğu kuleden iniş izni istiyor
        IliskiliKule.InisIzniCevap(UcusNo);
    }
    public virtual void SetInisIzni(bool Izin)
    {
        //kule iniş izni isteyen uçağa bu metot ile cevap verir.
        InisIzni = Izin;
        if (InisIzni)
            Console.WriteLine("İniş izni verildi.");
        else
            Console.WriteLine("İniş izni red edildi.");
    }
}