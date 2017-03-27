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

namespace SIPAA_CS.RecursosHumanos
{
    //***********************************************************************************************
    //Autor: Victor Jesús Iturburu Vergara
    //Fecha creación:23-03-2017       Última Modificacion: 23-03-2017
    //Descripción: Catalogo de Tipos de Incidencia
    //***********************************************************************************************

    public partial class IncidenciasTipo : Form
    {
        public int cvIncidencia;
        public int cvTipo;
        public int iOpcionAdmin;
        public string strIncidencia;
        public string strTipoIncidencia;
        public string strEstatus;
        public int sysH;
        public int sysW;
        public IncidenciasTipo()
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
            //int iOpcion = 5;
            DataTable dtIncidencia = objIncidencia.ObtenerIncidenciaxTipo(objIncidencia, Opcion);



            List<string> ltCombo = new List<string>();
            foreach (DataRow row in dtIncidencia.Rows)
            {
                ltCombo.Add(row[Display].ToString());
            }

            ltCombo.Insert(0, "Seleccionar");
            cb.DataSource = ltCombo;
            cb.DisplayMember = Display;
            if (cb.Items.Count == 0)
            {
                cb.Enabled = false;
                cb.SelectedText = "Sin datos para Asignar";
            }

        }

        //-----------------------------------------------------------------------------------------------
        //                                      G R I D // S
        //-----------------------------------------------------------------------------------------------
        private void LLenarGridIncapacidad(DataGridView dgvIncidencia, string strIncidencia, string Tipo)
        {

            if (dgvIncidencia.Columns.Count > 1)
            {
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
            objIncidencia.UsuuMod = "vjiturburuv";
            objIncidencia.PrguMod = this.Name;
            DataTable dtIncidencia = objIncidencia.ObtenerIncidenciaxTipo(objIncidencia, 4);
            dgvIncidencia.DataSource = dtIncidencia;



            DataGridViewImageColumn imgCheck = new DataGridViewImageColumn();
            imgCheck.Image = Resources.ic_lens_blue_grey_600_18dp;
            imgCheck.Name = "Seleccionar";
            //imgCheckPerfiles.HeaderText = "";
            dgvIncidencia.Columns.Insert(0, imgCheck);

            dgvIncidencia.Columns[0].Width = 40;
            dgvIncidencia.Columns[1].Visible = false;
            dgvIncidencia.Columns[2].Visible = false;
            dgvIncidencia.Columns[3].Width = 200;
            dgvIncidencia.Columns[4].Width = 150;
            dgvIncidencia.Columns[5].Width = 20;

            dgvIncidencia.ClearSelection();

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
                    Utilerias.AsignarBotonResize(btnGuardar, new Size(sysW, sysH), "Alta");
                }
                else
                {
                  //  btnGuardar.Image = Resources.Baja;
                    Utilerias.AsignarBotonResize(btnGuardar, new Size(sysW, sysH), "Baja");
                }


                iOpcionAdmin = 3;
                //Utilerias.CambioBoton(btnGuardar, btnEditar, btnGuardar, btnEliminar);
            }
            else
            {
                iOpcionAdmin = 2;
               // btnGuardar.Image = Resources.Editar;
                Utilerias.AsignarBotonResize(btnGuardar, new Size(sysW, sysH), "Editar");
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
    

            Utilerias.AsignarBotonResize(btnGuardar, new Size(sysW, sysH), "Guardar");
           
            txtTipoEditar.Text = String.Empty;

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
             strIncidencia = cbIncidencia.SelectedItem.ToString();

            lblAccion.Text = "       Asignar Tipo Incapacidad";

            Incidencia objIncidencia = new Incidencia();
            objIncidencia.CVIncidencia = cvIncidencia;
            objIncidencia.CVTipo = cvTipo;
            objIncidencia.Descripcion = strIncidencia;
            objIncidencia.Estatus = "";
            objIncidencia.TipoIncidencia = txtTipoEditar.Text;

            objIncidencia.PrguMod = this.Name;
            // objIncidencia.FhuMod = DateTime.Now;
            objIncidencia.UsuuMod = "vjiturburuv";
            try
            {
                string Mensaje = "";
                if (strEstatus == "1")
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

            if (cbTipo.SelectedIndex == 0)
            {
                Tipo = "%";
            }
            else
            {
                Tipo = cbTipo.SelectedItem.ToString();
            }

            LLenarGridIncapacidad(dgvIncidencia, Incidencia, Tipo);
            // LlenarComboTipoIncidencia(cbTipo, "Tipo", "cvtipo", 5);
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
        private void Incapacidad_Tipo_Load(object sender, EventArgs e)
        {
             sysH = SystemInformation.PrimaryMonitorSize.Height;
             sysW = SystemInformation.PrimaryMonitorSize.Width;
            Utilerias.ResizeForm(this, new Size(new Point(sysH, sysW)));

            LLenarGridIncapacidad(dgvIncidencia, "", "");
            LlenarComboTipoIncidencia(cbTipo, "Tipo", "cvtipo", 5);
        }

        private void dgvIncidencia_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

                LlenarComboTipoIncidencia(cbIncidencia, "Incidencia", "cvincidencia", 6);

                if (strEstatus == String.Empty || strEstatus == "0")
                {
                    ckbEliminar.Text = "Alta";
                }
                else
                {
                    ckbEliminar.Text = "Baja";
                }

                ckbEliminar.Visible = true;
                ckbEliminar.Checked = false;
                txtTipoEditar.Text = strTipoIncidencia;
                //   LlenarComboRepresenta(cbRepresentaEditar,5);
                cbIncidencia.SelectedItem = strIncidencia;
                lblAccion.Text = "      Editar Incidencia";
                cbIncidencia.Enabled = false;
                PanelEditar.Visible = true;
                row.Cells[0].Value = Resources.ic_check_circle_green_400_18dp;
                //btnGuardar.Image = Resources.Editar;
                Utilerias.AsignarBotonResize(btnGuardar, new Size(sysW, sysH), "Editar");
                //Utilerias.CambioBoton(btnGuardar, btnEliminar,btnGuardar, btnEditar);

                iOpcionAdmin = 2;


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


        //-----------------------------------------------------------------------------------------------
        //                                      R E P O R T E
        //-----------------------------------------------------------------------------------------------

    }
}