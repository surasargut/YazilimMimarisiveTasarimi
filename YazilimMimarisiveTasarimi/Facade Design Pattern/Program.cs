using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            //istemci olduğunu varsayıyoruz
            //istemci uygulama kredi kullanma operasyonu için gereken alt sisteme doğrudan erişmiyor, onun yerine bu alt sisttemin kullanımını kendiis kolaylaştıran bir arayüzle çıkyıor.(Facade tipi)
            /// facade tipi kendisi sistemi içerisinde slt sistemi oluşturuyor ve onları ilgili operasyonda kullanıyor.
            // briden fala operasyona da sahip olabilir.
            // alt sistemdeki tipler hiçbir şekilde facade tipini referaasn etmezler, birbirlerine bağlı değildir.    
            Facade fcd = new Facade();
            fcd.KrediKullan(new Musteri { Ad = "Sura ", TcNo = "344543", MusteriNumarasi = 1001 }, 1000);
        }
    }
}
