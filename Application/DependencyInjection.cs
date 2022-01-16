using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Services;
using Application.Services.EmailLayer;
using Application.Services.UrlLayer;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());
            //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehaviour<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
            string email = configuration["EmailConfig:AdminEmail"];
            string password = configuration["EmailConfig:AdminPassword"];

            //services.AddScoped<IEmailService,DotNetEmailServices>(new Func<IServiceProvider, DotNetEmailServices>(email, password, "TestSubject"));
            string domainUrl = configuration["EmailConfig:DomainUrl"];
            string controllerName = configuration["EmailConfig:ControllerName"];
            string confirmationActionMethod = configuration["EmailConfig:AdminBookingConfirmationAction"];

            var emailService = new DotNetEmailServices(email, password, "TestSubject");
            services.AddScoped<IEmailService>(e => emailService);
            services.AddScoped<IUrlActionService>(e => new UrlService(domainUrl,controllerName,confirmationActionMethod));
            services.AddScoped<ISecurityTextService>(e => new SecurityEncodeService());

            services
                .AddFluentEmail(email)
                .AddRazorRenderer()
                //.AddSmtpSender("localhost", 25);
                //.AddSmtpSender("smtp.gmail.com", 25);
                .AddSmtpSender(emailService.Smtp);

            return services;
        }
    }
}
