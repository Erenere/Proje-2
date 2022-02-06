using System;
using System.Collections.Generic;
using System.Linq;

namespace Proje_2
{
    public class Board
    {
        public List<Kart> TODOLine;
        public List<Kart> InProgressLine;
        public List<Kart> DoneLine;

        public Board()
        {
            this.TODOLine = new List<Kart>();
            this.InProgressLine = new List<Kart>();
            this.DoneLine = new List<Kart>();
        }

        public void BoardAcilis()
        {
            Console.WriteLine(@"Lütfen yapmak istediğiniz işlemi seçiniz :) 
                *******************************************
                (1) Board Listelemek
                (2) Board'a Kart Eklemek
                (3) Board'dan Kart Silmek
                (4) Kart Taşımak");
            int input = Int32.Parse(Console.ReadLine());
            if(input==1)
                this.BoardListele();
            else if(input==2)
                this.KartEkle();
            else if(input==3)
                this.KartSil();
            else if(input==4)
                this.BoardListele();
            else
                Console.WriteLine("Geçersiz giriş. ");
            
        }
        public void BoardListele()
        {
            Console.WriteLine("TODO Line");
            Console.WriteLine("*************");
            TODOLine.ForEach(k =>
            {
                Console.WriteLine("Baslik   : {0}",k.Baslik);
                Console.WriteLine("Icerik   : {0}",k.Icerik);
                Console.WriteLine("Atanan Kişi   : {0}",k.ID);
                Console.WriteLine("Buyukluk   : {0}",k.Buyukluk);
                Console.WriteLine("-");
            });
            if(TODOLine.Count==0)
                Console.WriteLine("~ BOŞ ~");
            
            Console.WriteLine("InProgress Line");
            Console.WriteLine("*************");
            InProgressLine.ForEach(k =>
            {
                Console.WriteLine("Baslik   : {0}",k.Baslik);
                Console.WriteLine("Icerik   : {0}",k.Icerik);
                Console.WriteLine("Atanan Kişi   : {0}",k.ID);
                Console.WriteLine("Buyukluk   : {0}",k.Buyukluk);
                Console.WriteLine("-");
            });
            if(InProgressLine.Count==0)
                Console.WriteLine("~ BOŞ ~");
            
            Console.WriteLine("Done Line");
            Console.WriteLine("*************");
            DoneLine.ForEach(k =>
            {
                Console.WriteLine("Baslik   : {0}",k.Baslik);
                Console.WriteLine("Icerik   : {0}",k.Icerik);
                Console.WriteLine("Atanan Kişi   : {0}",k.ID);
                Console.WriteLine("Buyukluk   : {0}",k.Buyukluk);
                Console.WriteLine("-");
            });
            if(DoneLine.Count==0)
                Console.WriteLine("~ BOŞ ~");
        }

        public void KartEkle()
        {
            Console.Write("Baslik Giriniz   : ");
            string baslik1 = Console.ReadLine();
            Console.Write("Icerik Girin     : ");
            string icerik1 = Console.ReadLine();
            Console.Write("Büyüklük Seçiniz -> XS(1),S(2),M(3),L(4),XL(5)  :");
            KartBuyukluk kb = (KartBuyukluk)Enum.Parse(typeof(KartBuyukluk),Console.ReadLine());
            Console.WriteLine("Kisi seciniz     : ");
            long id = long.Parse(Console.ReadLine());
            var member = Team.team.Find(member => member.ID == id);
            if (member == null)
            {
                Console.WriteLine("Takim uyesi bulunamadı");
            }
            else
            {
                TODOLine.Add(new Kart(baslik1,icerik1,id,kb));
            }
        }
        
        public void KartEkle(Kart kart)
        {
            TODOLine.Add(kart);
        }

        public void KartSil()
        {
            int sayi = 2;
            while (sayi == 2)
            {
                Console.WriteLine( @"Öncelikle silmek istediğiniz kartı seçmeniz gerekiyor.
                                Lütfen kart başlığını yazınız: " );
                string baslik = Console.ReadLine();
                Kart kart = TODOLine.Find(kart => kart.Baslik == baslik);
                if (kart != null)
                {
                    TODOLine.Remove(kart);
                }
                else
                {
                    kart = InProgressLine.Find(k => k.Baslik == baslik);
                    if (kart != null)
                    {
                        InProgressLine.Remove(kart);
                    }
                    else
                    {
                        kart = DoneLine.Find(k => k.Baslik == baslik);
                        if (kart != null)
                        {
                            DoneLine.Remove(kart);
                        }
                    }
                }

                if (kart == null)
                {
                    Console.WriteLine( @"Aradığınız krtiterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.
                                        * Silmeyi sonlandırmak için : (1)
                                        * Yeniden denemek için : (2)");
                    sayi = Int32.Parse(Console.ReadLine());
                }
            }
            
        }

        public void KartTasi()
        {
            int deneme = 2;
            string line = "";
            while (deneme == 2 && deneme != 1)
            {
                Console.WriteLine(@"Öncelikle silmek istediğiniz kartı seçmeniz gerekiyor.
                Lütfen kart başlığını yazınız:  ");
                string baslik = Console.ReadLine();
                Kart kart = TODOLine.Find(k => k.Baslik == baslik);

                if (kart != null)
                    line = "TODO";
                else
                {
                    kart = InProgressLine.Find(k => k.Baslik == baslik);
                    if (kart != null)
                        line = "InProgress";
                    else
                    {
                        kart = DoneLine.Find(k => k.Baslik == baslik);
                        if (kart != null)
                            line = "Done";
                    }
                }

                if (line == "TODO")
                {
                    Console.WriteLine(@"Bulunan Kart Bilgileri:
                    **************************************
                        Başlık      :{0}
            İçerik      :{1}
            Atanan Kişi :{2}
            Büyüklük    :{3}
            Line        :{4}", kart.Baslik, kart.Icerik, kart.ID, kart.Buyukluk, "TODO Line");
                    Console.WriteLine(@"Lütfen taşımak istediğiniz Line'ı seçiniz: 
                    (1) TODO
                    (2) IN PROGRESS
                    (3) DONE");

                    int input = Int32.Parse(Console.ReadLine());
                    if (input == 1)
                    {
                        BoardListele();
                    }
                    else if (input == 2)
                    {
                        TODOLine.Remove(kart);
                        InProgressLine.Add(kart);
                        BoardListele();
                    }
                    else if (input == 3)
                    {
                        TODOLine.Remove(kart);
                        DoneLine.Add(kart);
                        BoardListele();
                    }
                    else
                        Console.WriteLine("Hatalı seçim yaptınız");

                    deneme = 1;
                }

                else if (line == "InProgress")
                {
                    Console.WriteLine(@"Bulunan Kart Bilgileri:
                                    **************************************
                                        Başlık      :{0}
                            İçerik      :{1}
                            Atanan Kişi :{2}
                            Büyüklük    :{3}
                            Line        :{4}", kart.Baslik, kart.Icerik, kart.ID, kart.Buyukluk, "In Progress Line");

                    Console.WriteLine(@"Lütfen taşımak istediğiniz Line'ı seçiniz: 
                    (1) TODO
                        (2) IN PROGRESS
                        (3) DONE");
                    int input = Int32.Parse(Console.ReadLine());

                    if (input == 1)
                    {
                        InProgressLine.Remove(kart);
                        TODOLine.Add(kart);
                        BoardListele();
                    }
                    else if (input == 2)
                    {
                        BoardListele();
                    }
                    else if (input == 3)
                    {
                        InProgressLine.Remove(kart);
                        DoneLine.Add(kart);
                        BoardListele();
                    }
                    else
                        Console.WriteLine("Hatalı seçim yaptınız");

                    deneme = 1;
                }

                else if (line == "Done")
                {
                    Console.WriteLine(@"Bulunan Kart Bilgileri:
                                    **************************************
                                        Başlık      :{0}
                            İçerik      :{1}
                            Atanan Kişi :{2}
                            Büyüklük    :{3}
                            Line        :{4}", kart.Baslik, kart.Icerik, kart.ID, kart.Buyukluk, "Done Line");
                    Console.WriteLine(@"Lütfen taşımak istediğiniz Line'ı seçiniz: 
                    (1) TODO
                        (2) IN PROGRESS
                        (3) DONE");
                    int input = Int32.Parse(Console.ReadLine());

                    if (input == 1)
                    {
                        DoneLine.Remove(kart);
                        TODOLine.Add(kart);
                        BoardListele();
                    }
                    else if (input == 2)
                    {
                        DoneLine.Remove(kart);
                        InProgressLine.Add(kart);
                        BoardListele();
                    }
                    else if (input == 3)
                    {
                        BoardListele();
                    }
                    else
                        Console.WriteLine("Hatalı seçim yaptınız");

                    deneme = 1;
                }

                else
                {
                    Console.WriteLine(@"Aradığınız krtiterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.
                    * İşlemi sonlandırmak için : (1)
                * Yeniden denemek için : (2)");
                    deneme = Int32.Parse(Console.ReadLine());

                    if (deneme == 1)
                        break;
                    else if (deneme == 2)
                        continue;
                    else
                        Console.WriteLine("Yanlis giris.");
                }
            }
        }
    }
}