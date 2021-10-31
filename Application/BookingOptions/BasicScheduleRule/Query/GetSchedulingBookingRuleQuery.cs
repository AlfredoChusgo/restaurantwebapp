using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.BookingOptions.OptionsFactory;
using Domain.Entities;
using MediatR;
using Microsoft.VisualBasic.CompilerServices;

namespace Application.BookingOptions.BasicScheduleRule.Query
{
    public class GetSchedulingBookingRuleQuery : IRequest<BasicBookingScheduleRuleVm>
    {
        public int Id { get; set; }

        public class GetBasicScheduleRuleHandler : IRequestHandler<GetSchedulingBookingRuleQuery, BasicBookingScheduleRuleVm>
        {
            public Task<BasicBookingScheduleRuleVm> Handle(GetSchedulingBookingRuleQuery request, CancellationToken cancellationToken)
            {
                BasicBookingScheduleRuleVm rule = BasicScheduleRuleFactory.GetBasicBookingScheduleOptionsVm();
                return Task.FromResult(rule);
            }
        }
    }
}
