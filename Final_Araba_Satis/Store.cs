using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace Final_Araba_Satis
{
    public class Store
    {
        public List<Car> CarCatalogue { get; set; } // arabaları tutmak için bir list property kullanacagız 
        public List<Car> Cart { get; set; } //ve sepetimizdeki arabaları tutmak içinde bir list'e ihtiyacımız var

        public Store()
        {

            CarCatalogue = new List<Car>();
            Cart = new List<Car>();
            Car car1 = new Car(1, "Ford", "Mustang", "siyah", 2000, 100000); //bir kaç örnek araba ekleyelim.
            CarCatalogue.Add(car1);
            Car car2 = new Car(2, "Nissan", "Sentra", "Mavi", 2005, 300000);
            CarCatalogue.Add(car2);
            Car car3 = new Car(3, "Mercedes", "Benz", "siyah", 2000, 400000);
            CarCatalogue.Add(car3);

            string araba1 = JsonConvert.SerializeObject(car1);       //json a dönüştürelim
            string araba2 = JsonConvert.SerializeObject(car2);
            string araba3 = JsonConvert.SerializeObject(car3);
            File.WriteAllText("araba katalog.json", araba1 + araba2+ araba3);  //araba katalog adında dosyaya ekleyelim.

        }



        public decimal Checkout() //buraya hesap methodu yazıyorum ki daha sonra çağırabilelim.
    {

        decimal totalCost = 0;

        foreach (var car in Cart)
        {
            totalCost += car.Price;
        }

        Cart.Clear();
            totalCost.ToString("C");
        return totalCost;
    }
       }

}
