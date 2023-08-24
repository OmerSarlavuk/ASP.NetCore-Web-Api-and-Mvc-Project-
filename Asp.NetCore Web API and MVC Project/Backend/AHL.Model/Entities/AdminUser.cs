using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHL.Model.Entities
{
    public class AdminUser : IEntity
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? LinkedlnPath { get; set; }
        public string? PhotoPath { get; set; }
        public bool? IsActive { get; set; }
    }
}
