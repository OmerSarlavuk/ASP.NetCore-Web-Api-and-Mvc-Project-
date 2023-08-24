namespace AHL.UI.Areas.Admin.Models
{
    public class StudentItem
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? SchoolIdentity { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Gender { get; set; }
        public bool? IsActive { get; set; }
    }
}
