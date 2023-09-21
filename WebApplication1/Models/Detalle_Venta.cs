using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Detalle_Venta
    {
        [Key]
        public int id_Detalle_Venta { get; set; }

        public int subtotal { get; set; }

        public int id_Servicio { get; set; }

        public int id_Venta { get; set; }

        public Venta Venta { get; set; }
    }
}
