using Microsoft.EntityFrameworkCore;
using rice_ecommerce.Domain.Entities;

namespace rice_ecommerce.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<RiceItem> RiceItems { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
