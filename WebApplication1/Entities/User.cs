using DoranOfficeBackend.Attributes;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoranOfficeBackend.Entities;

public partial class User
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public Guid Id { get; set; }
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string? PasswordText { get; set; }

    public string? ApiToken { get; set; }

    public Guid RoleId { get; set; }


    [Column("sales_id")]
    public Guid? SalesId { get; set; }

    public string? RememberToken { get; set; }

    public bool Active { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Role? Role { get; set; } = null!;

    public virtual Sales? Sales { get; set; } = null!;
}

public class UserValidator : AbstractValidator<User>
{
    public UserValidator(MyDbContext dbContext)
    {

        RuleFor(x => x.Username)
            .NotNull().WithMessage("Username harus di isi")
            .NotEmpty().WithMessage("Username harus di isi")
            .Must((user, username) => UniqueName(user, username)).WithMessage("Username sudah ada pada database");

        RuleFor(x => x.Password)
            .NotNull().WithMessage("Username harus di isi")
           .NotEmpty().WithMessage("Password harus di isi");

        RuleFor(x => x.RoleId)
            .NotNull().WithMessage("Username harus di isi")
            .NotEmpty().WithMessage("Role ID harus di isi")
            .Must((user, roleId) => RoleIdExist(roleId)).WithMessage("ID Role tidak di temukan di database");


    }

    private bool RoleIdExist(Guid roleId)
    {
        MyDbContext _db = new MyDbContext();
        var dbUser = _db.Roles.Where(x => x.Id == roleId).SingleOrDefault();

        if (dbUser == null)
            return false;

        return true;
    }

    private bool UniqueName(User user, string username)
    {
        MyDbContext _db = new MyDbContext();
        var dbUser = _db.Users.Where(x => x.Username == username).SingleOrDefault();

        if (dbUser == null)
            return true;

        return dbUser.Id == user.Id;
    }
}