using System;
using System.Collections.Generic;

#nullable disable

namespace COMP2001_WebProj2.Models
{
    public partial class Password
    {
        public int Userid { get; set; }
        public DateTime PasswordModifiedDate { get; set; }
        public string Password1 { get; set; }
    }
}
