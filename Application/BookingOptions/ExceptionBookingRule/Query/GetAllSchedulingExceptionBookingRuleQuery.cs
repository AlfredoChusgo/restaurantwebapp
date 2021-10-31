using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.BookingOptions.BasicScheduleRule.Query;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.BookingOptions.ExceptionBookingRule.Query
{
    public class GetAllSchedulingExceptionBookingRuleQuery : IRequest<List<SchedulingExceptionBookingRule>>
    {
        public class GetAllSchedulingExceptionBookingRuleQueryHandler : IRequestHandler<GetAllSchedulingExceptionBookingRuleQuery, List<SchedulingExceptionBookingRule>>
        {
            private readonly IApplicationDbContext _context;

            public GetAllSchedulingExceptionBookingRuleQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public Task<List<SchedulingExceptionBookingRule>> Handle(GetAllSchedulingExceptionBookingRuleQuery request, CancellationToken cancellationToken)
            {
                List<SchedulingExceptionBookingRule> list = _context.SchedulingExceptionBookingRule.ToList();

                return Task.FromResult(list);
            }
        }
    }
}
