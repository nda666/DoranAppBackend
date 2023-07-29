using DoranOfficeBackend.Entities.Interfaces;
using FluentValidation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoranOfficeBackend.Entities
{
    [Table("salesteams")]
    public class SalesTeam : ITimestamps, ISoftDelete
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("name", TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Column("sales_channel_id")]
        public Guid SalesChannelId { get; set; }

        [Column("jete_target")]
        public ulong JeteTarget { get; set; }

        [Column("omzet_target")]
        public ulong OmzetTarget { get; set; }

        [Column("show_last_year")]
        public bool ShowLastYear { get; set; }

        [Column("commission_terms")]
        public bool CommissionTerms { get; set; }

        [Column("active")]
        public bool Active { get; set; }

        [Column("created_at", TypeName = "timestamp")]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_at", TypeName = "timestamp")]
        public DateTime? UpdatedAt { get; set; }

        [Column("deleted_at", TypeName = "timestamp")]
        public DateTime? DeletedAt { get; set; }

        public SalesChannel? SalesChannel { get; set; }

        public ICollection<Sales>? Sales { get; set; }
    }

    public class SalesTeamValidator : AbstractValidator<SalesTeam>
    {
        public SalesTeamValidator(MyDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Nama harus di isi");
            RuleFor(x => x.JeteTarget).NotNull().WithMessage("Target jete harus di isi");
            RuleFor(x => x.OmzetTarget).NotNull().WithMessage("Target jete harus di isi");
            RuleFor(x => x.Active).NotEmpty().WithMessage("Status Aktif harus di isi")
                .NotNull().WithMessage("Status Aktif harus di isi");
        }
    }
}
