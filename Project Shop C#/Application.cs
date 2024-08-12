using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Shop_C_
{
    static class Application
    {
        private static Store store;
        private static IUser user;
        static Application()
        {
           store = ProductFile.LoadFromJson("Products.json");
        }

        public static void Run()
        {
            string run = "N";
            string togo = "";

            while (run != "y")
            {
                SayToClient.GreetUser();
                togo = SayToClient.ToContinue();
                if (togo == "admin")
                {
                    user = new Admin();
                }
                else
                {
                    user = new Client();
                }

                user.Start(store);

                Console.WriteLine("Выйти из магазина? (y/n)");
                run = Console.ReadLine();

            }
        }

    }
}
