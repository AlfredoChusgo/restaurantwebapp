using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.BookingOptions.ExceptionBookingRule.Query
{
    public class GetSchedulingExceptionBookingRuleQuery : IRequest<SchedulingExceptionBookingRule>
    {
        public int Id { get; set; }

        public class GetSchedulingExceptionBookingRuleQueryHandler : IRequestHandler<GetSchedulingExceptionBookingRuleQuery, SchedulingExceptionBookingRule>
        {
            private readonly IApplicationDbContext _context;

            public GetSchedulingExceptionBookingRuleQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<SchedulingExceptionBookingRule> Handle(GetSchedulingExceptionBookingRuleQuery request, CancellationToken cancellationToken)
            {
                SchedulingExceptionBookingRule rule = await _context.SchedulingExceptionBookingRule.FindAsync(request.Id);
                return rule;
            }
        }
    }
}
