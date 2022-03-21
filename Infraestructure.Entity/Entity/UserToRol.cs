using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infraestructure.Model.Entity
{
    public class UserToRol
    {
        [Key]
        public int UserToRolID { get; set; }

        [ForeignKey("RolesID")]
        public int RolesID { get; set; }
        public virtual Roles Roles { get; set; }


        [ForeignKey("UserID")]
        public int UserID { get; set; }   
        public virtual User User { get; set; }

        public bool Estado { get; set; }

    }
}
