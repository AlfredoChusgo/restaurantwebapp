using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.BookingOptions.BasicScheduleRule.Command
{
    public class DeleteBasicScheduleRuleCommand : IRequest
    {
        public int Id { get; }

        public DeleteBasicScheduleRuleCommand(int id)
        {
            Id = id;
        }

        public class DeleteBasicScheduleRuleHandler : IRequestHandler<DeleteBasicScheduleRuleCommand>
        {
            private readonly IApplicationDbContext _context;

            public DeleteBasicScheduleRuleHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteBasicScheduleRuleCommand request, CancellationToken cancellationToken)
            {
                BasicBookingScheduleRule entity = await _context.BasicBookingScheduleRules.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(BookingItem), request.Id);
                }

                _context.BasicBookingScheduleRules.Remove(entity);
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
