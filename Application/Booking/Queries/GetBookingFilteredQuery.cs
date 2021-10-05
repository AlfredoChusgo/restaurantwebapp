using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Enums;

namespace Application.Booking.Queries
{
    public class GetBookingFilteredQuery
    {
        private BookingStatus Status { get; }
        private bool ApplyFilter { get; }

        public GetBookingFilteredQuery(BookingStatus status, bool applyFilter)
        {
            Status = status;
            ApplyFilter = applyFilter;
        }

        public GetBookingsVm Execute()
        {
            List<BookingItem> query = new GetAllBookingQuery().Execute();

            if (ApplyFilter)
            {
                query = query.Where(e => e.Status == Status).ToList();
            }
            GetBookingsVm vm = new GetBookingsVm();
            vm.BookingList = query;
            vm.ItemCount = query.Count();

            return vm;
        }
    }
}
