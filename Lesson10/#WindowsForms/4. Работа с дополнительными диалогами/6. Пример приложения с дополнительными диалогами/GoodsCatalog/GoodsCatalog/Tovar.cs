using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace GoodsCatalog 
{
    public class Tovar 
    {
        string name; //название товара
        string made_in; //страна-производитель
        double price;//цена

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        
        public string Made_in
        {
            get { return made_in; }
            set { made_in = value; }
        }
        
        public double Price
        {
            get { return price; }
            set { 
                if(price<0) 
                throw new System.Exception("Цена не может быть меньше нуля");
                price = value; 
                }
        }
        public Tovar()
        {
            Name = "unknown";
            Price = 0;
            Made_in = "unknown";
        }
        public Tovar(string name, string made, double price)
        {
            Name = name; 
            Made_in = made; 
            Price = price;
        }
        public override string ToString()
        {
            return Name + " Изготовитель: " + Made_in + " Цена: " + Price;
        }

              
    }
}
