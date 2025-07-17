namespace AccessControlAPI.Models
{
    public class Device
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; } = null!;
        public string Location { get; set; } = null!;
    }
}
