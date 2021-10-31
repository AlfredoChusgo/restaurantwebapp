using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.BookingOptions.BasicScheduleRule.Command;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.BookingOptions.Commands
{
    public class UpdateBookingOptionCommand : IRequest<BookingOption>
    {
        public int MinPartySize { get; set; }
        public int MaxPartySize { get; set; }
        public int EarlyBooking { get; set; }
        public int LateBooking { get; set; }


        public class UpdateBookingOptionCommandHandler : IRequestHandler<UpdateBookingOptionCommand, BookingOption>
        {
            private readonly IApplicationDbContext _context;

            public UpdateBookingOptionCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<BookingOption> Handle(UpdateBookingOptionCommand request, CancellationToken cancellationToken)
            {
                BookingOption entity = _context.BookingOptions.FirstOrDefault(e=>e.Id==1);

                if (entity == null)
                {
                    entity = new BookingOption
                    {
                        MinPartySize = request.MinPartySize,
                        MaxPartySize = request.MaxPartySize,
                        EarlyBooking = request.EarlyBooking,
                        LateBooking = request.LateBooking
                    };
                    _context.BookingOptions.Add(entity);
                }
                else
                {
                    entity.MinPartySize = request.MinPartySize;
                    entity.MaxPartySize = request.MaxPartySize;
                    entity.EarlyBooking = request.EarlyBooking;
                    entity.LateBooking = request.LateBooking;
                }

                await _context.SaveChangesAsync(cancellationToken);
                
                return entity;
            }
        }
    }
}
