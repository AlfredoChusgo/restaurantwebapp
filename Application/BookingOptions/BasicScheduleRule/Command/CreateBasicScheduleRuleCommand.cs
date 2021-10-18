using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Booking.Commands;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.BookingOptions.BasicScheduleRule.Command
{
    public class CreateBasicScheduleRuleCommand : IRequest<BasicBookingScheduleRule>
    {
        public int StartTimeId { get; set; }
        public int EndTimeId { get; set; }
        public bool MondaySelected { get; set; }
        public bool TuesdaySelected { get; set; }
        public bool WednesdaySelected { get; set; }
        public bool ThursdaySelected { get; set; }
        public bool FridaySelected { get; set; }
        public bool SaturdaySelected { get; set; }
        public bool SundaySelected { get; set; }

        public BasicBookingScheduleRule ToDomain()
        {
            return new BasicBookingScheduleRule
            {
                StartTimeId = StartTimeId,
                EndTimeId = EndTimeId,
                MondaySelected = MondaySelected,
                TuesdaySelected = TuesdaySelected,
                WednesdaySelected = WednesdaySelected,
                ThursdaySelected = ThursdaySelected,
                FridaySelected = FridaySelected,
                SaturdaySelected = SaturdaySelected,
                SundaySelected = SundaySelected
            };
        }

        public class CreateBasicSchedulerRuleCommandHandler : IRequestHandler<CreateBasicScheduleRuleCommand, BasicBookingScheduleRule>
        {
            private readonly IApplicationDbContext _context;

            public CreateBasicSchedulerRuleCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<BasicBookingScheduleRule> Handle(CreateBasicScheduleRuleCommand request, CancellationToken cancellationToken)
            {

                BasicBookingScheduleRule entity = request.ToDomain();
                _context.BasicBookingScheduleRules.Add(request.ToDomain());

                await _context.SaveChangesAsync(cancellationToken);

                return entity;
            }
        }
    }
}
