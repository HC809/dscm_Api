using System;
using System.ComponentModel;
using System.Net.Mail;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Services;
using Hangfire;
using Microsoft.Extensions.Configuration;

namespace DiunsaSCM.Service
{
    public class EmailService : IEmailService
    {
        private readonly IBackgroundJobClient _backgroundJobs;
        private readonly IConfiguration _configuration;
        private string _smtpHost = "";
        private string _fromAddress = "";
        private string _fromDisplayName = "";
        private int _smtpServerPort = 0;
        private string _fromPassword = "";

        public EmailService(IConfiguration configuration, IBackgroundJobClient backgroundJobs)
        {
            _backgroundJobs = backgroundJobs;
            _configuration = configuration;
            
            _smtpHost = _configuration.GetValue<string>("Smtp:SmtpServer", "defaultSmtpServer");
            _smtpServerPort = _configuration.GetValue<int>("Smtp:SmtpServerPort", 587);
            _fromAddress = _configuration.GetValue<string>("Smtp:FromAddress", "defaultFromAddress");
            _fromDisplayName = _configuration.GetValue<string>("Smtp:FromDisplayName", "defaultFromDisplayName");
            _fromPassword = _configuration.GetValue<string>("Smtp:FromPassword", "defaultFromPassword");
        }

        public void Enqueue(EmailDTO emailDTO)
        {
            _backgroundJobs.Enqueue(() => Send(emailDTO));
        }

        bool mailSent = false;
        private void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            // Get the unique identifier for this asynchronous operation.
            String token = (string)e.UserState;

            if (e.Cancelled)
            {
                Console.WriteLine("[{0}] Send canceled.", token);
            }
            if (e.Error != null)
            {
                Console.WriteLine("[{0}] {1}", token, e.Error.ToString());
            }
            else
            {
                Console.WriteLine("Message sent.");
            }
            
            mailSent = true;
        }

        public void Send(EmailDTO emailDTO)
        {
            Console.WriteLine("Sending");
            //SmtpClient client = new SmtpClient(_smtpHost,587);
            SmtpClient client = new SmtpClient(_smtpHost);
            client.Port = _smtpServerPort;
            client.EnableSsl = true;
            client.UseDefaultCredentials = true;

            client.Credentials = new System.Net.NetworkCredential(_fromAddress, _fromPassword);

            MailAddress from = new MailAddress(_fromAddress, _fromDisplayName, System.Text.Encoding.UTF8);
            MailAddress to = new MailAddress(emailDTO.ToAddress);
            MailMessage message = new MailMessage(from, to);

            message.Body = emailDTO.Body;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.Subject = emailDTO.Subject;
            message.SubjectEncoding = System.Text.Encoding.UTF8;

            client.SendCompleted += new
            SendCompletedEventHandler(SendCompletedCallback);

            client.SendCompleted += (s, e) => {
                SendCompletedCallback(s, e);
                client.Dispose();
                message.Dispose();
            };

            // The userState can be any object that allows your callback
            // method to identify this send operation.
            // For this example, the userToken is a string constant.
            string userState = "test message1";
            client.SendAsync(message, userState);
            Console.WriteLine("Sending message.");
            //message.Dispose();
            Console.WriteLine("Done.");
        }
    }
}
