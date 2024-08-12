using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Shop_C_
{
    static class SayToClient
    {
        public static void Farewell()
        {
            Console.Clear();
            Console.WriteLine("Спасибо за визит! Хорошего дня!");
        }

        public static void GreetUser()
        {
            Console.Clear();
            Console.WriteLine("Добро пожаловать в наш магазин!");
            Console.WriteLine("Чем могу помочь? Посмотрите наши товары!");
        }
        public static string ToContinue()
        {
            Console.WriteLine("Хотите ли вы продолжить? Y/N");
            return Console.ReadLine();
        }

        public static void AskAdmin()
        {
            Console.Clear();
            Console.WriteLine("Добро пожаловать в режим администратора!!");
            Console.WriteLine("1. Добавить новый продукт");
            Console.WriteLine("2. Редактировать продукт");
            Console.WriteLine("3. Удалить продукт");
            Console.WriteLine("4. Выход");
            
        }



        public static void AskClient()
        {
            Console.Clear();
            Console.WriteLine("Добро пожаловать в наш магазин.\nПожалуйста, выберите действие: ");
            Console.WriteLine("1. Добавить продукт в корзину.");
            Console.WriteLine("2. Удалить продукт из корзины.");
            Console.WriteLine("3. Оплатить заказ.");

            Console.WriteLine("4. Выйти.");
        }
    }
}
