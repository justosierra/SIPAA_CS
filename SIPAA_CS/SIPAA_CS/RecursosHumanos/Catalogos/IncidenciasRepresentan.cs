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
using SIPAA_CS.App_Code;
using SIPAA_CS.App_Code.RecursosHumanos;

using CrystalDecisions.CrystalReports.Engine;
using SIPAA_CS.RecursosHumanos.Reportes;
using static SIPAA_CS.App_Code.Usuario;

namespace SIPAA_CS.RecursosHumanos.Catalogos
{
    public partial class IncidenciasRepresentan : Form
    {
        public int cvIncidencia;
        public int cvRepresenta;
        public int iOpcionAdmin;
        public string strIncidencia;
        int sysH = SystemInformation.PrimaryMonitorSize.Height;
        int sysW = SystemInformation.PrimaryMonitorSize.Width;

        //***********************************************************************************************
        //Autor: Victor Jesús Iturburu Vergara
        //Fecha creación:15-03-2017      Última Modificacion: 23-03-2017
        //Descripción: -------------------------------
        //***********************************************************************************************

        //-----------------------------------------------------------------------------------------------
        //                                      C O M B O S
        //-----------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------
        //                                      G R I D // S
        //-----------------------------------------------------------------------------------------------
        private void LLenarGrid(int Opcion, Incidencia objIncidencia)
        {

            switch (Opcion)
            {

                case 1: //Busqueda

                    // objIncidencia.Descripcion = "%";
                    // objIncidencia.Representa = "%";
                    objIncidencia.UsuuMod = "";
                    objIncidencia.FhuMod = DateTime.Now;
                    objIncidencia.PrguMod = "";
                    int iOpcion = 4;

                    DataTable dtIncidencia = objIncidencia.ObtenerRepresentaxIncidencia(objIncidencia, iOpcion);
                    dgvIncidencia.DataSource = dtIncidencia;

                    DataGridViewImageColumn imgCheckPerfiles = new DataGridViewImageColumn();
                    imgCheckPerfiles.Image = Resources.ic_lens_blue_grey_600_18dp;
                    imgCheckPerfiles.Name = "Seleccionar";
                    //imgCheckPerfiles.HeaderText = "";
                    dgvIncidencia.Columns.Insert(0, imgCheckPerfiles);

                    dgvIncidencia.Columns[1].Visible = false;
                    dgvIncidencia.Columns[3].Visible = false;
                    dgvIncidencia.ClearSelection();

                    break;

            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            panelTag.Visible = false;
            timer1.Stop();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvIncidencia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            for (int iContador = 0; iContador < dgvIncidencia.Rows.Count; iContador++)
            {
                dgvIncidencia.Rows[iContador].Cells[0].Value = Resources.ic_lens_blue_grey_600_18dp;
            }


            if (dgvIncidencia.SelectedRows.Count != 0)
            {

                DataGridViewRow row = this.dgvIncidencia.SelectedRows[0];
                PanelEditar.Visible = true;
                cvIncidencia = Convert.ToInt32(row.Cells["cvincidencia"].Value.ToString());
                cvRepresenta = Convert.ToInt32(row.Cells["cvrepresenta"].Value.ToString());
                strIncidencia = row.Cells["Incidencia"].Value.ToString();
                string strRepresenta = row.Cells["Representa"].Value.ToString();
                LlenarComboRepresenta(cbIncidencia, 1);
                ckbEliminar.Visible = true;
                ckbEliminar.Checked = false;
                cbIncidencia.SelectedItem = strIncidencia;
                //   LlenarComboRepresenta(cbRepresentaEditar,5);
                cbRepresentaEditar.SelectedItem = strRepresenta;
                lblAccion.Text = "     Editar Incidencia";
                cbIncidencia.Enabled = false;
                PanelEditar.Visible = true;
                row.Cells[0].Value = Resources.ic_check_circle_green_400_18dp;
                btnGuardar.Image = Resources.Editar;
                //Utilerias.CambioBoton(btnGuardar, btnEliminar,btnGuardar, btnEditar);

                iOpcionAdmin = 2;


            }
        }
        //-----------------------------------------------------------------------------------------------
        //                                     B O T O N E S
        //-----------------------------------------------------------------------------------------------

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            lblAccion.Text = "     Nueva Asignación";
            panelTag.Visible = false;
            ckbEliminar.Checked = false;

            cbIncidencia.Enabled = true;
            LlenarComboRepresenta(cbIncidencia, 6);
            //  LlenarComboRepresenta(cbRepresentaEditar, 5);
            txtBuscarIncidencia.Text = "";
            PanelEditar.Visible = true;
            iOpcionAdmin = 4;
            //btnEditar.Visible = false;
            btnGuardar.Image = Resources.Guardar;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            strIncidencia = cbIncidencia.SelectedItem.ToString();


            lblAccion.Text = "       Selección";

            Incidencia objIncidencia = new Incidencia();
            //objIncidencia.CVIncidencia = cbIncidencia.SelectedIndex;
            objIncidencia.Descripcion = strIncidencia;
            objIncidencia.CVRepresenta = cbRepresentaEditar.SelectedIndex;
            objIncidencia.Representa = cbRepresentaEditar.SelectedItem.ToString();
            objIncidencia.PrguMod = this.Name;
            // objIncidencia.FhuMod = DateTime.Now;
            objIncidencia.UsuuMod = "vjiturburuv";
            try
            {
                DataTable reponse = objIncidencia.ObtenerRepresentaxIncidencia(objIncidencia, iOpcionAdmin);
                ckbEliminar.Checked = false;
                panelTag.Visible = true;
                if (iOpcionAdmin == 2) {
                   
                    panelTag.BackColor = ColorTranslator.FromHtml("#439047");
                    lbMensaje.Text = "Cambio Correcto";
                    timer1.Start();
                }
                else if (iOpcionAdmin == 3)
                {
                    panelTag.Visible = true;
                    panelTag.BackColor = ColorTranslator.FromHtml("#439047");
                    lbMensaje.Text = "Asignación Eliminada.";
                    timer1.Start();
                }
                else if (iOpcionAdmin == 4)
                {
                    panelTag.Visible = true;
                    panelTag.BackColor = ColorTranslator.FromHtml("#439047");
                    lbMensaje.Text = "Registro Completo.";
                    timer1.Start();
                }

                LlenarComboRepresenta(cbIncidencia, 6);

                
                btnBuscar_Click_1(sender, e);
            }
            catch (Exception ex)
            {

                Utilerias.ControlNotificaciones(panelTag, lbMensaje, 3, "Error de Comunicación con el Servidor. Intentarlo más tarde.");
                timer1.Start();
            }

        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            ckbEliminar.Checked = false;
            ckbEliminar.Visible = false;
            lblAccion.Text = "       Perfil Seleccionado";
            if (dgvIncidencia.Columns.Count > 3)
            {
                dgvIncidencia.Columns.Remove(columnName: "SELECCIONAR");
            }
           
            PanelEditar.Visible = false;

            Incidencia objIncidencia = new Incidencia();
            objIncidencia.Descripcion = txtBuscarIncidencia.Text;

            if (cbRepresenta.SelectedIndex < 1)
            {
                objIncidencia.Representa = "%";
            }
            else
            {
                objIncidencia.Representa = cbRepresenta.SelectedItem.ToString();
            }
            LLenarGrid(1, objIncidencia);
        }
    
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Seguro que desea salir?", "SIPAA", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        //-----------------------------------------------------------------------------------------------
        //                           C A J A S      D E      T E X T O   
        //-----------------------------------------------------------------------------------------------


        //-----------------------------------------------------------------------------------------------
        //                                     E V E N T O S
        //-----------------------------------------------------------------------------------------------

        public IncidenciasRepresentan()
        {
            InitializeComponent();
        }

        private void Incapacidad_Representa_Load(object sender, EventArgs e)
        {


            lblusuario.Text = LoginInfo.Nombre;
            Utilerias.cargaimagen(ptbimgusuario);
            // Diccionario Permisos x Pantalla
            DataTable dtPermisos = Modulo.ObtenerPermisosxUsuario(LoginInfo.IdTrab, this.Name);
            Permisos.dcPermisos = Utilerias.CrearListaPermisoxPantalla(dtPermisos);
            //////////////////////////////////////////////////////
            // resize 
            Utilerias.ResizeForm(this, Utilerias.PantallaSistema());
            ///////////////////////////////////////////////////////////////////////////////////////////////////

            Incidencia objIncidencia = new Incidencia();
            objIncidencia.Descripcion = "%";
            objIncidencia.Representa = "%";
            LLenarGrid(1, objIncidencia);
            txtBuscarIncidencia.Focus();
            //LlenarComboRepresenta(cbRepresenta,5);


            if (Permisos.dcPermisos["Crear"] != 1) {

                btnAgregar.Visible = false;
            }
        }

        private void ckbEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbEliminar.Checked == true)
            {
                btnGuardar.Image = Resources.Baja;

                iOpcionAdmin = 3;
                //Utilerias.CambioBoton(btnGuardar, btnEditar, btnGuardar, btnEliminar);
            }
            else
            {
                iOpcionAdmin = 2;
                btnGuardar.Image = Resources.Editar;
                //Utilerias.CambioBoton(btnGuardar, btnEliminar, btnGuardar, btnEditar);

            }
        }


        //-----------------------------------------------------------------------------------------------
        //                                      F U N C I O N E S 
        //-----------------------------------------------------------------------------------------------


        private void LlenarComboRepresenta(ComboBox cb, int Opcion)
        {
            Incidencia objIncidencia = new Incidencia();
            objIncidencia.Descripcion = "";
            objIncidencia.Representa = "";
            objIncidencia.UsuuMod = "";
            objIncidencia.FhuMod = DateTime.Now;
            objIncidencia.PrguMod = "";
            //int iOpcion = 5;
            DataTable dtIncidencia = objIncidencia.ObtenerRepresentaxIncidencia(objIncidencia, Opcion);
            List<string> ltRepresenta = new List<string>();
            foreach (DataRow row in dtIncidencia.Rows)
            {
                ltRepresenta.Add(row[1].ToString());
            }
            cb.DataSource = ltRepresenta;

            if (cb.Items.Count == 0)
            {
                cb.Enabled = false;
                cb.SelectedText = "Sin datos para Asignar";
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
          
        }

        private void dgvIncidencia_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {

        }




        //-----------------------------------------------------------------------------------------------
        //                                      R E P O R T E
        //-----------------------------------------------------------------------------------------------















    }
}
