using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
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

        public CreateBookingItemCommand(BookingItem bookingItem)
        {
            PartySize = bookingItem.PartySize;
            Name = bookingItem.Name;
            Email = bookingItem.Email;
            Date = bookingItem.Date;
            Phone = bookingItem.Phone;
            Status = bookingItem.Status;
            Details = bookingItem.Details;
        }

        public class CreateBookingItemCommandHandler : IRequestHandler<CreateBookingItemCommand, BookingItem>
        {
            private readonly IApplicationDbContext _context;

            public CreateBookingItemCommandHandler(IApplicationDbContext context)
            {
                _context = context;
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
                    Details = request.Details
                };
                _context.BookingItems.Add(item);
                await _context.SaveChangesAsync(cancellationToken);
                
                return item;
            }
        }
    }
}
