using AutoMapper;
using Domain.Service.Interfaces;
using Infraestructure.Core.Interfaces;
using Infraestructure.Entity.Request;
using Infraestructure.Model.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Service.Service
{
    public class UserToRolService : IUserToRolService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserToRolService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Insert(UserToRolRequest requests)
        {

            List<UserToRol> addUser = new List<UserToRol>();
            if (requests.RolDetails.Any(x => x.RolID == 6) && requests.RolDetails.Count() > 1)
            {
                return false;
            }  
            else
            {
                var typeCivil = _unitOfWork.UserToRolRepository.Any(x => x.RolesID == 6 && x.UserID == requests.UserID && x.Estado == true);
                if (typeCivil)
                {
                    return false;
                }
                foreach (var item in requests.RolDetails.Distinct())
                {
                  
                    if (item.RolID == 1 || item.RolID == 2 || item.RolID == 3)
                    {
                      
                        var validation = _unitOfWork.UserToRolRepository.Any(x => x.RolesID == item.RolID && x.Estado == true);

                        if (!validation)
                        {
                            UserToRol userToRol = new UserToRol
                            {
                                Estado = item.Estado,
                                RolesID = item.RolID,
                                UserID = requests.UserID
                            };
                            addUser.Add(userToRol);
                        }
                    }
                    else
                    {
                        bool exit = _unitOfWork.UserToRolRepository.Any(x => x.RolesID == item.RolID && x.UserID == requests.UserID && x.Estado == true);
                        if (!exit)
                        {
                            UserToRol userToRol = new UserToRol
                            {
                                Estado = item.Estado,
                                RolesID = item.RolID,
                                UserID = requests.UserID
                            };
                            addUser.Add(userToRol);
                        }                       
                    }
                 
                }
                await _unitOfWork.UserToRolRepository.AddRange(addUser);
                return await _unitOfWork.SaveChangesAsync();
            }

        }

        public async Task<bool> Update(UserUpdateRequest userToRol)
        {
            var userUpdate = await _unitOfWork.UserToRolRepository.Find(x=>x.UserID==userToRol.UserID && x.RolesID==userToRol.RolesID);

            if (userUpdate !=null)
            {
                userUpdate.Estado = userToRol.Estado;
                _unitOfWork.UserToRolRepository.Update(userUpdate);
                return await _unitOfWork.SaveChangesAsync();

            }
            return false;

        }
    }
}
