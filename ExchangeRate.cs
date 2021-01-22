namespace Amin_Database_Project_AssetTracking_Solution

{
    class ExchangeRate
    {
        public ExchangeRate(string currency, double rate)
        {
            Currency = currency;
            Rate = rate;
        }
        public string Currency { get; set; }
        public double Rate { get; set; }
        public int ExchangeRateId { get; set; }
        public int AssetId { get; set; }
        public Asset asset { get; set; }
    }

} 
