using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Masteruserretur
    {
        public bool Kodeku { get; set; }
        public string Usernameku { get; set; } = null!;
        public string Passwordku { get; set; } = null!;
        public string Akses { get; set; } = null!;
    }
}
