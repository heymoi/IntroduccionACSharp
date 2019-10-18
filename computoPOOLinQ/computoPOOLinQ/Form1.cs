using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace computoPOOLinQ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        //Creando un Origen de Datos de tipo Lista de la Clase  Computo.
        List<clsComputo> lstComputos = new List<clsComputo> {
            //Agregando un objeto Computo a la lista lstComputos
            new clsComputo {Id = 1, Nombre = "Computo A", Capacidad=25 }
        };

        //Boton limpiar
        private void Button1_Click(object sender, EventArgs e)
        {
            LimpiarControles();
        }
        //Función para reiniciar los controles
        private void LimpiarControles() {
            //Limpiando los controles
            txtId.Clear();
            txtNombre.Clear();
            txtCapacidad.Text = "";
            //Habilitando controles
            txtId.Enabled = true;
            btnAgregar.Enabled = true;
            btnActualizar.Enabled = false;
            txtId.Focus();
        }


        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            //Instanciando la clase clsComputo 
            clsComputo computo = new clsComputo();
            //Agregando las propiedades Id, Nombre, Capacidad al objeto computo
            computo.Id = Int32.Parse( txtId.Text.Trim());
            computo.Nombre = txtNombre.Text.Trim();
            computo.Capacidad = Int32.Parse(txtCapacidad.Text.Trim());
            //Agregando el computo a la lista lstComputos
            lstComputos.Add(computo);
            //Mostrando el computo en el label lblResultado
            lblResultado.Text = "Último Computo Registrado: \nID" + computo.Id + " \nComputo: "
                                + computo.Nombre + "\nCapacidad:"
                                + computo.Capacidad;
            lblResultado.AutoSize = true;
            //Despues de registrar y mostrar el computo, llenamos la datagrid con los datos de la lista
            LlenarDataGridComputo();
            //Reiniciamos los controles
            LimpiarControles();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Deshabilitamos el boton para limpiar
            button1.Enabled = false;
            //Definiendo los encabezados de la DataGridView
            /*dgvComputos.Columns.Add("Id", "Id");
            dgvComputos.Columns.Add("Computo", "Computo");
            dgvComputos.Columns.Add("Capacidad", "Capacidad");
            dgvComputos.Columns.Add("No PC", "No PC");

            /*
             Otra forma de definir el encabezado de las columnas
             dgvComputos.ColumnCount = #de columnas;
             dgvComputos.Columns[#Indice].Name = "NombreDeLaColumna"; 
             dgvComputos.Columns[#Indice].HeaderText= "TextoDeLaColumna";
             */
             //Limpiamos el lblResultado
            lblResultado.Text = "";
            LlenarDataGridComputo();
            LimpiarControles();
        }

        //Función para llenar la datagrid, recibe como parametro la variable filtro de tipo cadena
        private void LlenarDataGridComputo(string filtro = "") {
            //Si la variable filtro no esta vacia
            if (!String.IsNullOrEmpty(filtro)) {
                //la variable resultadoBusqueda hace una consulta a la lista verificando si la propiedad
                //nombre contiene el filtro indicado. Al final el resultado lo convierte en un arreglo
                var resultadoBusqueda = (from computos in lstComputos
                                         where computos.Nombre.ToLower().Contains(filtro.ToLower())
                                         select computos
                                     ).ToArray();
                //Se define el origen de datos del datagridview del tipo lista
                dgvComputos.DataSource = typeof(List<clsComputo>);
                //Se define el origen de datos del tipo resultado
                dgvComputos.DataSource = resultadoBusqueda;

            }
            //Si el filtro esta vacio, el origen de datos será la lista de Computos
            else {
                dgvComputos.DataSource = typeof(List<clsComputo>);
                dgvComputos.DataSource = lstComputos;

            }
            //Cambiando el nombre a la columna 4, corresponde el indice 3 de la lista
            dgvComputos.Columns[3].Name = "#PC";
            dgvComputos.Columns[3].HeaderText = "#PC";
            //Una forma de ajustar el ancho de una columna especifica
            //dgvComputos.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvComputos.AutoResizeColumns();//Otra forma de ajustar el ancho de las celdas
        }

        //en el evento TextChanged, es decir cuando cambie el contenido de la caja de texto ID
        private void TxtId_TextChanged(object sender, EventArgs e)
        {
            //Si el id Esta vacio el boton de limpiar se deshabilita
            if (String.IsNullOrEmpty(txtId.Text))
            {
                button1.Enabled = false;
            }
            //el boton de limpiar se habilita cuando el id tiene un valor
            else {
                button1.Enabled = true;
            }
        }

       
        //Cuando se cambia el contenido del control txtBusqueda
        private void TxtBusqueda_TextChanged(object sender, EventArgs e)
        {
            //la variable computo toma el contenido de la caja de texto txtBusqueda
            string computo = txtBusqueda.Text;
            //Se manda a llamar a la funcion LlenarDataGridComputo y se pasa el parametro (computo)
            LlenarDataGridComputo(computo);//otra forma: LlenarDataGridComputo(txtBusqueda.Text);
        }

        //El evento CellDoubleClick, este no es por defecto, hay que buscarlo en la lista de evento del contorl datagridview
        private void DgvComputos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
             A continuación se selecciona una fila, y se accede a cada celda por su indice
             y luego al valor de la celda referido; haciendo esto se puede asignar ese valor
             a una variable o a un control como es este caso.
             */
            txtId.Text = dgvComputos.CurrentRow.Cells[0].Value.ToString();
            txtNombre.Text = dgvComputos.CurrentRow.Cells[1].Value.ToString();
            txtCapacidad.Text = dgvComputos.CurrentRow.Cells[2].Value.ToString();
            txtId.Enabled = false;
            btnAgregar.Enabled = false;
            btnActualizar.Enabled = true;
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            //Se toman los valores de los controles de texto y se ingresan a una variable
            int id = Convert.ToInt32(txtId.Text);
            string nombre = txtNombre.Text.Trim();
            int capacidad = Convert.ToInt32( txtCapacidad.Text);
            //Se recorre la lista lstComputos, cada item se almacena en objComputo
            foreach (clsComputo objComputo in lstComputos) {
                //Si el id del objeto recorrido (objComputo) es igual al id de la caja de texto
                //Cambiamos los valores de las propiedades Nombre y Capacidad
                if (objComputo.Id == id) {
                    objComputo.Nombre = nombre;
                    objComputo.Capacidad = capacidad;
                    break;
                }
            }
            LimpiarControles();
            LlenarDataGridComputo();
        }
    }
}
