using System;
using System.Collections.Generic;

#nullable disable

namespace COMP2001_WebProj2.Models
{
    public partial class User
    {
        public int Userid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
