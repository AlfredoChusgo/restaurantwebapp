using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.BookingOptions.ExceptionBookingRule.Command
{
    public class DeleteSchedulingExceptionBookingRuleCommand : IRequest
    {
        public int Id { get; }

        public DeleteSchedulingExceptionBookingRuleCommand(int id)
        {
            Id = id;
        }

        public class DeleteSchedulingExceptionBookingRuleCommandHandler : IRequestHandler<DeleteSchedulingExceptionBookingRuleCommand>
        {
            private readonly IApplicationDbContext _context;

            public DeleteSchedulingExceptionBookingRuleCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteSchedulingExceptionBookingRuleCommand request, CancellationToken cancellationToken)
            {
                SchedulingExceptionBookingRule entity = await _context.SchedulingExceptionBookingRule.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(BookingItem), request.Id);
                }

                _context.SchedulingExceptionBookingRule.Remove(entity);
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
