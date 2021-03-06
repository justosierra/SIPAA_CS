﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SIPAA_CS.App_Code;
using SIPAA_CS.App_Code.RecursosHumanos.Catalogos;
using SIPAA_CS.RecursosHumanos.Reportes;
using SIPAA_CS.Properties;
using static SIPAA_CS.App_Code.Usuario;

using CrystalDecisions.CrystalReports.Engine;

//***********************************************************************************************
//Autor: noe alvarez marquina
//Fecha creación: 06-dic-2017       Última Modificacion: dd-mm-aaaa
//Descripción: catalogo de correos para alertas de correos
//***********************************************************************************************

namespace SIPAA_CS.RecursosHumanos.Catalogos
{
    public partial class CorreosAvisosIncidencias : Form
    {

        #region
        int iins, iact, ielim, iimp;

        int iactbtn, icvcorreomodif;
        #endregion

        Perfil DatPerfil = new Perfil();
        Utilerias Util = new Utilerias();
        CorreoAvisoIncidencia correoinc = new CorreoAvisoIncidencia();

        public CorreosAvisosIncidencias()
        {
            InitializeComponent();
        }


        //-----------------------------------------------------------------------------------------------
        //                                      C O M B O S
        //-----------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------
        //                                      G R I D // S
        //-----------------------------------------------------------------------------------------------

        //accion al tocar grid conforme a permisos del usuario
        private void dgvcatce_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (iins == 1 && iact == 1 && ielim == 1)
            {
                factgrid();
                Util.ChangeButton(btninsertar, 2, false);
                ckbeliminar.Visible = true;
                ckbeliminar.Checked = false;
                iactbtn = 2;
            }
            else if (iins == 1 && iact == 1)
            {
                factgrid();
                Util.ChangeButton(btninsertar, 2, false);
                iactbtn = 2;
            }
            else if (iins == 1 && ielim == 1)
            {
                factgrid();
                Util.ChangeButton(btninsertar, 2, false);
                ckbeliminar.Visible = true;
                ckbeliminar.Checked = false;
                iactbtn = 2;
            }
            else if (iact == 1 && ielim == 1)
            {
                factgrid();
                Util.ChangeButton(btninsertar, 2, false);
                ckbeliminar.Visible = true;
                ckbeliminar.Checked = false;
                iactbtn = 2;
            }
            else if (iins == 1)
            {
                factgrid();
                Util.ChangeButton(btninsertar, 2, false);
                iactbtn = 2;
            }
            else if (iact == 1)
            {
                factgrid();
                Util.ChangeButton(btninsertar, 2, false);
                iactbtn = 2;
            }
            else if (ielim == 1)
            {
                factgrid();
                Util.ChangeButton(btninsertar, 3, false);
                ckbeliminar.Visible = true;
                ckbeliminar.Checked = false;
                iactbtn = 3;
            }
            else
            {

            }
        }

        //-----------------------------------------------------------------------------------------------
        //                                     B O T O N E S
        //-----------------------------------------------------------------------------------------------
        private void btnregresar_Click(object sender, EventArgs e)
        {
            RechDashboard rechdb = new RechDashboard();
            rechdb.Show();
            this.Close();
        }

        private void btnminimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Seguro que desea salir?", "SIPAA", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            dgvcatce.DataSource = null;

            int inumcolumngrid = dgvcatce.ColumnCount;

            if (inumcolumngrid == 1)
            {
                dgvcatce.Columns.RemoveAt(0);
            }

            //llena grid
            fllenagridbusqueda(4, 0, "", 0, 0, "", LoginInfo.IdTrab, this.Name);

            pnlcrudcorreo.Visible = true;

            txtnombre.Text = "";

            Util.ChangeButton(btninsertar, 1, false);

            //cb rol
            cborol.DataSource = null;
            DataTable dtrol = correoinc.dtdgvcbcorreo(5, 0, "", 0, 0, "", LoginInfo.IdTrab, this.Name);
            Utilerias.llenarComboxDataTable(cborol, dtrol, "clave", "descrip");

            //cb rol
            cboformapago.DataSource = null;
            DataTable dtformapago = correoinc.dtdgvcbcorreo(6, 0, "", 0, 0, "", LoginInfo.IdTrab, this.Name);
            Utilerias.llenarComboxDataTable(cboformapago, dtformapago, "clave", "descrip");

            txtcorreo.Text = "";

            ckbeliminar.Visible = false;

            iactbtn = 1;

            txtnombre.Focus();
        }

        private void btninsertar_Click(object sender, EventArgs e)
        {
            //guarda datos
            if (iactbtn == 1)
            {
                //valida campos
                Boolean bvalidacampos = fvalidacampos();

                if (bvalidacampos == true)
                {
                    int ivali = correoinc.crudcorreo(1, 0, txtnombre.Text.Trim(), Int32.Parse(cborol.SelectedValue.ToString()), Int32.Parse(cboformapago.SelectedValue.ToString()), txtcorreo.Text.Trim(),
                        LoginInfo.IdTrab, this.Name);

                    if (ivali == 1)
                    {
                        //llena grid
                        fllenagridbusqueda(4, 0, "", 0, 0, "", LoginInfo.IdTrab, this.Name);
                        pnlmenssuid.Visible = true;
                        pnlmenssuid.BackColor = ColorTranslator.FromHtml("#2e7d32");
                        menssuid.Text = "Registro agregado correctamente";
                        timer1.Start();
                        flimpiaobj();
                        iactbtn = 1;
                        txtnombre.Focus();
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("No agrego su registro", "SIPAA", MessageBoxButtons.OK);
                    }
                }
            }
            else if (iactbtn == 2)
            {
                //valida campos
                Boolean bvalidacampos = fvalidacampos();

                if (bvalidacampos == true)
                {
                    int ivalu = correoinc.crudcorreo(2, icvcorreomodif, txtnombre.Text.Trim(), Int32.Parse(cborol.SelectedValue.ToString()), Int32.Parse(cboformapago.SelectedValue.ToString()), txtcorreo.Text.Trim(),
                        LoginInfo.IdTrab, this.Name);

                    if (ivalu == 2)
                    {
                        //llena grid
                        fllenagridbusqueda(4, 0, "", 0, 0, "", LoginInfo.IdTrab, this.Name);
                        pnlmenssuid.Visible = true;
                        pnlmenssuid.BackColor = ColorTranslator.FromHtml("#0277bd");
                        menssuid.Text = "Registro modificado correctamente";
                        timer1.Start();
                        flimpiaobj();
                        iactbtn = 0;
                        pnlcrudcorreo.Visible = false;
                        txtnombre.Focus();
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("No se modifico su registro", "SIPAA", MessageBoxButtons.OK);
                    }
                }
            }
            else if (iactbtn == 3)
            {
                //eliminar registro
                DialogResult result = MessageBox.Show("Esta acción elimina el registro, ¿Desea Continuar?", "SIPAA", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    int ivald = correoinc.crudcorreo(3, icvcorreomodif, txtnombre.Text.Trim(), Int32.Parse(cborol.SelectedValue.ToString()), Int32.Parse(cboformapago.SelectedValue.ToString()), txtcorreo.Text.Trim(),
                        LoginInfo.IdTrab, this.Name);

                    if (ivald == 3)
                    {
                        //llena grid
                        fllenagridbusqueda(4, 0, "", 0, 0, "", LoginInfo.IdTrab, this.Name);
                        pnlmenssuid.Visible = true;
                        pnlmenssuid.BackColor = ColorTranslator.FromHtml("#f44336");
                        menssuid.Text = "Registro eliminado correctamente";
                        timer1.Start();
                        flimpiaobj();
                        ckbeliminar.Checked = false;
                        Util.ChangeButton(btninsertar, 2, false);
                        iactbtn = 0;
                        pnlcrudcorreo.Visible = false;
                        txtnombre.Focus();
                    }
                    else
                    {
                        DialogResult result1 = MessageBox.Show("No se elimmino su registro", "SIPAA", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    ckbeliminar.Checked = false;
                    txtnombre.Focus();
                }
            }
            else
            {
                DialogResult result1 = MessageBox.Show("Seleccione una acción a realizar", "SIPAA", MessageBoxButtons.OK);
            }
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            dgvcatce.DataSource = null;

            int inumcolumngrid = dgvcatce.ColumnCount;

            if (inumcolumngrid == 1)
            {
                dgvcatce.Columns.RemoveAt(0);
            }

            //llena grid
            fllenagridbusqueda(4, 0, txtcorreobusq.Text.Trim(), 0, 0, "", "", "");
        }

        private void btnImprimircat_Click(object sender, EventArgs e)
        {
            DataTable dtReporteCorreo = new DataTable();
            dtReporteCorreo = correoinc.dtdgvcbcorreo(4, 0, "", 0, 0, "", "", "");

            //Preparación de los objetos para mandar a imprimir el reporte de Crystal Reports
            ViewerReporte form = new ViewerReporte();
            RepCatalogoCorreo dtrpt = new RepCatalogoCorreo();
            ReportDocument ReportDoc = Utilerias.ObtenerObjetoReporte(dtReporteCorreo, "SIPAA_CS.RecursosHumanos.Reportes", dtrpt.ResourceName);

            form.RptDoc = ReportDoc;
            form.Show();
        }
        //-----------------------------------------------------------------------------------------------
        //                           C A J A S      D E      T E X T O   
        //-----------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------
        //                                     E V E N T O S
        //-----------------------------------------------------------------------------------------------
        private void CorreosAvisosIncidencias_Load(object sender, EventArgs e)
        {
            //cierra formularios abiertos
            FormCollection formulariosApp = Application.OpenForms;
            foreach (Form f in formulariosApp)
            {
                if (f.Name != this.Name)
                {
                    f.Hide();
                }
            }

            //Rezise de la Forma
            Utilerias.ResizeForm(this, Utilerias.PantallaSistema());

            //inicializa tool tip
            ftooltip();

            //llena etiqueta de usuario
            lblusuario.Text = LoginInfo.Nombre;
            Utilerias.cargaimagen(ptbimgusuario);

            //variables accesos
            DataTable Permisos = DatPerfil.accpantalla(LoginInfo.IdTrab, this.Name);
            iins = Int32.Parse(Permisos.Rows[0][3].ToString());
            iact = Int32.Parse(Permisos.Rows[0][4].ToString());
            ielim = Int32.Parse(Permisos.Rows[0][5].ToString());
            iimp = Int32.Parse(Permisos.Rows[0][6].ToString());

            if (iins == 1)
            {
                btnAgregar.Visible = true;
            }

            if(iimp == 1)
            {
                label3.Visible = true;
                btnImprimircat.Visible = true;
            }

            //llena grid
            fllenagridbusqueda(4, 0, "", 0, 0, "", "", "");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pnlmenssuid.Visible = false;
            timer1.Stop();
        }

        private void ckbeliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbeliminar.Checked == true)
            {
                Util.ChangeButton(btninsertar, 3, false);
                iactbtn = 3;
            }
            else
            {
                Util.ChangeButton(btninsertar, 2, false);
                iactbtn = 2;
            }
        }
        //-----------------------------------------------------------------------------------------------
        //                                      F U N C I O N E S 
        //-----------------------------------------------------------------------------------------------
        //funcion para tool tip
        private void ftooltip()
        {
            //crea tool tip
            ToolTip toolTip1 = new ToolTip();

            //configuracion
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;

            //configura texto del objeto
            toolTip1.SetToolTip(this.btncerrar, "Cerrar Sistema");
            toolTip1.SetToolTip(this.btnminimizar, "Minimizar Sistema");
            toolTip1.SetToolTip(this.btnregresar, "Regresar");
            toolTip1.SetToolTip(this.btnbuscar, "Busca Registro");
            toolTip1.SetToolTip(this.btnbuscar, "Imprimir Catálogo");
        }

        protected void fllenagridbusqueda(int iopcion, int icvcorreo, string snombre, int itipo, int iformapago, string scorreo, string susuumod, string sprgumod)
        {

            if (iins == 1 && iact == 1 && ielim == 1)
            {
                fdgvsuid(iopcion, icvcorreo, snombre, itipo, iformapago, scorreo, susuumod, sprgumod);
            }
            else if (iins == 1 && iact == 1)
            {
                fdgvsuid(iopcion, icvcorreo, snombre, itipo, iformapago, scorreo, susuumod, sprgumod);
            }
            else if (iins == 1 && ielim == 1)
            {
                fdgvsuid(iopcion, icvcorreo, snombre, itipo, iformapago, scorreo, susuumod, sprgumod);
            }
            else if (iact == 1 && ielim == 1)
            {
                fdgvsuid(iopcion, icvcorreo, snombre, itipo, iformapago, scorreo, susuumod, sprgumod);
            }
            else if (iins == 1)
            {
                fdgvsuid(iopcion, icvcorreo, snombre, itipo, iformapago, scorreo, susuumod, sprgumod);
            }
            else if (iact == 1)
            {
                fdgvsuid(iopcion, icvcorreo, snombre, itipo, iformapago, scorreo, susuumod, sprgumod);
            }
            else if (ielim == 1)
            {
                fdgvsuid(iopcion, icvcorreo, snombre, itipo, iformapago, scorreo, susuumod, sprgumod);
            }
            else
            {
                fdgvs(iopcion, icvcorreo, snombre, itipo, iformapago, scorreo, susuumod, sprgumod);
            }

        }

        //funcion formto grid con modificación busqueda con permisos
        protected void fdgvsuid(int iopcion, int icvcorreo, string snombre, int itipo, int iformapago, string scorreo, string susuumod, string sprgumod)
        {
            dgvcatce.DataSource = null;

            int inumcolumngrid = dgvcatce.ColumnCount;

            if (inumcolumngrid == 1)
            {
                dgvcatce.Columns.RemoveAt(0);
            }

            DataTable dtdgvcapn = correoinc.dtdgvcbcorreo(iopcion, icvcorreo, snombre, itipo, iformapago, scorreo, susuumod, sprgumod);
            dgvcatce.DataSource = dtdgvcapn;

            DataGridViewImageColumn imgCheckUsuarios = new DataGridViewImageColumn();
            imgCheckUsuarios.Image = Resources.ic_lens_blue_grey_600_18dp;
            imgCheckUsuarios.Name = "img";
            dgvcatce.Columns.Insert(0, imgCheckUsuarios);
            dgvcatce.Columns[0].HeaderText = "Selección";

            dgvcatce.Columns[0].Width = 75;
            dgvcatce.Columns[1].Visible = false;
            dgvcatce.Columns[2].Width = 205;
            dgvcatce.Columns[3].Width = 80;
            dgvcatce.Columns[4].Width = 80;
            dgvcatce.Columns[5].Width = 205;
            dgvcatce.Columns[6].Visible = false;
            dgvcatce.Columns[7].Visible = false;
            dgvcatce.ClearSelection();
            lblModif.Visible = true;
        }

        //funcion formto grid sin modificación busqueda
        protected void fdgvs(int iopcion, int icvcorreo, string snombre, int itipo, int iformapago, string scorreo, string susuumod, string sprgumod)
        {
            DataTable dtdgvji = correoinc.dtdgvcbcorreo(iopcion, icvcorreo, snombre, itipo, iformapago, scorreo, susuumod, sprgumod);
            dgvcatce.DataSource = dtdgvji;

            dgvcatce.Columns[0].Visible = false;
            dgvcatce.Columns[1].Width = 220;
            dgvcatce.Columns[2].Width = 80;
            dgvcatce.Columns[3].Width = 80;
            dgvcatce.Columns[4].Width = 220;
            dgvcatce.Columns[5].Visible = false;
            dgvcatce.Columns[6].Visible = false;
            dgvcatce.ClearSelection();
            lblModif.Visible = false;
        }

        //validacion de campos
        private Boolean fvalidacampos()
        {
            if (txtnombre.Text.Trim() == "")
            {
                DialogResult result = MessageBox.Show("Capture un nombre", "SIPAA", MessageBoxButtons.OK);
                txtnombre.Focus();
                return false;
            }
            else if (cborol.Text.Trim() == "" || cborol.SelectedIndex == -1 || cborol.SelectedIndex == 0)
            {
                DialogResult result = MessageBox.Show("Seleccione un rol", "SIPAA", MessageBoxButtons.OK);
                cborol.Focus();
                return false;
            }
            else if (cboformapago.Text.Trim() == "" || cboformapago.SelectedIndex == -1 || cboformapago.SelectedIndex == 0)
            {
                DialogResult result = MessageBox.Show("Seleccione una forma de pago", "SIPAA", MessageBoxButtons.OK);
                cboformapago.Focus();
                return false;
            }
            else if (txtcorreo.Text.Trim() == "")
            {
                DialogResult result = MessageBox.Show("Capture un correo", "SIPAA", MessageBoxButtons.OK);
                txtcorreo.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        private void flimpiaobj()
        {

            txtnombre.Text = "";

            //cb rol
            cborol.DataSource = null;
            DataTable dtrol = correoinc.dtdgvcbcorreo(5, 0, "", 0, 0, "", LoginInfo.IdTrab, this.Name);
            Utilerias.llenarComboxDataTable(cborol, dtrol, "clave", "descrip");

            //cb rol
            cboformapago.DataSource = null;
            DataTable dtformapago = correoinc.dtdgvcbcorreo(6, 0, "", 0, 0, "", LoginInfo.IdTrab, this.Name);
            Utilerias.llenarComboxDataTable(cboformapago, dtformapago, "clave", "descrip");

            txtcorreo.Text = "";

        }

        private void factgrid()
        {
            if (iins == 1 && iact == 0 && ielim == 0)
            {
            }
            else
            {
                for (int iContador = 0; iContador < dgvcatce.Rows.Count; iContador++)
                {
                    dgvcatce.Rows[iContador].Cells[0].Value = Resources.ic_lens_blue_grey_600_18dp;
                }

                if (dgvcatce.SelectedRows.Count != 0)
                {
                    pnlcrudcorreo.Visible = true;
                    DataGridViewRow row = this.dgvcatce.SelectedRows[0];
                    icvcorreomodif = Convert.ToInt32(row.Cells["cvcorreo"].Value.ToString());

                    row.Cells[0].Value = Resources.ic_check_circle_green_400_18dp;

                    txtnombre.Text = row.Cells["Nombre"].Value.ToString();

                    //cb rol
                    cborol.DataSource = null;
                    DataTable dtrol = correoinc.dtdgvcbcorreo(5, 0, "", 0, 0, "", LoginInfo.IdTrab, this.Name);
                    Utilerias.llenarComboxDataTable(cborol, dtrol, "clave", "descrip");
                    cborol.SelectedValue = Convert.ToInt32(row.Cells["tipo"].Value.ToString());

                    //cb rol
                    cboformapago.DataSource = null;
                    DataTable dtformapago = correoinc.dtdgvcbcorreo(6, 0, "", 0, 0, "", LoginInfo.IdTrab, this.Name);
                    Utilerias.llenarComboxDataTable(cboformapago, dtformapago, "clave", "descrip");
                    cboformapago.SelectedValue = Convert.ToInt32(row.Cells["formapago"].Value.ToString());

                    txtcorreo.Text = row.Cells["Correo"].Value.ToString();

                    txtnombre.Focus();
                }
            }
        }
        //-----------------------------------------------------------------------------------------------
        //                                      R E P O R T E S
        //-----------------------------------------------------------------------------------------------
    }
}
