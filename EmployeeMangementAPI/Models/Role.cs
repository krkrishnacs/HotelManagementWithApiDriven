namespace EmployeeMangementAPI.Models
{
    public class Role
    {
        public int RoleID { get; set; }
        public string ?RoleName { get; set; }
        public string? RoleDescription { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
