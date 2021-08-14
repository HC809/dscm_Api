using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiunsaSCM.API.Security
{
    public interface IUserService
    {
        Task<bool> ValidateCredentialsAsync(UserCredentialDTO userCredential);
        Task<List<UserPermission>> GetUserPermissionsAsync(string userName);
    }
}
