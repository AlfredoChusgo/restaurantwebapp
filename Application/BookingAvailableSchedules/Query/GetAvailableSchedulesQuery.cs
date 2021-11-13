using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.BookingOptions.OptionsFactory;
using Application.Common.Interfaces;
using MediatR;

namespace Application.BookingAvailableSchedules.Query
{
    public class GetAvailableSchedulesQuery : IRequest<List<string>>
    {
        
        public string DateTimeInMilliseconds{ get; set; }

        public class GetAvailableSchedulesQueryHandler : IRequestHandler<GetAvailableSchedulesQuery, List<string>>
        {
            private readonly IApplicationDbContext _context;
            public GetAvailableSchedulesQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<List<string>> Handle(GetAvailableSchedulesQuery request, CancellationToken cancellationToken)
            {
                DateTime date = GetDateTimeFromMilliseconds(request.DateTimeInMilliseconds);
                List<string> result = new List<string>();
                result.Add("13:00");
                result.Add("14:00");
                result.Add("15:00");
                result.Add("16:00");
                return result;
            }

            public Dictionary<int, string> GetAvailableTimes()
            {
                List<DateTime> dateTimes = BasicScheduleRuleFactory.GetBaseDateTimes();

                

                return null;

            }

            public DateTime GetDateTimeFromMilliseconds(string milliseconds)
            {
                double ticks = double.Parse(milliseconds);
                TimeSpan time = TimeSpan.FromMilliseconds(ticks);
                DateTime date = new DateTime(1970, 1, 1) + time;

                return date;
            }
        }

    }
}
