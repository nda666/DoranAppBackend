namespace DoranOfficeBackend.Interfaces
{
    public interface ISoftDelete
    {
        public DateTime? DeletedAt { get; set; }
    }
}
