using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHL.Model.Dtos.AdminUser
{
    public class AdminUserGetDto : IDto
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? LinkedlnPath { get; set; }
        public string? PhotoPath { get; set; }
    }
}
