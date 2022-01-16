using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Services.EmailLayer.Model;
using Domain.Entities;

namespace Application.Services.EmailLayer
{
    internal class EmailModelFactory
    {
        internal static EmailModel CreateBookingConfirmationEmailModel(BookingItem bookingItem,
            IUrlActionService urlActionService, ISecurityTextService securityTextService)
        {
            string encodedBookingId = securityTextService.Crypt(bookingItem.Id.ToString());
            string buttonUrl =
                $"{urlActionService.GetDomainUrl()}/{urlActionService.GetAdminControllerName()}/{urlActionService.GetAdminBookingConfirmationAction()}/{encodedBookingId}";

            EmailModel model = new EmailModel
            {
                ToEmailAddress = bookingItem.Email,
                EmailSubject = "Test EmailSubject",
                EmailTitle = "Test EmailTitle",
                CompanyName = "Test CompanyName",
                CompanyAddress = "TestCompany Address",
                BodyDescription = "Test Body Description",
                FooterDescription = "Test Footer Description",
                CompanyPhoneNumber = "Test Company Number",
                ShowButton = true,
                ButtonText = "Test Button",
                ButtonUrl = buttonUrl
            };

            return model;
        }

        internal static EmailModel UpdateBookingConfirmationEmailModel(BookingItem bookingItem,
            IUrlActionService urlActionService, ISecurityTextService securityTextService)
        {
            string encodedBookingId = securityTextService.Crypt(bookingItem.Id.ToString());
            string buttonUrl =
                $"{urlActionService.GetDomainUrl()}/{urlActionService.GetAdminControllerName()}/{urlActionService.GetAdminBookingConfirmationAction()}/{encodedBookingId}";

            EmailModel model = new EmailModel
            {
                ToEmailAddress = bookingItem.Email,
                EmailSubject = "Test EmailSubject",
                EmailTitle = "Test EmailTitle",
                CompanyName = "Test CompanyName",
                CompanyAddress = "TestCompany Address",
                BodyDescription = $"Your reservation state has been changed to ${bookingItem.Status.ToString()}",
                FooterDescription = "Test Footer Description",
                CompanyPhoneNumber = "Test Company Number",
                ShowButton = false,
                ButtonText = "Test Button",
                ButtonUrl = buttonUrl
            };

            return model;
        }
    }
}
