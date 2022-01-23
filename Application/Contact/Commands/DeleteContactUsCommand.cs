using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Contact.Commands
{
    public class DeleteContactUsCommand : IRequest
    {
        public int Id { get; }

        public DeleteContactUsCommand(int id)
        {
            Id = id;
        }

        public class DeleteContactUsCommandHandler : IRequestHandler<DeleteContactUsCommand>
        {
            private readonly IApplicationDbContext _context;

            public DeleteContactUsCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteContactUsCommand request, CancellationToken cancellationToken)
            {
                ContactUs entity = await _context.ContactUs.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(ContactUs), request.Id);
                }

                _context.ContactUs.Remove(entity);
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
