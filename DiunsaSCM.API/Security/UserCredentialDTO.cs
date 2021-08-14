using System;
namespace DiunsaSCM.API.Security
{
    public class UserCredentialDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
        public string ApplicationCode { get; set; }
    }
}
