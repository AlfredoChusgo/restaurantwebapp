using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.BookingOptions.Queries
{
    public class BookingOptionsVm
    {
        public BookingOption BookingOption { get; set; }
        public DropDownItemInfo MinPartySizeOptions { get; set; }
        public DropDownItemInfo MaxPartySizeOptions { get; set; }
        public DropDownItemInfo EarlyBookingOptions { get; set; }
        public DropDownItemInfo LateBookingOptions { get; set; }
        public DropDownItemInfo TimeInterval { get; set; }


        public BookingOptionsVm()
        {
            MinPartySizeOptions = new DropDownItemInfo();
            MaxPartySizeOptions = new DropDownItemInfo();
            EarlyBookingOptions = new DropDownItemInfo();
            LateBookingOptions = new DropDownItemInfo();
            TimeInterval = new DropDownItemInfo();
            BookingOption = new BookingOption();
        }
    }

    public class DropDownItemInfo
    {
        public string Label { get; set; }
        public Dictionary<int, string> DropDownDictionary { get; }

        public DropDownItemInfo()
        {
            Label = "";
            DropDownDictionary = new Dictionary<int, string>();
        }
    }
}
