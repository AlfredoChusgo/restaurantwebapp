using System;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using DateTime = System.DateTime;

namespace Application.Products.Commands
{
    public class CreateProductCommand :IRequest<Product>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public bool IsNew { get; set; }
        public string PriceSymbol { get; set; }

        public string ProductImageBase64 { get; set; }
        public CreateProductCommand(Product product)
        {
            Name = product.Name;
            Description = product.Description;
            Price = product.Price;
            IsNew = product.IsNew;
            PriceSymbol = product.PriceSymbol;
            ProductImageBase64 = product.ProductImageBase64;
        }

        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Product>
        {
            private readonly IApplicationDbContext _context;

            public CreateProductCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                Product item = new Product
                {
                    Id = 0,
                    Name = request.Name,
                    Description = request.Description,
                    Price = request.Price,
                    PriceSymbol = request.PriceSymbol,
                    IsNew = request.IsNew,
                    ProductImageBase64 = request.ProductImageBase64,
                    DateCreated = DateTime.Now
                };

                _context.Products.Add(item);

                await _context.SaveChangesAsync(cancellationToken);

                return item;
            }
        }
    }
}
