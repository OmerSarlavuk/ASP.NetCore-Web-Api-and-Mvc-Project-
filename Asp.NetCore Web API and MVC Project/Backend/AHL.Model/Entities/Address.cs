using Infrastructure.Model;

namespace AHL.Model.Entities
{
    public class Address : IEntity
    {
        public int Id { get; set; }
        public int ProvinceId { get; set; }
        public int DistrictId { get; set; }
        public int StudentId { get; set; }
        public string? AddressDetail { get; set; }
        public bool? IsActive { get; set; }
        public Province? Province { get; set; }
        public District? District { get; set; }
        public Student? Student { get; set; }
    }
}
