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
        DataGridView dataGridViewRef;
        //fila que cogo del datagridview con el doble click
        DataGridViewCellCollection filaTraida;
        bool modoGuardar = false;

        public Clientes(ref DataGridView dataGridView, bool modoGuardar)
        {
            InitializeComponent();
            this.dataGridViewRef = dataGridView;
            this.modoGuardar = modoGuardar;
            pictureBoxSuspicious.Visible = true;
            pictureBoxhappy.Visible = false;
            pictureBoxSad.Visible = false;
        }

        public Clientes(ref DataGridViewCellCollection fila, ref DataGridView dataGridView, bool modoGuardar)
        {
            InitializeComponent();
            pictureBoxSuspicious.Visible = false;
            this.modoGuardar = modoGuardar;
            this.dataGridViewRef = dataGridView; // Guardar la referencia al DataGridView

            // Llenar los controles con los datos de la fila seleccionada
            this.textBoxNombre.Text = fila[1].Value.ToString();
            this.textBoxApellido1.Text = fila[2].Value.ToString();
            this.textBoxApellido2.Text = fila[3].Value.ToString();
            this.numericUpDownEdad.Value = int.Parse(fila[4].Value.ToString());
            this.textBoxDireccion.Text = fila[5].Value.ToString();
            this.dateTimePickerFecha.Value = DateTime.Parse(fila[6].Value.ToString());

            switch (fila[7].Value.ToString())
            {
                case "A": comboBoxTipoCliente.SelectedIndex = 0; break;
                case "B": comboBoxTipoCliente.SelectedIndex = 1; break;
                case "C": comboBoxTipoCliente.SelectedIndex = 2; break;
            }

            // Procesar el valor monetario
            string valorStr = fila[8].Value.ToString();
            double valorDouble;
            if (double.TryParse(valorStr, out valorDouble))
            {
                if (valorDouble < 1000)
                    this.progressBarDinero.Value = 25;
                else if (valorDouble >= 1000 && valorDouble <= 2000)
                    this.progressBarDinero.Value = 50;
                else if (valorDouble > 2000 && valorDouble <= 3000)
                    this.progressBarDinero.Value = 75;
                else
                    this.progressBarDinero.Value = 100;
            }

            // Procesar el género
            if (fila[9].Value.ToString().Equals("hombre", StringComparison.OrdinalIgnoreCase))
                radioButtonHombre.Checked = true;
            else
                radioButtonMujer.Checked = true;

            // Procesar si está activo o no
            checkBoxActivo.Checked = fila[10].Value.ToString() == "Si";

            filaTraida = fila; // Guardar la fila traída
            
            //Fotos
            if(valorDouble > 1500)
            {
                pictureBoxhappy.Visible = true;
                pictureBoxSad.Visible = false;
            }
            else
            {
                pictureBoxhappy.Visible = false;
                pictureBoxSad.Visible = true;
            }
        }



        private void buttonEditar_Click(object sender, EventArgs e)
        {
            filaTraida[1].Value = textBoxNombre.Text;
            filaTraida[2].Value = textBoxApellido1.Text;
            filaTraida[3].Value = textBoxApellido2.Text;
            filaTraida[4].Value = numericUpDownEdad.Value.ToString();
            filaTraida[5].Value = textBoxDireccion.Text;
            filaTraida[6].Value = dateTimePickerFecha.Value.ToString("yyyy-MM-dd");

            switch (comboBoxTipoCliente.SelectedIndex)
            {
                case 0:
                    filaTraida[7].Value = "A";
                    break;
                case 1:
                    filaTraida[7].Value = "B";
                    break;
                case 2:
                    filaTraida[7].Value = "C";
                    break;
                default:
                    filaTraida[7].Value = "A";
                    break;
            }

            filaTraida[8].Value = progressBarDinero.Value;
            filaTraida[9].Value = radioButtonHombre.Checked ? "hombre" : "mujer";
            filaTraida[10].Value = checkBoxActivo.Checked ? "Si" : "No";
            this.Close();
        }

        //Esto es limpiar formulario
        private void buttonClean_Click(object sender, EventArgs e)
        {
            textBoxNombre.Clear();
            textBoxApellido1.Clear();
            textBoxApellido2.Clear();
            numericUpDownEdad.Value = 0;
            textBoxDireccion.Clear();
            dateTimePickerFecha.Value = DateTime.Now;
            comboBoxTipoCliente.SelectedIndex = -1;
            progressBarDinero.Value = 0;
            radioButtonHombre.Checked = false;
            radioButtonMujer.Checked = false;
            checkBoxActivo.Checked = false;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (modoGuardar)
            {
                DataGridViewRow fila = new DataGridViewRow();
                fila.CreateCells(dataGridViewRef);

                fila.Cells[0].Value = 100 + dataGridViewRef.Rows.Count;
                fila.Cells[1].Value = textBoxNombre.Text;
                fila.Cells[2].Value = textBoxApellido1.Text;
                fila.Cells[3].Value = textBoxApellido2.Text;
                fila.Cells[4].Value = numericUpDownEdad.Value;
                fila.Cells[5].Value = textBoxDireccion.Text;
                fila.Cells[6].Value = dateTimePickerFecha.Value.ToString("yyyy-MM-dd");

                switch (comboBoxTipoCliente.SelectedIndex)
                {
                    case 0:
                        fila.Cells[7].Value = "A";
                        break;
                    case 1:
                        fila.Cells[7].Value = "B";
                        break;
                    case 2:
                        fila.Cells[7].Value = "C";
                        break;
                    default:
                        fila.Cells[7].Value = "A";
                        break;
                }

                fila.Cells[8].Value = progressBarDinero.Value;
                fila.Cells[9].Value = radioButtonHombre.Checked ? "hombre" : "mujer";
                fila.Cells[10].Value = checkBoxActivo.Checked ? "Si" : "No";
                dataGridViewRef.Rows.Add(fila);

                this.Close();
            }
            else
            {
                filaTraida[1].Value = textBoxNombre.Text;
                filaTraida[2].Value = textBoxApellido1.Text;
                filaTraida[3].Value = textBoxApellido2.Text;
                filaTraida[4].Value = numericUpDownEdad.Value.ToString();
                filaTraida[5].Value = textBoxDireccion.Text;
                filaTraida[6].Value = dateTimePickerFecha.Value.ToString("yyyy-MM-dd");

                switch (comboBoxTipoCliente.SelectedIndex)
                {
                    case 0:
                        filaTraida[7].Value = "A";
                        break;
                    case 1:
                        filaTraida[7].Value = "B";
                        break;
                    case 2:
                        filaTraida[7].Value = "C";
                        break;
                    default:
                        filaTraida[7].Value = "A";
                        break;
                }

                filaTraida[8].Value = progressBarDinero.Value;
                filaTraida[9].Value = radioButtonHombre.Checked ? "hombre" : "mujer";
                filaTraida[10].Value = checkBoxActivo.Checked ? "Si" : "No";

                this.Close();
            }
        }
    }
}
