namespace EmployeeMangementAPI.Models
{
    public class Guest
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string ?Email { get; set; }
        public string ?Phone { get; set; }
        public string ?AddressOfGuest { get; set; }
        public string? CheckInDate { get; set; }
        public string? CheckOutDate { get; set; }
        public bool Remember { get; set; }
    }
}
