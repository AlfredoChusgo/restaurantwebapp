using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Booking.Commands
{
    public class UpdateBookingItemCommand : IRequest<BookingItem>
    {
        public int Id { get; set; }
        public int PartySize { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
        public string Phone { get; set; }
        public BookingStatus Status { get; set; }
        public string Details { get; set; }

        public UpdateBookingItemCommand(BookingItem bookingItem)
        {
            Id = bookingItem.Id;
            PartySize = bookingItem.PartySize;
            Name = bookingItem.Name;
            Email = bookingItem.Email;
            Date = bookingItem.Date;
            Phone = bookingItem.Phone;
            Status = bookingItem.Status;
            Details = bookingItem.Details;
        }

        public class UpdateBookingItemCommandHandler : IRequestHandler<UpdateBookingItemCommand, BookingItem>
        {
            private readonly IApplicationDbContext _context;

            public UpdateBookingItemCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<BookingItem> Handle(UpdateBookingItemCommand request, CancellationToken cancellationToken)
            {
                BookingItem entity = await _context.BookingItems.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(BookingItem), request.Id);
                }

                entity.PartySize = request.PartySize;
                entity.Name = request.Name;
                entity.Email = request.Email;
                entity.Date = request.Date;
                entity.Phone = request.Phone;
                entity.Status = request.Status;
                entity.Details = request.Details;

                await _context.SaveChangesAsync(cancellationToken);
                
                return entity;
            }
        }
    }
}
