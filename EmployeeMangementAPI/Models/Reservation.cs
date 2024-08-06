namespace EmployeeMangementAPI.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public GuestMember? GuestMember { get; set; }
        public Room? Room { get; set; }
    }
    public class Room
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Capacity { get; set; }
    }
    public class GuestMember
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
