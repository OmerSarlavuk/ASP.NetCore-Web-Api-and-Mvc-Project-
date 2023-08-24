using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHL.Model.Dtos.Student
{
    public class StudentGetDto : IDto
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? SchoolIdentity { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Gender { get; set; }
        public string? AddressDetail { get; set; }
        public string? AdressId { get; set; }
        public bool? IsActive { get; set; }
    }
}
