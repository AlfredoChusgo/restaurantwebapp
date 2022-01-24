using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Services.EmailLayer;
using Application.Services.EmailLayer.Model;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Products.Commands
{
    public class UpdateProductCommand : IRequest<Product>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public bool IsNew { get; set; }
        public string PriceSymbol { get; set; }

        public string ProductImageBase64 { get; set; }
        public UpdateProductCommand(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Description = product.Description;
            Price = product.Price;
            PriceSymbol = product.PriceSymbol;
            IsNew = product.IsNew;
            ProductImageBase64 = product.ProductImageBase64;

        }

        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Product>
        {
            private readonly IApplicationDbContext _context;

            public UpdateProductCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
            {
                Product entity = await _context.Products.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Product), request.Id);
                }
                
                entity.Id = request.Id;
                entity.Name = request.Name;
                entity.Description = request.Description;
                entity.Price = request.Price;
                entity.PriceSymbol = request.PriceSymbol;
                entity.IsNew = request.IsNew;
                entity.DateUpdated = DateTime.Now;
                entity.ProductImageBase64 = request.ProductImageBase64;

                await _context.SaveChangesAsync(cancellationToken);

                return entity;
            }
        }
    }
}
