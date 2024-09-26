using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CRUD_ENTITY_FRAMEWORK
{
    public class Producto
    {
        [Key]
        public int Id_Producto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Marca { get; set; }
        public decimal Precio { get; set; }
        public decimal Stock { get; set; }
    }
}
