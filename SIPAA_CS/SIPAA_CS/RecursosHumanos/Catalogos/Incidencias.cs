﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SIPAA_CS.Properties;
using SIPAA_CS.Conexiones;
using SIPAA_CS.App_Code;
using SIPAA_CS.App_Code.Generales;
using SIPAA_CS.App_Code.RecursosHumanos.Catalogos;

using static SIPAA_CS.App_Code.Usuario;


//***********************************************************************************************
//Autor: Marco Dupont
//Fecha creación: 22-Mar-2017       Última Modificacion: dd-mm-aaaa
//Descripción: Administra Catálogo de Incidencias
//***********************************************************************************************

namespace SIPAA_CS.RecursosHumanos.Catalogos
{
    public partial class Incidencias : Form
    {
        #region

        int vValida;
        int iAgr;
        int iAct;
        int iEli;
        int iCvFR;
        int v_Orden;
        int iSt;
        int iStGen;
        int iStRep;
        string sDescAnt;

        #endregion

        ConcepInc CIncidencias = new ConcepInc();
        Utilerias Util = new Utilerias();
        statue Cstatus = new statue();
        public Incidencias()
        {
            InitializeComponent();
        }
        //-----------------------------------------------------------------------------------------------
        //                                      C O M B O S
        //-----------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------
        //                                      G R I D // S
        //-----------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------
        //                                     B O T O N E S
        //-----------------------------------------------------------------------------------------------
        //BOTON BUSCAR
        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            //LLAMA METODO LLENAR GRID
            pnlAct.Visible = false;
            SLlenaGrid(4, 0, txtFormReg.Text.Trim(), 0, 0, 0, 0, "", "");
            txtFormReg.Text = "";
            txtFormReg.Focus();
            pnlAct.Visible = false;

        }
        //BOTOS AGREGAR REGISTRO NUEVO
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            pnlAct.Visible = true;
            lblAct.Text = "     Agregar forma de registro";
            btnEliminar.Visible = false;
            btnEditar.Visible = false;
            ckbEliminar.Visible = false;
            btnGuardar.Visible = true;
            txtCapInc.Text = "";
            txtCapOrd.Text = "";
            iSt = 1;
            Utilerias.llenarComboxDataTable(cboRep, Cstatus.cbo(7, "rechcincidencia"), "Clave","Descripción");
            Utilerias.llenarComboxDataTable(cboGen, Cstatus.cbo(8, "rechcincidencia"), "Clave", "Descripción");
            txtCapInc.Focus();
        }
        //BOTON GUARDAR
        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            //VALIDA ESCRITURA DE ALGUN TEXTO
            Boolean bvalidacampos = fvalidacampos();

            if (bvalidacampos == true)
            {
                //valida registro duplicado
                sValIns(5, 0, txtCapInc.Text.Trim(), 0, 0, 0, 0, LoginInfo.IdTrab, this.Name);
                //
                if (vValida <= 0)
                {
                    sGuardaMod(1, 0, txtCapInc.Text.Trim(), Int32.Parse(txtCapOrd.Text.Trim()), Int32.Parse(cboGen.SelectedValue.ToString()), Int32.Parse(cboRep.SelectedValue.ToString()), iSt, LoginInfo.IdTrab, this.Name);
                    txtCapInc.Text = "";

                    panelTag.Visible = true;
                    timer1.Start();

                    SLlenaGrid(4, 0, "", 0, 0, 0, 0, "", "");
                    pnlAct.Visible = false;
                    txtFormReg.Focus();
                }
                else
                {
                    SLlenaGrid(4, 0, txtCapInc.Text.Trim(), 0, 0, 0, 0, "", "");
                    txtCapInc.Text = "";
                    pnlAct.Visible = false;
                    DialogResult result = MessageBox.Show("Registro ya existente", "SIPAA", MessageBoxButtons.OK);
                    txtFormReg.Focus();
                }
            }
        }
        //BOTON EDITAR
        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            //VALIDA ESCRITURA DE ALGUN TEXTO
            Boolean bvalidacampos = fvalidacampos();

            if (bvalidacampos == true)
            {
                if (sDescAnt == txtCapInc.Text.Trim())
                {

                    iStGen = Int32.Parse(cboGen.SelectedValue.ToString());
                    iStRep = Int32.Parse(cboRep.SelectedValue.ToString());
                    sGuardaMod(2, iCvFR, txtCapInc.Text.Trim(), v_Orden, iStGen, iStRep, 0, LoginInfo.IdTrab, this.Name);
                    txtCapInc.Text = "";
                    panelTag.Visible = true;
                    timer1.Start();
                    SLlenaGrid(4, iCvFR, "", 0, 0, 0, 0, "", "");
                    iCvFR = 0;
                    pnlAct.Visible = false;
                    txtFormReg.Focus();
                }
                else
                {
                    sValIns(5, 0, txtCapInc.Text.Trim(), 0, 0, 0, 0, LoginInfo.IdTrab, this.Name);
                    if (vValida >= 1)
                    {
                        SLlenaGrid(4, 0, txtCapInc.Text.Trim(), 0, 0, 0, 0, "", "");
                        txtCapInc.Text = "";
                        pnlAct.Visible = false;
                        DialogResult result = MessageBox.Show("Registro ya existente", "SIPAA", MessageBoxButtons.OK);
                        txtFormReg.Focus();
                    }
                    else
                    {
                        iStGen = Int32.Parse(cboGen.SelectedValue.ToString());
                        iStRep = Int32.Parse(cboRep.SelectedValue.ToString());
                        sGuardaMod(2, iCvFR, txtCapInc.Text.Trim(), v_Orden, iStGen, iStRep, 0, LoginInfo.IdTrab, this.Name);
                        txtCapInc.Text = "";
                        panelTag.Visible = true;
                        timer1.Start();
                        SLlenaGrid(4, iCvFR, "", 0, 0, 0, 0, "", "");
                        iCvFR = 0;
                        pnlAct.Visible = false;
                        txtFormReg.Focus();
                    }
                }
            }
            
        }
        //BOTON ELIMINAR
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Esta acción da de baja el registro, ¿Desea Continuar?", "SIPAA", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                iSt = 0;
                sGuardaMod(3, iCvFR, txtCapInc.Text.Trim(), 0, 0, 0, iSt, LoginInfo.IdTrab, this.Name);
                txtCapInc.Text = "";
                panelTag.Visible = true;
                timer1.Start();
                SLlenaGrid(4, 0, "", 0, 0, 0, 0, "", "");
                iCvFR = 0;
                pnlAct.Visible = false;
                txtFormReg.Focus();
            }
            else if (result == DialogResult.No)
            {

            }
        }
        //BOTON ALTA
        private void btnActiva_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Esta acción habilita el registro, ¿Desea Continuar?", "SIPAA", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                iSt = 1;
                v_Orden = int.Parse(txtCapOrd.Text);
                sGuardaMod(3, iCvFR, txtCapInc.Text.Trim(), 0, 0, v_Orden, iSt, LoginInfo.IdTrab, this.Name);
                txtCapInc.Text = "";
                panelTag.Visible = true;
                timer1.Start();
                SLlenaGrid(4, 0, "", 0, 0, 0, 0, "", "");
                iCvFR = 0;
                pnlAct.Visible = false;
            }
            else if (result == DialogResult.No)
            {

            }
        }


        //BOTON MINIMIZAR
        private void btnMinimizar_Click_1(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        //BOTON CERRAR
        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
        DialogResult result = MessageBox.Show("¿Seguro que desea salir?", "SIPAA", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (result == DialogResult.No)
            {

            }
        }
        //BOTON REGRESAR
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
        private void Incidencias_Load(object sender, EventArgs e)
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

            //llena etiqueta de usuario
            lblusuario.Text = LoginInfo.Nombre;
            Utilerias.cargaimagen(ptbimgusuario);

            //Configuracion de la pantalla
            int sysH = SystemInformation.PrimaryMonitorSize.Height;
            int sysW = SystemInformation.PrimaryMonitorSize.Width;

            Utilerias.ResizeForm(this, new Size(new Point(sysH, sysW)));

            //LLAMA TOOL TIP
            sTooltip();

            iAgr = 1;
            iAct = 1;
            iEli = 1;

            //LLAMA METODO LLENAR GRID
            SLlenaGrid(4, 0, "", 0, 0, 0, 0, LoginInfo.IdTrab, this.Name);

            //HABILITA BOTON AGREGAR
            if (iAgr == 1)
            {
                btnAgregar.Visible = true;
                pnlAct.Visible = false;
            }

            txtFormReg.Focus();
        }
        //evento tick de timer de mensajes
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            panelTag.Visible = false;
            timer1.Stop();
        }
        //-----------------------------------------------------------------------------------------------
        //                                  S U B R U T I N A S
        //-----------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------
        //                                      F U N C I O N E S 
        //-----------------------------------------------------------------------------------------------

        //TOOL TIP PARA OBJETOS
        private void sTooltip()
        {

            //CREA TOOL TIP
            ToolTip toolTip1 = new ToolTip();

            //CONFIGURACION
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;

            // CONFIGURA EL TEXTO POR OBJETO
            toolTip1.SetToolTip(this.btnCerrar, "Cierra Sistema");
            toolTip1.SetToolTip(this.btnMinimizar, "Minimiza Sistema");
            toolTip1.SetToolTip(this.btnRegresar, "Regresa");
            toolTip1.SetToolTip(this.btnAgregar, "Agrega Registro");
            toolTip1.SetToolTip(this.btnBuscar, "Busca Registro");
            toolTip1.SetToolTip(this.btnGuardar, "Guarda Registro");
            toolTip1.SetToolTip(this.btnEditar, "Edita Registro");
            toolTip1.SetToolTip(this.btnEliminar, "Elimina Registro");
            toolTip1.SetToolTip(this.btnActiva, "Activa Registro");
        }

        //LLENA GRID
        private void SLlenaGrid(int p_opcion, int p_cvIncidencia, string p_descripcion, int p_orden, int p_stgenera, int p_strepresenta, int p_stincidencia, string p_usuumod, string p_prgumodr)
        {

            DataTable dtIncidencia = CIncidencias.ConcepInc_S(p_opcion, p_cvIncidencia, p_descripcion, p_orden, p_stgenera, p_strepresenta, p_stincidencia, p_usuumod, p_prgumodr);
            dgvIncidencia.DataSource = dtIncidencia;
            
            DataGridViewImageColumn imgCheckUsuarios = new DataGridViewImageColumn();
            if (dgvIncidencia.Columns[0].HeaderText != "Selección")
            {
                imgCheckUsuarios.Image = Resources.ic_lens_blue_grey_600_18dp;
                imgCheckUsuarios.Name = "img";
                dgvIncidencia.Columns.Insert(0, imgCheckUsuarios);
                dgvIncidencia.Columns[0].HeaderText = "Selección";
            }
            
            dgvIncidencia.Columns[0].Width = 75;
            dgvIncidencia.Columns[1].Visible = false;
            dgvIncidencia.Columns[2].Width = 225;
            dgvIncidencia.Columns[3].Width = 50;
            dgvIncidencia.Columns[4].Visible = false;
            dgvIncidencia.Columns[5].Width = 85;
            dgvIncidencia.Columns[6].Visible = false;
            dgvIncidencia.Columns[7].Width = 85;
            dgvIncidencia.Columns[8].Visible = false;
            dgvIncidencia.Columns[9].Width = 70;
            dgvIncidencia.ClearSelection();
            sHabilitaPermisos();
        }

        //HABILITA PERMISOS
        private void sHabilitaPermisos()
        {

            //HABILITA MODITICAR ELIMINAR
            if (iAct == 1 && iEli == 1)
            {

                lblModifElim.Visible = true;

                pnlAct.Visible = true;
                btnEliminar.Visible = false;
                btnGuardar.Visible = false;
                ckbEliminar.Visible = true;

                ckbEliminar.Checked = false;

                lblModifElim.Visible = true;
                lblModifElim.Text = "Si desea modificar o eliminar un registro seleccione en el grid";

                btnEditar.Visible = true;

            }
            else if (iAct == 1)
            {

                pnlAct.Visible = true;
                lblModifElim.Visible = true;
                lblModifElim.Text = "Si desea modificar un registro seleccione en el grid";

            }
            else if (iEli == 1)
            {

                pnlAct.Visible = true;
                lblModifElim.Visible = true;
                lblModifElim.Text = "Si desea eliminar un registro seleccione en el grid";

            }
            else
            {
                //pnlAct.Visible = false;
                lblModifElim.Visible = false;
            }
        }
        private void ckbEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbEliminar.Checked == true)
            {
                if (iSt == 1)
                {
                    btnGuardar.Visible = false;
                    btnEditar.Visible = false;
                    btnEliminar.Visible = true;
                    btnActiva.Visible = false;
                }
                else
                {
                    btnGuardar.Visible = false;
                    btnEditar.Visible = true;
                    btnEliminar.Visible = false;
                    btnActiva.Visible = true;
                }
            }
            else
            {
                btnGuardar.Visible = false;
                btnEditar.Visible = true;
                btnEliminar.Visible = false;
                btnActiva.Visible = false;
            }
        }
        private void dgvIncidencia_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

            for (int iContador = 0; iContador < dgvIncidencia.Rows.Count; iContador++)
            {
                dgvIncidencia.Rows[iContador].Cells[0].Value = Resources.ic_lens_blue_grey_600_18dp;
            }

            sHabilitaPermisos();

            if (dgvIncidencia.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.dgvIncidencia.SelectedRows[0];
                
                iCvFR = Convert.ToInt32(row.Cells["Clave"].Value.ToString());
                string ValorRow = row.Cells["Descripción"].Value.ToString();
                string ValorRowO = row.Cells["Orden"].Value.ToString();
                iStGen = Convert.ToInt32(row.Cells["STGEN"].Value.ToString());
                iStRep = Convert.ToInt32(row.Cells["STREP"].Value.ToString());
                iSt = Convert.ToInt32(row.Cells["ST"].Value.ToString());

                Utilerias.llenarComboxDataTable(cboRep, Cstatus.cbo(7, "rechcincidencia"), "Clave", "Descripción");
                Utilerias.llenarComboxDataTable(cboGen, Cstatus.cbo(8, "rechcincidencia"), "Clave", "Descripción");

                cboGen.SelectedValue = iStGen;
                cboRep.SelectedValue = iStRep;

                txtCapInc.Text = ValorRow;
                txtCapOrd.Text = ValorRowO;
                txtCapInc.Focus();
                sDescAnt = txtCapInc.Text.Trim();

                row.Cells[0].Value = Resources.ic_check_circle_green_400_18dp;
                if (iSt == 0)
                {
                    ckbEliminar.Text = "Alta";
                }
                else
                {
                    ckbEliminar.Text = "Baja";
                }

            }
        }

        //validacion de campos
        private Boolean fvalidacampos()
        {
            if (txtCapInc.Text.Trim() == "")
            {
                DialogResult result = MessageBox.Show("Capture una descripción", "SIPAA", MessageBoxButtons.OK);
                txtCapInc.Focus();
                return false;
            }
            else if (txtCapOrd.Text.Trim() == "")
            {
                DialogResult result = MessageBox.Show("Capture el orden", "SIPAA", MessageBoxButtons.OK);
                txtCapOrd.Focus();
                return false;
            }
            else if (cboGen.Text.Trim() == "" || cboGen.SelectedIndex == -1 || cboGen.SelectedIndex == 0)
            {
                DialogResult result = MessageBox.Show("Selecione una opción *Generada por*", "SIPAA", MessageBoxButtons.OK);
                cboGen.Focus();
                return false;
            }
            else if (cboRep.Text.Trim() == "" || cboRep.SelectedIndex == -1 || cboRep.SelectedIndex == 0)
            {
                DialogResult result = MessageBox.Show("Selecione una opción *Representa*", "SIPAA", MessageBoxButtons.OK);
                cboRep.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        //GUARDA MODIFICA BAJA
        private void sGuardaMod(int iOpc, int sCve, string sDesc, int sOrd, int iSGn, int iSRp, int iStT, string sUsu, string sProg)
        {
            CIncidencias.ConcepInc_UID(iOpc, sCve, sDesc, sOrd, iSGn, iSRp, iStT, sUsu, sProg);
            if (iOpc == 1)
            {
                lbMensaje.Text = "Registro almacenado";
            }
            else if (iOpc == 2)
            {
                lbMensaje.Text = "Registro actualizado";
            }
            else if (iOpc == 3)
            {
                if (iSt == 0)
                {
                    lbMensaje.Text = "Registro dado de baja";
                }
                else
                {
                    lbMensaje.Text = "Registro dado de alta";
                }
            }
        }
        private void sValIns(int iOpc, int sCve, string sDesc, int sOrd, int iSGn, int iSRp, int iStT, string sUsu, string sProg)
        {
            vValida = CIncidencias.ConcepInc_V(iOpc, sCve, sDesc, sOrd, iSGn, iSRp, iStT, sUsu, sProg);
        }
        //-----------------------------------------------------------------------------------------------
        //                                      R E P O R T E
        //-----------------------------------------------------------------------------------------------

    }
}
