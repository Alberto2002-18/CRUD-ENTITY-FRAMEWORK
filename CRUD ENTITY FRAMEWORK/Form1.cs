using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_ENTITY_FRAMEWORK
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            using (var context = new ProductosContext())
            {
                dgvProductos.DataSource = context.Productos.ToList();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            using (var context = new ProductosContext())
            {
                var producto = new Producto
                {
                    Nombre = txtNombre.Text,
                    Descripcion = txtDescripcion.Text,
                    Marca = txtMarca.Text,
                    Precio = decimal.Parse(txtPrecio.Text),
                    Stock = decimal.Parse(txtStock.Text)
                };
                context.Productos.Add(producto);
                context.SaveChanges();
            }
            LoadData();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            using (var context = new ProductosContext())
            {
                int id = int.Parse(dgvProductos.CurrentRow.Cells[0].Value.ToString());
                var producto = context.Productos.Find(id);
                if (producto != null)
                {
                    producto.Nombre = txtNombre.Text;
                    producto.Descripcion = txtDescripcion.Text;
                    producto.Marca = txtMarca.Text;
                    producto.Precio = decimal.Parse(txtPrecio.Text);
                    producto.Stock = decimal.Parse(txtStock.Text);
                    context.SaveChanges();
                }
            }
            LoadData();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            using (var context = new ProductosContext())
            {
                int id = int.Parse(dgvProductos.CurrentRow.Cells[0].Value.ToString());
                var producto = context.Productos.Find(id);
                if (producto != null)
                {
                    context.Productos.Remove(producto);
                    context.SaveChanges();
                }
            }
            LoadData();
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProductos.CurrentRow != null)
            {
                txtNombre.Text = dgvProductos.CurrentRow.Cells[1].Value.ToString();
                txtDescripcion.Text = dgvProductos.CurrentRow.Cells[2].Value.ToString();
                txtMarca.Text = dgvProductos.CurrentRow.Cells[3].Value.ToString();
                txtPrecio.Text = dgvProductos.CurrentRow.Cells[4].Value.ToString();
                txtStock.Text = dgvProductos.CurrentRow.Cells[5].Value.ToString();
            }
        }
    }
}
