using DoranOfficeBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoranOfficeBackend.Extentsions
{
    public static class ControllerBaseExtensions
    {
        public static Masteruser GetUser(this ControllerBase controller)
        {
            var user = (Masteruser)controller.HttpContext.Items["User"];
            if (user == null)
            {
                throw new Exception("User not found");
            }
            return user;
        }
    }
}
