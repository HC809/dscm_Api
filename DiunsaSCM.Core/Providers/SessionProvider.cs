using System;
using DiunsaSCM.Core.Entities;

namespace DiunsaSCM.Core.Providers
{
    public class SessionProvider
    {
        public Session Session;

        public SessionProvider(
            )
        {
            Session = new Session();
        }

        public void Initialise(string username)
        {
            Session.Username = username;
        }
    }
}
