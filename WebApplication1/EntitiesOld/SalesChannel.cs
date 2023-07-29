using DoranOfficeBackend.Entities;
using DoranOfficeBackend.Entities.Interfaces;
using FluentValidation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoranOfficeBackend.Entities
{
    [Table("saleschannels")]
    public class SalesChannel: ITimestamps, ISoftDelete
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("name", TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Column("active")]
        public bool? Active { get; set; }

        [Column("created_at", TypeName = "timestamp")]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_at", TypeName = "timestamp")]
        public DateTime? UpdatedAt { get; set; }

        [Column("deleted_at", TypeName = "timestamp")]
        public DateTime? DeletedAt { get; set; }
        public virtual ICollection<SalesTeam>? SalesTeams { get; set; } = null!;
    }
}

public class SalesChannelValidator : AbstractValidator<SalesChannel>
{
    public SalesChannelValidator(MyDbContext dbContext)
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Nama harus di isi");
        RuleFor(x => x.Active).NotEmpty().WithMessage("Status Aktif harus di isi")
            .NotNull().WithMessage("Status Aktif harus di isi");
    }
}