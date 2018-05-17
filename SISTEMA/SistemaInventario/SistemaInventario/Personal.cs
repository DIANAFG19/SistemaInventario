using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace SistemaInventario
{
    public partial class Personal : Form
    {
        DataSet datosCargo;
        DataSet datosArea;
        public Personal()
        {
            InitializeComponent();
        }

        private void lRegresar_Click(object sender, EventArgs e)
        {
            MenuG m = new MenuG();
            m.Show();
            this.Close();
        }

        private void lCerrarSesion_Click(object sender, EventArgs e)
        {
            Autenticacion autenticacion = new Autenticacion();
            autenticacion.Show();
            this.Close();
        }

        private void pbMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pbCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Personal_Load(object sender, EventArgs e)
        {
            //Mostrar los cargos en el cbCargo
            Autenticacion.ConectarBD();
            datosCargo = new DataSet();
            OleDbDataAdapter adpCargo = new OleDbDataAdapter("SELECT * FROM CARGO", Autenticacion.con);
            adpCargo.Fill(datosCargo, "Cargo");
            cbCargo.DataSource = datosCargo.Tables[0].DefaultView;
            cbCargo.Text = null;
            cbCargo.ValueMember = "ID_Cargo";
            cbCargo.DisplayMember = "CARGO";
            cbNCargo.DataSource = datosCargo.Tables[0].DefaultView;
            cbNCargo.Text = null;
            cbNCargo.ValueMember = "ID_Cargo";
            cbNCargo.DisplayMember = "CARGO";
            //Mostrar las áreas en el cbArea
            datosArea = new DataSet();
            OleDbDataAdapter Adaptador = new OleDbDataAdapter("SELECT * FROM AREA", Autenticacion.con);
            Adaptador.Fill(datosArea, "Area");
            cbArea.DataSource = datosArea.Tables[0].DefaultView;
            cbArea.Text = null;
            cbArea.ValueMember = "ID_Area";
            cbArea.DisplayMember = "AREA";
            cbNArea.DataSource = datosArea.Tables[0].DefaultView;
            cbNArea.Text = null;
            cbNArea.ValueMember = "ID_Area";
            cbNArea.DisplayMember = "AREA";
            Autenticacion.con.Close();
            //Mostrar los datos de la tabla EMPLEADOS en el dgvEmpleados
            MostrarEmpleados();
            //Bloquear los TextBox para Actualizar
            cbMApePaterno.Enabled = false;
            cbMApeMaterno.Enabled = false;
            cbMNombre.Enabled = false;
            cbMCargo.Enabled = false;
            cbMArea.Enabled = false;
            tbNApePaterno.Enabled = false;
            tbNApeMaterno.Enabled = false;
            tbNNombre.Enabled = false;
            cbNCargo.Enabled = false;
            cbNArea.Enabled = false;
            btnActualizar.Enabled = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string id = tbNumeroE.Text;
            string apPaterno = tbApellidoP.Text;
            string apMaterno = tbApellidoM.Text;
            string nombre = tbNombre.Text;
            string cargo = cbCargo.Text;
            string area = cbArea.Text;
            if (id == "" || apPaterno == "" || apMaterno == "" || nombre == "" || cargo == "" || area == "")
            {
                MessageBox.Show("No puede dejar campos vacíos.");
            }
            else
            {
                Registrar(GenerarID(), id, apPaterno, apMaterno, nombre, cargo, area);
                MessageBox.Show("Registro Exitoso.");
            }
            tbNumeroE.Clear();
            tbApellidoP.Clear();
            tbApellidoM.Clear();
            tbNombre.Clear();
            cbCargo.Text = null;
            cbArea.Text = null;
            tbNumeroE.Focus();
            MostrarEmpleados();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            tbNumeroE.Clear();
            tbApellidoP.Clear();
            tbApellidoM.Clear();
            tbNombre.Clear();
            cbCargo.Text = null;
            cbArea.Text = null;
            tbNumeroE.Focus();;
        }

        public static int GenerarID()
        {
            Autenticacion.ConectarBD();
            int ultimo = 0;
            OleDbCommand buscaU = new OleDbCommand();
            buscaU.Connection = Autenticacion.con;
            buscaU.CommandText = @"SELECT ID FROM PERSONAL";
            OleDbDataReader reader = buscaU.ExecuteReader();
            while (reader.Read())
            {
                string algo = reader.GetValue(0).ToString();
                ultimo = Convert.ToInt16(algo);
            }
            ultimo += 1;
            Autenticacion.con.Close();
            return ultimo;
        }

        public static void Registrar(int idG, string id, string apPaterno, string apMaterno, string nombre, string cargo, string area)
        {
            Autenticacion.ConectarBD();
            OleDbCommand guardar = new OleDbCommand();
            guardar.Connection = Autenticacion.con;
            guardar.CommandText = @"INSERT INTO PERSONAL VALUES('" + idG + "','" + id + "','" + apPaterno + "','" + apMaterno + "','" + nombre + "','" + cargo + "','" + area + "')";
            guardar.ExecuteNonQuery();
            Autenticacion.con.Close();
        }

        public void MostrarEmpleados()
        {
            Autenticacion.ConectarBD();
            OleDbCommand coman = new OleDbCommand();
            coman.Connection = Autenticacion.con;
            string query = "SELECT ID_EMPLEADO,APELLIDO_PATERNO,APELLIDO_MATERNO,NOMBRE, CARGO, AREA FROM PERSONAL";
            coman.CommandText = query;
            OleDbDataAdapter da = new OleDbDataAdapter(coman);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvEmpleados.DataSource = dt;
            dgvActualizar.DataSource = dt;
            dgvEliminar.DataSource = dt;
        }

        public void EliminarBD(int id)
        {
            Autenticacion.ConectarBD();
            OleDbCommand eliminar = new OleDbCommand();
            eliminar.Connection = Autenticacion.con;
            eliminar.CommandText = @"DELETE FROM PERSONAL WHERE ID = " + id;
            eliminar.ExecuteNonQuery();
            Autenticacion.con.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(lID.Text);
            EliminarBD(id);
            string idE = tbNumeroEmA.Text;
            string apPaterno = tbNApePaterno.Text;
            string apMaterno = tbNApeMaterno.Text;
            string nombre = tbNNombre.Text;
            string cargo = cbNCargo.Text;
            string area = cbNArea.Text;
            Registrar(GenerarID(), idE, apPaterno, apMaterno, nombre, cargo, area);
            tbNumeroEmA.Clear();
            tbNApePaterno.Clear();
            tbNApeMaterno.Clear();
            tbNNombre.Clear();
            cbNCargo.Text = null;
            cbNArea.Text = null;
            tbNumeroEmA.Focus();
            cbMApePaterno.Enabled = false;
            cbMApeMaterno.Enabled = false;
            cbMNombre.Enabled = false;
            cbMCargo.Enabled = false;
            cbMArea.Enabled = false;
            tbNApePaterno.Enabled = false;
            tbNApeMaterno.Enabled = false;
            tbNNombre.Enabled = false;
            cbNCargo.Enabled = false;
            cbNArea.Enabled = false;
            btnActualizar.Enabled = false;
            MostrarEmpleados();
        }

        private void cbMCargo_CheckedChanged(object sender, EventArgs e)
        {
            cbNCargo.Enabled = true;
            btnActualizar.Enabled = true;
        }

        private void cbMArea_CheckedChanged(object sender, EventArgs e)
        {
            cbNArea.Enabled = true;
            btnActualizar.Enabled = true;
        }

        private void cbMApePaterno_CheckedChanged(object sender, EventArgs e)
        {
            tbNApePaterno.Enabled = true;
            btnActualizar.Enabled = true;
        }

        private void cbMApeMaterno_CheckedChanged(object sender, EventArgs e)
        {
            tbNApeMaterno.Enabled = true;
            btnActualizar.Enabled = true;
        }

        private void cbMNombre_CheckedChanged(object sender, EventArgs e)
        {
            tbNNombre.Enabled = true;
            btnActualizar.Enabled = true;
        }

        private void btnEBuscar_Click(object sender, EventArgs e)
        {
            btnEliminar.Enabled = true;
            if (tbBNumEmpleado.Text == "")
            {
                MessageBox.Show("Ingrese a un empleado existente.");
            }
            else
            {
                BuscarBD(tbBNumEmpleado.Text);
                cbMApePaterno.Enabled = true;
                cbMApeMaterno.Enabled = true;
                cbMNombre.Enabled = true;
                cbMCargo.Enabled = true;
                cbMArea.Enabled = true;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idEliminar = Convert.ToInt16(LIDEliminar.Text);
            EliminarBD(idEliminar);
            tbBNumEmpleado.Clear();
            tbBNumEmpleado.Focus();
            MostrarEmpleados();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            tbBNumEmpleado.Clear();
            tbBNumEmpleado.Focus(); ;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            tbNumeroEmA.Clear();
            tbNApePaterno.Clear();
            tbNApeMaterno.Clear();
            tbNNombre.Clear();
            cbNCargo.Text = null;
            cbNArea.Text = null;
            tbNumeroEmA.Focus(); ;
            cbMApePaterno.Enabled = false;
            cbMApeMaterno.Enabled = false;
            cbMNombre.Enabled = false;
            cbMCargo.Enabled = false;
            cbMArea.Enabled = false;
            tbNApePaterno.Enabled = false;
            tbNApeMaterno.Enabled = false;
            tbNNombre.Enabled = false;
            cbNCargo.Enabled = false;
            cbNArea.Enabled = false;
            btnActualizar.Enabled = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (tbNumeroEmA.Text == "")
            {
                MessageBox.Show("Ingrese a un empleado existente.");
            }
            else
            {
                BuscarBD(tbNumeroEmA.Text);
                cbMApePaterno.Enabled = true;
                cbMApeMaterno.Enabled = true;
                cbMNombre.Enabled = true;
                cbMCargo.Enabled = true;
                cbMArea.Enabled = true;
            }
        }

        public void BuscarBD(string id)
        {
            Autenticacion.ConectarBD();
            OleDbCommand busqueda = new OleDbCommand();
            busqueda.Connection = Autenticacion.con;
            busqueda.CommandText = @"SELECT * FROM PERSONAL";
            OleDbDataReader reader = busqueda.ExecuteReader();
            while (reader.Read())
            {
                if (id == reader.GetValue(1).ToString())
                {
                    lID.Text = reader.GetValue(0).ToString();
                    LIDEliminar.Text = reader.GetValue(0).ToString();
                    tbNApePaterno.Text = reader.GetValue(2).ToString();
                    tbNApeMaterno.Text = reader.GetValue(3).ToString();
                    tbNNombre.Text = reader.GetValue(4).ToString();
                    cbNCargo.Text = reader.GetValue(5).ToString();
                    cbNArea.Text = reader.GetValue(6).ToString();
                }
            }
            MostrarEmpleado(tbBNumEmpleado.Text);
        }

        public void MostrarEmpleado(string id)
        {
            Autenticacion.ConectarBD();
            OleDbCommand coman = new OleDbCommand();
            coman.Connection = Autenticacion.con;
            string query = "SELECT ID_EMPLEADO,APELLIDO_PATERNO,APELLIDO_MATERNO,NOMBRE, CARGO, AREA FROM PERSONAL WHERE ID_EMPLEADO ='" + id + "'";
            coman.CommandText = query;
            OleDbDataAdapter da = new OleDbDataAdapter(coman);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvEliminar.DataSource = dt;
        }

        private void tbApellidoP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
