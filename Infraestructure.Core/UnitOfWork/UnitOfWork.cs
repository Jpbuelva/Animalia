using AutoMapper;
using Infraestructure.Core.Context;
using Infraestructure.Core.Interfaces;
using Infraestructure.Core.Repositories;
using Infraestructure.Model.Entity;
using System.Threading.Tasks;

namespace Infraestructure.Core.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContextSql _context;
        private readonly IUserRepository _userRepository ; 
        private readonly IRepository<UserToRol> _userToRolRepository;
        private readonly IRepository<Roles> _rolesToRolRepository;
        private readonly IMapper _mapper;
        public UnitOfWork(ContextSql context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IUserRepository UserRepository => _userRepository ?? new UserRepository(_mapper, _context);
        public IRepository<UserToRol> UserToRolRepository => _userToRolRepository ?? new BaseRepository<UserToRol>(_context);
        public IRepository<Roles> RolesRepository => _rolesToRolRepository ?? new BaseRepository<Roles>(_context);

     
        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task<bool> SaveChangesAsync()
        {
           return await _context.SaveChangesAsync() > 0 ;
        }
    }
}
