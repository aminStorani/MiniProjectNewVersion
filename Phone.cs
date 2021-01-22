using System;



namespace Amin_Database_Project_AssetTracking_Solution

{
    class Phone : Asset
    {
        public Phone()
        {
        }

        public Phone(string brand, string model, DateTime purchaseDate, Office office, double purchasePrice, string currency, double exchangeRate)
        {
            Brand = brand;
            Model = model;
            PurchaseDate = purchaseDate;
            Office = office;
            PurchasePrice = purchasePrice;
            Currency = currency;
            ExchangeRate = exchangeRate;
        }
        public int PhoneId { get; set; }
        public int AssetId { get; set; }
        public Asset asset { get; set; }
    }

} 
