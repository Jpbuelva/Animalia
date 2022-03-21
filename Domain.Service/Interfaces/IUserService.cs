using Infraestructure.Entity.Dto;
using Infraestructure.Model.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Service.Interfaces
{
    public interface IUserService
    {
        //Task<UserDto> Get(int Identification);
        Task<CollectionResponse> GetAll();
        Task<bool> Insert(List<UserDto> user );
        Task<UserResponse> Get(int? identification, string name, string spice, bool? hasPet);
        Task<bool> Update(UserDto user );
        Task<bool> Delete(int identification);
    }
}