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
using SIPAA_CS.App_Code.Generales;
using SIPAA_CS.App_Code.RecursosHumanos.Catalogos;
using SIPAA_CS.App_Code.RecursosHumanos.Procesos;
using static SIPAA_CS.App_Code.Usuario;
using static SIPAA_CS.App_Code.Utilerias;
using SIPAA_CS.Conexiones;
using SIPAA_CS.Properties;

using CrystalDecisions.CrystalReports.Engine;
using SIPAA_CS.RecursosHumanos.Reportes;

//***********************************************************************************************
//Autor: Benjamin Huizar Barajas
//Fecha creación: 28-Mar-2017       
//Última Modificacion: 07-09-2017
//Modificó: Karla Torres Ramírez
//Descripción: Períodos Proceso Incidencias
//***********************************************************************************************

namespace SIPAA_CS.RecursosHumanos.Procesos
{
    public partial class PeriodosProcesoIncidencia : Form
    {
        #region Variables

        int iIns;
        int iAct;
        int iElim;
        int iActbtn;
        int iIdFormaPago;
        string sFechaInicioPeriodoIncidencia;
        string sFechaFinPeriodoIncidencia;
        string sDescripcion;
        int iStPeriodoIncidencia;
        int iResp; // iResp -> iResp
        string sCadenaStatusPeriodo;
        bool bClickPrimeraVezFormaPago = true;
        public string sFechaInicioProcInc;
        public string sFechaFinProcInc;
        public string sFechaInicioConsInc;
        public string sFechaFinConsInc;
        public string sFechaInicioCalifSup;
        public string sFechaFinCalifSup;
        public string sFechaInicioCalifDir;
        public string sFechaFinCalifDir;
        public string sFechaInicioUpdate;
        public string sFechaFinUpdate;
      

        #endregion

        statue oStatus = new statue();
        SonaFormaPago oSonaFormaPago = new SonaFormaPago();
        PeriodoProcesoIncidencia oPeriodoProcesoIncidencia = new PeriodoProcesoIncidencia();
        Utilerias Util = new Utilerias();
        
        public PeriodosProcesoIncidencia()
        {
            InitializeComponent();
        }

        //-----------------------------------------------------------------------------------------------
        //                                      C O M B O S
        //-----------------------------------------------------------------------------------------------

        //
        // Llena Combo Box de Forma Pago de la tabla de SONARH
        private void cbFormaPago_Click(object sender, EventArgs e)
        {
            if (bClickPrimeraVezFormaPago)
            {
                DataTable dtFormaPago = oSonaFormaPago.FormaPago_S(6, 0, "");
                cbFormaPago.DataSource = dtFormaPago;
                cbFormaPago.DisplayMember = "Descripción";
                cbFormaPago.ValueMember = "Clave";
                bClickPrimeraVezFormaPago = false;
            } // if (bClickPrimeraVezFormaPago)
        } // private void cbFormaPago_Click(object sender, EventArgs e)

        private void cbFormaPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            int iIdFormaPagoBuscar = 0;
            if (!bClickPrimeraVezFormaPago)
            {
                pnlActPeriodoIncidencia.Visible = false;
                iIdFormaPagoBuscar = Convert.ToInt32(cbFormaPago.SelectedValue.ToString());
                iIdFormaPago = iIdFormaPagoBuscar;
                fgPeriodosProcesoIncidencia(6, iIdFormaPagoBuscar, "", "", "", iStPeriodoIncidencia, LoginInfo.IdTrab, this.Name,"","","","","","","","","","", 0, "");
            } // if (!bClickPrimeraVezFormaPago)
        } // private void cbFormaPago_SelectedIndexChanged(object sender, EventArgs e)

        private void cbStatusPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
                
        }

        private void cbStatusPeriodo_SelectedValueChanged(object sender, EventArgs e)
        {
            sCadenaStatusPeriodo = cbStatusPeriodo.SelectedValue.ToString();

            if (sCadenaStatusPeriodo != "System.Data.DataRowView")
            {
                iStPeriodoIncidencia = Convert.ToInt32(sCadenaStatusPeriodo);
            }
         
        } 

        //-----------------------------------------------------------------------------------------------
        //                                      G R I D // S
        //-----------------------------------------------------------------------------------------------
        private void dgvPeriodosProcesoIncidencias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Permisos.dcPermisos["Crear"] == 1 && Permisos.dcPermisos["Actualizar"] == 1 && Permisos.dcPermisos["Eliminar"] == 1)  // (iIns == 1 && iAct == 1 && iElim == 1)
            {
                Util.ChangeButton(btnInsertar, 2, false);
                factgrid();
                ckbEliminar.Visible = true;
                iActbtn = 2;
            }
            else if (Permisos.dcPermisos["Crear"] == 1 && Permisos.dcPermisos["Actualizar"] == 1) // (iIns == 1 && iAct == 1)
            {   
                Util.ChangeButton(btnInsertar, 2, false);
                factgrid();
                iActbtn = 2;
            }
            else if (Permisos.dcPermisos["Crear"] == 1 && Permisos.dcPermisos["Eliminar"] == 1) // (iIns == 1 && iElim == 1)
            {   factgrid();
                Util.ChangeButton(btnInsertar, 2, false);
                ckbEliminar.Visible = true;
                iActbtn = 2;
            }
            else if (Permisos.dcPermisos["Actualizar"] == 1 && Permisos.dcPermisos["Eliminar"] == 1) // (iAct == 1 && iElim == 1)
            {   
                Util.ChangeButton(btnInsertar, 2, false);
                factgrid();
                ckbEliminar.Visible = true;
                iActbtn = 2;
            }
            else if (Permisos.dcPermisos["Crear"] == 1) // (iIns == 1)
            {   
                Util.ChangeButton(btnInsertar, 2, false);
               factgrid();
                iActbtn = 2;
            }
            else if (Permisos.dcPermisos["Actualizar"] == 1) // (iAct == 1)
            {  
                Util.ChangeButton(btnInsertar, 2, false);
                factgrid();
                iActbtn = 2;
            }
            else if (Permisos.dcPermisos["Eliminar"] == 1) // (iElim == 1)
            {   
                Util.ChangeButton(btnInsertar, 3, false);
               factgrid();
                ckbEliminar.Visible = true;
                iActbtn = 3;
            }
            else
            {

            }

        } 


        //-----------------------------------------------------------------------------------------------
        //                                     B O T O N E S
        //-----------------------------------------------------------------------------------------------

        //boton buscar
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            /*dgvPeriodosProcesoIncidencias.DataSource = null;
            string Buscar = txtBuscarDF.Text;
            //llena grid con datos existente
            fgPeriodosProcesoIncidencia(4, iIdFormaPago, "", "", Buscar, iStPeriodoIncidencia, LoginInfo.IdTrab, this.Name, "", "", "", "", "", "", "", "", "", "");
            txtBuscarDF.Text = "";
            //txtDescripcionPeriodoIncidencia.Text = "";
            //txtDescripcionPeriodoIncidencia.Focus();

            if (dgvPeriodosProcesoIncidencias.Columns.Count > 3)
            {
                dgvPeriodosProcesoIncidencias.Columns.RemoveAt(0);
            }

            fgPeriodosProcesoIncidencia(6, iIdFormaPago, "", "", Buscar, iStPeriodoIncidencia, LoginInfo.IdTrab, this.Name, "", "", "", "", "", "", "", "", "", "");
            */
        }
        //boton agregar
        private void btnAgregar_Click(object sender, EventArgs e)
        {
           
            // Valida que haya seleccionado un valor del Combo de Forma Pago
            if(cbFormaPago.SelectedIndex!=-1) // Se ha seleccionado un elemento del Combo Box
            {
                ckbEliminar.Visible = false;
                pnlActPeriodoIncidencia.Visible = true;
                lblActPeriodoIncidencia.Text = "     Agregar Período Incidencia";
                Util.ChangeButton(btnAgregar, 1, true);
                txtDescripcionPeriodoIncidencia.Text = cbFormaPago.Text;
                iActbtn = 1;
                fStatusPeriodoIncidencia(4, "rechtperiodopro", 0, "", 0, LoginInfo.IdTrab, this.Name);
                cbStatusPeriodo.Text = "CERRADO";
                dtpFechaInicioPeriodoIncidencia.Text = "";
                dtpFechaFinPeriodoIncidencia.Text = "";
                dtpFechaInicioProcesarIncidencia.Text = "";
                dtpFechaFinProcesarIncidencia.Text = "";
                dtpFechaInicioConsultarIncidencia.Text = "";
                dtpFechaFinConsultarIncidencia.Text = "";
                dtpFechaInicioCalificarIncidenciaSup.Text = "";
                dtpFechaFinCalificarIncidenciaSup.Text = "";
                dtpFechaInicioCalificarIncidenciaDir.Text = "";
                dtpFechaFinCalificarIncidenciaDir.Text = "";

                ckbaplicasanc.Visible = true;
                ckbaplicasanc.Checked = false;
                label11.Visible = false;
                dtpfecsancion.Visible = false;

            }
            else
            {
                lblMensaje.Text = "Debes seleccionar una Forma de Pago";
                panelTag.Visible = true;
                timer1.Start();
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            bool rV;
            if (txtDescripcionPeriodoIncidencia.Text.Trim() == "" && iActbtn == 1)
            {
                lblMensaje.Text = "Capture un dato a guardar";
            }
            else if (iActbtn == 1)//insertar
            {
                rV = validarFechas_Periodos();
                if (rV == true)
                {
                    int igensac;
                    string sfecgensanc;
                    if (ckbaplicasanc.Checked == true)
                    {
                        igensac = 1;
                        sfecgensanc = dtpfecsancion.Text;
                    }
                    else
                    {
                        igensac = 0;
                        sfecgensanc = "";
                    }

                   //inserta registro nuevo
                    fuidPeriodosProcesoIncidencia(1, iIdFormaPago, dtpFechaInicioPeriodoIncidencia.Text, dtpFechaFinPeriodoIncidencia.Text, txtDescripcionPeriodoIncidencia.Text.Trim(), iStPeriodoIncidencia, LoginInfo.IdTrab, this.Name,
                    dtpFechaInicioProcesarIncidencia.Text, dtpFechaFinProcesarIncidencia.Text,
                    dtpFechaInicioConsultarIncidencia.Text,
                    dtpFechaFinConsultarIncidencia.Text,
                    dtpFechaInicioCalificarIncidenciaSup.Text,
                    dtpFechaFinCalificarIncidenciaSup.Text,
                    dtpFechaInicioCalificarIncidenciaDir.Text,
                    dtpFechaFinCalificarIncidenciaDir.Text, "", "", igensac, sfecgensanc);
                    panelTag.Visible = true;
                    txtDescripcionPeriodoIncidencia.Text = "";
                    txtDescripcionPeriodoIncidencia.Focus();
                    timer1.Start();
                    //llena grid con datos existente
                    fgPeriodosProcesoIncidencia(6, iIdFormaPago, "", "", "", iStPeriodoIncidencia, LoginInfo.IdTrab, this.Name, "", "", "", "", "", "", "", "", "", "", 0, "");
                    ckbEliminar.Checked = false;
                    ckbEliminar.Visible = false;
                    pnlActPeriodoIncidencia.Visible = false;
               }
                

            }
            else if (iActbtn == 2)//actualizar
            {
                rV = validarFechas_Periodos();
                if (rV == true)
                {
                    /*  if (iStPeriodoIncidencia==1)
                      {
                          // Colocar el periodo abierto anterior en 0
                          fuidPeriodosProcesoIncidencia(12, iIdFormaPago, "", "", "", 0, LoginInfo.IdTrab, this.Name,"","","","","","","","","","");
                      }*/
                    int igensacm;
                    string sfecgensancm;
                    if (ckbaplicasanc.Checked == true)
                    {
                        igensacm = 1;
                        sfecgensancm = dtpfecsancion.Text;
                    }
                    else
                    {
                        igensacm = 0;
                        sfecgensancm = "";
                    }


                    fuidPeriodosProcesoIncidencia(2, iIdFormaPago, sFechaInicioPeriodoIncidencia, sFechaFinPeriodoIncidencia, txtDescripcionPeriodoIncidencia.Text.Trim(), iStPeriodoIncidencia, LoginInfo.IdTrab, this.Name,
                    dtpFechaInicioProcesarIncidencia.Text,
                    dtpFechaFinProcesarIncidencia.Text,
                    dtpFechaInicioConsultarIncidencia.Text,
                    dtpFechaFinConsultarIncidencia.Text,
                    dtpFechaInicioCalificarIncidenciaSup.Text,
                    dtpFechaFinCalificarIncidenciaSup.Text,
                    dtpFechaInicioCalificarIncidenciaDir.Text,
                    dtpFechaFinCalificarIncidenciaDir.Text, dtpFechaInicioPeriodoIncidencia.Text, dtpFechaFinPeriodoIncidencia.Text, igensacm, sfecgensancm);
                    panelTag.Visible = true;
                    txtDescripcionPeriodoIncidencia.Text = "";
                    txtDescripcionPeriodoIncidencia.Focus();
                    timer1.Start();
                    //llena grid con datos existente
                    //fgPeriodosProcesoIncidencia(6, iIdFormaPago, "", "", "", iStPeriodoIncidencia, "bhb", "PeriodosProcesoIncidencia");
                    fgPeriodosProcesoIncidencia(6, iIdFormaPago, "", "", "", iStPeriodoIncidencia, LoginInfo.IdTrab, this.Name, "", "", "", "", "", "", "", "", "", "", 0, "");
                    ckbEliminar.Checked = false;
                    ckbEliminar.Visible = false;
                    pnlActPeriodoIncidencia.Visible = false;
                }
            }
            else if (iActbtn == 3)//eliminar
            {
                DialogResult result = MessageBox.Show("Esta acción elimina el registro, ¿Desea Continuar?", "SIPAA", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                   //inserta registro nuevo
                    fuidPeriodosProcesoIncidencia(3, iIdFormaPago, dtpFechaInicioPeriodoIncidencia.Text, dtpFechaFinPeriodoIncidencia.Text, txtDescripcionPeriodoIncidencia.Text.Trim(), iStPeriodoIncidencia, LoginInfo.IdTrab, this.Name,"","","","","","","","","","", 0, "");
                    panelTag.Visible = true;
                    txtDescripcionPeriodoIncidencia.Text = "";
                    txtDescripcionPeriodoIncidencia.Focus();
                    timer1.Start();
                    //llena grid con datos existente
                    fgPeriodosProcesoIncidencia(6, iIdFormaPago, "", "", "", iStPeriodoIncidencia, LoginInfo.IdTrab, this.Name,"","","","","","","","","","", 0, "");
                    ckbEliminar.Checked = false;
                    ckbEliminar.Visible = false;
                    pnlActPeriodoIncidencia.Visible = false;
                }
                else if (result == DialogResult.No)
                {

                }
            }

        } // private void btnInsertar_Click(object sender, EventArgs e)

        //Boton minimizar
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
            else if (result == DialogResult.No)
            {
                // No hace nada, se queda en la pantalla
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            DataTable dtreporte = new DataTable();
            dtreporte = oPeriodoProcesoIncidencia.obtPeriodosProcesoIncidencia(20, Int32.Parse(cbFormaPago.SelectedValue.ToString()),"2","","",0,
                                                                               LoginInfo.IdTrab, this.Name, "","","","","","","","","","", 0, "");

            //Preparación de los objetos para mandar a imprimir el reporte de Crystal Reports
            ViewerReporte form = new ViewerReporte();
            RepPerInc dtrpt = new RepPerInc();
            ReportDocument ReportDoc = Utilerias.ObtenerObjetoReporte(dtreporte, "SIPAA_CS.RecursosHumanos.Reportes", dtrpt.ResourceName);

            form.RptDoc = ReportDoc;
            form.Show();
        }

        //-----------------------------------------------------------------------------------------------
        //                           C A J A S      D E      T E X T O   
        //-----------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------
        //                                     E V E N T O S
        //-----------------------------------------------------------------------------------------------
        private void PeriodosProcesoIncidencia_Load(object sender, EventArgs e)
        {
            // resize 
            Utilerias.ResizeForm(this, Utilerias.PantallaSistema());

            //cierra formularios abiertos
            FormCollection formulariosApp = Application.OpenForms;
            foreach (Form f in formulariosApp)
            {
                if (f.Name != this.Name)
                {
                    f.Hide();
                }
            }

            //LLAMA TOOL TIP
            fTooltip();

            //llena etiqueta de usuario
            lblusuario.Text = LoginInfo.Nombre;
            Utilerias.cargaimagen(ptbimgusuario);

            //
            // Los valores deben venir de los permisos con los que cuente el PERFIL de USUARIO
            // iIns = 1; // Permite Insertar
            // iAct = 1; // Permite Actualizar
            // iElim = 1; // Permite Eliminar

            // Diccionario Permisos x Pantalla
            DataTable dtPermisos = Modulo.ObtenerPermisosxUsuario(LoginInfo.IdTrab, this.Name);
            Permisos.dcPermisos = Utilerias.CrearListaPermisoxPantalla(dtPermisos);
            //HABILITA BOTON AGREGAR
            if (Permisos.dcPermisos["Crear"] == 1) // (iIns == 1)
            {
                btnAgregar.Visible = true;
            }

            if (bClickPrimeraVezFormaPago)
            {
                DataTable dtFormaPago = oSonaFormaPago.FormaPago_S(6, 0, "");

               // Utilerias.llenarComboxDataTable(cbFormaPago, dtFormaPago, "Clave", "Descripción");

                cbFormaPago.DataSource = dtFormaPago;
                cbFormaPago.DisplayMember = "Descripción";
                cbFormaPago.ValueMember = "Clave";

                bClickPrimeraVezFormaPago = false;

            } // if (bClickPrimeraVezFormaPago)

            int iIdFormaPagoBuscar = 0;
            if (!bClickPrimeraVezFormaPago)
            {
                pnlActPeriodoIncidencia.Visible = false;
                iIdFormaPagoBuscar = Convert.ToInt32(cbFormaPago.SelectedValue.ToString());
                iIdFormaPago = iIdFormaPagoBuscar;
                fgPeriodosProcesoIncidencia(6, iIdFormaPagoBuscar, "", "", "", iStPeriodoIncidencia, LoginInfo.IdTrab, this.Name, "", "", "", "", "", "", "", "", "", "", 0, "");
            } // if (!bClickPrimeraVezFormaPago)



        } // private void PeriodosProcesoIncidencia_Load(object sender, EventArgs e)

        private void ckbEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbEliminar.Checked == true)
            {
                Util.ChangeButton(btnInsertar, 3, false);
                lblActPeriodoIncidencia.Text = "     Elimina Período Incidencias";
                iActbtn = 3;
            }
            else
            {
                Util.ChangeButton(btnInsertar, 2, false);
                lblActPeriodoIncidencia.Text = "     Modifica Período Incidencias";
                iActbtn = 2;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            panelTag.Visible = false;
            timer1.Stop();
        }

        //-----------------------------------------------------------------------------------------------
        //                                      F U N C I O N E S 
        //-----------------------------------------------------------------------------------------------

        //TOOL TIP PARA OBJETOS
        private void fTooltip()
        {

            //CREA TOOL TIP
            ToolTip toolTip1 = new ToolTip();

            //CONFIGURACION
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;

            // CONFIGURA EL TEXTO POR OBJETO
            toolTip1.SetToolTip(this.btnCerrar, "Cerrar Sistema");
            toolTip1.SetToolTip(this.btnMinimizar, "Minimizar Sistema");
            toolTip1.SetToolTip(this.btnRegresar, "Regresar");
            toolTip1.SetToolTip(this.btnAgregar, "Agrega Registro");
            toolTip1.SetToolTip(this.btnBuscar, "Busca Registro");
            toolTip1.SetToolTip(this.btnInsertar, "Insertar Registro");
            toolTip1.SetToolTip(this.btnImprimir, "Imprimir");
        } // private void fTooltip()

        private void fgPeriodosProcesoIncidencia(int iOpcion, int iIdFormaPago, string sFechaInicioPeriodoIncidencia, string sFechaFinPeriodoIncidencia, string sDescripcion, int iStPeriodoProceso, string sUsuumod, string sPrgumod, string sFechaInicioProcInc, string sFechaFinProcInc, string sFechaInicioConsInc, string
            sFechaFinConsInc, string sFechaInicioCalifSup, string sFechaFinCalifSup, string sFechaInicioCalifDir, string sFechaFinCalifDir, string sFechaInicioUpdate, string sFechaFinUpdate,
            int istgensanciones, string sfgensanciones)
        {
            if (iIns == 1 && iAct == 1 && iElim == 1)
            {

                DataTable dtPeriodosProcesoIncidencias = oPeriodoProcesoIncidencia.obtPeriodosProcesoIncidencia(iOpcion, iIdFormaPago, sFechaInicioPeriodoIncidencia, sFechaFinPeriodoIncidencia, sDescripcion, iStPeriodoIncidencia, sUsuumod, sPrgumod,  sFechaInicioProcInc,  sFechaFinProcInc,  sFechaInicioConsInc, 
                sFechaFinConsInc,  sFechaInicioCalifSup,  sFechaFinCalifSup,  sFechaInicioCalifDir,  sFechaFinCalifDir,  sFechaInicioUpdate,  sFechaFinUpdate, istgensanciones, sfgensanciones);
                dgvPeriodosProcesoIncidencias.DataSource = dtPeriodosProcesoIncidencias;

               

                if (dgvPeriodosProcesoIncidencias.Columns.Count > 6)
                {
                   dgvPeriodosProcesoIncidencias.Columns.RemoveAt(0);
                }

                DataGridViewImageColumn imgCheckUsuarios = new DataGridViewImageColumn();
                imgCheckUsuarios.Image = Resources.ic_lens_blue_grey_600_18dp;
                imgCheckUsuarios.Name = "img";
                dgvPeriodosProcesoIncidencias.Columns.Insert(0, imgCheckUsuarios);
                dgvPeriodosProcesoIncidencias.Columns[0].HeaderText = "Selección";
                dgvPeriodosProcesoIncidencias.Columns[0].Width = 75;
                dgvPeriodosProcesoIncidencias.Columns[1].Visible = false;
                dgvPeriodosProcesoIncidencias.Columns[2].Width = 100;
                dgvPeriodosProcesoIncidencias.Columns[3].Width = 100;
                dgvPeriodosProcesoIncidencias.Columns[4].Width = 130;
                dgvPeriodosProcesoIncidencias.Columns[5].Width = 60;
                dgvPeriodosProcesoIncidencias.Columns[5].Visible = false;
                dgvPeriodosProcesoIncidencias.ClearSelection();
            }
            else if (iIns == 1 && iAct == 1)
            {
                DataTable dtPeriodosProcesoIncidencias = oPeriodoProcesoIncidencia.obtPeriodosProcesoIncidencia(iOpcion, iIdFormaPago, sFechaInicioPeriodoIncidencia, sFechaFinPeriodoIncidencia, sDescripcion, iStPeriodoIncidencia, sUsuumod, sPrgumod, sFechaInicioProcInc, sFechaFinProcInc, sFechaInicioConsInc,
            sFechaFinConsInc, sFechaInicioCalifSup, sFechaFinCalifSup, sFechaInicioCalifDir, sFechaFinCalifDir, sFechaInicioUpdate, sFechaFinUpdate, istgensanciones, sfgensanciones);
                dgvPeriodosProcesoIncidencias.DataSource = dtPeriodosProcesoIncidencias;
                DataGridViewImageColumn imgCheckUsuarios = new DataGridViewImageColumn();
                imgCheckUsuarios.Image = Resources.ic_lens_blue_grey_600_18dp;
                imgCheckUsuarios.Name = "img";
                if (dgvPeriodosProcesoIncidencias.Columns.Count > 6)
                {
                  dgvPeriodosProcesoIncidencias.Columns.RemoveAt(0);
                }

                dgvPeriodosProcesoIncidencias.Columns.Insert(0, imgCheckUsuarios);
                dgvPeriodosProcesoIncidencias.Columns[0].HeaderText = "Selección";
                dgvPeriodosProcesoIncidencias.Columns[0].Width = 75;
                dgvPeriodosProcesoIncidencias.Columns[1].Visible = false;
                dgvPeriodosProcesoIncidencias.Columns[2].Width = 100;
                dgvPeriodosProcesoIncidencias.Columns[3].Width = 100;
                dgvPeriodosProcesoIncidencias.Columns[4].Width = 130;
                dgvPeriodosProcesoIncidencias.Columns[5].Width = 60;
                dgvPeriodosProcesoIncidencias.Columns[5].Visible = false;
               // dgvPeriodosProcesoIncidencias.Columns[6].Width = 80;
                dgvPeriodosProcesoIncidencias.ClearSelection();

            }
            else if (iIns == 1 && iElim == 1)
            {
                DataTable dtPeriodosProcesoIncidencias = oPeriodoProcesoIncidencia.obtPeriodosProcesoIncidencia(iOpcion, iIdFormaPago, sFechaInicioPeriodoIncidencia, sFechaFinPeriodoIncidencia, sDescripcion, iStPeriodoIncidencia, sUsuumod, sPrgumod, sFechaInicioProcInc, sFechaFinProcInc, sFechaInicioConsInc,
                sFechaFinConsInc, sFechaInicioCalifSup, sFechaFinCalifSup, sFechaInicioCalifDir, sFechaFinCalifDir, sFechaInicioUpdate, sFechaFinUpdate, istgensanciones, sfgensanciones);
                dgvPeriodosProcesoIncidencias.DataSource = dtPeriodosProcesoIncidencias;
                DataGridViewImageColumn imgCheckUsuarios = new DataGridViewImageColumn();
                imgCheckUsuarios.Image = Resources.ic_lens_blue_grey_600_18dp;
                imgCheckUsuarios.Name = "img";
                if (dgvPeriodosProcesoIncidencias.Columns.Count > 6)
                {
                   dgvPeriodosProcesoIncidencias.Columns.RemoveAt(0);
                }

                dgvPeriodosProcesoIncidencias.Columns.Insert(0, imgCheckUsuarios);
                dgvPeriodosProcesoIncidencias.Columns[0].HeaderText = "Selección";
                dgvPeriodosProcesoIncidencias.Columns[0].Width = 75;
                dgvPeriodosProcesoIncidencias.Columns[1].Visible = false;
                dgvPeriodosProcesoIncidencias.Columns[2].Width = 100;
                dgvPeriodosProcesoIncidencias.Columns[3].Width = 100;
                dgvPeriodosProcesoIncidencias.Columns[4].Width = 130;
                dgvPeriodosProcesoIncidencias.Columns[5].Width = 60;
                dgvPeriodosProcesoIncidencias.Columns[5].Visible = false;
                //dgvPeriodosProcesoIncidencias.Columns[6].Width = 80;
                dgvPeriodosProcesoIncidencias.ClearSelection();
            }
            else if (iAct == 1 && iElim == 1)
            {
                DataTable dtPeriodosProcesoIncidencias = oPeriodoProcesoIncidencia.obtPeriodosProcesoIncidencia(iOpcion, iIdFormaPago, sFechaInicioPeriodoIncidencia, sFechaFinPeriodoIncidencia, sDescripcion, iStPeriodoIncidencia, sUsuumod, sPrgumod, sFechaInicioProcInc, sFechaFinProcInc, sFechaInicioConsInc,
                sFechaFinConsInc, sFechaInicioCalifSup, sFechaFinCalifSup, sFechaInicioCalifDir, sFechaFinCalifDir, sFechaInicioUpdate, sFechaFinUpdate, istgensanciones, sfgensanciones);
                dgvPeriodosProcesoIncidencias.DataSource = dtPeriodosProcesoIncidencias;
                DataGridViewImageColumn imgCheckUsuarios = new DataGridViewImageColumn();
                imgCheckUsuarios.Image = Resources.ic_lens_blue_grey_600_18dp;
                imgCheckUsuarios.Name = "img";
                if (dgvPeriodosProcesoIncidencias.Columns.Count > 6)
                {
                    dgvPeriodosProcesoIncidencias.Columns.RemoveAt(0);
                }

                dgvPeriodosProcesoIncidencias.Columns.Insert(0, imgCheckUsuarios);
                dgvPeriodosProcesoIncidencias.Columns[0].HeaderText = "Selección";
                dgvPeriodosProcesoIncidencias.Columns[0].Width = 75;
                dgvPeriodosProcesoIncidencias.Columns[1].Visible = false;
                dgvPeriodosProcesoIncidencias.Columns[2].Width = 100;
                dgvPeriodosProcesoIncidencias.Columns[3].Width = 100;
                dgvPeriodosProcesoIncidencias.Columns[4].Width = 130;
                dgvPeriodosProcesoIncidencias.Columns[5].Width = 60;
                dgvPeriodosProcesoIncidencias.Columns[5].Visible = false;
                //dgvPeriodosProcesoIncidencias.Columns[6].Width = 80;
                dgvPeriodosProcesoIncidencias.ClearSelection();
            }
            else if (iIns == 1)
            {
                DataTable dtPeriodosProcesoIncidencias = oPeriodoProcesoIncidencia.obtPeriodosProcesoIncidencia(iOpcion, iIdFormaPago, sFechaInicioPeriodoIncidencia, sFechaFinPeriodoIncidencia, sDescripcion, iStPeriodoIncidencia, sUsuumod, sPrgumod, sFechaInicioProcInc, sFechaFinProcInc, sFechaInicioConsInc,
                sFechaFinConsInc, sFechaInicioCalifSup, sFechaFinCalifSup, sFechaInicioCalifDir, sFechaFinCalifDir, sFechaInicioUpdate, sFechaFinUpdate, istgensanciones, sfgensanciones);
                dgvPeriodosProcesoIncidencias.DataSource = dtPeriodosProcesoIncidencias;
                dgvPeriodosProcesoIncidencias.Columns[1].Visible = false;
                dgvPeriodosProcesoIncidencias.Columns[2].Width = 100;
                dgvPeriodosProcesoIncidencias.Columns[3].Width = 100;
                dgvPeriodosProcesoIncidencias.Columns[4].Width = 130;
                dgvPeriodosProcesoIncidencias.Columns[5].Width = 60;
                dgvPeriodosProcesoIncidencias.Columns[5].Visible = false;
                //dgvPeriodosProcesoIncidencias.Columns[6].Width = 80;
                dgvPeriodosProcesoIncidencias.ClearSelection();
            }
            else if (iAct == 1)
            {
                DataTable dtPeriodosProcesoIncidencias = oPeriodoProcesoIncidencia.obtPeriodosProcesoIncidencia(iOpcion, iIdFormaPago, sFechaInicioPeriodoIncidencia, sFechaFinPeriodoIncidencia, sDescripcion, iStPeriodoIncidencia, sUsuumod, sPrgumod, sFechaInicioProcInc, sFechaFinProcInc, sFechaInicioConsInc,
                sFechaFinConsInc, sFechaInicioCalifSup, sFechaFinCalifSup, sFechaInicioCalifDir, sFechaFinCalifDir, sFechaInicioUpdate, sFechaFinUpdate, istgensanciones, sfgensanciones);
                dgvPeriodosProcesoIncidencias.DataSource = dtPeriodosProcesoIncidencias;
                DataGridViewImageColumn imgCheckUsuarios = new DataGridViewImageColumn();
                imgCheckUsuarios.Image = Resources.ic_lens_blue_grey_600_18dp;
                imgCheckUsuarios.Name = "img";
                if (dgvPeriodosProcesoIncidencias.Columns.Count > 6)
                {
                   dgvPeriodosProcesoIncidencias.Columns.RemoveAt(0);
                }

                dgvPeriodosProcesoIncidencias.Columns.Insert(0, imgCheckUsuarios);
                dgvPeriodosProcesoIncidencias.Columns[0].HeaderText = "Selección";
                dgvPeriodosProcesoIncidencias.Columns[0].Width = 75;
                dgvPeriodosProcesoIncidencias.Columns[1].Visible = false;
                dgvPeriodosProcesoIncidencias.Columns[2].Width = 100;
                dgvPeriodosProcesoIncidencias.Columns[3].Width = 100;
                dgvPeriodosProcesoIncidencias.Columns[4].Width = 130;
                dgvPeriodosProcesoIncidencias.Columns[5].Width = 60;
                dgvPeriodosProcesoIncidencias.Columns[5].Visible = false;
               // dgvPeriodosProcesoIncidencias.Columns[6].Width = 80;
                dgvPeriodosProcesoIncidencias.ClearSelection();
            }
            else if (iElim == 1)
            {
                DataTable dtPeriodosProcesoIncidencias = oPeriodoProcesoIncidencia.obtPeriodosProcesoIncidencia(iOpcion, iIdFormaPago, sFechaInicioPeriodoIncidencia, sFechaFinPeriodoIncidencia, sDescripcion, iStPeriodoIncidencia, sUsuumod, sPrgumod, sFechaInicioProcInc, sFechaFinProcInc, sFechaInicioConsInc,
                sFechaFinConsInc, sFechaInicioCalifSup, sFechaFinCalifSup, sFechaInicioCalifDir, sFechaFinCalifDir, sFechaInicioUpdate, sFechaFinUpdate, istgensanciones, sfgensanciones);
                dgvPeriodosProcesoIncidencias.DataSource = dtPeriodosProcesoIncidencias;
                DataGridViewImageColumn imgCheckUsuarios = new DataGridViewImageColumn();
                imgCheckUsuarios.Image = Resources.ic_lens_blue_grey_600_18dp;
                imgCheckUsuarios.Name = "img";
                if (dgvPeriodosProcesoIncidencias.Columns.Count > 6)
                {
                  dgvPeriodosProcesoIncidencias.Columns.RemoveAt(0);
                }
                dgvPeriodosProcesoIncidencias.Columns.Insert(0, imgCheckUsuarios);
                dgvPeriodosProcesoIncidencias.Columns[0].HeaderText = "Selección";
                dgvPeriodosProcesoIncidencias.Columns[0].Width = 75;
                dgvPeriodosProcesoIncidencias.Columns[1].Visible = false;
                dgvPeriodosProcesoIncidencias.Columns[2].Width = 100;
                dgvPeriodosProcesoIncidencias.Columns[3].Width = 100;
                dgvPeriodosProcesoIncidencias.Columns[4].Width = 130;
                dgvPeriodosProcesoIncidencias.Columns[5].Width = 60;
                dgvPeriodosProcesoIncidencias.Columns[5].Visible = false;
                // dgvPeriodosProcesoIncidencias.Columns[6].Width = 80;
                dgvPeriodosProcesoIncidencias.ClearSelection();
            }
            else
            {
                DataTable dtPeriodosProcesoIncidencias = oPeriodoProcesoIncidencia.obtPeriodosProcesoIncidencia(iOpcion, iIdFormaPago, sFechaInicioPeriodoIncidencia, sFechaFinPeriodoIncidencia, sDescripcion, iStPeriodoIncidencia, sUsuumod, sPrgumod, sFechaInicioProcInc, sFechaFinProcInc, sFechaInicioConsInc,
                sFechaFinConsInc, sFechaInicioCalifSup, sFechaFinCalifSup, sFechaInicioCalifDir, sFechaFinCalifDir, sFechaInicioUpdate, sFechaFinUpdate, istgensanciones, sfgensanciones);
                dgvPeriodosProcesoIncidencias.DataSource = dtPeriodosProcesoIncidencias;


                DataGridViewImageColumn imgCheckUsuarios = new DataGridViewImageColumn();
                imgCheckUsuarios.Image = Resources.ic_lens_blue_grey_600_18dp;
                imgCheckUsuarios.Name = "img";
                if (dgvPeriodosProcesoIncidencias.Columns.Count > 6)
                {
                     dgvPeriodosProcesoIncidencias.Columns.RemoveAt(0);
                }
                dgvPeriodosProcesoIncidencias.Columns.Insert(0, imgCheckUsuarios);
                dgvPeriodosProcesoIncidencias.Columns[0].HeaderText = "Selección";
                dgvPeriodosProcesoIncidencias.Columns[0].Width = 75;



               // dgvPeriodosProcesoIncidencias.Columns[0].Visible = false;
                dgvPeriodosProcesoIncidencias.Columns[1].Width = 80;
                dgvPeriodosProcesoIncidencias.Columns[2].Width = 80;
                dgvPeriodosProcesoIncidencias.Columns[3].Width = 80;
                dgvPeriodosProcesoIncidencias.Columns[4].Visible = false;
                dgvPeriodosProcesoIncidencias.Columns[5].Width = 87;
                dgvPeriodosProcesoIncidencias.Columns[6].Width = 85;
                dgvPeriodosProcesoIncidencias.Columns[7].Width = 85;
                dgvPeriodosProcesoIncidencias.Columns[8].Width = 85;
                dgvPeriodosProcesoIncidencias.Columns[9].Width = 85;
                dgvPeriodosProcesoIncidencias.Columns[10].Width = 85;
                dgvPeriodosProcesoIncidencias.Columns[11].Width = 85;
                dgvPeriodosProcesoIncidencias.Columns[12].Width = 85;
                dgvPeriodosProcesoIncidencias.Columns[13].Width = 85;
                //dgvPeriodosProcesoIncidencias.Columns[14].Visible = false;
                dgvPeriodosProcesoIncidencias.ClearSelection();
            }
        }

        private void fStatusPeriodoIncidencia(int iOpcion, string sTablaStatus, int iStValor, string sDescripcion, int iStStatus, string sUsuumod, string sPrgumod)
        {
            DataTable dtStatusPeriodoIncidencia = oStatus.statue_S(iOpcion, sTablaStatus, iStValor, sDescripcion, iStStatus, sUsuumod, sPrgumod);
            cbStatusPeriodo.DataSource = dtStatusPeriodoIncidencia;
            cbStatusPeriodo.DisplayMember = "Descripción";
            cbStatusPeriodo.ValueMember = "Val Status";
        }
        private void fuidPeriodosProcesoIncidencia(int iOpcion, int iIdFormaPago, string sFechaInicioPeriodoIncidencia, string sFechaFinPeriodoIncidencia, string sDescripcion, 
            int iStPeriodoIncidencia, string sUsuumod, string sPrgumod, string sFechaInicioProcInc, string sFechaFinProcInc, 
            string sFechaInicioConsInc, string sFechaFinConsInc, string sFechaInicioCalifSup, string sFechaFinCalifSup, string sFechaInicioCalifDir, 
            string sFechaFinCalifDir, string sFechaInicioUpdate, string sFechaFinUpdate, int istgensanciones, string sfgensanciones)
        {

            //agrega registro
            if (iActbtn == 1)
            {
                iResp = oPeriodoProcesoIncidencia.udiPeriodosProcesoIncidencia(iOpcion, iIdFormaPago, sFechaInicioPeriodoIncidencia, sFechaFinPeriodoIncidencia, sDescripcion, iStPeriodoIncidencia, sUsuumod, sPrgumod,  sFechaInicioProcInc,  sFechaFinProcInc,  sFechaInicioConsInc, 
            sFechaFinConsInc,  sFechaInicioCalifSup,  sFechaFinCalifSup,  sFechaInicioCalifDir,  sFechaFinCalifDir,  sFechaInicioUpdate, sFechaFinUpdate, istgensanciones, sfgensanciones);
                //lbMensaje.Text = iResp.ToString();
                txtDescripcionPeriodoIncidencia.Text = "";
            }
            //actualiza registro
            else if (iActbtn == 2)
            {
                iResp = oPeriodoProcesoIncidencia.udiPeriodosProcesoIncidencia(iOpcion, iIdFormaPago, sFechaInicioPeriodoIncidencia, sFechaFinPeriodoIncidencia, sDescripcion, iStPeriodoIncidencia, sUsuumod, sPrgumod, sFechaInicioProcInc, sFechaFinProcInc, sFechaInicioConsInc,
            sFechaFinConsInc, sFechaInicioCalifSup, sFechaFinCalifSup, sFechaInicioCalifDir, sFechaFinCalifDir, sFechaInicioUpdate, sFechaFinUpdate, istgensanciones, sfgensanciones);
            }
            //elimina registro
            else if (iActbtn == 3)
            {
                iResp = oPeriodoProcesoIncidencia.udiPeriodosProcesoIncidencia(iOpcion, iIdFormaPago, sFechaInicioPeriodoIncidencia, sFechaFinPeriodoIncidencia, sDescripcion, iStPeriodoIncidencia, sUsuumod, sPrgumod, sFechaInicioProcInc, sFechaFinProcInc, sFechaInicioConsInc,
                sFechaFinConsInc, sFechaInicioCalifSup, sFechaFinCalifSup, sFechaInicioCalifDir, sFechaFinCalifDir, sFechaInicioUpdate, sFechaFinUpdate, istgensanciones, sfgensanciones);
                txtDescripcionPeriodoIncidencia.Text = "";
            } // 

            switch (iResp.ToString())
            {
                case "1":
                    lblMensaje.Text = "Registro agregado correctamente";
                    break;
                case "2":
                    lblMensaje.Text = "Registro modificado correctamente";
                    break;
                case "3":
                    lblMensaje.Text = "Registro eliminado correctamente";
                    break;
                case "99":
                    lblMensaje.Text = "Registro ya existe";
                    break;
                default:
                    lblMensaje.Text = "";
                    break;
            } // switch (iResp.ToString())
        } // 

        private void factgrid()
        {
            string sStPeriodoIncidencia = "";
            for (int iContador = 0; iContador < dgvPeriodosProcesoIncidencias.Rows.Count; iContador++)
            {
                  dgvPeriodosProcesoIncidencias.Rows[iContador].Cells[0].Value = Resources.ic_lens_blue_grey_600_18dp;
            }
            


            if (dgvPeriodosProcesoIncidencias.SelectedRows.Count != 0)
            {



                DataGridViewRow row = this.dgvPeriodosProcesoIncidencias.SelectedRows[0];

                row.Cells[0].Value = Resources.ic_check_circle_green_400_18dp;


                sFechaInicioPeriodoIncidencia = row.Cells["Inicio"].Value.ToString();
                sFechaFinPeriodoIncidencia = row.Cells["Fin"].Value.ToString();
                sDescripcion = row.Cells["Descripción"].Value.ToString();
                sFechaInicioProcInc = row.Cells["FIProcesar"].Value.ToString();
                sFechaFinProcInc = row.Cells["FFProcesar"].Value.ToString();
                sFechaInicioConsInc = row.Cells["FIConsulta"].Value.ToString();
                sFechaFinConsInc = row.Cells["FFConsulta"].Value.ToString();
                sFechaInicioCalifSup = row.Cells["FICalifSup"].Value.ToString();
                sFechaFinCalifSup = row.Cells["FFCalifSup"].Value.ToString();
                sFechaInicioCalifDir = row.Cells["FICalifDir"].Value.ToString();
                sFechaFinCalifDir = row.Cells["FFCalifDir"].Value.ToString();
                fStatusPeriodoIncidencia(4, "rechtperiodopro", 0, "", 0, LoginInfo.IdTrab, this.Name);

                switch (row.Cells["Estatus"].Value.ToString())
                {
                                  
                    case "0":
                        sStPeriodoIncidencia = "CERRADO";
                        break;
                    case "1":
                        sStPeriodoIncidencia = "ABIERTO";
                        break;
                    case "2":
                        sStPeriodoIncidencia = "PROCESAR";
                        break;

                } // switch (row.Cells["Estatus"].Value.ToString())

                pnlActPeriodoIncidencia.Visible = true;
                lblActPeriodoIncidencia.Text = "     Modifica Período Incidencia";
                dtpFechaInicioPeriodoIncidencia.Text = sFechaInicioPeriodoIncidencia;
                dtpFechaFinPeriodoIncidencia.Text = sFechaFinPeriodoIncidencia;
                dtpFechaInicioPeriodoIncidencia.Focus();
                txtDescripcionPeriodoIncidencia.Text = sDescripcion;
                dtpFechaInicioProcesarIncidencia.Text = sFechaInicioProcInc;
                dtpFechaFinProcesarIncidencia.Text = sFechaFinProcInc;
                dtpFechaInicioConsultarIncidencia.Text = sFechaInicioConsInc;
                dtpFechaFinConsultarIncidencia.Text = sFechaFinConsInc;
                dtpFechaInicioCalificarIncidenciaSup.Text = sFechaInicioCalifSup;
                dtpFechaFinCalificarIncidenciaSup.Text = sFechaFinCalifSup;
                dtpFechaInicioCalificarIncidenciaDir.Text = sFechaInicioCalifDir;
                dtpFechaFinCalificarIncidenciaDir.Text =  sFechaFinCalifDir;
                cbStatusPeriodo.Text = sStPeriodoIncidencia;
                row.Cells[0].Value = Resources.ic_check_circle_green_400_18dp;

                string sgeninc = row.Cells["GeneraSanciones"].Value.ToString();

                if (sgeninc == "Si")
                {
                    ckbaplicasanc.Checked = true;
                    label11.Visible = true;
                    dtpfecsancion.Visible = true;
                    dtpfecsancion.Text = row.Cells["FecSanciones"].Value.ToString();
                }
                else if (sgeninc == "No")
                {
                    ckbaplicasanc.Checked = false;
                    label11.Visible = false;
                    dtpfecsancion.Visible = false;
                    dtpfecsancion.Text = dtpFechaFinCalificarIncidenciaDir.Text;
                }

            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            RechDashboard rechdb = new RechDashboard();
            rechdb.Show();
            this.Close();
        }

        private void lbltitulo_Click(object sender, EventArgs e)
        {

        }

        private void pnlActPeriodoIncidencia_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void lblFechaInicioCalificaIncidenciaSup_Click(object sender, EventArgs e)
        {

        }

        private void cbStatusPeriodo_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void dtpFechaInicioPeriodoIncidencia_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void dtpFechaInicioProcesarIncidencia_ValueChanged(object sender, EventArgs e)
        {
            dtpFechaFinProcesarIncidencia.Text = dtpFechaInicioProcesarIncidencia.Text;
        }

        private void dtpFechaInicioConsultarIncidencia_ValueChanged(object sender, EventArgs e)
        {
            dtpFechaFinConsultarIncidencia.Text = dtpFechaInicioConsultarIncidencia.Text;

        }

        private void dtpFechaInicioCalificarIncidenciaSup_ValueChanged(object sender, EventArgs e)
        {
            dtpFechaFinCalificarIncidenciaSup.Text = dtpFechaInicioCalificarIncidenciaSup.Text;
        }

        private void dtpFechaInicioCalificarIncidenciaDir_ValueChanged(object sender, EventArgs e)
        {
            dtpFechaFinCalificarIncidenciaDir.Text = dtpFechaInicioCalificarIncidenciaDir.Text;
        }

        private void dtpFechaFinPeriodoIncidencia_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
                       
        }

        private void pnlBusqueda_Paint(object sender, PaintEventArgs e)
        {

        }


       

        private bool validarFechas_Periodos()
        {
            bool resultadoValida = true;

            /* if (dtpFechaFinPeriodoIncidencia.Value.Date < dtpFechaInicioPeriodoIncidencia.Value.Date)
             {
                 MessageBox.Show("No puede elegir una Fecha de Fin de Periodo de Incidencia menor a la de Inicio de Periodo de Incidencia", "SIPPA - Periodo Incidencia", MessageBoxButtons.OK);
                 //Poner el foco en dtpFechaFinPeriodoIncidencia
                 dtpFechaFinPeriodoIncidencia.Focus();

                 resultadoValida = false;
             }
             else
             {
                 if (dtpFechaInicioProcesarIncidencia.Value.Date <= dtpFechaFinPeriodoIncidencia.Value.Date)
                 {
                     MessageBox.Show("No puede elegir una Fecha de Inicio de Procesar Incidencia menor o igual a la de Fin de Periodo de Incidencia", "SIPPA - Procesar Incidencia", MessageBoxButtons.OK);
                     // poner el foco en dtpFechaInicioProcesarIncidencia
                     dtpFechaInicioProcesarIncidencia.Focus();
                     resultadoValida = false;
                 }
                 else
                 {
                     if (dtpFechaFinProcesarIncidencia.Value.Date < dtpFechaInicioProcesarIncidencia.Value.Date)
                     {
                         MessageBox.Show("No puede elegir una Fecha de Fin de Procesar Incidencia menor a la de Inicio de Procesar Incidencia", "SIPPA - Procesar Incidencia", MessageBoxButtons.OK);
                         //Poner el foco en dtpFechaFinProcesarIncidencia
                         dtpFechaFinProcesarIncidencia.Focus();
                         resultadoValida = false;
                     }
                     else
                     { 
                         if (dtpFechaInicioConsultarIncidencia.Value.Date<=dtpFechaFinProcesarIncidencia.Value.Date)
                         {
                             MessageBox.Show("No puede elegir una Fecha de Inicio de Consultar Incidencia menor o igual a la de Fin de Procesar Incidencia", "SIPPA - Consultar Incidencia", MessageBoxButtons.OK);
                             // Poner el foco en dtpFechaInicioConsultarIncidencia
                             dtpFechaInicioConsultarIncidencia.Focus();
                             resultadoValida = false;
                         }
                         else
                         {
                             if (dtpFechaFinConsultarIncidencia.Value.Date < dtpFechaInicioConsultarIncidencia.Value.Date)
                             {
                                 MessageBox.Show("No puede elegir una Fecha de Fin de Consultar Incidencia menor a la de Inicio de Consultar Incidencia", "SIPPA - Consultar Incidencia", MessageBoxButtons.OK);
                                 // POner el foco en dtpFechaFinConsultarIncidencia.Value.Date
                                 dtpFechaFinConsultarIncidencia.Focus();
                                 resultadoValida = false;
                             }
                             else
                             {
                                 if (dtpFechaInicioCalificarIncidenciaSup.Value.Date<=dtpFechaFinConsultarIncidencia.Value.Date)
                                 {
                                     MessageBox.Show("No puede elegir una Fecha de Inicio de Calificar Incidencia Supervisor menor o igual a la de Fin de Consultar Incidencia", "SIPPA - Calificar Incidencia Supervisor", MessageBoxButtons.OK);
                                     // poner el foco en dtpFechaInicioCalificarIncidenciaSup
                                     dtpFechaInicioCalificarIncidenciaSup.Focus();
                                     resultadoValida = false;
                                 }
                                 else
                                 {
                                     if (dtpFechaFinCalificarIncidenciaSup.Value.Date <dtpFechaInicioCalificarIncidenciaSup.Value.Date)
                                     {
                                         MessageBox.Show("No puede elegir una Fecha de Fin de Calificar Incidencia Supervisor menor o a la de Inicio de Calificar Incidencia Supervisor", "SIPPA - Calificar Incidencia Supervisor", MessageBoxButtons.OK);
                                         // poner el foco en dtpFechaFinCalificarIncidenciaSup
                                         dtpFechaFinCalificarIncidenciaSup.Focus();
                                         resultadoValida = false;
                                     }
                                     else
                                     {
                                         if (dtpFechaInicioCalificarIncidenciaDir.Value.Date<=dtpFechaFinCalificarIncidenciaSup.Value.Date)
                                         {
                                             MessageBox.Show("No puede elegir una Fecha de Inicio de Calificar Incidencia Director menor o igual a la de Fin de Calificar de Incidencia Supervisor", "SIPPA - Calificar Incidencia Director", MessageBoxButtons.OK);
                                             // poner el foco en dtpFechaInicioCalificarIncidenciaDir
                                             dtpFechaInicioCalificarIncidenciaDir.Focus();
                                             resultadoValida = false;
                                         }
                                         else
                                         {
                                             if (dtpFechaFinCalificarIncidenciaDir.Value.Date < dtpFechaInicioCalificarIncidenciaDir.Value.Date)
                                             {
                                                 MessageBox.Show("No puede elegir una Fecha de Fin de Calificar Incidencia Director menor  a la de Fin de Calificar de Incidencia Director", "SIPPA - Calificar Incidencia Director", MessageBoxButtons.OK);
                                                 // poner el foco en dtpFechaFinCalificarIncidenciaDir
                                                 dtpFechaFinCalificarIncidenciaDir.Focus();
                                                 resultadoValida = false;
                                             }

                                         }
                                     }
                                 }
                             }
                         }

                     }

                 }
             }*/


            if (dtpFechaFinPeriodoIncidencia.Value.Date < dtpFechaInicioPeriodoIncidencia.Value.Date)
            {
                MessageBox.Show("No puede elegir una Fecha de Fin de Periodo de Incidencia menor a la de Inicio de Periodo de Incidencia", "SIPPA - Periodo Incidencia", MessageBoxButtons.OK);
                //Poner el foco en dtpFechaFinPeriodoIncidencia
                dtpFechaFinPeriodoIncidencia.Focus();

                resultadoValida = false;
            }
            else
            {
                if (dtpFechaInicioProcesarIncidencia.Value.Date <= dtpFechaFinPeriodoIncidencia.Value.Date)
                {
                    MessageBox.Show("No puede elegir una Fecha de Inicio de Procesar Incidencia menor o igual a la de Fin de Periodo de Incidencia", "SIPPA - Procesar Incidencia", MessageBoxButtons.OK);
                    // poner el foco en dtpFechaInicioProcesarIncidencia
                    dtpFechaInicioProcesarIncidencia.Focus();
                    resultadoValida = false;
                }
                else
                {
                    if (dtpFechaFinProcesarIncidencia.Value.Date < dtpFechaInicioProcesarIncidencia.Value.Date)
                    {
                        MessageBox.Show("No puede elegir una Fecha de Fin de Procesar Incidencia menor a la de Inicio de Procesar Incidencia", "SIPPA - Procesar Incidencia", MessageBoxButtons.OK);
                        //Poner el foco en dtpFechaFinProcesarIncidencia
                        dtpFechaFinProcesarIncidencia.Focus();
                        resultadoValida = false;
                    }
                    else
                    {
                        if (dtpFechaInicioConsultarIncidencia.Value.Date < dtpFechaFinProcesarIncidencia.Value.Date)
                        {
                            MessageBox.Show("No puede elegir una Fecha de Inicio de Consultar Incidencia menor a la de Fin de Procesar Incidencia", "SIPPA - Consultar Incidencia", MessageBoxButtons.OK);
                            // Poner el foco en dtpFechaInicioConsultarIncidencia
                            dtpFechaInicioConsultarIncidencia.Focus();
                            resultadoValida = false;
                        }
                        else
                        {
                            if (dtpFechaFinConsultarIncidencia.Value.Date < dtpFechaInicioConsultarIncidencia.Value.Date)
                            {
                                MessageBox.Show("No puede elegir una Fecha de Fin de Consultar Incidencia menor a la de Inicio de Consultar Incidencia", "SIPPA - Consultar Incidencia", MessageBoxButtons.OK);
                                // POner el foco en dtpFechaFinConsultarIncidencia.Value.Date
                                dtpFechaFinConsultarIncidencia.Focus();
                                resultadoValida = false;
                            }
                            else
                            {
                                if (dtpFechaInicioCalificarIncidenciaSup.Value.Date < dtpFechaFinConsultarIncidencia.Value.Date)
                                {
                                    MessageBox.Show("No puede elegir una Fecha de Inicio de Calificar Incidencia Supervisor menor a la de Fin de Consultar Incidencia", "SIPPA - Calificar Incidencia Supervisor", MessageBoxButtons.OK);
                                    // poner el foco en dtpFechaInicioCalificarIncidenciaSup
                                    dtpFechaInicioCalificarIncidenciaSup.Focus();
                                    resultadoValida = false;
                                }
                                else
                                {
                                    if (dtpFechaFinCalificarIncidenciaSup.Value.Date < dtpFechaInicioCalificarIncidenciaSup.Value.Date)
                                    {
                                        MessageBox.Show("No puede elegir una Fecha de Fin de Calificar Incidencia Supervisor menor o a la de Inicio de Calificar Incidencia Supervisor", "SIPPA - Calificar Incidencia Supervisor", MessageBoxButtons.OK);
                                        // poner el foco en dtpFechaFinCalificarIncidenciaSup
                                        dtpFechaFinCalificarIncidenciaSup.Focus();
                                        resultadoValida = false;
                                    }
                                    else
                                    {
                                        if (dtpFechaInicioCalificarIncidenciaDir.Value.Date < dtpFechaFinCalificarIncidenciaSup.Value.Date)
                                        {
                                            MessageBox.Show("No puede elegir una Fecha de Inicio de Calificar Incidencia Director menor  a la de Fin de Calificar de Incidencia Supervisor", "SIPPA - Calificar Incidencia Director", MessageBoxButtons.OK);
                                            // poner el foco en dtpFechaInicioCalificarIncidenciaDir
                                            dtpFechaInicioCalificarIncidenciaDir.Focus();
                                            resultadoValida = false;
                                        }
                                        else
                                        {
                                            if (dtpFechaFinCalificarIncidenciaDir.Value.Date < dtpFechaInicioCalificarIncidenciaDir.Value.Date)
                                            {
                                                MessageBox.Show("No puede elegir una Fecha de Fin de Calificar Incidencia Director menor  a la de Fin de Calificar de Incidencia Director", "SIPPA - Calificar Incidencia Director", MessageBoxButtons.OK);
                                                // poner el foco en dtpFechaFinCalificarIncidenciaDir
                                                dtpFechaFinCalificarIncidenciaDir.Focus();
                                                resultadoValida = false;
                                            }

                                        }
                                    }
                                }
                            }
                        }

                    }

                }
            }

            return resultadoValida;
        }

        private void ckbaplicasanc_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbaplicasanc.Checked == true)
            {
                label11.Visible = true;
                dtpfecsancion.Visible = true;

            }
            else if (ckbaplicasanc.Checked == false)
            {
                label11.Visible = false;
                dtpfecsancion.Visible = false;
            }
            else
            {
                label11.Visible = false;
                dtpfecsancion.Visible = false;
            }
        }

        //-----------------------------------------------------------------------------------------------
        //                                      R E P O R T E S
        //-----------------------------------------------------------------------------------------------

    } // public partial class PeriodosProcesoIncidencia : Form
}
