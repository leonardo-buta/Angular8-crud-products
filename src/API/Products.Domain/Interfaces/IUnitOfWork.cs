using System;
using System.Threading.Tasks;

namespace Products.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Commit();
    }
}
