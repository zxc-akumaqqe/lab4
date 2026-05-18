using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineClothingStore
{
    class ProductItem
    {
        private readonly string code;
        private string name;
        private decimal price;
        private static int count = 0;
        public ProductItem(string code, string name, decimal price)
        {
            this.code = code;
            this.name = name;
            this.price = price;
            count++;
            Console.WriteLine($"Создан товар: {name} (код: {code})");
        }
        public string Code => code;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }
        public static int GetCount()
        {
            return count;
        }
        public virtual string GetInfo()
        {
            return $"Код: {code}, Назва: {name}, Ціна: {price:C}";
        }
        public bool IsPremium()
        {
            return price > 3000;
        }
    }
    class TShirt : ProductItem
    {
        private string size;
        public TShirt(string code, string name, decimal price, string size)
            : base(code, name, price)
        {
            this.size = size;
        }
        public string Size
        {
            get { return size; }
            set { size = value; }
        }
        public override string GetInfo()
        {
            return base.GetInfo() + $", Розмір: {size}";
        }
    }
    class Shoes : ProductItem
    {
        private double size;
        private string type;
        public Shoes(string code, string name, decimal price, double size, string type)
            : base(code, name, price)
        {
            this.size = size;
            this.type = type;
        }
        public double Size
        {
            get { return size; }
            set { size = value; }
        }
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public override string GetInfo()
        {
            return base.GetInfo() + $", Розмір: {size}, Тип: {type}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<ProductItem> products = new List<ProductItem>
            {
                new TShirt("TS001", "Футболка з принтом", 1200m, "L"),
                new Shoes("SH001", "Кросівки Nike", 4500m, 42, "Кросівки"),
                new TShirt("TS002", "Футболка базова", 800m, "M"),
                new Shoes("SH002", "Черевики зимові", 6500m, 43, "Черевики")
            };
            Console.WriteLine("Інформація про товари:");
            decimal totalPrice = 0;
            int premiumCount = 0;
            foreach (var item in products)
            {
                Console.WriteLine(item.GetInfo());
                totalPrice += item.Price;
                if (item.IsPremium())
                {
                    premiumCount++;
                }
            }
            Console.WriteLine($"\nЗагальна кількість товарів: {ProductItem.GetCount()}");
            Console.WriteLine($"Загальна сума цін: {totalPrice:C}");
            Console.WriteLine($"Кількість преміум товарів: {premiumCount}");
            Console.WriteLine("Натисніть будь-яку клавішу для виходу...");
            Console.ReadKey();
        }
    }
}