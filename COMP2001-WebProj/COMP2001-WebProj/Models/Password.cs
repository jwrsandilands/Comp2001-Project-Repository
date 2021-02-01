using System;
using System.Collections.Generic;

#nullable disable

namespace COMP2001_WebProj.Models
{
    public partial class Password
    {
        public int Userid { get; set; }
        public DateTime DateChanged { get; set; }
        public string Passw { get; set; }
    }
}
