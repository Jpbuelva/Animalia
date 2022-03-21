using Domain.Service.Interfaces;
using Infraestructure.Core.Interfaces;
using Infraestructure.Model.Entity;
using System.Collections.Generic;

namespace Domain.Service.Service
{
    public class RolService : IRolService
    {
        private readonly IUnitOfWork _unitOfWork;
        public RolService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Roles> GetAll()
        {
            return _unitOfWork.RolesRepository.GetAll();
        }

    }
}
