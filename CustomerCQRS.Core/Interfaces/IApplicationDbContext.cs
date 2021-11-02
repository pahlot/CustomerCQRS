using CustomerCQRS.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerCQRS.Core.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Customer> Customers { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
