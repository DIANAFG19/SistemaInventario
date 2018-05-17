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
    public partial class Articulos : Form
    {

        DataSet datosArea;
        DataSet datosMarca;

        public static String eli;
        public static String act;
        public static String vg;
        public static String baja;
        public static int identificador;

        public Articulos()
        {
            InitializeComponent();
        }

        private void lRegresar_Click(object sender, EventArgs e)
        {
            if(Autenticacion.user == "Administrador")
            {
                MenuG m = new MenuG();
                m.Show();
                this.Close();
            }
            else if(Autenticacion.user == "Usuario")
            {
                MenuP m = new MenuP();
                m.Show();
                this.Close();
            }
        }

        private void lCerrarSesion_Click(object sender, EventArgs e)
        {
            Autenticacion f = new Autenticacion();
            f.Show();
            this.Close();
        }

        private void pbMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Articulos_Load(object sender, EventArgs e)
        {
            gbInventario.Visible = false;
            gbSerie.Visible = false;
            gbMarca.Visible = false;
            gbTipo.Visible = false;
            gbEstado.Visible = false;
            gbEmpleado.Visible = false;
            gbArea.Visible = false;
            gbFecha.Visible = false;
            timer2.Enabled = true;
            tbFecha.Enabled = false;
            tbHora.Enabled = false;
            //Mostrar todas las áreas en el cbArea
            datosArea = new DataSet();
            OleDbDataAdapter Adaptador = new OleDbDataAdapter("SELECT * FROM AREA", Autenticacion.con);
            Adaptador.Fill(datosArea, "Area");
            cbArea.DataSource = datosArea.Tables[0].DefaultView;
            cbArea.Text = null;
            cbArea.ValueMember = "AREA";
            cbBArea.DisplayMember = "AREA";
            cbBArea.DataSource = datosArea.Tables[0].DefaultView;
            cbBArea.Text = null;
            cbBArea.ValueMember = "AREA";
            cbBArea.DisplayMember = "AREA";
            cbAAreas.DataSource = datosArea.Tables[0].DefaultView;
            cbAAreas.Text = null;
            cbAAreas.ValueMember = "AREA";
            cbAAreas.DisplayMember = "AREA";
            //Mostrar todas las marcas en el cbMarca
            datosMarca = new DataSet();
            OleDbDataAdapter AdaptadorM = new OleDbDataAdapter("SELECT * FROM MARCA", Autenticacion.con);
            AdaptadorM.Fill(datosMarca, "Marca");
            cbMarca.DataSource = datosMarca.Tables[0].DefaultView;
            cbMarca.Text = null;
            cbMarca.ValueMember = "MARCA";
            cbMarca.DisplayMember = "MARCA";
            cbBMarca.DataSource = datosMarca.Tables[0].DefaultView;
            cbBMarca.Text = null;
            cbBMarca.ValueMember = "MARCA";
            cbBMarca.DisplayMember = "MARCA";
            cbAMarcas.DataSource = datosMarca.Tables[0].DefaultView;
            cbAMarcas.Text = null;
            cbAMarcas.ValueMember = "MARCA";
            cbAMarcas.DisplayMember = "MARCA";
            //Mostrar todos los artículos
            MostrarArticulos();
            MostrarBajas();
            //Bloquear todos los checkbox y demás
            cbANumSerie.Enabled = false;
            cbAMarca.Enabled = false;
            cbATipo.Enabled = false;
            cbAEstado.Enabled = false;
            cbAEmpleado.Enabled = false;
            cbAArea.Enabled = false;
            cbAObservaciones.Enabled = false;
            tbANumSerie.Enabled = false;
            cbAMarcas.Enabled = false;
            tbATipo.Enabled = false;
            cbAEstados.Enabled = false;
            tbAEmpleados.Enabled = false;
            cbAAreas.Enabled = false;
            tbAObservaciones.Enabled = false;
            btnActualizar.Enabled = false;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            DateTime hoy = DateTime.Now;
            label18.Text = hoy.ToShortDateString();
            label19.Text = hoy.ToShortTimeString();
            tbFecha.Text = hoy.ToShortDateString();
            tbHora.Text = hoy.ToShortTimeString();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int id = GenerarIDArticulo();
            string idInventario1 = tbInventario.Text;
            string idInventario2 = tbInventario2.Text;
            string idInventario = idInventario1 + "-" + idInventario2;
            string idSerie = tbSerie.Text;
            string marca = cbMarca.Text;
            string tipo = tbTipo.Text;
            string estado = cbEstado.Text;
            string empleado = tbEmpleado.Text;
            string area = cbArea.Text;
            string observacion = tbObservaciones.Text;
            string fecha = tbFecha.Text;
            string hora = tbHora.Text;
            if (idInventario1 == "" || idInventario2 == "" || idSerie == "" || marca == "" || tipo == "" || estado == "" || empleado == "" || area == "" || observacion == "" || fecha == "" || hora == "")
            {
                MessageBox.Show("No puede dejar campos vacíos.");
            }
            else
            {
                GuardarArticulo(id, idInventario, idSerie, marca, tipo, estado, empleado, area, observacion, fecha, hora);
                MessageBox.Show("Registro Exitoso.");
            }
            tbInventario.Clear();
            tbInventario2.Clear();
            tbSerie.Clear();
            cbMarca.Text = null;
            tbTipo.Clear();
            cbEstado.Text = null;
            tbEmpleado.Clear();
            cbArea.Text = null;
            tbObservaciones.Clear();
            tbInventario.Focus();
            MostrarArticulos();
        }

        private void tbInventario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("No se permiten espacios.");
            }
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                e.Handled = true;
                MessageBox.Show("Ingrese solo letras y números.");
            }
        }

        private void tbInventario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                MessageBox.Show("Tecla.");
            }
        }

        private void tbInventario_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Space)
            {
                MessageBox.Show("Tecla.");
            }
        }

        private void tbSerie_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("No se permiten espacios.");
            }
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                e.Handled = true;
                MessageBox.Show("Ingrese solo letras y números.");
            }
        }

        private void tbSerie_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                MessageBox.Show("Tecla.");
            }
        }

        private void tbSerie_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Space)
            {
                MessageBox.Show("Tecla.");
            }
        }

        private void tbFecha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("No se permiten espacios");
            }
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                e.Handled = true;
                MessageBox.Show("Ingrese solo letras y numeros");
            }
        }

        private void btnABuscar_Click(object sender, EventArgs e)
        {
            string idInventario1 = tbAInventario1.Text;
            string idInventario2 = tbAInventario2.Text;
            string idInventario = idInventario1 + "-" + idInventario2;
            if (tbAInventario1.Text == "" || tbAInventario2.Text == "")
            {
                MessageBox.Show("Ingrese un número de inventario existente.");
            }
            else
            {
                BuscarBD(idInventario);
                cbANumSerie.Enabled = true;
                cbAMarca.Enabled = true;
                cbATipo.Enabled = true;
                cbAEstado.Enabled = true;
                cbAEmpleado.Enabled = true;
                cbAArea.Enabled = true;
                cbAObservaciones.Enabled = true;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(idAInven.Text);
            EliminarArticulo(id);
            string idI1 = tbAInventario1.Text;
            string idI2 = tbAInventario2.Text;
            string idInventarioG = idI1 + "-" + idI2;
            string numSerie = tbANumSerie.Text;
            string marca = cbAMarcas.Text;
            string tipo = tbATipo.Text;
            string estado = cbAEstados.Text;
            string empleado = tbAEmpleados.Text;
            string area = cbAAreas.Text;
            string observaciones = tbAObservaciones.Text;
            string fecha = tbAFecha.Text;
            string hora = tbAHora.Text;
            GuardarArticulo(GenerarIDArticulo(), idInventarioG, numSerie, marca, tipo, estado, empleado, area, observaciones, fecha, hora);
            tbAInventario1.Clear();
            tbAInventario2.Clear();  
            tbANumSerie.Clear();
            cbAMarcas.Text = null;
            tbATipo.Clear();
            cbAEstados.Text = null;
            tbAEmpleados.Clear();
            cbAAreas.Text = null;
            tbAObservaciones.Clear();
            tbAFecha.Clear();
            tbAHora.Clear();
            tbAInventario1.Focus();
            cbANumSerie.Enabled = false;
            cbAMarca.Enabled = false;
            cbATipo.Enabled = false;
            cbAEstado.Enabled = false;
            cbAEmpleado.Enabled = false;
            cbAArea.Enabled = false;
            cbAObservaciones.Enabled = false;
            tbANumSerie.Enabled = false;
            cbAMarcas.Enabled = false;
            tbATipo.Enabled = false;
            cbAEstados.Enabled = false;
            tbAEmpleados.Enabled = false;
            cbAAreas.Enabled = false;
            tbAObservaciones.Enabled = false;
            btnActualizar.Enabled = false;
            MostrarArticulos();
        }

        public void BuscarBD(string id)
        {
            Autenticacion.ConectarBD();
            OleDbCommand busqueda = new OleDbCommand();
            busqueda.Connection = Autenticacion.con;
            busqueda.CommandText = @"SELECT * FROM ARTICULO";
            OleDbDataReader reader = busqueda.ExecuteReader();
            while (reader.Read())
            {
                if (id == reader.GetValue(1).ToString())
                {
                    idAInven.Text = reader.GetValue(0).ToString();
                    tbANumSerie.Text = reader.GetValue(2).ToString();
                    cbAMarcas.Text = reader.GetValue(3).ToString();
                    tbATipo.Text = reader.GetValue(4).ToString();
                    cbAEstados.Text = reader.GetValue(5).ToString();
                    tbAEmpleados.Text = reader.GetValue(6).ToString();
                    cbAAreas.Text = reader.GetValue(7).ToString();
                    tbAObservaciones.Text = reader.GetValue(8).ToString();
                    tbAFecha.Text = reader.GetValue(9).ToString();
                    tbAHora.Text = reader.GetValue(10).ToString();
                }
            }
        }

        public void BuscarBorrar(string id)
        {
            Autenticacion.ConectarBD();
            OleDbCommand busqueda = new OleDbCommand();
            busqueda.Connection = Autenticacion.con;
            busqueda.CommandText = @"SELECT * FROM ARTICULO";
            OleDbDataReader reader = busqueda.ExecuteReader();
            while (reader.Read())
            {
                if (id == reader.GetValue(1).ToString())
                {
                    idBajas.Text = reader.GetValue(0).ToString();
                    string serie = reader.GetValue(2).ToString();
                    string marca= reader.GetValue(3).ToString();
                    string tipo = reader.GetValue(4).ToString();
                    string estado = reader.GetValue(5).ToString();
                    string empleado = reader.GetValue(6).ToString();
                    string area = reader.GetValue(7).ToString();
                    string observacion = reader.GetValue(8).ToString();
                    string fecha = reader.GetValue(9).ToString();
                    string hora = reader.GetValue(10).ToString();
                    GuardarArticuloBaja(GenerarIDArticulo(), id, serie, marca, tipo, estado, empleado, area, observacion, fecha, hora);
                    EliminarArticulo(Convert.ToInt16(idBajas.Text));
                }
            }
        }

        public void EliminarArticulo(int id)
        {
            Autenticacion.ConectarBD();
            OleDbCommand eliminar = new OleDbCommand();
            eliminar.Connection = Autenticacion.con;
            eliminar.CommandText = @"DELETE FROM ARTICULO WHERE ID = " + id;
            eliminar.ExecuteNonQuery();
            Autenticacion.con.Close();
        }

        private void btnNumInventario_Click(object sender, EventArgs e)
        {
            gbSerie.Visible = false;
            gbMarca.Visible = false;
            gbTipo.Visible = false;
            gbEstado.Visible = false;
            gbEmpleado.Visible = false;
            gbArea.Visible = false;
            gbFecha.Visible = false;
            gbInventario.Visible = true;
        }

        private void btnNumSerie_Click(object sender, EventArgs e)
        {
            gbInventario.Visible = false;
            gbMarca.Visible = false;
            gbTipo.Visible = false;
            gbEstado.Visible = false;
            gbEmpleado.Visible = false;
            gbFecha.Visible = false;
            gbArea.Visible = false;
            gbSerie.Visible = true;
        }

        private void btnMarca_Click(object sender, EventArgs e)
        {
            gbInventario.Visible = false;
            gbSerie.Visible = false;
            gbTipo.Visible = false;
            gbEstado.Visible = false;
            gbEmpleado.Visible = false;
            gbFecha.Visible = false;
            gbArea.Visible = false;
            gbMarca.Visible = true;
        }

        private void btnTipo_Click(object sender, EventArgs e)
        {
            gbInventario.Visible = false;
            gbSerie.Visible = false;
            gbMarca.Visible = false;
            gbEstado.Visible = false;
            gbEmpleado.Visible = false;
            gbFecha.Visible = false;
            gbArea.Visible = false;
            gbTipo.Visible = true;
        }

        private void btnEstado_Click(object sender, EventArgs e)
        {
            gbInventario.Visible = false;
            gbSerie.Visible = false;
            gbMarca.Visible = false;
            gbTipo.Visible = false;
            gbEmpleado.Visible = false;
            gbFecha.Visible = false;
            gbArea.Visible = false;
            gbEstado.Visible = true;
        }

        private void btnEmpleado_Click(object sender, EventArgs e)
        {
            gbInventario.Visible = false;
            gbSerie.Visible = false;
            gbMarca.Visible = false;
            gbTipo.Visible = false;
            gbEstado.Visible = false;
            gbFecha.Visible = false;
            gbArea.Visible = false;
            gbEmpleado.Visible = true;
        }

        private void btnArea_Click(object sender, EventArgs e)
        {
            gbInventario.Visible = false;
            gbSerie.Visible = false;
            gbMarca.Visible = false;
            gbTipo.Visible = false;
            gbEstado.Visible = false;
            gbEmpleado.Visible = false;
            gbFecha.Visible = false;
            gbArea.Visible = true;
        }

        private void btnFecha_Click(object sender, EventArgs e)
        {
            gbInventario.Visible = false;
            gbSerie.Visible = false;
            gbMarca.Visible = false;
            gbTipo.Visible = false;
            gbEstado.Visible = false;
            gbEmpleado.Visible = false;
            gbArea.Visible = false;
            gbFecha.Visible = true;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if(gbInventario.Visible == true)
            {
                string invenB1 = tbBNumInven1.Text;
                string invenB2 = tbBNumInven2.Text;
                string idInventario = invenB1 + "-" + invenB2;
                BuscarInventario(idInventario);
            }
            else if (gbSerie.Visible == true)
            {
                string idSerie = tbBNumSerie.Text;
                BuscarSerie(idSerie);
            }
            else if (gbMarca.Visible == true)
            {
                string marca = cbBMarca.Text;
                BuscarMarca(marca);
            }
            else if (gbTipo.Visible == true)
            {
                string tipo = tbBTipo.Text;
                BuscarTipo(tipo);
            }
            else if (gbEstado.Visible == true)
            {
                string estado = cbBEstado.Text;
                BuscarEstado(estado);
            }
            else if (gbEmpleado.Visible == true)
            {
                string empleado = tbBEmpleado.Text;
                BuscarEmpleado(empleado);
            }
            else if (gbArea.Visible == true)
            {
                string area = cbBArea.Text;
                BuscarArea(area);
            }
            else if (gbFecha.Visible == true)
            {
                string fecha = tbFechaB.Text;
                BuscarFecha(fecha);
            }
        }

        private void btnMostrarTodo_Click(object sender, EventArgs e)
        {
            MostrarArticulos();
        }

        private void fecha_ValueChanged(object sender, EventArgs e)
        {
            char u, d, t, c, ci, s, si, o, n, di;
            string uu, dd, tt, cc, cic, ss, sis, oo, nn, did;
            string ll;
            ll = Convert.ToString(fecha.Value);
            tbFechaA.Text = ll;
            u = tbFechaA.Text[0];
            d = tbFechaA.Text[1];
            t = tbFechaA.Text[2];
            c = tbFechaA.Text[3];
            ci = tbFechaA.Text[4];
            s = tbFechaA.Text[5];
            si = tbFechaA.Text[6];
            o = tbFechaA.Text[7];
            n = tbFechaA.Text[8];
            di = tbFechaA.Text[9];
            uu = Convert.ToString(u);
            dd = Convert.ToString(d);
            tt = Convert.ToString(t);
            cc = Convert.ToString(c);
            cic = Convert.ToString(ci);
            ss = Convert.ToString(s);
            sis = Convert.ToString(si);
            oo = Convert.ToString(o);
            nn = Convert.ToString(n);
            did = Convert.ToString(di);
            tbFechaB.Text = uu + dd + tt + cc + cic + ss + sis + oo + nn + did;
        }

        public void MostrarBajas()
        {
            Autenticacion.ConectarBD();
            OleDbCommand coman = new OleDbCommand();
            coman.Connection = Autenticacion.con;
            string query = "SELECT NUMERO_INVENTARIO,NUMERO_SERIE,MARCA,TIPO,ESTADO,EMPLEADO,AREA,OBSERVACIONES,FECHA,HORA FROM BAJA";
            coman.CommandText = query;
            OleDbDataAdapter da = new OleDbDataAdapter(coman);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvBajasTemp.DataSource = dt;
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            string baja1 = tbBTNumInvent1.Text;
            string baja2 = tbBTNumInvent2.Text;
            string bajaTemporal = baja1 + "-" + baja2;
            if (tbBTNumInvent1.Text == "" || tbBTNumInvent2.Text == "")
            {
                MessageBox.Show("Ingrese un número de inventario existente.");
            }
            else
            {
                BuscarBorrar(bajaTemporal);
                MostrarArticulos();
                MostrarBajas();
            }
            tbBTNumInvent1.Clear();
            tbBTNumInvent2.Clear();
        }

        public void BuscarBaja(string id)
        {
            Autenticacion.ConectarBD();
            OleDbCommand busqueda = new OleDbCommand();
            busqueda.Connection = Autenticacion.con;
            busqueda.CommandText = @"SELECT * FROM BAJA";
            OleDbDataReader reader = busqueda.ExecuteReader();
            while (reader.Read())
            {
                if (id == reader.GetValue(1).ToString())
                {
                    idBajas.Text = reader.GetValue(0).ToString();
                    string serie = reader.GetValue(2).ToString();
                    string marca = reader.GetValue(3).ToString();
                    string tipo = reader.GetValue(4).ToString();
                    string estado = reader.GetValue(5).ToString();
                    string empleado = reader.GetValue(6).ToString();
                    string area = reader.GetValue(7).ToString();
                    string observacion = reader.GetValue(8).ToString();
                    string fecha = reader.GetValue(9).ToString();
                    string hora = reader.GetValue(10).ToString();
                    GuardarArticulo(GenerarIDArticulo(), id, serie, marca, tipo, estado, empleado, area, observacion, fecha, hora);
                    EliminarBajaTe(Convert.ToInt16(idBajas.Text));
                }
            }
        }

        public void EliminarBajaTe(int id)
        {
            Autenticacion.ConectarBD();
            OleDbCommand eliminar = new OleDbCommand();
            eliminar.Connection = Autenticacion.con;
            eliminar.CommandText = @"DELETE FROM BAJA WHERE ID = " + id;
            eliminar.ExecuteNonQuery();
            Autenticacion.con.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string alta1 = tbBANumInvent1.Text;
            string alta2 = tbBANumInvent2.Text;
            string altaOV = alta1 + "-" + alta2;
            if (tbBANumInvent1.Text == "" || tbBANumInvent2.Text == "")
            {
                MessageBox.Show("Ingrese un número de inventario existente.");
            }
            else
            {
                BuscarBaja(altaOV);
                MostrarArticulos();
                MostrarBajas();
            }
            tbBANumInvent1.Clear();
            tbBANumInvent2.Clear();
        }

        public void BuscarBajaD(string id)
        {
            Autenticacion.ConectarBD();
            OleDbCommand busqueda = new OleDbCommand();
            busqueda.Connection = Autenticacion.con;
            busqueda.CommandText = @"SELECT * FROM BAJA";
            OleDbDataReader reader = busqueda.ExecuteReader();
            while (reader.Read())
            {
                if (id == reader.GetValue(1).ToString())
                {
                    idBajas.Text = reader.GetValue(0).ToString();
                    string serie = reader.GetValue(2).ToString();
                    string marca = reader.GetValue(3).ToString();
                    string tipo = reader.GetValue(4).ToString();
                    string estado = reader.GetValue(5).ToString();
                    string empleado = reader.GetValue(6).ToString();
                    string area = reader.GetValue(7).ToString();
                    string observacion = reader.GetValue(8).ToString();
                    string fecha = reader.GetValue(9).ToString();
                    string hora = reader.GetValue(10).ToString();
                    EliminarBajaTe(Convert.ToInt16(idBajas.Text));
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string baja1 = tbBDNumInvent1.Text;
            string baja2 = tbBDNumInvent2.Text;
            string bajaDefinitiva = baja1 + "-" + baja2;
            if (tbBDNumInvent1.Text == "" || tbBDNumInvent2.Text == "")
            {
                MessageBox.Show("Ingrese un número de inventario existente.");
            }
            else
            {
                BuscarBajaD(bajaDefinitiva);
                MostrarArticulos();
                MostrarBajas();
            }
            tbBDNumInvent1.Clear();
            tbBDNumInvent2.Clear();
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("No se permiten espacios");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tbInventario.Text = "";
            tbInventario2.Text = "";
            tbSerie.Text = "";
            tbEmpleado.Text = "";
            cbMarca.Text = "";
            tbTipo.Text = "";
            cbEstado.Text = "";
            cbArea.Text = "";
            tbObservaciones.Text = "";
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("No se permiten espacios");
            }
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("No se permiten espacios");
            }
        }

        public void MostrarArticulos()
        {
            Autenticacion.ConectarBD();
            OleDbCommand coman = new OleDbCommand();
            coman.Connection = Autenticacion.con;
            string query = "SELECT NUMERO_INVENTARIO,NUMERO_SERIE,MARCA,TIPO,ESTADO,EMPLEADO,AREA,OBSERVACIONES,FECHA,HORA FROM ARTICULO";
            coman.CommandText = query;
            OleDbDataAdapter da = new OleDbDataAdapter(coman);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvActualizar.DataSource = dt;
            dgvConsultar.DataSource = dt;
        }

        public void BuscarInventario(string idInventario)
        {
            Autenticacion.ConectarBD();
            OleDbCommand coman = new OleDbCommand();
            coman.Connection = Autenticacion.con;
            string query = "SELECT NUMERO_INVENTARIO,NUMERO_SERIE,MARCA,TIPO,ESTADO,EMPLEADO,AREA,OBSERVACIONES,FECHA,HORA FROM ARTICULO WHERE NUMERO_INVENTARIO ='" + idInventario + "'";
            coman.CommandText = query;
            OleDbDataAdapter da = new OleDbDataAdapter(coman);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvConsultar.DataSource = dt;
        }

        public void BuscarSerie(string idSerie)
        {
            Autenticacion.ConectarBD();
            OleDbCommand coman = new OleDbCommand();
            coman.Connection = Autenticacion.con;
            string query = "SELECT NUMERO_INVENTARIO,NUMERO_SERIE,MARCA,TIPO,ESTADO,EMPLEADO,AREA,OBSERVACIONES,FECHA,HORA FROM ARTICULO WHERE NUMERO_SERIE ='" + idSerie + "'";
            coman.CommandText = query;
            OleDbDataAdapter da = new OleDbDataAdapter(coman);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvConsultar.DataSource = dt;
        }

        public void BuscarMarca(string marca)
        {
            Autenticacion.ConectarBD();
            OleDbCommand coman = new OleDbCommand();
            coman.Connection = Autenticacion.con;
            string query = "SELECT NUMERO_INVENTARIO,NUMERO_SERIE,MARCA,TIPO,ESTADO,EMPLEADO,AREA,OBSERVACIONES,FECHA,HORA FROM ARTICULO WHERE MARCA ='" + marca + "'";
            coman.CommandText = query;
            OleDbDataAdapter da = new OleDbDataAdapter(coman);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvConsultar.DataSource = dt;
        }

        public void BuscarTipo(string tipo)
        {
            Autenticacion.ConectarBD();
            OleDbCommand coman = new OleDbCommand();
            coman.Connection = Autenticacion.con;
            string query = "SELECT NUMERO_INVENTARIO,NUMERO_SERIE,MARCA,TIPO,ESTADO,EMPLEADO,AREA,OBSERVACIONES,FECHA,HORA FROM ARTICULO WHERE TIPO ='" + tipo + "'";
            coman.CommandText = query;
            OleDbDataAdapter da = new OleDbDataAdapter(coman);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvConsultar.DataSource = dt;
        }

        public void BuscarEstado(string estado)
        {
            Autenticacion.ConectarBD();
            OleDbCommand coman = new OleDbCommand();
            coman.Connection = Autenticacion.con;
            string query = "SELECT NUMERO_INVENTARIO,NUMERO_SERIE,MARCA,TIPO,ESTADO,EMPLEADO,AREA,OBSERVACIONES,FECHA,HORA FROM ARTICULO WHERE ESTADO ='" + estado + "'";
            coman.CommandText = query;
            OleDbDataAdapter da = new OleDbDataAdapter(coman);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvConsultar.DataSource = dt;
        }

        public void BuscarEmpleado(string empleado)
        {
            Autenticacion.ConectarBD();
            OleDbCommand coman = new OleDbCommand();
            coman.Connection = Autenticacion.con;
            string query = "SELECT NUMERO_INVENTARIO,NUMERO_SERIE,MARCA,TIPO,ESTADO,EMPLEADO,AREA,OBSERVACIONES,FECHA,HORA FROM ARTICULO WHERE EMPLEADO ='" + empleado + "'";
            coman.CommandText = query;
            OleDbDataAdapter da = new OleDbDataAdapter(coman);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvConsultar.DataSource = dt;
        }

        public void BuscarArea(string area)
        {
            Autenticacion.ConectarBD();
            OleDbCommand coman = new OleDbCommand();
            coman.Connection = Autenticacion.con;
            string query = "SELECT NUMERO_INVENTARIO,NUMERO_SERIE,MARCA,TIPO,ESTADO,EMPLEADO,AREA,OBSERVACIONES,FECHA,HORA FROM ARTICULO WHERE AREA ='" + area + "'";
            coman.CommandText = query;
            OleDbDataAdapter da = new OleDbDataAdapter(coman);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvConsultar.DataSource = dt;
        }

        public void BuscarFecha(string fecha)
        {
            Autenticacion.ConectarBD();
            OleDbCommand coman = new OleDbCommand();
            coman.Connection = Autenticacion.con;
            string query = "SELECT NUMERO_INVENTARIO,NUMERO_SERIE,MARCA,TIPO,ESTADO,EMPLEADO,AREA,OBSERVACIONES,FECHA,HORA FROM ARTICULO WHERE FECHA LIKE '%" + fecha + "%'";
            coman.CommandText = query;
            OleDbDataAdapter da = new OleDbDataAdapter(coman);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvConsultar.DataSource = dt;
        }

        public static int GenerarIDArticulo()
        {
            Autenticacion.ConectarBD();
            int ultimo = 0;
            OleDbCommand buscaU = new OleDbCommand();
            buscaU.Connection = Autenticacion.con;
            buscaU.CommandText = @"SELECT ID FROM ARTICULO";
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

        public static void GuardarArticulo(int id, string idInventario, string idSerie, string marca, string tipo, string estado, string empleado, string area, string observaciones, string fecha, string hora)
        {
            Autenticacion.ConectarBD();
            OleDbCommand guardar = new OleDbCommand();
            guardar.Connection = Autenticacion.con;
            guardar.CommandText = @"INSERT INTO ARTICULO VALUES('" + id + "','" + idInventario + "','" + idSerie + "','" + marca + "','" + tipo + "','" + estado + "','" + empleado + "','" + area + "','" + observaciones + "','" + fecha + "','" + hora + "')";
            guardar.ExecuteNonQuery();
            Autenticacion.con.Close();
        }

        public static void GuardarArticuloBaja(int id, string idInventario, string idSerie, string marca, string tipo, string estado, string empleado, string area, string observaciones, string fecha, string hora)
        {
            Autenticacion.ConectarBD();
            OleDbCommand guardar = new OleDbCommand();
            guardar.Connection = Autenticacion.con;
            guardar.CommandText = @"INSERT INTO BAJA VALUES('" + id + "','" + idInventario + "','" + idSerie + "','" + marca + "','" + tipo + "','" + estado + "','" + empleado + "','" + area + "','" + observaciones + "','" + fecha + "','" + hora + "')";
            guardar.ExecuteNonQuery();
            Autenticacion.con.Close();
        }

        string b, c, d, e, f, g, h, i, j, k;

        public void veribaja(String a)
        {
            if (a == "")
            {
                MessageBox.Show("Ingrese un numero de serie para eliminar");
            }
            else
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = Autenticacion.con;
                String query = "SELECT * FROM ARTICULOS WHERE NUMERO_INVENTARIO ='" + a + "'";
                cmd.CommandText = @query;
                cmd.ExecuteNonQuery();
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    baja = reader.GetValue(0).ToString();
                    b = reader.GetValue(1).ToString();
                    c = reader.GetValue(2).ToString();
                    d = reader.GetValue(3).ToString();
                    e = reader.GetValue(4).ToString();
                    f = reader.GetValue(5).ToString();
                    g = reader.GetValue(6).ToString();
                    h = reader.GetValue(7).ToString();
                    i = reader.GetValue(8).ToString();
                    j = reader.GetValue(9).ToString();
                    k = reader.GetValue(10).ToString();
                }
                if (baja == a)
                {
                    bajas(a, b, c, d, e, f, g, h, i, j, k);
                    a = ""; b = ""; c = ""; d = ""; e = ""; f = ""; g = ""; h = ""; i = ""; j = ""; k = "";
                }
                else
                {
                    MessageBox.Show("Numero de serie inexiste");
                }
            }
        }

        public void bajas(String a, String b, String c, String d, String e, String f, String g, String h, String i, String j, String k)
        {

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = Autenticacion.con;
            String query = "DELETE * FROM ARTICULOS WHERE NUMERO_INVENTARIO ='" + a + "'";
            cmd.CommandText = @query;
            cmd.ExecuteNonQuery();
            OleDbDataReader reader = cmd.ExecuteReader();
            GA1(a, b, c, d, e, f, g, h, i, j, k);
            actualizardata1();
        }

        public void GA1(String a, String b, String c, String d, String e, String f, String g, String h, String i, String j, String k)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = Autenticacion.con;
            String query = "INSERT INTO BAJAS(NUMERO_INVENTARIO,NUMERO_SERIE,MARCA,TIPO,ESTADO,ID_RESGUARDANTE,ID_AREA,OBSERVACIONES,DEPARTAMENTO,FECHA,HORA)VALUES('" + a + "','" + b + "','" + c + "','" + d + "','" + e + "','" + f + "','" + g + "','" + h + "','" + i + "','" + j + "','" + k + "')";
            cmd.CommandText = @query;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Registro Borrado");
            a = " ";
            b = " ";
            c = " ";
            d = " ";
            e = " ";
            f = " ";
            g = " ";
            h = " ";
            i = " ";
        }

        public void actualizardata()
        {
            try
            {
                Autenticacion.ConectarBD();
                OleDbCommand coman = new OleDbCommand();
                coman.Connection = Autenticacion.con;
                string query = "select * from ARTICULOS";
                coman.CommandText = query;
                OleDbDataAdapter da = new OleDbDataAdapter(coman);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvConsultar.DataSource = dt;
                Autenticacion.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        string bb, cc, dd, ee, ff, gg, hh, ii, jj, kk;

        private void cbAObservaciones_CheckedChanged(object sender, EventArgs e)
        {
            tbAObservaciones.Enabled = true;
            btnActualizar.Enabled = true;
        }

        private void cbAArea_CheckedChanged(object sender, EventArgs e)
        {
            cbAAreas.Enabled = true;
            btnActualizar.Enabled = true;
        }

        private void cbAEmpleado_CheckedChanged(object sender, EventArgs e)
        {
            tbAEmpleados.Enabled = true;
            btnActualizar.Enabled = true;
        }

        private void cbAEstado_CheckedChanged(object sender, EventArgs e)
        {
            cbAEstados.Enabled = true;
            btnActualizar.Enabled = true;
        }

        private void cbATipo_CheckedChanged(object sender, EventArgs e)
        {
            tbATipo.Enabled = true;
            btnActualizar.Enabled = true;
        }

        private void cbAMarca_CheckedChanged(object sender, EventArgs e)
        {
            cbAMarcas.Enabled = true;
            btnActualizar.Enabled = true;
        }

        private void cbANumSerie_CheckedChanged(object sender, EventArgs e)
        {
            tbANumSerie.Enabled = true;
            btnActualizar.Enabled = true;
        }






        /* public void MostrarArticulo(string id)
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
         }*/


        public void veribaja1(String aa)
        {
            if (aa == "")
            {
                MessageBox.Show("Ingrese un numero de serie para dar de alta");
            }
            else
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = Autenticacion.con;
                String query = "SELECT * FROM BAJAS WHERE NUMERO_INVENTARIO ='" + aa + "'";
                cmd.CommandText = @query;
                cmd.ExecuteNonQuery();
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    baja = reader.GetValue(0).ToString();
                    bb = reader.GetValue(1).ToString();
                    cc = reader.GetValue(2).ToString();
                    dd = reader.GetValue(3).ToString();
                    ee = reader.GetValue(4).ToString();
                    ff = reader.GetValue(5).ToString();
                    gg = reader.GetValue(6).ToString();
                    hh = reader.GetValue(7).ToString();
                    ii = reader.GetValue(8).ToString();
                    jj = reader.GetValue(9).ToString();
                    kk = reader.GetValue(10).ToString();
                }
                if (baja == aa)
                {
                    guardar(aa, bb, cc, dd, ee, ff, gg, hh, ii, jj, kk);
                    bajas1(aa);
                    aa = ""; bb = ""; cc = ""; dd = ""; ee = ""; ff = ""; gg = ""; hh = ""; ii = "";
                }
                else
                {
                    MessageBox.Show("Numero de serie inexiste");
                }
            }
        }

        public void guardar(String a, String b, String c, String d, String e, String f, String g, String h, String i, String j, String k)
        {
            if (a == "" || c == "" || d == "" || e == "" || f == "" || g == "" || i == "")
            {
                MessageBox.Show("Te faltan valores");
            }
            else
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = Autenticacion.con;
                String query = "SELECT * FROM ARTICULOS WHERE NUMERO_INVENTARIO ='" + a + "'";
                cmd.CommandText = @query;
                cmd.ExecuteNonQuery();
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    vg = reader.GetValue(1).ToString();
                }
                if (vg == a)
                {
                    MessageBox.Show("Numero de serie duplicado");
                }
                else
                {
                    veriguarda(a, b, c, d, e, f, g, h, i, j, k);
                }
            }
        }

        public void veriguarda(String a, String b, String c, String d, String e, String f, String g, String h, String i, String j, String k)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = Autenticacion.con;
            String query = "INSERT INTO ARTICULOS(NUMERO_INVENTARIO,NUMERO_SERIE,MARCA,TIPO,ESTADO,ID_RESGUARDANTE,ID_AREA,OBSERVACIONES,DEPARTAMENTO,FECHA,HORA)VALUES('" + a + "','" + b + "','" + c + "','" + d + "','" + e + "','" + f + "','" + g + "','" + h + "','" + i + "','" + j + "','" + k + "')";
            cmd.CommandText = @query;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Registro guardado");
            actualizardata();
            a = "";
            b = "";
            c = "";
            d = "";
            e = "";
            f = "";
            g = "";
            h = "";
            i = "";
        }

        public void bajas1(String a)
        {
            Autenticacion.ConectarBD();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = Autenticacion.con;
            String query = "DELETE * FROM bajas WHERE NUMERO_INVENTARIO ='" + a + "'";
            cmd.CommandText = @query;
            cmd.ExecuteNonQuery();
            OleDbDataReader reader = cmd.ExecuteReader();
            actualizardata1();
            Autenticacion.con.Close();
        }

        public void actualizardata1()
        {
            try
            {
                Autenticacion.ConectarBD();
                OleDbCommand coman = new OleDbCommand();
                coman.Connection = Autenticacion.con;
                string query = "select * from BAJAS";
                coman.CommandText = query;
                OleDbDataAdapter da = new OleDbDataAdapter(coman);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvBajasTemp.DataSource = dt;
                Autenticacion.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
            }

        public void veribaja2(String a)
        {
            if (a == "")
            {
                MessageBox.Show("Ingrese un numero de serie para eliminar");
            }
            else
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = Autenticacion.con;
                String query = "SELECT * FROM ARTICULOS WHERE NUMERO_INVENTARIO ='" + a + "'";
                cmd.CommandText = @query;
                cmd.ExecuteNonQuery();
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    baja = reader.GetValue(0).ToString();
                    b = reader.GetValue(1).ToString();
                    c = reader.GetValue(2).ToString();
                    d = reader.GetValue(3).ToString();
                    e = reader.GetValue(4).ToString();
                    f = reader.GetValue(5).ToString();
                    g = reader.GetValue(6).ToString();
                    h = reader.GetValue(7).ToString();
                    i = reader.GetValue(8).ToString();
                    j = reader.GetValue(9).ToString();
                    k = reader.GetValue(10).ToString();
                }
                if (baja == a)
                {
                    bajas2(a, b, c, d, e, f, g, h, i, j, k);
                    a = ""; b = ""; c = ""; d = ""; e = ""; f = ""; g = ""; h = ""; i = ""; j = ""; k = "";
                }
                else
                {
                    MessageBox.Show("Numero de serie inexiste");
                }
            }
        }

        public void bajas2(String a, String b, String c, String d, String e, String f, String g, String h, String i, String j, String k)
        {

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = Autenticacion.con;
            String query = "DELETE * FROM ARTICULOS WHERE NUMERO_INVENTARIO ='" + a + "'";
            cmd.CommandText = @query;
            cmd.ExecuteNonQuery();
            OleDbDataReader reader = cmd.ExecuteReader();
            GA3(a, b, c, d, e, f, g, h, i, j, k);
            actualizardata1();
        }

        public void GA3(String a, String b, String c, String d, String e, String f, String g, String h, String i, String j, String k)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = Autenticacion.con;
            String query = "INSERT INTO BAJASDEF(NUMERO_INVENTARIO,NUMERO_SERIE,MARCA,TIPO,ESTADO,ID_RESGUARDANTE,ID_AREA,OBSERVACIONES,DEPARTAMENTO,FECHA,HORA)VALUES('" + a + "','" + b + "','" + c + "','" + d + "','" + e + "','" + f + "','" + g + "','" + h + "','" + i + "','" + j + "','" + k + "')";
            cmd.CommandText = @query;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Registro Borrado");
            a = " ";
            b = " ";
            c = " ";
            d = " ";
            e = " ";
            f = " ";
            g = " ";
            h = " ";
            i = " ";
        }

        public void veriact(String a, String b, String c, String d, String e, String f, String g, String h, String i, String j)
        {
            if (a == "" || c == "" || d == "" || e == "" || f == "" || g == "" || i == "")
            {
                MessageBox.Show("Completa los campos");
            }
            else
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = Autenticacion.con;
                String query = "SELECT * FROM ARTICULOS WHERE NUMERO_INVENTARIO ='" + a + "'";
                cmd.CommandText = @query;
                cmd.ExecuteNonQuery();
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    act = reader.GetValue(0).ToString();
                }
                if (act == a)
                {
                    elimi1(a, b, c, d, e, f, g, h, i, j, k);
                }
                else
                {
                    MessageBox.Show("No existe el registro");
                }
            }
        }
        public void elimi1(String a, String b, String c, String d, String e, String f, String g, String h, String i, String j, String k)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = Autenticacion.con;
            String query = "DELETE * FROM ARTICULOS WHERE NUMERO_INVENTARIO ='" + a + "'";
            cmd.CommandText = @query;
            cmd.ExecuteNonQuery();
            OleDbDataReader reader = cmd.ExecuteReader();
            GA(a, b, c, d, e, f, g, h, i, j, k);
            actualizardata();
        }

        public void GA(String a, String b, String c, String d, String e, String f, String g, String h, String i, String j, String k)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = Autenticacion.con;
            String query = "INSERT INTO ARTICULOS(NUMERO_INVENTARIO,NUMERO_SERIE,MARCA,TIPO,ESTADO,ID_RESGUARDANTE,ID_AREA,OBSERVACIONES,DEPARTAMENTO,FECHA,HORA)VALUES('" + a + "','" + b + "','" + c + "','" + d + "','" + e + "','" + f + "','" + g + "','" + h + "','" + i + "','" + j + "','" + k + "')";
            cmd.CommandText = @query;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Registro Agregado");
            a = "";
            b = "";
            c = "";
            d = "";
            e = "";
            f = "";
            g = "";
            h = "";
            i = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*Autenticacion.ConectarBD();
            veriact(tbInventario.Text, tbSerie.Text, tbEmpleado.Text, cbMarca.Text, tbTipo.Text, cbEstado.Text, cbArea.Text, tbObservaciones.Text, tbFecha.Text, tbHora.Text);
            Autenticacion.con.Close();*/
        }

        /*

         public void veri(String elim)
         {
             if (elim == "")
             {
                 MessageBox.Show("Ingrese un numero de serie para eliminar");
             }
             else
             {
                 OleDbCommand cmd = new OleDbCommand();
                 cmd.Connection = Autenticacion.con;
                 String query = "SELECT * FROM ARTICULOS WHERE NUMERO_INVENTARIO ='" + elim + "'";
                 cmd.CommandText = @query;
                 cmd.ExecuteNonQuery();
                 OleDbDataReader reader = cmd.ExecuteReader();
                 while (reader.Read())
                 {
                     eli = reader.GetValue(0).ToString();
                 }
                 if (eli == elim)
                 {
                     elimi(elim);
                 }
                 else
                 {
                     MessageBox.Show("Numero de serie inexiste");
                 }
             }
         }

         public void actualizar(String a, String b, String c, String d, String e, String f, String g, String h, String i, String j, String k)
         {
             OleDbCommand cmd = new OleDbCommand();
             cmd.Connection = Autenticacion.con;
             String query = "Update ARTICULOS set NUMERO_SERIE=' " + b + "',MARCA=' " + c + "',TIPO=' " + d + "',ESTADO=' " + e + "',ID_RESGUARDANTE=' " + f + "',ID_AREA=' " + g + "',OBSERVACIONES=' " + h + "',DEPARTAMENTO=' " + i + "',FECHA=' " + j + "',HORA=' " + k + "' WHERE(NUMERO_INVENTARIO) = '" + a + "'";
             cmd.CommandText = @query;
             cmd.ExecuteNonQuery();
             MessageBox.Show("Ariculo Actualizado");
             actualizardata();
         }

         public void elimi(String eli)
         {
             OleDbCommand cmd = new OleDbCommand();
             cmd.Connection = Autenticacion.con;
             String query = "DELETE * FROM ARTICULOS WHERE NUMERO_INVENTARIO ='" + eli + "'";
             cmd.CommandText = @query;
             cmd.ExecuteNonQuery();
             OleDbDataReader reader = cmd.ExecuteReader();
             MessageBox.Show("Ariculo Eliminado");
             actualizardata();      
         }*/


    }
}
