using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Cliente
    {
        [Key]
        [Column("id_Cliente")]
        public int  Id { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; }

        [Column("telefono")]
        public string Telefono { get; set; }

        [Column("email")]
        public string Correo { get; set; }

        [Column("documento")]
        public string Documento { get; set; }
        public List<Venta> Venta { get; set; }
    }
}
