using Microsoft.EntityFrameworkCore;

namespace DoranOfficeBackend.Entities
{
    [Keyless]
    public class KeylessCount
    {
        public int RowCount { get; set; }
        
    }
}
