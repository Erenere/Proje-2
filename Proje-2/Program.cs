using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Proje_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Kart kart1 = new Kart("Baslik1", "Icerik1", 1,KartBuyukluk.S);
            Kart kart2 = new Kart("Baslik2", "Icerik2", 2,KartBuyukluk.M);
            Kart kart3 = new Kart("Baslik3", "Icerik3", 4,KartBuyukluk.L);
            Board board1 = new Board();
            board1.KartEkle(kart1);
            board1.KartEkle(kart2);
            board1.KartEkle(kart3);

            board1.BoardAcilis();
            Console.WriteLine("**************\n");
            board1.BoardListele();
            Console.WriteLine("**************\n");
            board1.KartTasi();
            Console.WriteLine("**************\n");
            board1.KartSil();
            Console.WriteLine("**************\n");
            board1.BoardListele();
        }
    }

    static class Team
    {
        public static List<Kisi> team;

         static Team()
         {
             team = new List<Kisi>(new Kisi[]
             {
                 new Kisi("kisi1", 1), new Kisi("kisi2", 2), new Kisi("kisi3", 3),
                 new Kisi("kisi4", 4), new Kisi("kisi5", 5), new Kisi("kisi6", 6),
                 new Kisi("kisi7", 7), new Kisi("kisi8", 8), new Kisi("kisi9", 9)
             });
         }
    }
}