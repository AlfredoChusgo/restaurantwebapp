using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Booking.Commands
{
    public class UpdateBasicScheduleRuleCommand : IRequest<BasicBookingScheduleRule>
    {
        public int Id { get; set; }
        public int StartTimeId { get; set; }
        public int EndTimeId { get; set; }
        public bool MondaySelected { get; set; }
        public bool TuesdaySelected { get; set; }
        public bool WednesdaySelected { get; set; }
        public bool ThursdaySelected { get; set; }
        public bool FridaySelected { get; set; }
        public bool SaturdaySelected { get; set; }
        public bool SundaySelected { get; set; }


        public class UpdateBasicScheduleRuleCommandHandler : IRequestHandler<UpdateBasicScheduleRuleCommand, BasicBookingScheduleRule>
        {
            private readonly IApplicationDbContext _context;

            public UpdateBasicScheduleRuleCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<BasicBookingScheduleRule> Handle(UpdateBasicScheduleRuleCommand request, CancellationToken cancellationToken)
            {
                BasicBookingScheduleRule entity = await _context.BasicBookingScheduleRules.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(BasicBookingScheduleRule), request.Id);
                }

                entity.StartTimeId = request.StartTimeId;
                entity.EndTimeId = request.EndTimeId;
                entity.MondaySelected = request.MondaySelected;
                entity.TuesdaySelected= request.TuesdaySelected;
                entity.WednesdaySelected = request.WednesdaySelected;
                entity.ThursdaySelected= request.ThursdaySelected;
                entity.FridaySelected= request.FridaySelected;
                entity.SaturdaySelected= request.SaturdaySelected;
                entity.SundaySelected= request.SundaySelected;

                await _context.SaveChangesAsync(cancellationToken);
                
                return entity;
            }
        }
    }
}
