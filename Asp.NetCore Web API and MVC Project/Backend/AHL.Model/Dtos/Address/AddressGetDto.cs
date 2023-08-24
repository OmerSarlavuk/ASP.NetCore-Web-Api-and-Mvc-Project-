using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHL.Model.Dtos.Address
{
    public class AddressGetDto : IDto
    {
        public int Id { get; set; }
        public string? AddressDetail { get; set; }
        public string? ProvinceName { get; set; }
        public string? DistrictName { get; set; }
        public string? studentfirstName { get; set; }
        public string? studentlastName { get; set; }
        public bool? IsActive { get; set; }
    }
}
