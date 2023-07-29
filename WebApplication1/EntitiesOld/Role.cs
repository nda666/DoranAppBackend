

using DoranOfficeBackend.Attributes;
using DoranOfficeBackend.Entities.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoranOfficeBackend.Entities;

public partial class Role : ITimestamps, ISoftDelete
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;

    public bool Active { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<User>? Users { get; set; }
}

public class RoleValidator : AbstractValidator<Role>
{
    public RoleValidator(MyDbContext dbContext)
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Nama harus di isi").Must((role,name) => UniqueName(role, name)).WithMessage("Nama sudah ada pada database");
        RuleFor(x => x.Active).NotEmpty().WithMessage("Status Aktif harus di isi")
            .NotNull().WithMessage("Status Aktif harus di isi");
    }

    private bool UniqueName(Role role, string name)
    {
        MyDbContext _db = new MyDbContext();
        var dbRole = _db.Roles.Where(x => x.Name == name).SingleOrDefault();

        if (dbRole == null)
            return true;

        return dbRole.Id == role.Id;
    }
}