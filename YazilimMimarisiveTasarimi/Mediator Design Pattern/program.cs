 class Program
{
    static void Main(string[] args)
    {
        //ilk olarak uçakların bağlı olacağı kule oluşturulur
        IKule kule = new EsenbogaKule();
        //Uçak nesneleri oluşturulur.
        AbsUcak ThyTK001 = new ThyUcak { UcusNo = "ThyTK001"};
        AbsUcak ThyTK002 = new ThyUcak { UcusNo = "ThyTK002"};
        AbsUcak UsaUS001 = new ThyUcak { UcusNo = "UsaUS001"};
           
        //uçak nesneleri kule nesnesine kayıt ettirilir.
        //Uçak nesnesindeki IliskiliKule nesnesi kule nesnesindeki UcakKayit metodunda yapılır.
        kule.UcakKayit(ThyTK001);
        kule.UcakKayit(ThyTK002);
        kule.UcakKayit(UsaUS001);
        //sadece ilk izin isteyen uçağa iniş izni true verilir.
        ThyTK001.InisIzniIste();
        ThyTK002.InisIzniIste();
        ThyTK001.InisIzni = false;
        //ThyTK001 nesnesinin iniş izni iptal edildiği için ThyTK002 nesnesine iniş izni verilir.
        ThyTK002.InisIzniIste();
        Console.ReadKey();
    }
}