using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Project_Shop_C_
{
    class Store
    {
        public List<Product> ProductList { get; }

        [JsonConstructor]
        public Store(List<Product> productList)
        {
            this.ProductList = productList;
        }
        public Store()
        {
            ProductList = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            ProductList.Add(product);
            Console.WriteLine($"Продукт '{product.GetName()}' добавлен в магазин.");
        }

        private void SortStore()
        {
            ProductList.OrderBy(p => p.GetCategory());
        }
        public void ShowStore()
        {
            SortStore();
            Console.WriteLine("Ассортимент: ");
            foreach (var item in ProductList)
            {
                Console.WriteLine("\t" + item.ToString());
            }

        }
    }
}
