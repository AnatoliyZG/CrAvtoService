using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimeAvtoService
{
    public static class AvtoServiceDB
    {
        public static List<AvtoService> avtoServices = new List<AvtoService>()
        {
            new AvtoService("АвтоДвиж", "ул. Беспалова, 70, Симферополь", (44.937915, 34.130231), "+7 (978) 215-48-98", "шиномонтаж", "ремонт", "эвакуация"),
            new AvtoService("АвтоДвиж", "ул. Беспалова, 70, Симферополь", (44.937915, 34.130231), "+7 (978) 215-48-98", "шиномонтаж", "ремонт", "эвакуация"),
            new AvtoService("АвтоДвиж", "ул. Беспалова, 70, Симферополь", (44.937915, 34.130231), "+7 (978) 215-48-98", "шиномонтаж", "ремонт", "эвакуация"),
            new AvtoService("АвтоДвиж", "ул. Беспалова, 70, Симферополь", (44.937915, 34.130231), "+7 (978) 215-48-98", "шиномонтаж", "ремонт", "эвакуация"),
            new AvtoService("АвтоДвиж", "ул. Беспалова, 70, Симферополь", (44.937915, 34.130231), "+7 (978) 215-48-98", "шиномонтаж", "ремонт", "эвакуация"),
            new AvtoService("АвтоДвиж", "ул. Беспалова, 70, Симферополь", (44.937915, 34.130231), "+7 (978) 215-48-98", "шиномонтаж", "ремонт", "эвакуация"),
            new AvtoService("АвтоДвиж", "ул. Беспалова, 70, Симферополь", (44.937915, 34.130231), "+7 (978) 215-48-98", "шиномонтаж", "ремонт", "эвакуация"),
            new AvtoService("АвтоДвиж", "ул. Беспалова, 70, Симферополь", (44.937915, 34.130231), "+7 (978) 215-48-98", "шиномонтаж", "ремонт", "эвакуация"),
            new AvtoService("АвтоДвиж", "ул. Беспалова, 70, Симферополь", (44.937915, 34.130231), "+7 (978) 215-48-98", "шиномонтаж", "ремонт", "эвакуация"),
            new AvtoService("АвтоДвиж", "ул. Беспалова, 70, Симферополь", (44.937915, 34.130231), "+7 (978) 215-48-98", "шиномонтаж", "ремонт", "эвакуация"),
            new AvtoService("АвтоДвиж", "ул. Беспалова, 70, Симферополь", (44.937915, 34.130231), "+7 (978) 215-48-98", "шиномонтаж", "ремонт", "эвакуация"),
        };

        public static AvtoService GetService(string name)
        {
            foreach(var avtoService in avtoServices)
            {
                if(avtoService.Name == name) return avtoService;
            }

            return null;
        }


    }

    public class Avto
    {
        public static Dictionary<AvtoProducer, string[]> AvtoBrands = new Dictionary<AvtoProducer, string[]>()
        {
            {AvtoProducer.Lada, new []{"Granta"} },
        };

        public AvtoProducer Producer;
        public string Brand;

        public Avto(AvtoProducer Producer, string Brand)
        {
            this.Producer = Producer;
            this.Brand = Brand;
        }
    }

    public enum AvtoProducer
    {
        Acura,
        AlfaRomeo,
        Alpina,
        AstonMartin,
        Audi,
        Bentley,
        BMW,
        Bugatti,
        Buick,
        Cadillac,
        Chery,
        Chevrolet,
        Chrysler,
        Citroen,
        Dacia,
        Daewoo,
        Daf,
        Derways,
        Dodge,
        Faw,
        Ferrari,
        Fiat,
        Ford,
        GMC,
        Honda,
        Hummer,
        Hyundai,
        Infiniti,
        Isuzu,
        Jaguar,
        Jeep,
        Kia,
        Lada,
        Lifan,
        Lamborghini,
        LandRover,
        Lexus,
        Lincoln,
        Maserati,
        Maybach,
        Mazda,
        Mercedes,
        Mini,
        Mitsubishi,
        Nissan,
        Opel,
        Peugeot,
        Pontiac,
        Porsche,
        Renault,
        RollsRoyce,
        Skoda,
        Smart,
        Subaru,
        Suzuki,
        Toyota,
        Volkswagen,
        Volvo,
    }

    public class AvtoService
    {
        public string Name;
        public string Address;

        public (double lat, double lon) Coords = (34.100318, 44.948237);

        public string PhoneNumber;

        public string[] Services;

        public Avto[] SupportedCars;

        public float Mark;

        public string[] Feedbacks;

        public AvtoService(string name, string address, (double lon, double lat) coords, string phoneNumber, params string[] services)
        {
            Name = name;
            Address = address;
            Coords = coords;
            PhoneNumber = phoneNumber;
            Services = services;
        }
    }
}
