using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Rol

    {
        [Key]   
        public int id_Rol { get; set; }
        public string nombre { get; set; }
    }
}
