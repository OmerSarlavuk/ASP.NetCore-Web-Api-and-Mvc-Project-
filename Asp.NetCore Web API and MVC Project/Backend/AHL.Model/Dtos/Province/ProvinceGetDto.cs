using Infrastructure.Model;

namespace AHL.Model.Dtos.Province
{
    public class ProvinceGetDto : IDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? PicturePath { get; set; }
    }
}
