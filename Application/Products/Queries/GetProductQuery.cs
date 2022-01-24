using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Contact.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Products.Queries
{
    public class GetProductQuery : IRequest<Product>
    {
        public int Id { get; set; }

        public GetProductQuery(int id)
        {
            Id = id;
        }

        private class GetProductQueryHandler : IRequestHandler<GetProductQuery, Product>
        {
            private readonly IApplicationDbContext _context;

            public GetProductQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Product> Handle(GetProductQuery request, CancellationToken cancellationToken)
            {
                Product entity = await _context.Products.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(BookingItem), request.Id);
                }

                return entity;
            }
        }
    }
}
