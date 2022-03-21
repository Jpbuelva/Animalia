using Infraestructure.Entity.Dto;
using Infraestructure.Model.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infraestructure.Core.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<UserResponse> GetFilters(int? identification, string name, string spice, bool? hasPet);
        Task<CollectionResponse> GetAllUser();
    }
}
