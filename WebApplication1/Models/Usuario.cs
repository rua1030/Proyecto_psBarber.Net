using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Usuario
    {
        [Column("id_Usuario")]
        public int Id { get; set; }

        [Column("nombres")]
        public string Nombre { get; set; }

        [Column("pass")]
        public string Clave { get; set; }
        
        [Column("email")]
        public string Correo { get; set; }

        [Column("id_Rol")] // Nombre de la columna que almacena el ID del rol
        public int Id_Rol { get; set; } // Propiedad para almacenar el ID del rol
    }
}