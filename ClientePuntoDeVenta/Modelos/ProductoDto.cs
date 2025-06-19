using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientePuntoDeVenta.Modelos
{
    public class ProductoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
    }
}
