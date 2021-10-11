using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Booking.Queries
{
    public class GetBookingItemQuery : IRequest<BookingItem>
    {
        public int Id { get; set; }

        public class GetBookingItemQueryHandler : IRequestHandler<GetBookingItemQuery, BookingItem>
        {
            private readonly IApplicationDbContext _context;

            public GetBookingItemQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<BookingItem> Handle(GetBookingItemQuery request, CancellationToken cancellationToken)
            {
                BookingItem item = _context.BookingItems.FirstOrDefault(e => e.Id == request.Id);

                return item;
            }
        }
    }
}
