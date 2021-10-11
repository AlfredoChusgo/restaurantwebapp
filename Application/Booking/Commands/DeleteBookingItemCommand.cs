using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Booking.Commands
{
    public class DeleteBookingItemCommand :IRequest
    {
        public int Id { get; }

        public DeleteBookingItemCommand(int id)
        {
            Id = id;
        }

        public class DeleteBookingItemCommandHandler : IRequestHandler<DeleteBookingItemCommand>
        {
            private readonly IApplicationDbContext _context;

            public DeleteBookingItemCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteBookingItemCommand request, CancellationToken cancellationToken)
            {
                BookingItem entity = await _context.BookingItems.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(BookingItem), request.Id);
                }

                _context.BookingItems.Remove(entity);
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
