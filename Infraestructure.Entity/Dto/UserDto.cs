using Infraestructure.Entity.Request;
using System.Collections.Generic;

namespace Infraestructure.Entity.Dto
{
    public class UserDto
    {
        public int UserID { get; set; }
        public int Identification { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public string Description { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }
        public string UrlPhoto { get; set; }
        public bool HasPet { get; set; } 
    }
}
