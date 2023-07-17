namespace UberEats.Models
{
    public class DriversViewModel
    {
        public string ActiveConf { get; set; } = "all";
        public string ActiveDiv { get; set; } = "all";
        public Driver Driver { get; set; } = new Driver();
        public List<Driver> Drivers { get; set; } = new List<Driver>();

        // methods to help view determine active link
        public string CheckActiveConf(string c) =>
            c.ToLower() == ActiveConf.ToLower() ? "active" : "";

        public string CheckActiveDiv(string d) =>
            d.ToLower() == ActiveDiv.ToLower() ? "active" : "";
    }
}
