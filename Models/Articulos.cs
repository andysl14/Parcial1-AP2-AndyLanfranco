using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Parcial1_AP2_AndyLanfranco.Models
{
    public class Articulos
    {
        [Key]
        public int ProductoId { get; set; }

        [Required(ErrorMessage ="Este Campo esta vacio")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo Existencia esta vacio")]
        public int Existencia { get; set; }

        [Required(ErrorMessage = "El campo Costo esta vacio")]
        public decimal Costo { get; set; }

        [Required(ErrorMessage = "El Campo Valor Inventario esta vacio")]
        public decimal Valor_Inventario { get; set; }
    }
}
