using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;



namespace Amin_Database_Project_AssetTracking_Solution

{
    class Program
    {
        static AssetContext _AssetContext = new AssetContext();
        static void Main(string[] args)
        {
            Console.WriteLine("What do you want to do Assets database ?");
            Console.WriteLine("If you want to create or add a new asset to the database enter C");
            Console.WriteLine("If you want to read from the database enter R");
            Console.WriteLine("If you want to update the database enter U");
            Console.WriteLine("If you want to delete an asset from the database enter D");
            string input = Console.ReadLine();
            while (true)
            {

                if (input.ToLower() == "c")
                {
                    Computer computer = new Computer("iPhone", "X", GetDate("2018-07-15"), new Office("Sweden"), 12450, "SEK", 8.45);
                    _AssetContext.computers.Add(computer); 
                    _AssetContext.SaveChanges(); 
                }
                else if (input.ToLower() == "r")
                {
                    Asset assetRead = _AssetContext.computers.FirstOrDefault();
                }
                else if (input.ToLower() == "u")
                {
                    Asset databaseUpdate = _AssetContext.computers.FirstOrDefault();
                    databaseUpdate.Model = "240 GL"; 
                    _AssetContext.SaveChanges(); 

                }
                else if (input.ToLower() == "d")
                {
                    Computer assetDelete = _AssetContext.computers.Where(car => car.Brand == "Asus").FirstOrDefault();
                    _AssetContext.computers.Remove(assetDelete);
                    _AssetContext.SaveChanges(); 

                }
            }
            //No input from Console in this solution 
            List<Asset> assets = PrepareAssets();
            List<ExchangeRate> exchangeRates = PrepareExchangeRates();
            assets = SortAssets(assets);
            PrintHeader();
            PrintData(assets, exchangeRates);
            Console.ReadLine();
        }
        static List<Asset> PrepareAssets()
        {
            return new List<Asset>()
            {
                new Phone("iPhone", "X", GetDate("2018-07-15"),new Office("Sweden"), 12450, "SEK",8.45),
                new Computer("Asus", "W234", GetDate("2017-04-21"),new Office("USA"), 1200, "USD",1.00),
                new Phone("iPhone", "11", GetDate("2020-09-25"),new Office("Spain"), 990, "EUR",10.12),
                new Computer("Lenovo", "Yoga 530", GetDate("2019-04-21"),new Office("USA"), 1530, "USD",1.00),
                new Phone("iPhone", "8", GetDate("2018-03-16"),new Office("Spain"), 970, "EUR",10.12),
                new Computer("Lenovo", "Yoga 730", GetDate("2018-05-28"),new Office("USA"), 1835, "USD",1.00),
                new Phone("Motorola", "Razr", GetDate("2020-03-16"),new Office("Sweden"), 9700, "SEK",8.45),
                new Computer("HP", "Elitebook", GetDate("2020-10-02"),new Office("Sweden"), 1588, "SEK",8.45)
            };
        }
        static List<ExchangeRate> PrepareExchangeRates()
        {
            return new List<ExchangeRate>()
            {
                new ExchangeRate("USD",1.00),
                new ExchangeRate("SEK", 0.12),
                new ExchangeRate("EUR", 1.21)
            };
        }
        static List<Asset> SortAssets(List<Asset> assets)
        {
            assets = assets.OrderBy(asset => asset.GetType().ToString()).ThenBy(asset => asset.PurchaseDate).ToList();
            return assets;
        }
        static void PrintHeader()
        {
            Console.WriteLine(
                Tab("Brand") +
                Tab("Model") +
                Tab("Office") +
                Tab("Purchase Date") +
                Tab("Price") +
                Tab("Currency") +
                Tab("In USD today")
                );
            Console.WriteLine(
                Tab("-----") +
                Tab("-----") +
                Tab("------") +
                Tab("-------------") +
                Tab("-----") +
                Tab("---------") +
                Tab("------------")
                );
        }
        static void PrintData(List<Asset> assets, List<ExchangeRate> exchangeRates)
        {
            assets.ForEach(asset => PreparePrintDataLine(asset, exchangeRates));
        }
        static DateTime GetDate(string date)
        {
            return DateTime.ParseExact(date, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
        }
        static void PreparePrintDataLine(Asset asset, List<ExchangeRate> exchangeRates)
        {
            int daysWarning = 913; //Approx 30 months 
            int daysAlarm = 1004;  //Approx 33 months 
            TimeSpan diff = DateTime.Now - asset.PurchaseDate;
            DecideForegroundColor(daysWarning, daysAlarm, diff);
            double usdRateToday = exchangeRates.Where(exchangeRate => exchangeRate.Currency == asset.Currency).Select(ex => ex.Rate).FirstOrDefault();
            PrintDataLine(asset, usdRateToday);
            Console.ForegroundColor = ConsoleColor.White;
        }          

        static void DecideForegroundColor(int daysWarning, int daysAlarm, TimeSpan diff)
        {
            if (diff.Days > daysAlarm)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (diff.Days > daysWarning)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        static void PrintDataLine(Asset asset, double usdRateToday)
        {
            Console.WriteLine(
                            Tab(asset.Brand) +
                            Tab(asset.Model) +
                            Tab(asset.Office.Name) +
                            Tab(asset.PurchaseDate.ToShortDateString()) +
                            Tab(asset.PurchasePrice.ToString("0.##")) +
                            Tab(asset.Currency) +
                            Tab((asset.PurchasePrice * usdRateToday).ToString("0.##"))
                            );
        }
        static string Tab(string input)
        {
            return input.PadRight(14);
        }
    }
} 
