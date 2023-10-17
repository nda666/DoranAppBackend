using _Masteruser = DoranOfficeBackend.Models.Masteruser;
namespace DoranOfficeBackend.Dtos.Auth
{
    public class LoginResposeDto
    {
        public string ApiToken { get; set; }

        public _Masteruser Masteruser { get; set; }
    }
}
