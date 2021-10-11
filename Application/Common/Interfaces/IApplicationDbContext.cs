using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Booking.Queries;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<BookingItem> BookingItems { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
