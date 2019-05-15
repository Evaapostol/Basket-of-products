using System;

namespace Basket_Of_Products
{
    class Program
    {
        static void Main(string[] args)
        {
            Basket bskt = new Basket();
            bskt.FillWithDummyData();
            Console.WriteLine("give the name of the new file");
            string filename = Console.ReadLine();
            Console.WriteLine("give the name of the new file");
            string filenameText = Console.ReadLine();
            bskt.Savexcel(filename);
            bskt.LoadExcel(filename);
            bskt.SaveText(filename);
            bskt.LoadText(filename);
            bskt.PrintList();
            bskt.SaveJson();
            bskt.LoadJson();

        }
    }
}
