using AutoMapper;
using Infraestructure.Core.Context;
using Infraestructure.Core.Interfaces;
using Infraestructure.Entity.Dto;
using Infraestructure.Model.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Core.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly IMapper _mapper;

        public ContextSql Context
        {
            get
            {
                return (ContextSql) _context;
            }
        }
        public UserRepository(IMapper mapper,   ContextSql context ) : base(context)
        {
            _mapper = mapper;
        }
    

        public async Task<UserResponse> GetFilters(int? identification, string name, string spice, bool? hasPet)
        {
            UserResponse filterResult = new UserResponse { };
            var user = await Context.User.Where(x => x.Identification == identification || x.Name == name
                                                    || x.Species == spice || x.HasPet == hasPet ).Include(o=>o.UserToRols ).FirstOrDefaultAsync();
            filterResult.userDto = _mapper.Map<UserDto>(user);

            if (user != null && user.UserToRols.Count > 0)
            {
                foreach (var item in user.UserToRols.Where(x=>x.Estado))
                {
                    var rol = await Context.Roles.Where(x => x.RolesID == item.RolesID).FirstOrDefaultAsync();
                    filterResult.Roles.Add(new RolesResponse { DescriptionRol = rol.Description });                  
                }
            }    
            return filterResult;
        }

        public async Task<CollectionResponse> GetAllUser()
        {
            CollectionResponse filterResult = new CollectionResponse { };
            List<int> group = new List<int>();

            var userList = await Context.User.ToListAsync();
            foreach (var item in userList)
            {
                UserResponse userResponse = new UserResponse();

                userResponse.userDto = _mapper.Map<UserDto>(item);
                var roles = Context.UserToRol.Where(x => x.UserID == item.UserID).Include(o => o.Roles).ToList();
                if (roles.Count() > 0 )
                {
                    foreach (var rol in roles.Where(x=>x.Estado))
                    {
                        userResponse.Roles.Add(new RolesResponse { DescriptionRol = rol.Roles.Description });
                    }
                }
                filterResult.listResult.Add(userResponse);
            }       
            return filterResult;
        }

        
       
    }
}
