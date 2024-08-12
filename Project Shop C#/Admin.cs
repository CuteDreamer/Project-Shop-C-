using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Project_Shop_C_
{
    internal class Admin : IUser
    {

        public Admin()
        {
        }

        private Product CreateProduct()
        {
            Console.WriteLine("Введите название товара: ");
            string name = Console.ReadLine();
            Console.WriteLine("Введите цену товара: ");
            double price = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите доступное количество: ");
            double quantity = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите название категории (Фрукты, Овощи, Мясо, Другое): ");
            string category = Console.ReadLine();
            return new Product(name, price, quantity, category);
        }

        private void EditProduct(Store store)
        {
            Product product = SelectProduct(store);
            Console.WriteLine(product);
            
            Console.WriteLine("Введите цену товара: ");
            double price = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите доступное количество: ");
            double quantity = Convert.ToDouble(Console.ReadLine());
            product.SetPrice(price);
            product.SetQuantity(quantity);
        }
        private void DeleteProduct(Store store)
        {
            Product product = SelectProduct(store);
            store.ProductList.Remove(product);
        }
        private Product SelectProduct(Store store)
        {
            Console.WriteLine("Какой товар вы хотите изменить?: ");
            string productname = Console.ReadLine();
            return store.ProductList.Find(p => p.GetName() == productname);

        }
        private void EditStore(Store store)
        {
            string active = "y";
            while (active != "n")
            {
                SayToClient.AskAdmin();

                store.ShowStore();

                int select = Convert.ToInt32(Console.ReadLine());
                switch (select)
                {
                    case 1:
                        store.AddProduct(CreateProduct());
                        break;
                    case 2:
                        EditProduct(store);
                        break;
                    case 3:
                        DeleteProduct(store);
                        break;
                    case 4:
                        active = "n";
                        break;
                    default:
                        break;
                }
                ProductFile.SaveToJson("Products.json", store);
            }
        }

        public void Start(Store store)
        {
            EditStore(store);
        }
    }
}


