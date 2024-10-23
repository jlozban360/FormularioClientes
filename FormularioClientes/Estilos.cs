using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormularioClientes
{
    public class Estilos
    {
        private DataGridView dataGridView;

        public Estilos(DataGridView dataGrid)
        {
            this.dataGridView = dataGrid;
            InicializarEstilos();
        }

        private void InicializarEstilos()
        {
            DataGridViewCellStyle defaultCellStyle = new DataGridViewCellStyle();
            defaultCellStyle.BackColor = Color.White;
            defaultCellStyle.ForeColor = Color.Black;

            DataGridViewCellStyle estiloAlterno = new DataGridViewCellStyle();
            estiloAlterno.BackColor = Color.LightGray;
            estiloAlterno.ForeColor = Color.Black;
            estiloAlterno.SelectionBackColor = Color.DarkGray;
            estiloAlterno.SelectionForeColor = Color.White;
            dataGridView.AlternatingRowsDefaultCellStyle = estiloAlterno;

            DataGridViewCellStyle estiloCabecera = new DataGridViewCellStyle();
            estiloCabecera.BackColor = Color.Navy;
            estiloCabecera.ForeColor = Color.White;
            estiloCabecera.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            estiloCabecera.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.ColumnHeadersDefaultCellStyle = estiloCabecera;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridView.ColumnHeadersHeight = 40;
            dataGridView.EnableHeadersVisualStyles = false;

            DataGridViewCellStyle estiloCodigo = new DataGridViewCellStyle();
            estiloCodigo.BackColor = Color.LightBlue;
            estiloCodigo.ForeColor = Color.DarkBlue;
            estiloCodigo.Font = new Font("Arial", 9, FontStyle.Bold);
            estiloCodigo.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView.Columns["Código"].DefaultCellStyle = estiloCodigo;

            DataGridViewCellStyle estiloNombre = new DataGridViewCellStyle();
            estiloNombre.ForeColor = Color.DarkGreen;
            estiloNombre.Font = new Font("Tahoma", 9, FontStyle.Italic);
            dataGridView.Columns["Nombre"].DefaultCellStyle = estiloNombre;

            DataGridViewCellStyle estiloApellido1 = new DataGridViewCellStyle();
            estiloApellido1.ForeColor = Color.DarkRed;
            dataGridView.Columns["Apellido1"].DefaultCellStyle = estiloApellido1;

            DataGridViewCellStyle estiloApellido2 = new DataGridViewCellStyle();
            estiloApellido2.ForeColor = Color.Purple;
            dataGridView.Columns["Apellido2"].DefaultCellStyle = estiloApellido2;

            //dataGridView.Columns["Código"].DefaultCellStyle = estiloCodigo;

            DataGridViewCellStyle estiloLocalidad = new DataGridViewCellStyle();
            estiloLocalidad.BackColor = Color.LightYellow;
            estiloLocalidad.ForeColor = Color.DarkOrange;
            dataGridView.Columns["Localidad"].DefaultCellStyle = estiloLocalidad;

            DataGridViewCellStyle estiloFechaAlta = new DataGridViewCellStyle();
            estiloFechaAlta.BackColor = Color.LightPink;
            estiloFechaAlta.ForeColor = Color.DarkMagenta;
            estiloFechaAlta.Format = "dd/MM/yyyy";
            dataGridView.Columns["Fecha Alta"].DefaultCellStyle = estiloFechaAlta;

            DataGridViewCellStyle estiloTipoCliente = new DataGridViewCellStyle();
            estiloTipoCliente.BackColor = Color.LightCyan;
            estiloTipoCliente.ForeColor = Color.DarkSlateGray;
            dataGridView.Columns["TipoCliente"].DefaultCellStyle = estiloTipoCliente;

            DataGridViewCellStyle estiloSumaTotal = new DataGridViewCellStyle();
            estiloSumaTotal.BackColor = Color.LightGreen;
            estiloSumaTotal.ForeColor = Color.DarkGreen;
            estiloSumaTotal.Format = "N2";
            estiloSumaTotal.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView.Columns["SumaTotal"].DefaultCellStyle = estiloSumaTotal;
        }
    }
}
