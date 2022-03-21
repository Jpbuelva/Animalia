using Infraestructure.Model.Entity;
using System.Collections.Generic;

namespace Domain.Service.Interfaces
{
    public interface IRolService
    {
        List<Roles> GetAll();
    }
}
