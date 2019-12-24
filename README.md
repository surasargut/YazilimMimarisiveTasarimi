# Yazilim Mimarisi ve Tasarimi

## Facade Tasarım Deseni

- Facade tasarım deseni, Structural tasarım deseninin bir örneğidir.Facade, varolan bir sistemi spesifik bir iş açısından farklı açıdan ele almayı veya mevcut arayüzleri kullanarak daha yüksek seviyede bir işi daha basit şekilde yapmayı tanımlar. Örneğin çok karmaşık bir sınıf kütüphaneniz veya çok karmaşık bir modülünüz var. Çoğu zaman belirli bir işlemi yapmak için çok fazla sayıda nesne üretmeniz ve onlar arasında çeşitli ilişkiler kurmanız gerekir. Bunu sıkça yaptığınız için çoğu zaman kopyala yapıştır yapmanız olasıdır. Facade tasarım desenine göre ise belirli bir işi büyük bir kütüphane içerisinde sık sık yapıyorsak, bu iş için özelleştirilmiş yüksek seviyeli bir arayüz tanımlamak kısa vadede fayda getirecektir.


![Image of Class](https://github.com/surasargut/YazilimMimarisiveTasarimi/blob/master/YazilimMimarisiveTasarimi/facade_uml.png)


- Facade tasarım deseni alt sistemin içeriğini olşturan tiplerim kullanımını istemciden soyutlamakla kalmıyor aynı zamanda kulllanımını daha da kollaylaştırıyor.  İstemci alt sistemdeki parçalara doğrudan ulaşmak zorunda kalmıyor, isteklerini facade üzerinden karşılıyor.

![Image of Class](https://github.com/surasargut/YazilimMimarisiveTasarimi/blob/master/YazilimMimarisiveTasarimi/facadeUml.png)

Facade programdan gelen yani sistemmden gelen talepleri alt sisteme ilerletmekle ve alt sistemi kullaıp geriye cevap göndermekle sorumlu bir arayüz. Musteri classı burada yardımcı tip olarak ele alınabilir. Kredi classında müşterinin ```KrediKullanmaDurumu()```  true olarak ele alınıyor. Bu işlemleri müşterinin bankadan para çekmesi için öngörülen şartlar olarak düşünebiliriz. Banka ve MerkezBanka Classında da ```KrediyiKullan()``` ve ```KaraListeKontrol()``` fonksiyonları bool tipinde kontrol ediliyor. 


Facade pattern arayüz görevinde olduğu için ilk olarak arayüz sınıfı oluşturulur.


```C#
class Facade // bu tasarım deseeni alt sistemin tiplerinin içerir 
    {
        ...
    
       public void KrediKullan(Musteri m, decimal talep)//musteri datasını parametre olarak vereceğiz, talep dilen miktar verilecek
        {
            if (!_merkezBanka.KaraListeKontrol(m.TcNo) // o anki musterinin tc sini gönder -> geçtiyse
                && _kredi.KrediKullanmaDurumu(m)) // kredi kullanma durumu pozitifse     
            {
                _banka.KrediyiKullan(m, talep);
                Console.WriteLine("Kredi kullandiirldi.");
            }
        }
    }
```
Bu facade tipi kullanmakta olduğu alt sistemin gerekli olan uygulama tiplerini ele alır. İstemciye sunacağımız şey istemcinin bizden talep edeceği fonksiyonellik olmalı.

İstemci alt sistemlere erişmek için Facade kullanır. Fakat facade ortadan kaldırılırsa istemci, alt sistemleri tipleri bağımsız parametre olarak kullanabilir.


```C#

class Program
    {
        static void Main(string[] args)
        {
            Facade fcd = new Facade();
            fcd.KrediKullan(new Musteri { Ad = "Sura ", TcNo = "344543", MusteriNumarasi = 1001 }, 1000);
        }
    }


```

İstemci olduğunu varsayıyoruz. İstemci uygulama kredi kullanma operasyonu için gereken alt sisteme doğrudan erişmiyor, onun yerine bu alt sistemin kullanımını kendisi kolaylaştıran bir arayüzle çıkyıor(Facade tipi). Facade tipi kendisi sistemi içerisinde alt sistemi oluşturuyor ve onları ilgili operasyonda kullanıyor. Birden fala operasyona da sahip olabilir. Alt sistemdeki tipler hiçbir şekilde facade tipini referans etmezler, birbirlerine bağlı değildir. 



```C#
class Musteri
    {
        public int MusteriNumarasi { get; set; }
        public string TcNo { get; set; }
        public string Ad { get; set; }
    }

```

```Musteri``` Classında müşterinin bilgileri tutulur.



Client-> istemcidir. 

Facade -> istemcinin alt sisteme daha da kolay ulaşmasını sağlayan arayüz.

musteri-> kullanıcı bilgilerini bulundurur.

alt sistem (Kredi,Banka,MerkezBanka)-> istemciden gelen (facade yoluyla) işin yapılması için geeken ön şartların kontrolünü gerçekleştirir.




## Mediator Tasarım Deseni

-Mediator design pattern (aracı tasarım deseni), behavior grubununa ait, çalışmaları birbirleri ile aynı arayüzden türeyen nesnelerin durumlarına bağlı olan nesnelerin davranışlarını düzenleyen tasarım desenidir. Bazı durumlarda nesnelerin davranışları kendi türünden başka nesnelere bağlı olabilir. Mediator tasarım deseni birbirleri ile ilişkili olan bu nesneler arasında ki iletişimin ana bir nesne üzerinden (mediator) yapılmasını sağlar. Böylece nesneler arasındaki bağ zayıflatılır ve geliştirme aşamasında kod karmaşasını önler ve kodun yönetilmesini kolaylaştırır. 


![Image of Class](https://github.com/surasargut/YazilimMimarisiveTasarimi/blob/master/YazilimMimarisiveTasarimi/mediator_uml.png)


- Örneğin hava alanı kontrolünü düşünelim. Eğer uçaklar iniş, kalkış işlemleri için kule ile değil de birbirleri arasında direkt haberleşerek davransalar; bir uçak bir işlem yapacağı zaman ilgili bütün uçaklarla nasıl iletişime geçeceğini bilmesi ve iletişime geçmesi gerekirdi. Hava alanı kontrolünü mediator deseni ile düşünelim. İlk olarak uçaklar ve kule (aslında farklı hava alanları da olacağından kuleler) gereklidir ve bunların birbirleri ile nasıl iletişime geçeceklerini belirten operasyon tanımlamaları olması gereklidir. Kulenin gerçekleştireceği iniş – kalkış izni vermek gibi operasyonlar “Mediator” arayüzünü temsil eder ve kendisine bağlı olan nesnelerin yani uçakların bilgilerini kendi içinde tutar. Her bir kule de ConcreteMediator yapısına denk düşer ve kendisine bağlı olan uçaklar ile iletişime geçer. Uçakların gerçekleştireceği iniş – kalkış istemek gibi operasyonların tanımlanması ise “Colleague” arayüzünü temsil eder. Uçaklar ise “ConcreteColleague” yapısına denk düşer ve içinde ilgili “Mediator” tipinden nesneyi barındırır.


Bu senaryo üzerinden örnek bir uygulama geliştirelim. Uygulamamızın class diyagramı aşağıdaki gibi olur.


![Image of Class](https://github.com/surasargut/YazilimMimarisiveTasarimi/blob/master/YazilimMimarisiveTasarimi/mediatorUml.png)


```C#
//mediator yapısı
interface IKule
{
    
    void UcakKayit(AbsUcak _ucak);
    void InisIzniCevap(string UcusNo);
}
```
Mediatör yapısını bu arayüzde kullanıyoruz. İçerisinde Kulenin gerçekleştirmesi gereken operasyonları bulunduruyor.


```C#
 //Colleague yapısı
abstract class AbsUcak
{
    
    public IKule IliskiliKule { get; set; }
    public string UcusNo { get; set; }
    public bool InisIzni { get; set; }
    public void InisIzniIste()
    {
        IliskiliKule.InisIzniCevap(UcusNo);
    }
    public virtual void SetInisIzni(bool Izin)
    {
        InisIzni = Izin;
        if (InisIzni)
            Console.WriteLine("İniş izni verildi.");
        else
            Console.WriteLine("İniş izni red edildi.");
    }
}
```
Uçağın hangi kule ile irtibata geçmesi gerektiğini tutması gerekir. Bu yüzden ilk aşama olarak bu verileri alıyoruz. Daha sonraki ```InisIzniIste``` metodu uçağın bağlı olduğu kuleden iniş izni istiyor. Kule //kule iniş izni isteyen uçağa ```SetInisIzni``` metodu ile cevap verir.


```C#
 //ConcreteMediator yapısı
class EsenbogaKule : IKule
{
    private List<AbsUcak> _UcakListe = new List<AbsUcak>();
    public void UcakKayit(AbsUcak _ucak)
    {
        _UcakListe.Add(_ucak);
        _ucak.IliskiliKule = this;
    }
    public void InisIzniCevap(string UcusNo)
    {
        bool izin = true;
        if (_UcakListe.Where(u => u.InisIzni == true).Count() > 0)
            izin = false;
            
        _UcakListe.Where(u => u.UcusNo == UcusNo).Single().SetInisIzni(izin);
    }
}
```
Kule kendisine bağlı olan uçakların bilgisini tutmak zorunda, çünkü isteklere buna göre cevap verebilsin. ```private List<AbsUcak> _UcakListe = new List<AbsUcak>();``` metoduna tutacağız. ```_UcakListe.Add(_ucak);``` ile listeye eklenen AbsUcak nesnesine yöneticisinin hangi sınıf olduğunu bildiriyoruz. Daha sonrasında if bloğunda kontrol ettiğimiz şey eğer başka bir uçağa iniş izni verilmedi ise ilk izin isteyen uçağa izin veriyor. Ardından uçağın cevap alması için barındırdığı metoda cevap verilir.


```C#
//ConcreteColleague1
class ThyUcak : AbsUcak
{
    public override void SetInisIzni(bool Izin)
    {
        Console.WriteLine("Thy Uçuş No:{0} iniş izni istiyor...", UcusNo );
        base.SetInisIzni(Izin);
    }
}
```
```InisIzniIste``` metotu ```AbsUcak abstract``` sınıfından gelir. Kule cevabı ```SetInisIzni``` metodu ile verir. UsaUcak classı için de işlemler ThyUcak classındakiyle aynıdır.




mediator tasarım deseninde 4 temel yapı bulunur.

Mediator--> Nesneler arasındaki ilişkiyi sağlayacak metotların tanımlı olduğu arayüz.

ConcreteMediator--> Nesneler arasındaki ilişkiyi sağlayacak gerçek nesnedir. Mediator arayüzünü uygular. İçinde Colleague ara yüzünden türeyen nesnelerin listesini barındırır.

Colleague--> ConcreteMediator u kullanarak işlem gerçekleştirecek olan nesnelerin uygulaması gereken arayüzü temsil eder. Kendi içinde ConcreteMediator nesnesi barındırır.

ConcreteColleague--> ConcreteMediator üzerinden birbirleri ile ilişkili nesnelerdir. Colleague arayüzünü uygularlar.




