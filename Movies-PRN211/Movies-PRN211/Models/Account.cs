using System;
using System.Collections.Generic;

namespace Movies_PRN211.Models
{
    public partial class Account
    {
        public string Gmail { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Name { get; set; } = null!;
        public bool Gender { get; set; }
        public string Role { get; set; } = null!;
        public bool AccStatus { get; set; }
    }
}
