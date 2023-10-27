using SekerTeshis.Core.CrossCuttingConcerns.MailService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekerTeshisApp.Application.Mail.Abstract
{
    public interface IMailSender
    {
        void SendEmail(Message message);
        Task SendEmailAsync(Message message);
    }
}
