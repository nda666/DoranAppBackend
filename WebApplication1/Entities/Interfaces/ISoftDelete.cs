namespace DoranOfficeBackend.Entities.Interfaces
{
    public interface ISoftDelete
    {
        public DateTime? DeletedAt { get; set; }
    }
}
