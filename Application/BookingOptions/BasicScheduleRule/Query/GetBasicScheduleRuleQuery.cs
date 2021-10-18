using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.VisualBasic.CompilerServices;

namespace Application.BookingOptions.BasicScheduleRule.Query
{
    public class GetBasicScheduleRuleQuery : IRequest<BasicBookingScheduleRule>
    {
        public int Id { get; set; }

        public class GetBasicScheduleRuleHandler : IRequestHandler<GetBasicScheduleRuleQuery, BasicBookingScheduleRule>
        {
            private readonly IApplicationDbContext _context;

            public GetBasicScheduleRuleHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<BasicBookingScheduleRule> Handle(GetBasicScheduleRuleQuery request, CancellationToken cancellationToken)
            {
                BasicBookingScheduleRule rule = await _context.BasicBookingScheduleRules.FindAsync(request.Id);
                return rule;
            }
        }
    }
}
