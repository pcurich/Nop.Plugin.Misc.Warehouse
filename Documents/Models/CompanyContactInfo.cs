namespace Nop.Plugin.Misc.Warehouse.Documents.Models
{
    public class CompanyContactInfo
    {
        public string CompanyName { get; set; }
        public string Line1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string CityStateZip { get; set; }

        public CompanyContactInfo()
        {
            CityStateZip = City + "," + State + " " + Zip;
        }
    }
}