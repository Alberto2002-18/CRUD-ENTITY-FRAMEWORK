using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CRUD_ENTITY_FRAMEWORK
{
    public class ProductosContext : DbContext
    {
        public ProductosContext() : base("name=ProductosContext")
        {
        }

        public DbSet<Producto> Productos { get; set; }
    }
}
