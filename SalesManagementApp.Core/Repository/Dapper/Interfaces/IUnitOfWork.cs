using System;

namespace SalesManagementApp.Core.Dapper.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Dispose(bool disposing);
        IDapperRepository<TEntity> Repository<TEntity>() where TEntity : class;
        void Commit();
        void Rollback();
    }
}
