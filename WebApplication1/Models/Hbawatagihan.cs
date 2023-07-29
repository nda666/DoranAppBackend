using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Hbawatagihan
    {
        public int KodeH { get; set; }
        public sbyte Sales { get; set; }
        public DateTime TglBawa { get; set; }
        public DateTime InsertTime { get; set; }
        public sbyte InsertName { get; set; }
    }
}
