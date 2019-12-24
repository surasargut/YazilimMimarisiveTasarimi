using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    class Facade // bu tasarım deseeni alt sistemin tiplerinin içerir 
    {
        private Banka _banka;
        private MerkezBanka _merkezBanka;
        private Kredi _kredi;
    
        public Facade()
        {   //instansları örnkeliyoruz
            _banka = new Banka();
            _merkezBanka = new MerkezBanka();
            _kredi = new Kredi();
        }
        //bu facade tipi üzeirnde istemciye sunacağımız şey istemcinin bizden talep edeceği fonksiyonellik olmalı
        public void KrediKullan(Musteri m, decimal talep) //musteri datasını vereceğiz parametre olaral talep dilen miktar verileccek
        //bu facade tipi kullanmakta olduğu alt sistemin gerekli olan uygulama tiplerini ele alacak  
        {
            if (!_merkezBanka.KaraListeKontrol(m.TcNo) // o anki musterinin tc sini gönder -> geçtiyse
                && _kredi.KrediKullanmaDurumu(m)) // kredi kullanma durumu pozitifse     
            {
                _banka.KrediyiKullan(m, talep);
                Console.WriteLine("Kredi kullandiirldi.");
            }
        }
    }

}
