using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Entity.Dto
{
   public class UserResponse
    {
        public UserResponse()
        {
            userDto = new UserDto();
            Roles = new List<RolesResponse>();
        }
        public UserDto userDto { get; set; }
        public List<RolesResponse>  Roles { get; set; }

    }
    public class RolesResponse
    {
       
        public string DescriptionRol { get; set; }

    }

}
