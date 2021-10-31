using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.BookingOptions.OptionsFactory;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.BookingOptions.Queries
{
    public class GetBookingOptionsQuery : IRequest<BookingOptionsVm>
    {

        public class GetBookingOptionsQueryHandler : IRequestHandler<GetBookingOptionsQuery, BookingOptionsVm>
        {
            private readonly IApplicationDbContext _context;

            public GetBookingOptionsQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public Task<BookingOptionsVm> Handle(GetBookingOptionsQuery request, CancellationToken cancellationToken)
            {
                var entity = _context.BookingOptions.FirstOrDefault(e=>e.Id==1);

                if (entity == null)
                {
                    entity = new BookingOption
                    {
                        MinPartySize = 6,
                        MaxPartySize = 7,
                        EarlyBooking = 4,
                        LateBooking = 6
                    };
                }
                BookingOptionsFactory factory = new BookingOptionsFactory();
                BookingOptionsVm vm = factory.GetBookingOptionsVm(entity);

                return Task.FromResult(vm);
            }
        }
    }
}
