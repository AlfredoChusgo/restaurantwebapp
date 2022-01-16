using Application.Common.Interfaces;

namespace Application.Services.UrlLayer
{
    internal class UrlService : IUrlActionService
    {
        private string DomainUrl { get; }
        private string ControllerName { get; }
        private string ConfirmationAction { get; }

        public UrlService(string domainUrl, string controllerName, string confirmationAction)
        {
            DomainUrl = domainUrl;
            ControllerName = controllerName;
            ConfirmationAction = confirmationAction;
        }
        public string GetDomainUrl()
        {
            return DomainUrl;
        }

        public string GetAdminControllerName()
        {
            return ControllerName;
        }

        public string GetAdminBookingConfirmationAction()
        {
            return ConfirmationAction;
        }
    }
}
