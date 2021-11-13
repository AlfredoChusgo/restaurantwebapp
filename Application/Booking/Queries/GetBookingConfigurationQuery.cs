using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Booking.Queries
{
    public class GetBookingConfigurationQuery : IRequest<BookingConfigurationVm>
    {

        public class GetBookingConfigurationQueryHandler 
            : IRequestHandler<GetBookingConfigurationQuery, BookingConfigurationVm>
        {
            private readonly IApplicationDbContext _context;

            public GetBookingConfigurationQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<BookingConfigurationVm> Handle(GetBookingConfigurationQuery request, CancellationToken cancellationToken)
            {
                BookingConfigurationVm vm = new BookingConfigurationVm();

                vm.PartySizeDictionary = GetPartySizeList(_context);
                vm.StatusDictionary = GetStatusDictionary(_context);
                vm.DisabledDatesDictionary = GetDisabledDatesList(_context);

                return vm;
            }

            private List<DateTime> GetDisabledDatesList(IApplicationDbContext context)
            {
                List<DateTime> list = _context.SchedulingExceptionBookingRule
                    .Select(e=>e.Date).ToList();

                return list;
            }

            private Dictionary<int, string> GetStatusDictionary(IApplicationDbContext context)
            {
                return EnumDictionary<BookingStatus>();
            }

            private List<int> GetPartySizeList(IApplicationDbContext context)
            {
                BookingOption options = context.BookingOptions.FirstOrDefault();

                if (options.MinPartySize >= options.MaxPartySize)
                {
                    throw new Exception("MinPartySize must be greater that MaxPartySize");
                }

                List<int> result = new List<int>();

                for (int i = options.MinPartySize; i <= options.MaxPartySize; i++)
                {
                    result.Add(i);
                }

                return result;
            }

            public static Dictionary<int, string> EnumDictionary<T>()
            {
                if (!typeof(T).IsEnum)
                    throw new ArgumentException("Type must be an enum");
                return Enum.GetValues(typeof(T))
                    .Cast<T>()
                    .ToDictionary(t => (int)(object)t, t => t.ToString());
            }
        }
    }
}
