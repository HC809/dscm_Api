using System;
namespace DiunsaSCM.Core.Models
{
    public class EmailDTO
    {
        public string ToAddress { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }
    }
}