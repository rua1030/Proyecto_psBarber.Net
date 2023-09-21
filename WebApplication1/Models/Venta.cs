using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Venta
    {
        [Key]
        public int Id_Venta { get; set; }

        public DateTime fecha {get; set; }

        public int total { get; set; }

        
        public int id_Cliente { get; set; }
        public Cliente Cliente { get; set; } //relacion de muchos a uno para relacionar las tablas


        public List<Detalle_Venta> Detalle_Ventas { get; set; } //ralacion de muchos a uno de venta con detalle de venta


    }
}
