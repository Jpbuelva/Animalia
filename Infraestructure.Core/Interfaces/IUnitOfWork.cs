
using Infraestructure.Model.Entity;
using System;
using System.Threading.Tasks;

namespace Infraestructure.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {

        IUserRepository UserRepository { get; }

        IRepository<UserToRol> UserToRolRepository { get; }
        IRepository<Roles> RolesRepository { get; }

        void SaveChanges();
        Task<bool> SaveChangesAsync();
    }
}
