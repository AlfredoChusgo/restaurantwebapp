using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.BookingOptions.Queries;
using Application.Common.Resources;

namespace Application.BookingOptions.OptionsFactory
{
    public class BookingOptionsFactory
    {
        public BookingOptionsVm GetBookingOptionsVm(Domain.Entities.BookingOption entity)
        {
            BookingOptionsVm vm = new BookingOptionsVm();
            vm.EarlyBookingOptions = GetEarlyBookingOptions();
            vm.MinPartySizeOptions = GetMinPartyOptions();
            vm.MaxPartySizeOptions = GetMaxPartyOptions();
            vm.LateBookingOptions= GetLateBookingOptions();
            vm.BookingOption.LateBooking = entity.LateBooking;
            vm.BookingOption.EarlyBooking= entity.EarlyBooking;
            vm.BookingOption.MaxPartySize = entity.MaxPartySize;
            vm.BookingOption.MinPartySize = entity.MinPartySize;

            return vm;
        }
        private DropDownItemInfo GetMinPartyOptions()
        {
            int count = 15;
            DropDownItemInfo options = new DropDownItemInfo();

            options.Label = StringConstants.SelectPartySize;

            for (int i = 1; i < count; i++)
            {
                options.DropDownDictionary.Add(i, i.ToString());
            }
            return options;
        }

        private DropDownItemInfo GetMaxPartyOptions()
        {
            int minParty = 2;
            int count = 20;
            DropDownItemInfo options = new DropDownItemInfo();

            options.Label = StringConstants.SelectPartySize;

            for (int i = minParty; i < count; i++)
            {
                options.DropDownDictionary.Add(i, i.ToString());
            }
            return options;
        }

        private DropDownItemInfo GetEarlyBookingOptions()
        {
            DropDownItemInfo options = new DropDownItemInfo();

            options.Label = StringConstants.Select;

            options.DropDownDictionary.Add(1, StringConstants.AnyTime);
            options.DropDownDictionary.Add(2, StringConstants.OneDayBefore);
            options.DropDownDictionary.Add(3, StringConstants.FifteenMinutesBefore);
            options.DropDownDictionary.Add(4, StringConstants.ThirtyMinutesBefore);
            options.DropDownDictionary.Add(5, StringConstants.OneHourBefore);
            options.DropDownDictionary.Add(6, StringConstants.OneWeekBefore);
            options.DropDownDictionary.Add(7, StringConstants.OneMonthBefore);

            return options;
        }

        private DropDownItemInfo GetLateBookingOptions()
        {
            DropDownItemInfo options = new DropDownItemInfo();

            options.Label = StringConstants.Select;

            options.DropDownDictionary.Add(1, StringConstants.AnyTime);
            options.DropDownDictionary.Add(2, StringConstants.OneDayBefore);
            options.DropDownDictionary.Add(3, StringConstants.FifteenMinutesBefore);
            options.DropDownDictionary.Add(4, StringConstants.ThirtyMinutesBefore);
            options.DropDownDictionary.Add(5, StringConstants.OneHourBefore);
            options.DropDownDictionary.Add(6, StringConstants.OneWeekBefore);
            options.DropDownDictionary.Add(7, StringConstants.OneMonthBefore);

            return options;
        }
    }
}
