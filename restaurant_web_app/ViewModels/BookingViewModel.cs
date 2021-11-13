using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Booking.Queries;
using restaurant_web_app.Models;

namespace restaurant_web_app.ViewModels
{
    public class BookingViewModel
    {
        public List<BasicEntry> PartySize { get; }
        public List<BasicEntry> BookingStatus { get; }
        public List<string> DisabledDates { get; }

        public BookingViewModel()
        {
            PartySize = new List<BasicEntry>();
            BookingStatus = new List<BasicEntry>();
            DisabledDates = new List<string>();
        }

        public BookingViewModel(BookingConfigurationVm vm)
        {
            PartySize = vm.PartySizeDictionary.Select(e => new BasicEntry
            {
                Key = e,
                Value = e.ToString()
            }).ToList();

            BookingStatus = vm.StatusDictionary.Select(e => new BasicEntry
            {
                Key = e.Key,
                Value = e.Value
            }).ToList();
            DisabledDates = vm.DisabledDatesDictionary.Select(e=>e.Date.ToString("yyyy/MM/dd HH:mm:ss")).ToList();
        }
    }
}
