using System;
using System.Security.Claims;
using System.Threading.Tasks;
using DiunsaSCM.Core.Providers;
using Microsoft.AspNetCore.Http;

namespace DiunsaSCM.API.Security
{
    public class SessionMiddleware
    {
        private readonly RequestDelegate next;

        public SessionMiddleware(RequestDelegate next)
        {
            this.next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task Invoke(HttpContext context, SessionProvider sessionProvider)
        {
            var claimsIdentity = context.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;

            if (userName != null)
            {
                sessionProvider.Initialise(userName);
            }

            await next(context);
        }
    }
}
