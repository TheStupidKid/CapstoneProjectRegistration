using System;
using System.Collections.Generic;

namespace BussinessObject.Models
{
    public partial class Admin
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Role { get; set; } = null!;
    }
}
