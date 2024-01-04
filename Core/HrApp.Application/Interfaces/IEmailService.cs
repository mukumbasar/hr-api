using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Application.Interfaces
{
    public interface IEmailService
    {
        void SendMail(string reciverMailAddress, string subject, string mailBody);
        Task<string> GenerateNewPasswordMailBody(string id, string token);
    }
}
