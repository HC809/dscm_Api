using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DiunsaSCM.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace DiunsaSCM.API.Security
{
    public class UserService : IUserService
    {

        private IConfiguration _configuration;

        public UserService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> ValidateCredentialsAsync(UserCredentialDTO userCredential) {
            try
            {
                var permissions = new List<UserPermission>();

                using (var httpClient = new HttpClient())
                {
                    string alsURL = _configuration.GetValue<string>("AuthService:AuthServer", "AuthServer");
                    alsURL = string.Format("{0}/{1}", alsURL, "service/credentials");

                    string applicationCode = _configuration.GetValue<string>("AuthService:ApplicationCode", "ApplicationCode");
                    userCredential.ApplicationCode = applicationCode;

                    var userCredentialContent = JsonConvert.SerializeObject(userCredential);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(userCredentialContent);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    using (var response = await httpClient.PostAsync(alsURL, byteContent))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        var alsServiceResult = JsonConvert.DeserializeObject<ALSServiceResult<bool>>(apiResponse);
                        return alsServiceResult.Data;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<List<UserPermission>> GetUserPermissionsAsync(string username)
        {
            try
            {
                var permissions = new List<UserPermission>();

                using (var httpClient = new HttpClient())
                {
                    string alsURL = _configuration.GetValue<string>("AuthService:AuthServer", "AuthServer");
                    alsURL = string.Format("{0}/{1}", alsURL, "service/permissions");
                    string applicationCode = _configuration.GetValue<string>("AuthService:ApplicationCode", "ApplicationCode");
                    string apiURL = String.Format("{0}?applicationCode={1}&username={2}", alsURL, applicationCode, username);
                    using (var response = await httpClient.GetAsync(apiURL))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        var alsServiceResult = JsonConvert.DeserializeObject<ALSServiceResult<List<UserPermission>>>(apiResponse);
                        return alsServiceResult.Data;
                    }
                }

                return permissions;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}