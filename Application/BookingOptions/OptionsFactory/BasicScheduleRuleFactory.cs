using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.BookingOptions.BasicScheduleRule.Query;
using Application.BookingOptions.Queries;
using Application.Common.Resources;

namespace Application.BookingOptions.OptionsFactory
{
    public class BasicScheduleRuleFactory
    {
        private const string TimeFormat = "hh:mm tt";
        public static BasicBookingScheduleRuleVm GetBasicBookingScheduleOptionsVm()
        {
            BasicBookingScheduleRuleVm vm = new BasicBookingScheduleRuleVm();
            vm.StartTimeBookingRule = GetTimeBookingRuleInfo();
            vm.EndTimeBookingRule = GetTimeBookingRuleInfo();
            return vm;
        }

        private static DropDownItemInfo GetTimeBookingRuleInfo()
        {
            DropDownItemInfo info = new DropDownItemInfo();
            List<DateTime> dateTimes = GetBaseDateTimes();
            dateTimes.Select((value,
                    i) => new
                {
                    Key = i,
                    Value = value.ToString(TimeFormat)
                    })
                .ToList()
                .ForEach(e => info.DropDownDictionary.Add(e.Key,
                    e.Value));

            return info;
        }

        public static string GetTimeFromTimeId(int timeId)
        {
            List<DateTime> dateTimes = GetBaseDateTimes();

            DateTime dateTime = dateTimes[timeId];

            return dateTime.ToString(TimeFormat);
        }
        

        internal static int DateTimeToInt(DateTime dateTime)
        {
            List<DateTime> dateTimes = GetBaseDateTimes();

            int index = dateTimes.IndexOf(dateTime);

            if (index < 0)
            {
                throw new Exception($"DateTime : {dateTime} is not valid");
            }

            return index;
        }
        
        public static List<DateTime> GetBaseDateTimes()
        {
            DateTime baseDateTime = new DateTime(1991, 1, 1, 5, 0, 0);

            List<DateTime> dateTimes = new List<DateTime>();

            for (int i = 0; i < 38; i++)
            {
                dateTimes.Add(baseDateTime);
                baseDateTime = baseDateTime.AddMinutes(30.0);
            }

            return dateTimes;
        }
    }
}
