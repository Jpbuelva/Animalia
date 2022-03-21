using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Entity.Dto
{
   public class UserResult
    {
        public int UserID { get; set; }
        public int Identification { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public string Description { get; set; }
        public string DescriptionRol { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }
        public string UrlPhoto { get; set; }
        public bool HasPet { get; set; }
    }
}
