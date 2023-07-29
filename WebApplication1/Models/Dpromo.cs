using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Dpromo
    {
        public int Kodehpromo { get; set; }
        public int Kodehtrans { get; set; }
        public bool Hadiahlunas { get; set; }
        public bool History { get; set; }
        public string Hadiahdiberikan { get; set; } = null!;
        public DateTime Tglhadiahdiberikan { get; set; }
    }
}
