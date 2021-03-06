﻿using SIPAA_CS.App_Code;
using SIPAA_CS.App_Code.RecursosHumanos;
using SIPAA_CS.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SIPAA_CS.App_Code.Usuario;

namespace SIPAA_CS.RecursosHumanos.Catalogos
{
    //***********************************************************************************************
    //Autor: Victor Jesús Iturburu Vergara
    //Fecha creación:23-03-2017       Última Modificacion: 23-03-2017
    //Descripción: Catalogo de Tipos de Incidencia
    //***********************************************************************************************

    public partial class IncidenciasTipos : Form
    {
        public int cvIncidencia;
        public int cvTipo;
        public int iOpcionAdmin;
        public string strIncidencia;
        public string strTipoIncidencia;
        public string strEstatus;
        public int sysH;
        public int sysW;

        Incidencia incid = new Incidencia();

        public IncidenciasTipos()
        {
            InitializeComponent();
        }

        //-----------------------------------------------------------------------------------------------
        //                                      C O M B O S
        //-----------------------------------------------------------------------------------------------
        private void LlenarComboTipoIncidencia(ComboBox cb, string Display, string Clave, int Opcion)
        {
            Incidencia objIncidencia = new Incidencia();
            objIncidencia.CVIncidencia = 0;
            objIncidencia.CVTipo = 0;
            objIncidencia.Descripcion = "";
            objIncidencia.TipoIncidencia = "";
            objIncidencia.UsuuMod = "";
            objIncidencia.PrguMod = "";
            objIncidencia.Estatus = "";

            DataTable dtIncidencia = objIncidencia.ObtenerIncidenciaxTipo(objIncidencia, Opcion);

            Utilerias.llenarComboxDataTable(cbIncidencia, dtIncidencia, "cvincidencia", "Incidencia");

            //List<string> ltCombo = new List<string>();
            //foreach (DataRow row in dtIncidencia.Rows)
            //{
            //    ltCombo.Add(row[Display].ToString());
            //}

            //ltCombo.Insert(0, "Seleccionar");
            //cb.DataSource = ltCombo;
            //cb.DisplayMember = Display;
            //if (cb.Items.Count == 0)
            //{
            //    cb.Enabled = false;
            //    cb.SelectedText = "Sin datos para Asignar";
            //}

        }

        //-----------------------------------------------------------------------------------------------
        //                                      G R I D // S
        //-----------------------------------------------------------------------------------------------
        private void LLenarGridIncapacidad(DataGridView dgvIncidencia, string strIncidencia, string Tipo)
        {


            if (dgvIncidencia.Columns.Count > 1) {
                dgvIncidencia.Columns.RemoveAt(0);
            }

            Incidencia objIncidencia = new Incidencia();

            switch (cbEstatus.SelectedIndex)
            {

                case 0: objIncidencia.Estatus = "%"; break;
                case 1: objIncidencia.Estatus = "1"; break;
                case 2: objIncidencia.Estatus = "0"; break;


            }

            objIncidencia.CVIncidencia = 0;
            objIncidencia.CVTipo = 0;
            objIncidencia.Descripcion = strIncidencia;
            objIncidencia.TipoIncidencia = Tipo;
            objIncidencia.UsuuMod = LoginInfo.IdTrab;
            objIncidencia.PrguMod = this.Name;
            DataTable dtIncidencia = objIncidencia.ObtenerIncidenciaxTipo(objIncidencia, 4);
            dgvIncidencia.DataSource = dtIncidencia;



            Utilerias.AgregarCheck(dgvIncidencia, 0);

            dgvIncidencia.Columns[1].Visible = false;
            dgvIncidencia.Columns[2].Visible = false;
            dgvIncidencia.Columns[3].Width = 200;
            dgvIncidencia.Columns[4].Width = 150;
            dgvIncidencia.Columns[5].Visible = false;

            dgvIncidencia.ClearSelection();

            if (Permisos.dcPermisos["Eliminar"] == 0 && Permisos.dcPermisos["Actualizar"] == 0) {

                dgvIncidencia.Columns[0].Visible = false;
                label2.Text = "Incidencias Registradas";

            }

        }
        //-----------------------------------------------------------------------------------------------
        //                                     B O T O N E S
        //-----------------------------------------------------------------------------------------------
        private void ckbEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbEliminar.Checked == true)
            {

                if (strEstatus == String.Empty || strEstatus == "0")
                {

                 //   btnGuardar.Image = Resources.Alta;
                    Utilerias.AsignarBotonResize(btnGuardar,Utilerias.PantallaSistema(), "Alta");
                }
                else
                {
                  //  btnGuardar.Image = Resources.Baja;
                    Utilerias.AsignarBotonResize(btnGuardar, Utilerias.PantallaSistema(), "Baja");
                }


                iOpcionAdmin = 3;
                //Utilerias.CambioBoton(btnGuardar, btnEditar, btnGuardar, btnEliminar);
            }
            else
            {
                iOpcionAdmin = 2;
               // btnGuardar.Image = Resources.Editar;
                Utilerias.AsignarBotonResize(btnGuardar, Utilerias.PantallaSistema(), "Editar");
                //Utilerias.CambioBoton(btnGuardar, btnEliminar, btnGuardar, btnEditar);

            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            dgvIncidencia.ClearSelection();

            lblAccion.Text = "      Nueva Asignación";
            panelTag.Visible = false;
            ckbEliminar.Checked = false;
            ckbEliminar.Visible = false;
            cbIncidencia.Enabled = true;

            LlenarComboTipoIncidencia(cbIncidencia, "Incidencia", "cvincidencia", 6);
            txtBuscarIncidencia.Text = "";
            PanelEditar.Visible = true;
            iOpcionAdmin = 1;
    

            Utilerias.AsignarBotonResize(btnGuardar, Utilerias.PantallaSistema(), "Guardar");
           
            txtTipoEditar.Text = String.Empty;
            txtTipoEditar.Focus();

        }

        //boton minimizar
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        //boton cerrar
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Seguro que desea salir?", "SIPAA", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
         
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //strIncidencia = cbIncidencia.SelectedValue.ToString();

            lblAccion.Text = "       Asignar Tipo Incapacidad";

            Incidencia objIncidencia = new Incidencia();
            objIncidencia.CVIncidencia = Int32.Parse(cbIncidencia.SelectedValue.ToString());
            objIncidencia.CVTipo = cvTipo;
            objIncidencia.Descripcion = txtTipoEditar.Text;
            objIncidencia.Estatus = "";
            objIncidencia.TipoIncidencia = txtTipoEditar.Text;

            objIncidencia.PrguMod = this.Name;
            objIncidencia.UsuuMod = LoginInfo.IdTrab;
            try
            {
                string Mensaje = "";
                if (strEstatus == "Activo")
                {
                    Mensaje = "¿Seguro que desea dar de BAJA el Registro?";
                }
                else
                {
                    Mensaje = "¿Seguro que desea dar de ALTA el Registro?";
                }

                DataTable response = new DataTable();
                switch (iOpcionAdmin)
                {

                    case 3:
                        DialogResult result = MessageBox.Show(Mensaje, this.Name, MessageBoxButtons.YesNo);

                        if (result == DialogResult.Yes)
                        {
                            response = objIncidencia.ObtenerIncidenciaxTipo(objIncidencia, iOpcionAdmin);
                            MostrarNotificacion(response);
                        }
                        break;

                    default:
                        response = objIncidencia.ObtenerIncidenciaxTipo(objIncidencia, iOpcionAdmin);
                        MostrarNotificacion(response);

                        break;
                }

                // LlenarComboRepresenta(cbIncidencia, 6);
                LlenarComboTipoIncidencia(cbTipo, "Tipo", "cvtipo", 5);
                LLenarGridIncapacidad(dgvIncidencia, "%", "%");

            }
            catch (Exception ex)
            {

                Utilerias.ControlNotificaciones(panelTag, lbMensaje, 3, "Error de Comunicación con el Servidor. Intentarlo más tarde.");
                timer1.Start();
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string Incidencia;
            string Tipo;



            PanelEditar.Visible = false;

            if (txtBuscarIncidencia.Text == String.Empty)
            {

                Incidencia = "%";
            }
            else
            {
                Incidencia = txtBuscarIncidencia.Text;
            }

            if (cbTipo.SelectedValue.ToString() == "0")
            {
                Tipo = "%";
            }
            else
            {
                Tipo = cbTipo.SelectedItem.ToString();
            }

            LLenarGridIncapacidad(dgvIncidencia, Incidencia, Tipo);

        }


        private void btnRegresar_Click(object sender, EventArgs e)
        {
            RechDashboard rechdb = new RechDashboard();
            rechdb.Show();
            this.Close();
        }

        //-----------------------------------------------------------------------------------------------
        //                           C A J A S      D E      T E X T O   
        //-----------------------------------------------------------------------------------------------


        //-----------------------------------------------------------------------------------------------
        //                                     E V E N T O S
        //-----------------------------------------------------------------------------------------------
        private void Incapacidad_Tipo_Load(object sender, EventArgs e)
        {
            Incidencia objIncidencia = new Incidencia();
            //cierra formularios abiertos
            FormCollection formulariosApp = Application.OpenForms;
            foreach (Form f in formulariosApp)
            {
                if (f.Name != this.Name)
                {
                    f.Hide();
                }
            }

            //llena etiqueta de usuario
            lblusuario.Text = LoginInfo.Nombre;
            Utilerias.cargaimagen(ptbimgusuario);

            ftooltip();

            // Diccionario Permisos x Pantalla
            DataTable dtPermisos = Modulo.ObtenerPermisosxUsuario(LoginInfo.IdTrab, this.Name);
            Permisos.dcPermisos = Utilerias.CrearListaPermisoxPantalla(dtPermisos);
            //////////////////////////////////////////////////////
            // resize 
            Utilerias.ResizeForm(this, Utilerias.PantallaSistema());
            ///////////////////////////////////////////////////////////////////////////////////////////////////

            LLenarGridIncapacidad(dgvIncidencia, "", "");


            //LlenarComboTipoIncidencia(cbTipo, "Tipo", "cvtipo", 5);


            Utilerias.llenarComboxDataTable(cbTipo, incid.ObtenerIncidenciaxTipo(objIncidencia,5), "cvincidencia", "Incidencia");

            if (Permisos.dcPermisos["Crear"] == 0) {

                btnAgregar.Visible = false;

            }
        }

        private void dgvIncidencia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (Permisos.dcPermisos["Actualizar"] != 0 || Permisos.dcPermisos["Eliminar"] != 0)
            {

                for (int iContador = 0; iContador < dgvIncidencia.Rows.Count; iContador++)
                {
                    dgvIncidencia.Rows[iContador].Cells[0].Value = Resources.ic_lens_blue_grey_600_18dp;
                }


                if (dgvIncidencia.SelectedRows.Count != 0)
                {

                    cbIncidencia.Visible = true;

                    DataGridViewRow row = this.dgvIncidencia.SelectedRows[0];
                    PanelEditar.Visible = true;
                    cvIncidencia = Convert.ToInt32(row.Cells["cvincidencia"].Value.ToString());
                    cvTipo = Convert.ToInt32(row.Cells["cvtipo"].Value.ToString());
                    strIncidencia = row.Cells["Incidencia"].Value.ToString();
                    strTipoIncidencia = row.Cells["Tipo"].Value.ToString();
                    txtTipoEditar.Text = strTipoIncidencia;
                    strEstatus = row.Cells["Estatus"].Value.ToString();

                    Incidencia objIncidencia = new Incidencia();
                    Utilerias.llenarComboxDataTable(cbIncidencia, incid.ObtenerIncidenciaxTipo(objIncidencia, 6), "cvincidencia", "Incidencia");

                    ckbEliminar.Visible = true;
                    ckbEliminar.Checked = false;

                    txtTipoEditar.Text = strTipoIncidencia;
                    cbIncidencia.Text = row.Cells["Incidencia"].Value.ToString();
                    lblAccion.Text = "      Editar Incidencia";
                    cbIncidencia.Enabled = false;
                    PanelEditar.Visible = true;
                    row.Cells[0].Value = Resources.ic_check_circle_green_400_18dp;

                    //Permisos
                    if (Permisos.dcPermisos["Eliminar"] == 1 && Permisos.dcPermisos["Actualizar"] == 1)
                    {

                        Utilerias.AsignarBotonResize(btnGuardar, Utilerias.PantallaSistema(), "Editar");
                        iOpcionAdmin = 2;



                        if (strEstatus == "0")
                        {
                            ckbEliminar.Text = "Alta";

                        }
                        else if (strEstatus == "1")
                        {
                            ckbEliminar.Text = "Baja";

                        }

                    }
                    else if (Permisos.dcPermisos["Eliminar"] == 1 && Permisos.dcPermisos["Actualizar"] == 0)
                    {
                        iOpcionAdmin = 3;
                        ckbEliminar.Visible = false;
                        if (strEstatus == "0")
                        {
                            Utilerias.AsignarBotonResize(btnGuardar, Utilerias.PantallaSistema(), "Alta");

                        }
                        else if (strEstatus == "1")
                        {
                            Utilerias.AsignarBotonResize(btnGuardar, Utilerias.PantallaSistema(), "Baja");
                        }
                    }
                    else if (Permisos.dcPermisos["Actualizar"] == 1 && Permisos.dcPermisos["Eliminar"] == 0)
                    {
                        Utilerias.AsignarBotonResize(btnGuardar, Utilerias.PantallaSistema(), "Editar");
                        iOpcionAdmin = 2;
                        ckbEliminar.Visible = false;
                    }




                }
            }
        }


        //-----------------------------------------------------------------------------------------------
        //                                      F U N C I O N E S 
        //-----------------------------------------------------------------------------------------------


        

        private void MostrarNotificacion(DataTable response)
        {


            ckbEliminar.Checked = false;
            PanelEditar.Visible = false;

            if (response.Columns.Contains("INSERTAR"))
            {
                Utilerias.ControlNotificaciones(panelTag, lbMensaje, 1, "Asignación Correcta");
                timer1.Start();
            }
            else if (response.Columns.Contains("EXISTE"))
            {
                Utilerias.ControlNotificaciones(panelTag, lbMensaje, 3, "Esta Asignación ya existe");
                timer1.Start();
            }
            else if (response.Columns.Contains("ACTUALIZAR"))
            {
                Utilerias.ControlNotificaciones(panelTag, lbMensaje, 1, "Actualización Correcta");
                timer1.Start();
            }
            else if (response.Columns.Contains("ESTATUS"))
            {
                Utilerias.ControlNotificaciones(panelTag, lbMensaje, 1, "Cambio de Estatus Correcto");
                timer1.Start();
            }

        }

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
            toolTip1.SetToolTip(this.btnCerrar, "Cerrar Sistema");
            toolTip1.SetToolTip(this.btnMinimizar, "Minimizar Sistema");
            toolTip1.SetToolTip(this.btnRegresar, "Regresar");
            toolTip1.SetToolTip(this.btnBuscar, "Buscar Registros");
        }


        //-----------------------------------------------------------------------------------------------
        //                                      R E P O R T E
        //-----------------------------------------------------------------------------------------------

    }
}
