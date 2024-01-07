using HrApp.Application.EmailOptions;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HrApp.Application.Interfaces;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace HrApp.Application.Services
{
    public class EmailManager : IEmailService
    {
        private readonly EmailOption _option;

        public EmailManager(IOptions<EmailOption> option)
        {
            _option = option.Value;
        }

        public async Task<string> GenerateNewPasswordMailBody(string id, string token)
        {
            byte[] tokenGeneratedBytes = Encoding.UTF8.GetBytes(token);
            var codeEncoded = WebEncoders.Base64UrlEncode(tokenGeneratedBytes);

            var url = EmailComfirmLinkGenerator(codeEncoded, id);

            var html = $@"<html><head></head>
                        <body>
                                    <h2>Human Resources uygulamasına hoş geldiniz!</h2>
                            <a href = {url}> Adınıza oluşturulmuş hesabın şifresini belirlemek için tıklayınız!</a>
                        </body>
                       </html>";

            return html;
        }

        public void SendMail(string reciverMailAddress, string subject, string mailBody)
        {
            var smtpClient = new SmtpClient();

            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;

            smtpClient.Host = _option.Host;
            smtpClient.Port = _option.Port;
            smtpClient.Credentials = new NetworkCredential(_option.Email, _option.Password);

            var mailMessage = new MailMessage();

            mailMessage.From = new MailAddress(_option.Email);

            mailMessage.To.Add(reciverMailAddress);
            mailMessage.Subject = subject;
            mailMessage.Body = mailBody;
            mailMessage.IsBodyHtml = true;

            smtpClient.Send(mailMessage);
        }

        private string EmailComfirmLinkGenerator(string token, string userId)
        {
            var temp = WebApplication.Create();
            string link = "";
            if (temp.Environment.IsDevelopment())
                link = "https://localhost:7298/Personnel/PasswordChange";
            else
                link = "https://ank14hrmvc.azurewebsites.net/Personnel/PasswordChange";

            link += "?" + "token=" + Uri.EscapeDataString(token) + "&userId=" + userId;
            return link;
        }
    }
}
