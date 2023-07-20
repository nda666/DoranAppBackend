using DoranOfficeBackend.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using UserEntity = DoranOfficeBackend.Entities.User;

namespace DoranOfficeBackend.Dto.User
{
    public class SaveUserDto
    {
        public string Username { get; set;}
        public string Password { get; set;}
        public Guid RoleId { get; set;}
    }
}
