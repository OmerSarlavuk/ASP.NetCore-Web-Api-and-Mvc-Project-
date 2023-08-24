using Infrastructure.Model;

namespace AHL.Model.Entities
{
    public class Province : IEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? PicturePath { get; set; }
        public List<Address>? Address { get; set; }
        public List<District>? District { get; set; }
    }
}