using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Bogus;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Booking.Queries
{
    public class GetAllBookingQuery : IRequest<GetBookingsVm>
    {

        public class GetAllBookingQueryHandler : IRequestHandler<GetAllBookingQuery, GetBookingsVm>
        {
            private readonly IApplicationDbContext _context;

            public GetAllBookingQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<GetBookingsVm> Handle(GetAllBookingQuery request, CancellationToken cancellationToken)
            {
                GetBookingsVm vm = new GetBookingsVm();
                vm.BookingList = await _context.BookingItems.ToListAsync(cancellationToken: cancellationToken);
                vm.ItemCount = vm.BookingList.Count;
                vm.AlertData = AlertData.MakeInfoAlert();

                return vm;
            }
        }

        public List<BookingItem> Execute()
        {
            List<BookingItem> list = GetQuery();


            return list;
        }

        private List<BookingItem> GetQuery()
        {
            List<BookingItem> list = new List<BookingItem>();

            var faker = new Faker<BookingItem>();
            faker.RuleFor(e => e.Email, f => f.Person.Email)
                .RuleFor(e => e.Name, f => f.Name.FullName())
                .RuleFor(e => e.Details, f => f.Lorem.Sentence(6))
                .RuleFor(e => e.PartySize, f => f.Random.Int(2, 12))
                .RuleFor(e => e.Phone, f => f.Person.Phone)
                .RuleFor(e => e.Status, f => f.PickRandom<BookingStatus>())
                .RuleFor(e=>e.Date,f=>f.Date.Recent())
                .RuleFor(e => e.Id, f => f.Random.Int(1,500));

            list = faker.Generate(50);

            return list;
        }

        public List<BookingItem> SeedData(int count)
        {
            List<BookingItem> list = new List<BookingItem>();

            var faker = new Faker<BookingItem>();
            faker.RuleFor(e => e.Email, f => f.Person.Email)
                .RuleFor(e => e.Name, f => f.Name.FullName())
                .RuleFor(e => e.Details, f => f.Lorem.Sentence(6))
                .RuleFor(e => e.PartySize, f => f.Random.Int(2, 12))
                .RuleFor(e => e.Phone, f => f.Person.Phone)
                .RuleFor(e => e.Status, f => f.PickRandom<BookingStatus>())
                .RuleFor(e => e.Date, f => f.Date.Recent());
                //.RuleFor(e => e.Id, f => f.IndexFaker);

            list = faker.Generate(count);

            return list;
        }
    }
}
