using System;



namespace Amin_Database_Project_AssetTracking_Solution

{
    class Computer : Asset
    {
        public Computer()
        {
        }

        public Computer(string brand, string model, DateTime purchaseDate, Office office, double purchasePrice, string currency, double exchangeRate)
        {
            Brand = brand;
            Model = model;
            PurchaseDate = purchaseDate;
            Office = office;
            PurchasePrice = purchasePrice;
            Currency = currency;
            ExchangeRate = exchangeRate;
        }
        public int ComputerId { get; set; }
        public int AssetId { get; set; }
        public Asset asset { get; set; }
    }

} 
