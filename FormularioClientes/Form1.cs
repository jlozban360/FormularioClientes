using System.Windows.Forms;

namespace FormularioClientes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataGridViewTextBoxColumn codigoCol = new DataGridViewTextBoxColumn();
            codigoCol.Name = "Código";
            codigoCol.HeaderText = "Código";
            codigoCol.ValueType = typeof(int);
            codigoCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns.Add(codigoCol);

            DataGridViewTextBoxColumn nombreCol = new DataGridViewTextBoxColumn();
            nombreCol.Name = "Nombre";
            nombreCol.HeaderText = "Nombre";
            nombreCol.ValueType = typeof(string);
            dataGridView1.Columns.Add(nombreCol);

            DataGridViewTextBoxColumn apellido1Col = new DataGridViewTextBoxColumn();
            apellido1Col.Name = "Apellido1";
            apellido1Col.HeaderText = "Apellido1";
            apellido1Col.ValueType = typeof(string);
            dataGridView1.Columns.Add(apellido1Col);

            DataGridViewTextBoxColumn apellido2Col = new DataGridViewTextBoxColumn();
            apellido2Col.Name = "Apellido2";
            apellido2Col.HeaderText = "Apellido2";
            apellido2Col.ValueType = typeof(string);
            dataGridView1.Columns.Add(apellido2Col);

            DataGridViewTextBoxColumn localidadCol = new DataGridViewTextBoxColumn();
            localidadCol.Name = "Localidad";
            localidadCol.HeaderText = "Localidad";
            localidadCol.ValueType = typeof(string);
            dataGridView1.Columns.Add(localidadCol);

            DataGridViewTextBoxColumn fechaAltaCol = new DataGridViewTextBoxColumn();
            fechaAltaCol.Name = "Fecha Alta";
            fechaAltaCol.HeaderText = "Fecha Alta";
            fechaAltaCol.ValueType = typeof(DateTime);
            fechaAltaCol.DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridView1.Columns.Add(fechaAltaCol);

            DataGridViewComboBoxColumn tipoClienteCol = new DataGridViewComboBoxColumn();
            tipoClienteCol.Name = "TipoCliente";
            tipoClienteCol.HeaderText = "TipoCliente";
            tipoClienteCol.Items.AddRange("A", "B", "C");
            dataGridView1.Columns.Add(tipoClienteCol);

            DataGridViewTextBoxColumn sumaTotalCol = new DataGridViewTextBoxColumn();
            sumaTotalCol.Name = "SumaTotal";
            sumaTotalCol.HeaderText = "SumaTotal";
            sumaTotalCol.ValueType = typeof(decimal);
            sumaTotalCol.DefaultCellStyle.Format = "N2";
            sumaTotalCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns.Add(sumaTotalCol);

            Estilos estilos = new Estilos(dataGridView1);

            falseandoDatos(50);
        }

        private void falseandoDatos(int nDatos)
        {
            DataGridView dgv = dataGridView1;

            for (int i = 0; i < nDatos; i++)
            {
                DataGridViewRow fila = new DataGridViewRow();
                fila.CreateCells(dgv);

                fila.Cells[0].Value = 100 + i;
                fila.Cells[1].Value = "Nombre " + i;
                fila.Cells[2].Value = "Apellido1 " + i;
                fila.Cells[3].Value = "Apellido2 " + i;
                fila.Cells[4].Value = "Localidad " + i;
                fila.Cells[5].Value = DateTime.Now.AddDays(-i);
                fila.Cells[6].Value = i % 3 == 0 ? "A" : i % 2 == 0 ? "B" : "C";
                fila.Cells[7].Value = 1000 + i * 1.5m;

                dgv.Rows.Add(fila);
            }
        }
    }
}
