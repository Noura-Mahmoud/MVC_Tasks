using System;
using System.Collections.Generic;

#nullable disable

namespace DbWithDotNetCore.Models
{
    public partial class Client
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
    }
}
