using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Contact.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Products.Queries
{
    public class GetAllProductsQuery : IRequest<GetAllProductsVm>
    {

        public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, GetAllProductsVm>
        {
            private readonly IApplicationDbContext _context;

            public GetAllProductsQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<GetAllProductsVm> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
            {
                List<Product> contactUsList = await _context.Products.ToListAsync(cancellationToken: cancellationToken);

                GetAllProductsVm vm = new GetAllProductsVm();
                vm.Products = contactUsList;

                return vm;
            }
        }
    }
}
