
using DoranOfficeBackend.Entities.Interfaces;
using FluentValidation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;

namespace DoranOfficeBackend.Entities
{
    [Table("sales")]
    public class Sales : ITimestamps, ISoftDelete
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("name", TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Column("sales_team_id")]
        public Guid SalesTeamId { get; set; }

        [Column("is_manager")]
        public bool IsManager { get; set; }

        [Column("manager_id")]
        public Guid? ManagerId { get; set; }

        [Column("get_omzet_email")]
        public bool GetOmzetEmail { get; set; }

        [Column("active")]
        public bool Active { get; set; }

        [Column("created_at", TypeName = "timestamp")]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_at", TypeName = "timestamp")]
        public DateTime? UpdatedAt { get; set; }

        [Column("deleted_at", TypeName = "timestamp")]
        public DateTime? DeletedAt { get; set; }

        public virtual Sales? Manager { get; set; } = null!;

        public virtual User? User { get; set; } = null!;

        public virtual SalesTeam? SalesTeam { get; set; } = null!;
    }


    public class SalesValidator : AbstractValidator<Sales>
    {
        public SalesValidator(MyDbContext dbContext)
        {

            RuleFor(x => x.Name)
                .NotNull().WithMessage("Username harus di isi")
                .NotEmpty().WithMessage("Username harus di isi");

            RuleFor(x => x.SalesTeamId)
                .NotNull().WithMessage("Tim Sales harus di isi")
                .NotEmpty().WithMessage("Tim Sales harus di isi")
                .Must((user, roleId) => SalesTeamlIdExist(roleId.ToString())).WithMessage("Tim sales tidak ditemukan");
        }

        private bool SalesTeamlIdExist(string roleId) 
        {
            if (!Guid.TryParse(roleId, out var tenantId))
                return false;

            MyDbContext _db = new MyDbContext();
            var dbUser = _db.SalesTeams.Where(x => x.Id == tenantId).SingleOrDefault();
            
            if (dbUser == null)
                return false;

            return true;
        }
    }
}