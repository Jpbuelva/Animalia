using System.Collections.Generic;

namespace Infraestructure.Entity.Request
{
    public class UserToRolRequest
    {
        public int UserID { get; set; }
        public List<RolDetails> RolDetails { get; set; }

    }

    public class RolDetails
    {
        public int RolID { get; set; }
        public bool Estado { get; set; } 

    }
}
