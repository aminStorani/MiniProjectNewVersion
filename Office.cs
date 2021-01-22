namespace Amin_Database_Project_AssetTracking_Solution

{
    class Office
    {
        public Office(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
        public int OfficeId { get; set; }
        public int AssetId { get; set; }
        public Asset asset { get; set; }
    }

} 
