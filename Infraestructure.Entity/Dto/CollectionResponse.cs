using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Entity.Dto
{
    public class CollectionResponse
    {
        public CollectionResponse()
        {
            listResult = new List<UserResponse>();
        }
        public List<UserResponse> listResult { get; set; }

    }
}
