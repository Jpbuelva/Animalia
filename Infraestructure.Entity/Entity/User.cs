using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Infraestructure.Model.Entity
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public int Identification { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public string Description { get; set; }

        public int MyProperty { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }
        public string UrlPhoto { get; set; }
        public bool HasPet { get; set; }
        public virtual List<UserToRol> UserToRols { get; set; }

    }
}
