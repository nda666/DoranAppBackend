using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    /// <summary>
    /// table untuk log saat terakhir ubah nomor hp pelanggan
    /// </summary>
    public partial class LogUpdatePhone
    {
        public int Id { get; set; }
        public int? BrandId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
