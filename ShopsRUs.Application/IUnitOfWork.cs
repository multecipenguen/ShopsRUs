using System;
using System.Threading.Tasks;

namespace ShopsRUs.Application.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync();

        Task BeginTransactionAsync();

        Task CommitTransactionAsync();

        void RollbackTransaction();
    }
}
