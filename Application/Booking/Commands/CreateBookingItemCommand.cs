using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Services.EmailLayer;
using Application.Services.EmailLayer.Model;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Booking.Commands
{
    public class CreateBookingItemCommand :IRequest<BookingItem>
    {
        
        public int PartySize { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
        public string Phone { get; set; }
        public BookingStatus Status { get; set; }
        public string Details { get; set; }
        public int TimeId { get; set; }

        public CreateBookingItemCommand(BookingItem bookingItem)
        {
            PartySize = bookingItem.PartySize;
            Name = bookingItem.Name;
            Email = bookingItem.Email;
            Date = bookingItem.Date;
            Phone = bookingItem.Phone;
            Status = bookingItem.Status;
            Details = bookingItem.Details;
            TimeId = bookingItem.TimeId;
        }

        public class CreateBookingItemCommandHandler : IRequestHandler<CreateBookingItemCommand, BookingItem>
        {
            private readonly IApplicationDbContext _context;
            private readonly IEmailService _emailService;
            private readonly IUrlActionService _urlActionService;
            private readonly ISecurityTextService _securityTextService;

            public CreateBookingItemCommandHandler(IApplicationDbContext context, IEmailService emailService, IUrlActionService urlActionService, ISecurityTextService securityTextService)
            {
                _context = context;
                _emailService = emailService;
                _urlActionService = urlActionService;
                _securityTextService = securityTextService;
            }

            public async Task<BookingItem> Handle(CreateBookingItemCommand request, CancellationToken cancellationToken)
            {
                BookingItem item = new BookingItem
                {
                    PartySize = request.PartySize,
                    Name = request.Name,
                    Email = request.Email,
                    Date = request.Date,
                    Phone = request.Phone,
                    Status = request.Status,
                    Details = request.Details,
                    TimeId = request.TimeId
                };
                _context.BookingItems.Add(item);

                await _context.SaveChangesAsync(cancellationToken);

                EmailModel model = EmailModelFactory.CreateBookingConfirmationEmailModel(item, _urlActionService, _securityTextService);

                await _emailService.SendEmail(model);

                return item;
            }
        }
    }
}
