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
            Console.WriteLine("What do you want to do in Assets database ? (Write computer or phone )");
           
            string input = Console.ReadLine();
            while (input == "computer" || input == "phone")
            {
                Console.WriteLine("If you want to create or add a new asset to the database enter C");
                Console.WriteLine("If you want to read from the database enter R");
                Console.WriteLine("If you want to update the database enter U");
                Console.WriteLine("If you want to delete an asset from the database enter D");
                string input1 = Console.ReadLine();
                if (input1.ToLower() == "c" && input.ToLower() == "computer")
                {
                    Console.WriteLine("Write the name of a computer");
                    string namn = Console.ReadLine();
                    Console.WriteLine("Write the model of the computer");
                    string mod = Console.ReadLine();
                    Console.WriteLine("Write the purchaseDate of the computer in this formate (2018 - 07 - 15)");
                    DateTime datum = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                    Console.WriteLine("Write the name of the country");
                    Office place = new Office (Console.ReadLine());
                    Console.WriteLine("Write the purchasePrice");
                    double pris = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Write the currency");
                    string cur = Console.ReadLine();
                    Console.WriteLine("Write the currencyRate");
                    double rate = Convert.ToInt32(Console.ReadLine());

                    Computer computer = new Computer(namn, mod, datum, place, pris, cur, rate);
                    _AssetContext.computers.Add(computer); 
                    _AssetContext.SaveChanges(); 
                }
                else if (input1.ToLower() == "r" && input.ToLower() == "computer")
                {
                    Asset assetRead = _AssetContext.computers.FirstOrDefault();
                }
                else if (input1.ToLower() == "u" && input.ToLower() == "computer")
                {
                    Asset databaseUpdate = _AssetContext.computers.FirstOrDefault();
                    databaseUpdate.Model = Console.ReadLine(); 
                    _AssetContext.SaveChanges(); 

                }
                else if (input1.ToLower() == "d" && input.ToLower() == "computer")
                {
                    Console.WriteLine("Write the name of a computer in order to delete from the database");
                    string namn1 = Console.ReadLine();
                    Computer assetDelete = _AssetContext.computers.Where(computer => computer.Brand == namn1).FirstOrDefault();
                    _AssetContext.computers.Remove(assetDelete);
                    _AssetContext.SaveChanges(); 

                }


                if (input1.ToLower() == "c" && input.ToLower() == "phone")
                {
                    Console.WriteLine("Write the name of a phone");
                    string namn = Console.ReadLine();
                    Console.WriteLine("Write the model of the phone");
                    string mod = Console.ReadLine();
                    Console.WriteLine("Write the purchaseDate of the phone in this formate (2018 - 07 - 15)");
                    DateTime datum = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                    Console.WriteLine("Write the name of the country");
                    Office place = new Office(Console.ReadLine());
                    Console.WriteLine("Write the purchasePrice");
                    double pris = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Write the currency");
                    string cur = Console.ReadLine();
                    Console.WriteLine("Write the currencyRate");
                    double rate = Convert.ToInt32(Console.ReadLine());

                    Phone phone = new Phone(namn, mod, datum, place, pris, cur, rate);
                    _AssetContext.phones.Add(phone);
                    _AssetContext.SaveChanges();
                }
                else if (input1.ToLower() == "r" && input.ToLower() == "phone")
                {
                    Asset assetRead = _AssetContext.phones.FirstOrDefault();
                }
                else if (input1.ToLower() == "u" && input.ToLower() == "phone")
                {
                    Asset databaseUpdate = _AssetContext.phones.FirstOrDefault();
                    databaseUpdate.Model = Console.ReadLine();
                    _AssetContext.SaveChanges();

                }
                else if (input1.ToLower() == "d" && input.ToLower() == "phone")
                {
                    Console.WriteLine("Write the name of a the phone in order to delete from the database");
                    string namn2 = Console.ReadLine();
                    Phone assetDelete = _AssetContext.phones.Where(phone => phone.Brand == namn2).FirstOrDefault();
                    _AssetContext.phones.Remove(assetDelete);
                    _AssetContext.SaveChanges();

                }
            }
           
        }
       
    }
        
       
       
} 
