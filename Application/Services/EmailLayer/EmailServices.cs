using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Services.EmailLayer.Model;
using FluentEmail.Core;
using FluentEmail.Razor;
using FluentEmail.Smtp;
using Microsoft.AspNetCore.Routing;

namespace Application.Services.EmailLayer
{
    internal class DotNetEmailServices : IEmailService
    {
        private string FromMailAddress { get; }
        private string Subject { get; }
        public SmtpClient Smtp { get; }

        public DotNetEmailServices(string fromMailAddress, string password, string subject)
        {
            FromMailAddress = fromMailAddress;
            Subject = subject;
            Smtp = new SmtpClient();

            Smtp.Credentials = new NetworkCredential(fromMailAddress, password);
            Smtp.Host = "smtp.gmail.com";
            Smtp.EnableSsl = true;
            Smtp.UseDefaultCredentials = false;
            Smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            Smtp.Port = 587;
        }

        public async Task SendEmail(EmailModel model)
        {

            Email.DefaultRenderer = new RazorRenderer();

            var buildDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var filePath = buildDir + @"\Services\EmailLayer\HtmlTemplates\confirm_email.html";
            string template = File.ReadAllText(filePath);
            

            //var model = new
            //{
            //    EmailTitle = "Restaurant Wep App",
            //    CompanyName = "Restaurant Germany",
            //    CompanyAddress = "av. siempre viva #594",
            //    BodyDescription = "Body Description",
                
            //    FooterDescription = "Footer Description",
            //    CompanyPhoneNumber = "75517478",
            //    ButtonText = "ButtonText",
            //    ButtonURL = "https://google.com/",
            //};

            try
            {
                var email = new Email()
                    .SetFrom(FromMailAddress)
                    .To(model.ToEmailAddress)
                    .Subject(model.EmailSubject)
                    .UsingTemplate(template, model);

                email.Sender = new SmtpSender(Smtp);

                email.Send();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            //.Body(body);

            //.Send(); //this will use the SmtpSender

        }
    }
}
