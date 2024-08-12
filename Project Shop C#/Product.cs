using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Project_Shop_C_
{
    class Product
    {
        protected string name;
        protected double price;
        protected double quantity;
        protected string category;

        public string Name => name;
        public double Price => price;
        public double Quantity => quantity;
        public string Category => category;

        [JsonConstructor]
        public Product(string name, double price, double quantity, string category)
        {
            this.name = name;
            this.price = price;
            this.quantity = quantity;
            this.category = category;
        }
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

        public string GetCategory()
        {
            return category;
        }
        public void SetPrice(double price)
        {
            this.price = price;
        }
        public void SetQuantity(double quantity)
        {
            this.quantity=quantity;
        }

        public override string ToString()
        {
            return $"Название: {name} Цена: {price} Количество: {quantity} Категория: {category}";
        }


    }
}
