using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Shop_C_
{
    internal class Basket
    {
        private Dictionary<Product, int> products;
        public Dictionary<Product, int> Products { get => products; } 

        public Basket()
        {
            products = new Dictionary<Product, int>();
        }

        public void AddToBasket(Product product,  int quantity)
        {
            products[product] = quantity;
        }

        public void RemoveFromBasket(Product product)
        {
            products.Remove(product);
        }

        public void ShowBasket()
        {
            Console.WriteLine("Корзина:");
            foreach (var item in products)
            {
                Console.WriteLine($"\tИмя: {item.Key.Name} Цена: {item.Key.Price} Количество: {item.Value}");
            }
        }
    }
}
