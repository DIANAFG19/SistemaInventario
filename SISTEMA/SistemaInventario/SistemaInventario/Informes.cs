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
    public partial class Informes : Form
    {

        DataSet datosArea;
        public Informes()
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

        private void Informes_Load(object sender, EventArgs e)
        {
            MostrarArticulos();
            MostrarEmpleados();
            //Mostrar las áreas en el cbArea
            datosArea = new DataSet();
            OleDbDataAdapter Adaptador = new OleDbDataAdapter("SELECT * FROM AREA", Autenticacion.con);
            Adaptador.Fill(datosArea, "Area");
            cbAreas.DataSource = datosArea.Tables[0].DefaultView;
            cbAreas.Text = null;
            cbAreas.ValueMember = "ID_Area";
            cbAreas.DisplayMember = "AREA";
            Autenticacion.con.Close();
        }

        private void btnEBuscar_Click(object sender, EventArgs e)
        {
            if(tbNumEmpleado.Text == "")
            {
                MessageBox.Show("Ingrese un número de empleado válido");
            }
            else
            {
                MostrarEmpleado(tbNumEmpleado.Text);
            }
        }

        private void btnExportarArticulos_Click(object sender, EventArgs e)
        {
            ExportarArticulos(dgvArticulos);
        }

        private void btnExportarEmpleado_Click(object sender, EventArgs e)
        {
            ExportarEmpleados(dgvEmpleado);
        }

        private void fecha_ValueChanged(object sender, EventArgs e)
        {
            char u, d, t, c, ci, s, si, o, n, di;
            string uu, dd, tt, cc, cic, ss, sis, oo, nn, did;
            string ll;
            ll = Convert.ToString(fecha.Value);
            textBox14.Text = ll;
            u = textBox14.Text[0];
            d = textBox14.Text[1];
            t = textBox14.Text[2];
            c = textBox14.Text[3];
            ci = textBox14.Text[4];
            s = textBox14.Text[5];
            si = textBox14.Text[6];
            o = textBox14.Text[7];
            n = textBox14.Text[8];
            di = textBox14.Text[9];
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
            textBox15.Text = uu + dd + cc + cic + sis + oo + nn + did;
        }

        private void fecha2_ValueChanged(object sender, EventArgs e)
        {
            char u, d, t, c, ci, s, si, o, n, di;
            string uu, dd, cc, cic, sis, oo, nn, did;
            string ll;
            ll = Convert.ToString(fecha2.Value);
            textBox2.Text = ll;
            u = textBox2.Text[0];
            d = textBox2.Text[1];
            t = textBox2.Text[2];
            c = textBox2.Text[3];
            ci = textBox2.Text[4];
            s = textBox2.Text[5];
            si = textBox2.Text[6];
            o = textBox2.Text[7];
            n = textBox2.Text[8];
            di = textBox2.Text[9];
            uu = Convert.ToString(u);
            dd = Convert.ToString(d);
            cc = Convert.ToString(c);
            cic = Convert.ToString(ci);
            sis = Convert.ToString(si);
            oo = Convert.ToString(o);
            nn = Convert.ToString(n);
            did = Convert.ToString(di);
            textBox3.Text = uu + dd + cc + cic + sis + oo + nn + did;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            consultarFecha(textBox15.Text, textBox3.Text);
        }

        private void btnExportar4_Click(object sender, EventArgs e)
        {
            ExportarFechas(dgvFechas);
        }

        private void btnBuscarArea_Click(object sender, EventArgs e)
        {
            consultarArea(cbAreas.Text);
        }

        private void btnExportar5_Click(object sender, EventArgs e)
        {
            ExportarAreas(dgvAreas);
        }

        public void MostrarArticulos()
        {
            Autenticacion.ConectarBD();
            OleDbCommand coman = new OleDbCommand();
            coman.Connection = Autenticacion.con;
            string query = "SELECT ARTICULO.NUMERO_INVENTARIO,ARTICULO.NUMERO_SERIE,ARTICULO.MARCA,ARTICULO.TIPO,ARTICULO.ESTADO,PERSONAL.APELLIDO_PATERNO,PERSONAL.APELLIDO_MATERNO,PERSONAL.NOMBRE,ARTICULO.AREA,ARTICULO.OBSERVACIONES,ARTICULO.FECHA,ARTICULO.HORA FROM ARTICULO, PERSONAL WHERE ARTICULO.EMPLEADO = PERSONAL.ID_EMPLEADO";
            coman.CommandText = query;
            OleDbDataAdapter da = new OleDbDataAdapter(coman);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvArticulos.DataSource = dt;
            dgvFechas.DataSource = dt;
            dgvAreas.DataSource = dt;
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
            dgvEmpleado.DataSource = dt;
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
            dgvEmpleado.DataSource = dt;
        }

        public void consultarFecha(String A, String B)
        {
            Autenticacion.ConectarBD();
            OleDbCommand coman = new OleDbCommand();
            coman.Connection = Autenticacion.con;
            string query = "SELECT NUMERO_INVENTARIO,NUMERO_SERIE,MARCA,TIPO,ESTADO,EMPLEADO,AREA,OBSERVACIONES,FECHA,HORA FROM ARTICULO WHERE FECHA BETWEEN '" + A + "' AND '" + B + "'";
            coman.CommandText = query;
            OleDbDataAdapter da = new OleDbDataAdapter(coman);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvFechas.DataSource = dt;
            Autenticacion.con.Close();
        }

        public void consultarArea(string area)
        {
            Autenticacion.ConectarBD();
            OleDbCommand coman = new OleDbCommand();
            coman.Connection = Autenticacion.con;
            string query = "SELECT NUMERO_INVENTARIO,NUMERO_SERIE,MARCA,TIPO,ESTADO,EMPLEADO,AREA,OBSERVACIONES,FECHA,HORA FROM ARTICULO WHERE AREA = '" + area + "'";
            coman.CommandText = query;
            OleDbDataAdapter da = new OleDbDataAdapter(coman);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvAreas.DataSource = dt;
            Autenticacion.con.Close();
        }

        public void ExportarArticulos(DataGridView grd)
        {
            try
            {
                SaveFileDialog archivo = new SaveFileDialog();
                archivo.Filter = "Excel (*.xls)|*.xls";
                archivo.FileName = "Informe de Articulos." + DateTime.Now.Date.ToShortDateString().Replace('/', '-');
                if (archivo.ShowDialog() == DialogResult.OK)
                {
                    Microsoft.Office.Interop.Excel.Application aplicacion;
                    Microsoft.Office.Interop.Excel.Workbook libroDeTrabajo;
                    Microsoft.Office.Interop.Excel.Worksheet hojaDeTrabajo;
                    aplicacion = new Microsoft.Office.Interop.Excel.Application();
                    libroDeTrabajo = aplicacion.Workbooks.Add();
                    hojaDeTrabajo = (Microsoft.Office.Interop.Excel.Worksheet)libroDeTrabajo.Worksheets.get_Item(1);
                    hojaDeTrabajo.Cells[1, "A"] = grd.Columns[0].HeaderText;
                    hojaDeTrabajo.Cells[1, "B"] = grd.Columns[1].HeaderText;
                    hojaDeTrabajo.Cells[1, "C"] = grd.Columns[2].HeaderText;
                    hojaDeTrabajo.Cells[1, "D"] = grd.Columns[3].HeaderText;
                    hojaDeTrabajo.Cells[1, "E"] = grd.Columns[4].HeaderText;
                    hojaDeTrabajo.Cells[1, "F"] = grd.Columns[5].HeaderText;
                    hojaDeTrabajo.Cells[1, "G"] = grd.Columns[6].HeaderText;
                    hojaDeTrabajo.Cells[1, "H"] = grd.Columns[7].HeaderText;
                    hojaDeTrabajo.Cells[1, "I"] = grd.Columns[8].HeaderText;
                    hojaDeTrabajo.Cells[1, "J"] = grd.Columns[9].HeaderText;
                    hojaDeTrabajo.Columns[1].AutoFit();
                    hojaDeTrabajo.Columns[2].AutoFit();
                    hojaDeTrabajo.Columns[3].AutoFit();
                    hojaDeTrabajo.Columns[4].AutoFit();
                    hojaDeTrabajo.Columns[5].AutoFit();
                    hojaDeTrabajo.Columns[6].AutoFit();
                    hojaDeTrabajo.Columns[7].AutoFit();
                    hojaDeTrabajo.Columns[8].AutoFit();
                    hojaDeTrabajo.Columns[9].AutoFit();
                    hojaDeTrabajo.Columns[10].AutoFit();
                    hojaDeTrabajo.Name = "ARTICULOS";
                    for (int i = 0; i < grd.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j < grd.Columns.Count; j++)
                        {
                            if (grd.Rows[i].Cells[j].Value != null)
                            {
                                hojaDeTrabajo.Cells[i + 2, j + 1] = grd.Rows[i].Cells[j].Value.ToString();
                            }
                        }
                    }
                    libroDeTrabajo.SaveAs(archivo.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                    libroDeTrabajo.Close(true);
                    aplicacion.Quit();
                    MessageBox.Show("Informe de articulos exportado con éxito.", "PROCURADURÍA");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar la informacion debido a: " + ex.ToString());
            }
        }

        public void ExportarEmpleados(DataGridView grd)
        {
            try
            {
                SaveFileDialog archivo = new SaveFileDialog();
                archivo.Filter = "Excel (*.xls)|*.xls";
                archivo.FileName = "Informe de Personal" + DateTime.Now.Date.ToShortDateString().Replace('/', '-');
                if (archivo.ShowDialog() == DialogResult.OK)
                {
                    Microsoft.Office.Interop.Excel.Application aplicacion;
                    Microsoft.Office.Interop.Excel.Workbook libroDeTrabajo;
                    Microsoft.Office.Interop.Excel.Worksheet hojaDeTrabajo;
                    aplicacion = new Microsoft.Office.Interop.Excel.Application();
                    libroDeTrabajo = aplicacion.Workbooks.Add();
                    hojaDeTrabajo = (Microsoft.Office.Interop.Excel.Worksheet)libroDeTrabajo.Worksheets.get_Item(1);
                    hojaDeTrabajo.Cells[1, "A"] = grd.Columns[0].HeaderText;
                    hojaDeTrabajo.Cells[1, "B"] = grd.Columns[1].HeaderText;
                    hojaDeTrabajo.Cells[1, "C"] = grd.Columns[2].HeaderText;
                    hojaDeTrabajo.Cells[1, "D"] = grd.Columns[3].HeaderText;
                    hojaDeTrabajo.Cells[1, "E"] = grd.Columns[4].HeaderText;
                    hojaDeTrabajo.Cells[1, "F"] = grd.Columns[5].HeaderText;
                    hojaDeTrabajo.Columns[1].AutoFit();
                    hojaDeTrabajo.Columns[2].AutoFit();
                    hojaDeTrabajo.Columns[3].AutoFit();
                    hojaDeTrabajo.Columns[4].AutoFit();
                    hojaDeTrabajo.Columns[5].AutoFit();
                    hojaDeTrabajo.Columns[6].AutoFit();
                    hojaDeTrabajo.Name = "Empleados";
                    for (int i = 0; i < grd.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j < grd.Columns.Count; j++)
                        {
                            if (grd.Rows[i].Cells[j].Value != null)
                            {
                                hojaDeTrabajo.Cells[i + 2, j + 1] = grd.Rows[i].Cells[j].Value.ToString();
                            }
                        }
                    }
                    libroDeTrabajo.SaveAs(archivo.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                    libroDeTrabajo.Close(true);
                    aplicacion.Quit();
                    MessageBox.Show("Informe de Empleado (s) exportado exitosamente.", "PROCURADURÍA");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar la informacion debido a: " + ex.ToString());
            }
        }

        public void ExportarFechas(DataGridView grd)
        {
            try
            {
                SaveFileDialog archivo = new SaveFileDialog();
                archivo.Filter = "Excel (*.xls)|*.xls";
                archivo.FileName = "Informe de Fechas" + DateTime.Now.Date.ToShortDateString().Replace('/', '-');
                if (archivo.ShowDialog() == DialogResult.OK)
                {
                    Microsoft.Office.Interop.Excel.Application aplicacion;
                    Microsoft.Office.Interop.Excel.Workbook libroDeTrabajo;
                    Microsoft.Office.Interop.Excel.Worksheet hojaDeTrabajo;
                    aplicacion = new Microsoft.Office.Interop.Excel.Application();
                    libroDeTrabajo = aplicacion.Workbooks.Add();
                    hojaDeTrabajo = (Microsoft.Office.Interop.Excel.Worksheet)libroDeTrabajo.Worksheets.get_Item(1);
                    hojaDeTrabajo.Cells[1, "A"] = grd.Columns[0].HeaderText;
                    hojaDeTrabajo.Cells[1, "B"] = grd.Columns[1].HeaderText;
                    hojaDeTrabajo.Cells[1, "C"] = grd.Columns[2].HeaderText;
                    hojaDeTrabajo.Cells[1, "D"] = grd.Columns[3].HeaderText;
                    hojaDeTrabajo.Cells[1, "E"] = grd.Columns[4].HeaderText;
                    hojaDeTrabajo.Cells[1, "F"] = grd.Columns[5].HeaderText;
                    hojaDeTrabajo.Cells[1, "G"] = grd.Columns[6].HeaderText;
                    hojaDeTrabajo.Cells[1, "H"] = grd.Columns[7].HeaderText;
                    hojaDeTrabajo.Cells[1, "I"] = grd.Columns[8].HeaderText;
                    hojaDeTrabajo.Cells[1, "J"] = grd.Columns[9].HeaderText;
                    hojaDeTrabajo.Columns[1].AutoFit();
                    hojaDeTrabajo.Columns[2].AutoFit();
                    hojaDeTrabajo.Columns[3].AutoFit();
                    hojaDeTrabajo.Columns[4].AutoFit();
                    hojaDeTrabajo.Columns[5].AutoFit();
                    hojaDeTrabajo.Columns[6].AutoFit();
                    hojaDeTrabajo.Columns[7].AutoFit();
                    hojaDeTrabajo.Columns[8].AutoFit();
                    hojaDeTrabajo.Columns[9].AutoFit();
                    hojaDeTrabajo.Columns[10].AutoFit();
                    hojaDeTrabajo.Name = "Fecha (s)";
                    for (int i = 0; i < grd.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j < grd.Columns.Count; j++)
                        {
                            if (grd.Rows[i].Cells[j].Value != null)
                            {
                                hojaDeTrabajo.Cells[i + 2, j + 1] = grd.Rows[i].Cells[j].Value.ToString();
                            }
                        }
                    }
                    libroDeTrabajo.SaveAs(archivo.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                    libroDeTrabajo.Close(true);
                    aplicacion.Quit();
                    MessageBox.Show("Informe de Fechas exportado a Excel exitosamente.", "PROCURADURÍA");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar la informacion debido a: " + ex.ToString());
            }
        }

        public void ExportarAreas(DataGridView grd)
        {
            try
            {
                SaveFileDialog archivo = new SaveFileDialog();
                archivo.Filter = "Excel (*.xls)|*.xls";
                archivo.FileName = "Informe de Áreas" + DateTime.Now.Date.ToShortDateString().Replace('/', '-');
                if (archivo.ShowDialog() == DialogResult.OK)
                {
                    Microsoft.Office.Interop.Excel.Application aplicacion;
                    Microsoft.Office.Interop.Excel.Workbook libroDeTrabajo;
                    Microsoft.Office.Interop.Excel.Worksheet hojaDeTrabajo;
                    aplicacion = new Microsoft.Office.Interop.Excel.Application();
                    libroDeTrabajo = aplicacion.Workbooks.Add();
                    hojaDeTrabajo = (Microsoft.Office.Interop.Excel.Worksheet)libroDeTrabajo.Worksheets.get_Item(1);
                    hojaDeTrabajo.Cells[1, "A"] = grd.Columns[0].HeaderText;
                    hojaDeTrabajo.Cells[1, "B"] = grd.Columns[1].HeaderText;
                    hojaDeTrabajo.Cells[1, "C"] = grd.Columns[2].HeaderText;
                    hojaDeTrabajo.Cells[1, "D"] = grd.Columns[3].HeaderText;
                    hojaDeTrabajo.Cells[1, "E"] = grd.Columns[4].HeaderText;
                    hojaDeTrabajo.Cells[1, "F"] = grd.Columns[5].HeaderText;
                    hojaDeTrabajo.Cells[1, "G"] = grd.Columns[6].HeaderText;
                    hojaDeTrabajo.Cells[1, "H"] = grd.Columns[7].HeaderText;
                    hojaDeTrabajo.Cells[1, "I"] = grd.Columns[8].HeaderText;
                    hojaDeTrabajo.Cells[1, "J"] = grd.Columns[9].HeaderText;
                    hojaDeTrabajo.Columns[1].AutoFit();
                    hojaDeTrabajo.Columns[2].AutoFit();
                    hojaDeTrabajo.Columns[3].AutoFit();
                    hojaDeTrabajo.Columns[4].AutoFit();
                    hojaDeTrabajo.Columns[5].AutoFit();
                    hojaDeTrabajo.Columns[6].AutoFit();
                    hojaDeTrabajo.Columns[7].AutoFit();
                    hojaDeTrabajo.Columns[8].AutoFit();
                    hojaDeTrabajo.Columns[9].AutoFit();
                    hojaDeTrabajo.Columns[10].AutoFit();
                    hojaDeTrabajo.Name = "Área";
                    for (int i = 0; i < grd.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j < grd.Columns.Count; j++)
                        {
                            if (grd.Rows[i].Cells[j].Value != null)
                            {
                                hojaDeTrabajo.Cells[i + 2, j + 1] = grd.Rows[i].Cells[j].Value.ToString();
                            }
                        }
                    }
                    libroDeTrabajo.SaveAs(archivo.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                    libroDeTrabajo.Close(true);
                    aplicacion.Quit();
                    MessageBox.Show("Informe de áreas exportado de manera exitosa a Excel.", "PROCURADURÍA");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar la informacion debido a: " + ex.ToString());
            }
        }   
    }
}
