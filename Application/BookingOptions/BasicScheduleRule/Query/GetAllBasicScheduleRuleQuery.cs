using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.BookingOptions.BasicScheduleRule.Query
{
    public class GetAllBasicScheduleRuleQuery : IRequest<List<BasicBookingScheduleRule>>
    {
        public class GetAllBasicScheduleRuleHandler : IRequestHandler<GetAllBasicScheduleRuleQuery, List<BasicBookingScheduleRule>>
        {
            private readonly IApplicationDbContext _context;

            public GetAllBasicScheduleRuleHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public Task<List<BasicBookingScheduleRule>> Handle(GetAllBasicScheduleRuleQuery request, CancellationToken cancellationToken)
            {
                List<BasicBookingScheduleRule> list = _context.BasicBookingScheduleRules.ToList();

                return Task.FromResult(list);
            }
        }
    }
}
