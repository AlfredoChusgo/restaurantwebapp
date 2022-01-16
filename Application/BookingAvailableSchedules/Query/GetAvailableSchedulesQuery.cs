using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.BookingOptions.OptionsFactory;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.BookingAvailableSchedules.Query
{
    public class GetAvailableSchedulesQuery : IRequest<Dictionary<int, string>>
    {
        
        public string DateTimeInStringFormat{ get; set; }

        public class GetAvailableSchedulesQueryHandler : IRequestHandler<GetAvailableSchedulesQuery, Dictionary<int, string>>
        {
            private readonly IApplicationDbContext _context;
            public GetAvailableSchedulesQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Dictionary<int, string>> Handle(GetAvailableSchedulesQuery request, CancellationToken cancellationToken)
            {
                DateTime date = DateTime.ParseExact(request.DateTimeInStringFormat, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);


                DayOfWeek dayOfWeekSelected = date.DayOfWeek;

                Func<BasicBookingScheduleRule, bool> filterByDay = delegate (BasicBookingScheduleRule rule)
                {
                    List<DayOfWeek> listOfDays = ToDayOfWeeks(rule);

                    if (listOfDays.Contains(dayOfWeekSelected))
                    {
                        return true;
                    }
                    return false;
                };

                List<BasicBookingScheduleRule> rules = _context.BasicBookingScheduleRules.Where(filterByDay).ToList();
                List<int> listDateTimesId = new List<int>();

                rules.ForEach(e =>
                {
                    for (int i = e.StartTimeId; i <= e.EndTimeId; i++)
                    {
                        if (!listDateTimesId.Contains(i))
                        {
                            listDateTimesId.Add(i);
                        }
                    }
                });

                List<DateTime> dateTimes = BasicScheduleRuleFactory.GetBaseDateTimes();

                Dictionary<int,string> dictionary = new Dictionary<int, string>();

                listDateTimesId.ForEach(e =>
                {
                    DateTime date = dateTimes[e];
                    dictionary.Add(e, date.ToString(BasicScheduleRuleFactory.TimeFormat));
                });

                //List<DateTime> filteredDateTimes = dateTimes.Where((e, index) => listDateTimesId.Contains(index)).ToList();

                //Dictionary<int, DateTime> result = new Dictionary<int, DateTime>();
                return dictionary;
            }

            private List<DayOfWeek> ToDayOfWeeks(BasicBookingScheduleRule rule)
            {
                List<DayOfWeek> list = new List<DayOfWeek>();

                if (rule.MondaySelected)
                {
                    list.Add(DayOfWeek.Monday);
                }
                if (rule.TuesdaySelected)
                {
                    list.Add(DayOfWeek.Tuesday);
                }
                if (rule.WednesdaySelected)
                {
                    list.Add(DayOfWeek.Wednesday);
                }
                if (rule.ThursdaySelected)
                {
                    list.Add(DayOfWeek.Thursday);
                }
                if (rule.FridaySelected)
                {
                    list.Add(DayOfWeek.Friday);
                }

                if (rule.SaturdaySelected)
                {
                    list.Add(DayOfWeek.Saturday);
                }
                if (rule.SundaySelected)
                {
                    list.Add(DayOfWeek.Sunday);
                }

                return list;
            }


            public List<DateTime> GetAvailableTimes()
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
