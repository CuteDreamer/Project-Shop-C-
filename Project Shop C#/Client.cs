using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Shop_C_
{
    internal class Client : IUser
    {
        double money = 500;
        double totalBill = 0;
        private Basket basket;

        public Client()
        {
            this.basket = new Basket();
        }

        private void CalculateBill()
        {
            foreach (var item in basket.Products)
            {
                totalBill += item.Key.Price * item.Value;
            }
        }

        private void AddToOrder(Store store)
        {
            Console.WriteLine("Введите имя продукта: ");
            var selected = Console.ReadLine();
            Console.WriteLine("Введите количество: ");
            int quantity = Convert.ToInt32(Console.ReadLine());
            var product = store.ProductList.Find(p => p.Name == selected);
            if (quantity > product.GetQuantity())
            {
                Console.WriteLine($"Недостаточно {product.Name} в магазине. Нажмите любую кнопку, чтобы продолжить");
                Console.ReadKey();

                return;
            }
            if (product == null)
            {
                Console.WriteLine("Продукта не существует. Нажмите любую конпку, чтобы продолжить");
                Console.ReadKey();
                return;
            }
            product.SetQuantity(product.GetQuantity() - quantity);
            var currentQuantity = 0;
            if (basket.Products.ContainsKey(product))
            {
                currentQuantity = basket.Products[product];
            }
            basket.AddToBasket(product, currentQuantity + quantity);
        }

        private void RemoveFromOrder(Store store)
        {
            Console.WriteLine("Введите имя продукта, чтобы удалить его: ");
            var selected = Console.ReadLine();
            var product = store.ProductList.Find(p => p.Name == selected);
            if (product == null)
            {
                Console.WriteLine("Продукта не существует. Нажмите любую конпку, чтобы продолжить");
                Console.ReadKey();
                return;
            }
            product.SetQuantity(product.GetQuantity() + basket.Products[product]);
            basket.RemoveFromBasket(product);
        }

        private void Pay()
        {
            Console.WriteLine($"Ваш баланс: {money} $");
            Console.WriteLine($"Сумма заказа: {totalBill}");
            Console.WriteLine("Готовы оплатить? (y/n)");
            var action = Console.ReadLine();

            if (action == "y")
            {
                if (money > totalBill)
                {
                    money -= totalBill;
                    Console.WriteLine("Поздравляем с покупкой!!");
                    Console.WriteLine($"Ваш текщий баланс: {money}");
                    basket.Products.Clear();
                }
                else
                {
                    Console.WriteLine($"Сумма к оплате {totalBill} больше чем сумма на вашем счету!");
                    return;
                }
            }
        }
        private void EditBasket(Store store)
        {
            var active = "y";
            while (active != "n")
            {
                SayToClient.AskClient();
                Console.WriteLine($"Ваш баланс: {money}");
                store.ShowStore();
                basket.ShowBasket();
                Console.WriteLine("Выберите действие:");
                int select = Convert.ToInt32(Console.ReadLine());
                switch (select)
                {
                    case 1:
                        AddToOrder(store);
                        break;
                    case 2:
                        RemoveFromOrder(store);
                        break;
                    case 3:
                        Pay();
                        break;
                    case 4:
                        active = "n";
                        break;
                    default:
                        break;
                }
                CalculateBill();
            }
        }

        public void Start(Store store)
        {
            EditBasket(store);
        }
    }
}
