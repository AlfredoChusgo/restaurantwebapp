using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.BookingOptions.ExceptionBookingRule.Command
{
    public class UpdateSchedulingExceptionBookingRuleCommand : IRequest<SchedulingExceptionBookingRule>
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public class UpdateSchedulingExceptionBookingRuleCommandHandler : IRequestHandler<UpdateSchedulingExceptionBookingRuleCommand, SchedulingExceptionBookingRule>
        {
            private readonly IApplicationDbContext _context;

            public UpdateSchedulingExceptionBookingRuleCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<SchedulingExceptionBookingRule> Handle(UpdateSchedulingExceptionBookingRuleCommand request, CancellationToken cancellationToken)
            {
                SchedulingExceptionBookingRule entity = await _context.SchedulingExceptionBookingRule.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(BasicBookingScheduleRule), request.Id);
                }

                entity.Date = request.Date;

                await _context.SaveChangesAsync(cancellationToken);
                
                return entity;
            }
        }
    }
}
