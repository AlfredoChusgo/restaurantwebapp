using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Contact.Commands
{
    public class CreateContactUsCommand :IRequest<ContactUs>
    {

        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }

        public CreateContactUsCommand(ContactUs contactUs)
        {
            Name = contactUs.Name;
            EmailAddress = contactUs.EmailAddress;
            Subject = contactUs.Subject;
            Message = contactUs.Message;
        }

        public class CreateContactUsCommandHandler : IRequestHandler<CreateContactUsCommand, ContactUs>
        {
            private readonly IApplicationDbContext _context;

            public CreateContactUsCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<ContactUs> Handle(CreateContactUsCommand request, CancellationToken cancellationToken)
            {
                ContactUs item = new ContactUs
                {
                    Name = request.Name,
                    EmailAddress = request.EmailAddress,
                    Subject = request.Subject,
                    Message = request.Message,
                    Date = DateTime.Now
                };

                _context.ContactUs.Add(item);

                await _context.SaveChangesAsync(cancellationToken);

                return item;
            }
        }
    }
}
