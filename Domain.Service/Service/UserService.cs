using AutoMapper;
using Domain.Service.Interfaces;
using Infraestructure.Core.Interfaces;
using Infraestructure.Entity.Dto;
using Infraestructure.Model.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Service.Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CollectionResponse> GetAll()
        {
            return await _unitOfWork.UserRepository.GetAllUser();
        }
        public async Task<UserResponse> Get(int? identification, string name, string spice, bool? hasPet)
        {
            return await _unitOfWork.UserRepository.GetFilters(identification, name, spice, hasPet);
        }

        public async Task<bool> Insert(List<UserDto> user)
        {
            List<User> listUser = _mapper.Map<List<User>>(user);
            await _unitOfWork.UserRepository.AddRange(listUser);
            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> Update(UserDto user)
        {
            var userRestult = await _unitOfWork.UserRepository.GetById(user.Identification);
            if (userRestult != null)
            {
                userRestult.Description = user.Description;
                userRestult.Name = user.Name;
                userRestult.Species = user.Species;
                userRestult.HasPet = user.HasPet;
                _unitOfWork.UserRepository.Update(userRestult);
            }
            return await _unitOfWork.SaveChangesAsync();
        }
        public async Task<bool> Delete(int identification)
        {
            var userRestult = await _unitOfWork.UserRepository.GetById(identification);
            if (userRestult != null)
            {
                await _unitOfWork.UserRepository.Delete(userRestult.UserID);
            }
            return await _unitOfWork.SaveChangesAsync();
        }


    }
}
