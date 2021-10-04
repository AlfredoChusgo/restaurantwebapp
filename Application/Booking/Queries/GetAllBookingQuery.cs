using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using Domain.Entities;
using Domain.Enums;

namespace Application.Booking.Queries
{
    public class GetAllBookingQuery
    {
        public List<BookingItem> Execute()
        {
            List<BookingItem> list = new List<BookingItem>();
            //list.Add(new BookingItem
            //{
            //    Details = Faker.Lorem.Sentence(6),
            //    Email =
            //});

            var faker = new Faker<BookingItem>();
            faker.RuleFor(e => e.Email, f => f.Person.Email)
                .RuleFor(e=>e.Name, f => f.Name.FullName())
                .RuleFor(e=>e.Details,f=>f.Lorem.Sentence(6))
                .RuleFor(e=>e.PartySize,f=>f.Random.Int(2,12))
                .RuleFor(e=>e.Phone,f=>f.Person.Phone)
                .RuleFor(e=>e.Status,f=>f.PickRandom<BookingStatus>())
                .RuleFor(e=>e.Id,f=>f.IndexFaker);

            list = faker.Generate(50);


            return list;
        }
    }
}
