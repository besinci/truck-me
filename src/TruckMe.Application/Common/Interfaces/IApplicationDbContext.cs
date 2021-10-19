namespace TruckMe.Application.Common.Interfaces
{
    using System.Threading;
    using System.Threading.Tasks;

    public interface IApplicationDbContext
    {
        // DbSets...

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
