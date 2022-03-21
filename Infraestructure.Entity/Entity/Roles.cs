using System.ComponentModel.DataAnnotations;

namespace Infraestructure.Model.Entity
{
    public class Roles
    {
        [Key]
        public int RolesID { get; set; }
        public string Description { get; set; }

    }
}
