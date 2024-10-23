using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormularioClientes
{
    public partial class Clientes : Form
    {
        public String codigo, nombre, apellido1, apellido2, localidad, fechaAlta, tipoCliente, sumaTotal;
        //datagridview completo
        DataGridView d;
        //fila que cogo del datagridview con el doble click
        DataGridViewCellCollection filaTraida;

        public Clientes()
        {
            InitializeComponent();
        }

        public Clientes(ref DataGridViewCellCollection fila)
        {
            InitializeComponent();

            this.textBoxNombre.Text = fila[1].Value.ToString();
            this.text
            /*
            this.text.Text = fila[1].Value.ToString();
            this.tbApellido1.Text = fila[2].Value.ToString();
            this.tbApellido2.Text = fila[3].Value.ToString();
            this.tbLocalidad.Text = fila[4].Value.ToString();
            this.tbFecha.Text = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            this.tbSuma.Text = fila[7].Value.ToString();

            switch (fila[6].Value)
            {
                case "A": cbTipo.SelectedIndex = 0; break;
                case "B": cbTipo.SelectedIndex = 1; break;
                case "C": cbTipo.SelectedIndex = 2; break;

            }

            filaTraida = fila;*/
        }
    }
}
