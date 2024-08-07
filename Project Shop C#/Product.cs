using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Shop_C_
{
    abstract class Product
    {
        protected string name;
        protected double price;
        protected double quantity;

        public string GetName()
        {
            return name;
        }

        public double GetPrice()
        {
            return price;
        }

        public double GetQuantity()
        {
            return quantity;
        }
    }
    class Fruits : Product
    {
        public Fruits(string name, double price, double quantity)
        {
            this.name = name;
            this.price = price;
            this.quantity = quantity;
        }
        public List<Fruits> FruitList { get; private set; } = new List<Fruits>();
    }
    class Vegetables : Product
    {
        public Vegetables(string name, double price, double quantity)
        {
            this.name = name;
            this.price = price;
            this.quantity = quantity;
        }
        public List<Vegetables> VegetablesList { get; private set; } = new List<Vegetables>();
    }

    class Meat : Product
    {
        public Meat(string name, double price, double quantity)
        {
            this.name = name;
            this.price = price;
            this.quantity = quantity;
        }
        public List<Meat> MeatList { get; private set; } = new List<Meat>();
    }

    class Other : Product
    {
        public Other(string name, double price, double quantity)
        {
            this.name = name;
            this.price = price;
            this.quantity = quantity;
        }
        public List<Other> OtherList { get; private set; } = new List<Other>();
    }

    class Basket
    {
        private List<Product> products;
        public Basket()
        {
            products = new List<Product>();
        }

        public void AddToBasket(Product product)
        {
            products.Add(product);
            Console.WriteLine($"Продукт '{product.GetName()}' добавлен в корзину.");
        }


        public void DisplayBasketContents()
        {
            Console.WriteLine("Содержимое корзины:");
            foreach (var product in products)
            {
                Console.WriteLine($"- {product.GetName()} (Цена: {product.GetPrice():C}, Количество: {product.GetQuantity()})");
            }
        }

        public void RemoveFromBasket(string productname)
        {
            var productremove = products.FirstOrDefault(p => p.GetName() == productname);
            if (productremove != null)
            {
                products.Remove(productremove);
                Console.WriteLine($"Продукт '{productname}' удалён из корзины.");
            }
            else
            {
                Console.WriteLine($"Продукт '{productname}' не найден в корзине.");
            }
        }
        public double CalculateTotalCost()
        {
            double totalcost = 0;
            foreach (var product in products)
            {
                totalcost += product.GetPrice() * product.GetQuantity();
            }
            return totalcost;
        }

    }

    class SayHello
    {
        public void GreetUser()
        {
            Console.WriteLine("Добро пожаловать в наш магазин!");
            Console.WriteLine("Чем могу помочь? Посмотрите наши товары!");
        }
    }

    class SayGoodbye
    {
        public void Farewell()
        {
            Console.WriteLine("Спасибо за визит! Хорошего дня!");
        }
    }


    class ShowAssort
    {
        public void DisplayAllProducts(Fruits fruits, Vegetables vegetables, Meat meat, Other other)
        {
            Console.WriteLine("Ассортимент магазина:");

            // Вывод фруктов
            Console.WriteLine("Фрукты:");
            foreach (var fruit in fruits.FruitList)
            {
                Console.WriteLine($"- {fruit.GetName()} (Цена: {fruit.GetPrice():C}, Количество: {fruit.GetQuantity()})");
            }

            // Вывод овощей
            Console.WriteLine("Овощи:");
            foreach (var vegetable in vegetables.VegetablesList)
            {
                Console.WriteLine($"- {vegetable.GetName()} (Цена: {vegetable.GetPrice():C}, Количество: {vegetable.GetQuantity()})");
            }

            // Вывод мяса
            Console.WriteLine("Мясо:");
            foreach (var meatitem in meat.MeatList)
            {
                Console.WriteLine($"- {meatitem.GetName()} (Цена: {meatitem.GetPrice():C}, Количество: {meatitem.GetQuantity()})");
            }

            // Вывод других продуктов
            Console.WriteLine("Другие товары:");
            foreach (var otheritem in other.OtherList)
            {
                Console.WriteLine($"- {otheritem.GetName()} (Цена: {otheritem.GetPrice():C}, Количество: {otheritem.GetQuantity()})");
            }
        }
    }

    class Client
    {
        private int money;


    }

    class Program
    {
        static void Main(string[] args)
        {
            // Создаем экземпляры продуктов
            var apple = new Fruits("Apple", 1.99, 5);
            var carrot = new Vegetables("Carrot", 0.79, 3);

            // Создаем корзину и добавляем продукты
            var basket = new Basket();
            basket.AddToBasket(apple);
            basket.AddToBasket(carrot);

            // Отображаем содержимое корзины
            basket.DisplayBasketContents();

            // Рассчитываем общую стоимость
            double totalсost = basket.CalculateTotalCost();
            Console.WriteLine($"Общая стоимость: {totalсost:C}");
        }
    }
}
