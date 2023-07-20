using System.ComponentModel.DataAnnotations.Schema;

namespace DoranOfficeBackend.Entities.Interfaces
{
    public interface ITimestamps
    {
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
