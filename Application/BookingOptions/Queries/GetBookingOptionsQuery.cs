using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.BookingOptions.OptionsFactory;
using Domain.Entities;
using MediatR;

namespace Application.BookingOptions.Queries
{
    public class GetBookingOptionsQuery : IRequest<BookingOptionsVm>
    {

        public class GetBookingOptionsQueryHandler : IRequestHandler<GetBookingOptionsQuery, BookingOptionsVm>
        {
            public GetBookingOptionsQueryHandler()
            {
            }

            public Task<BookingOptionsVm> Handle(GetBookingOptionsQuery request, CancellationToken cancellationToken)
            {
                BookingOptionsFactory factory = new BookingOptionsFactory();
                BookingOptionsVm vm = factory.GetBookingOptionsVm();

                return Task.FromResult(vm);
            }
        }
    }
}
