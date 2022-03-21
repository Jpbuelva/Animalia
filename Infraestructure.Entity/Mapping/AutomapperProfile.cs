using AutoMapper;
using Infraestructure.Entity.Dto;
using Infraestructure.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Entity.Mapping
{
  public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UserDto, UserResult>().ReverseMap();

        }
    }
}
