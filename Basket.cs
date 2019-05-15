using Newtonsoft.Json;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Basket_Of_Products
{
    public class Basket
    {
        public List<Product> products = new List<Product>();

        public void FillWithDummyData()
        {
            products.Add(new Product(12, "Sugar", 15, 1));
            products.Add(new Product(24, "Coffee", 29, 2));
            products.Add(new Product(89, "Salt", 18, 1));
        }

        public bool LoadExcel(string NewFileName)
        {
            products.Clear();
            XSSFWorkbook hssfwb;
            using (FileStream file = new FileStream
                ($@"C:\Users\Admin\source\repos\Basket Of Products\Basket Of Products\bin\Debug\netcoreapp2.1\{NewFileName}.xlsx", FileMode.Open, FileAccess.Read))
            {
                hssfwb = new XSSFWorkbook(file);
            }
            ISheet sheet = hssfwb.GetSheet("Sheet");
            for (int row = 1; row <= sheet.LastRowNum; row++)
            {

                if (sheet.GetRow(row) != null)
                {
                    double id = sheet.GetRow(row).GetCell(0).NumericCellValue;
                    int id1 = Convert.ToInt32(id);
                    string name = sheet.GetRow(row).GetCell(1).StringCellValue;
                    double price = sheet.GetRow(row).GetCell(2).NumericCellValue;
                    double category = sheet.GetRow(row).GetCell(3).NumericCellValue;
                    int category1 = Convert.ToInt32(category);
                    products.Add(new Product(id1, name, price, category1));
                }
            }
            return true;
        }

        public bool Savexcel(string NewFileName)
        {
            XSSFWorkbook wb = new XSSFWorkbook();
            ISheet sheet = wb.CreateSheet("Sheet");
           
            int x = 0;
            var r1 = sheet.CreateRow(0);
            r1.CreateCell(0).SetCellValue("Id");
            r1.CreateCell(1).SetCellValue("Name");
            r1.CreateCell(2).SetCellValue("Price");
            r1.CreateCell(3).SetCellValue("Category");

            foreach (Product p in products)
            {
                x++;
                var r = sheet.CreateRow(x);
                r.CreateCell(0).SetCellValue(products[x - 1].Id);
                r.CreateCell(1).SetCellValue(products[x - 1].Name);
                r.CreateCell(2).SetCellValue(products[x - 1].Price);
                r.CreateCell(3).SetCellValue(products[x - 1].Category);
            }

            using (var fs = new FileStream($"{NewFileName}.xlsx", FileMode.Create,
            FileAccess.Write))
            {
                wb.Write(fs);
            }
            return true;
        }

        public void PrintList()
        {
            foreach (Product p in products)
            {
                Console.WriteLine(p.ToString());
                Console.WriteLine("---------------------");
            }
        }

        public bool LoadText(string filenameofText)
        {
            try
            {
                var myList = new List<String>();
                var fileStream = new FileStream($@"C:\Users\Admin\source\repos\Basket Of Products\Basket Of Products\bin\Debug\netcoreapp2.1\{filenameofText}",
                    FileMode.Open, FileAccess.Read);
                using (var streamReader = new System.IO.StreamReader(fileStream, Encoding.UTF8))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        myList.Add(line);
                    }
                }

                foreach (String l in myList)
                {
                    Console.WriteLine("----------------");
                    Console.WriteLine(l);
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
        
        public bool SaveText(string filenameofText)
        {
            using (StreamWriter file = new StreamWriter($@"C:\Users\Admin\source\repos\Basket Of Products\Basket Of Products\bin\Debug\netcoreapp2.1\{filenameofText}"))
            {
                foreach (Product p in products)
                {
                    file.WriteLine(p);
                }
            }
            return true;
        }

        public void SaveJson()
        {
            string jsonData = JsonConvert.SerializeObject(products, Formatting.None);
            File.WriteAllText($@"C:\Users\Admin\source\repos\Basket Of Products\Basket Of Products\bin\Debug\netcoreapp2.1\BasketToJson.json", jsonData);
        }

        public void LoadJson()
        {
            string data = File.ReadAllText($@"C:\Users\Admin\source\repos\Basket Of Products\Basket Of Products\bin\Debug\netcoreapp2.1\BasketToJson.json");
            var tempProducts = JsonConvert.DeserializeObject<List<Product>>(data);

            foreach (Product p in tempProducts)
            {
                products.Add(p);
            }
        }
    }
}

