using System;
using DiunsaSCM.Core.Models;

namespace DiunsaSCM.Core.Services
{
    public interface IEmailService
    {
        public void Enqueue(EmailDTO emailDTO);
        public void Send(EmailDTO emailDTO);
        
    }
}
