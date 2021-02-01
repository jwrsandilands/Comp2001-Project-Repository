using System;
using System.Collections.Generic;

#nullable disable

namespace COMP2001_WebProj.Models
{
    public partial class User
    {
        public int Userid { get; set; }
        public string Firstn { get; set; }
        public string Lastn { get; set; }
        public string Email { get; set; }
        public string Passw { get; set; }
    }
}
