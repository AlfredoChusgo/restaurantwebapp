using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Booking.Queries;
using Application.Common.Interfaces;
using Bogus;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Contact.Queries
{
    public class GetAllContactUsQuery : IRequest<List<ContactUs>>
    {

        public class GetAllContactUsQueryHandler : IRequestHandler<GetAllContactUsQuery, List<ContactUs>>
        {
            private readonly IApplicationDbContext _context;

            public GetAllContactUsQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<List<ContactUs>> Handle(GetAllContactUsQuery request, CancellationToken cancellationToken)
            {
                List<ContactUs> contactUsList = await _context.ContactUs.ToListAsync(cancellationToken: cancellationToken);

                return contactUsList;
            }
        }
    }
}
