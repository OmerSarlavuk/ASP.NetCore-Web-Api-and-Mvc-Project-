using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHL.Model.Entities
{
    public class District : IEntity
    {
        public int Id { get; set; }
        public int ProvinceId { get; set; }
        public int StudentId { get; set; }
        public string AddressDetail { get; set; }
        public string? Name { get; set; }
        public bool? IsActive { get; set; }
        public Province? Province { get; set; }
        public Address? Addresses { get; set; }
        public Student? Student { get; set; }
    }
}
