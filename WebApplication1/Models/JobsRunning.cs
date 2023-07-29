using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class JobsRunning
    {
        public int Id { get; set; }
        public string? ConnectionName { get; set; }
        public int? TotalData { get; set; }
        public int? CurrentOffset { get; set; }
        public string? ShopId { get; set; }
        public string? Log { get; set; }
        public int? JobId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
