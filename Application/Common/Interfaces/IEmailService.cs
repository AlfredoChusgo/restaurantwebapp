using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.EmailLayer.Model;

namespace Application.Common.Interfaces
{
    public interface IEmailService
    {
        Task SendEmail(EmailModel model);
    }
}
