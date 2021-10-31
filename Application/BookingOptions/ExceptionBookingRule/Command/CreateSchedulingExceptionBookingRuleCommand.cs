using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.BookingOptions.ExceptionBookingRule.Command
{
    public class CreateSchedulingExceptionBookingRuleCommand : IRequest<SchedulingExceptionBookingRule>
    {
        public DateTime Date { get; set; }

        public class CreateSchedulingExceptionBookingRuleHandler : IRequestHandler<CreateSchedulingExceptionBookingRuleCommand, SchedulingExceptionBookingRule>
        {
            private readonly IApplicationDbContext _context;

            public CreateSchedulingExceptionBookingRuleHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<SchedulingExceptionBookingRule> Handle(CreateSchedulingExceptionBookingRuleCommand request, CancellationToken cancellationToken)
            {
                SchedulingExceptionBookingRule entity = _context.SchedulingExceptionBookingRule
                    .FirstOrDefault(e => e.Date.Equals(request.Date));

                if (entity == null)
                {
                    entity = new SchedulingExceptionBookingRule
                    {
                        Date = request.Date
                    };
                    _context.SchedulingExceptionBookingRule.Add(entity);

                    await _context.SaveChangesAsync(cancellationToken);
                }

                return entity;
            }
        }
    }
}
