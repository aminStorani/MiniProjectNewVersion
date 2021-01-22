using System;
using System.Collections.Generic;

namespace Amin_Database_Project_AssetTracking_Solution

{
    class Asset
    {
        public int AssetId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime PurchaseDate { get; set; }
        public Office Office { get; set; }
        public double PurchasePrice { get; set; }
        public string Currency { get; set; }
        public double ExchangeRate { get; set; }
        public List<Computer> computers { get; set; }
        public List<Phone> phones { get; set; }
    }

} 
