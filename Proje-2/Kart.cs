using System;

namespace Proje_2
{
    public class Kart
    {
        public string Baslik;
        public string Icerik;
        public long ID;
        public KartBuyukluk Buyukluk;

        public Kart(string baslik, string icerik,long id, KartBuyukluk buyukluk)
        {
            Baslik = baslik;
            Icerik = icerik;
            if (Team.team.Find(m => m.ID == id) != null)
            {
                ID = id;
            }
            else
            {
                Console.WriteLine("Bu ID'ye sahip kisi bulunamadı");
            }
            Buyukluk = buyukluk;
        }
    }
}