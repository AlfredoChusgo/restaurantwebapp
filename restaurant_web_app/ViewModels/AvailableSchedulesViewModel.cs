using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using restaurant_web_app.Models;

namespace restaurant_web_app.ViewModels
{
    public class AvailableSchedulesViewModel
    {
        public List<BasicEntry> ListEntries { get; }

        public AvailableSchedulesViewModel(Dictionary<int, string> dictionary)
        {
            ListEntries = dictionary.Select(e => new BasicEntry
            {
                key = e.Key,
                value = e.Value
            }).ToList();
        }
    }
}
