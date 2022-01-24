using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Araba_Satis
{
  public  class Car
    {
        public string Brand { get; set; }            //Marka model renk yıl fiyat ve id get set property olarak tanımlıyoruz
        public string Model { get; set; }
        public string Colour { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }

        public int Id
        {
            get; set;
        }


        public Car(int id, string brand, string model, string colour, int year, decimal price)   //car methodu.
        {

            Id = id;
            Brand = brand;
            Model = model;
            Colour = colour;
            Year = year;
            Price = price;

        }
   
        override public string ToString()   //yazdırma metodu
        {
            return "ID : " + " " + Id + "|" + "Marka : " + " " + Brand + "|" + "Model: " + " " + Model + "|" + "Renk : " + " " + Colour + "|" + "Yıl: " + " " + Year + "|" + "Fiyat: " + Price.ToString("C") + " " + " ";
        }
    }
}
