using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Products.Commands
{
    public class DeleteProductCommand : IRequest
    {
        public int Id { get; }

        public DeleteProductCommand(int id)
        {
            Id = id;
        }

        public class DeleteContactUsCommandHandler : IRequestHandler<DeleteProductCommand>
        {
            private readonly IApplicationDbContext _context;

            public DeleteContactUsCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
            {
                Product entity = await _context.Products.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(ContactUs), request.Id);
                }

                _context.Products.Remove(entity);
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
