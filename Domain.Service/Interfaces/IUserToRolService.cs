using Infraestructure.Entity.Request;
using Infraestructure.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.Interfaces
{
    public interface IUserToRolService
    {
 
        Task<bool> Insert(UserToRolRequest requests);
        Task<bool> Update(UserUpdateRequest userToRol); 
    }
}
