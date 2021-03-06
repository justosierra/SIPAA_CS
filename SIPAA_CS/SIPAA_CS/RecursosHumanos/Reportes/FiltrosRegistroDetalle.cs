﻿using CrystalDecisions.CrystalReports.Engine;
using SIPAA_CS.App_Code;
using SIPAA_CS.App_Code.RecursosHumanos.Catalogos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SIPAA_CS.App_Code.Usuario;

namespace SIPAA_CS.RecursosHumanos.Reportes
{
    public partial class FiltrosRegistroDetalle : Form
    {
        public string sIdTrab;
        public string sCompania;
        public string sUbicacion;
        public string dtFechaInicio;
        public string dtFechaFin;
        SonaTrabajador contenedorempleados = new SonaTrabajador();
        //public int sysH = SystemInformation.PrimaryMonitorSize.Height;
        //public int sysW = SystemInformation.PrimaryMonitorSize.Width;

        //////instanciamos los objetos (segun san lucas)
        SonaTrabajador oTrabajador = new SonaTrabajador();
        SonaCompania2 oCompañia = new SonaCompania2();
        SonaUbicacion oUbicacion = new SonaUbicacion();
        Utilerias util = new Utilerias();

        public FiltrosRegistroDetalle()
        {
            InitializeComponent();
        }

        bool bprimeravez = true;

        //***********************************************************************************************
        //Autor: José Luis Alvarez Delgado
        //Fecha creación:26-04-2017     Última Modificacion: 
        //Descripción: -------------------------------
        //***********************************************************************************************

        //-----------------------------------------------------------------------------------------------
        //                                      C O M B O S
        //-----------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------
        //                                      G R I D // S
        //-----------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------
        //                                     B O T O N E S
        //-----------------------------------------------------------------------------------------------
        private void btnImprimirDetalle_Click(object sender, EventArgs e)
        {
            dtFechaInicio = dpFechaInicio.Text;
            dtFechaFin = dpFechaFin.Text;

            if (cbEmpleados.Text==string.Empty)
                  sIdTrab = "%";
             else
                 sIdTrab = cbEmpleados.SelectedValue.ToString();
           
            if (cbCompania.Text==string.Empty | cbCompania.Text=="Seleccionar Compañia...")
                sCompania = "%";
            else
                sCompania = cbCompania.SelectedValue.ToString();
            if (cbUbicacion.Text==string.Empty | cbUbicacion.Text=="Seleccionar")
             sUbicacion = "%";
            else
              sUbicacion = cbUbicacion.SelectedValue.ToString();
            if (sIdTrab == "0")
                sIdTrab = "%";
            DataTable dtReporteRegistroDetalle = oTrabajador.ObtenerRegistroDetalle(sIdTrab, dtFechaInicio
                     ,dtFechaFin, sCompania, sUbicacion);

            switch (dtReporteRegistroDetalle.Rows.Count)
            {
                case 0:
                    DialogResult result = MessageBox.Show("No existeinformación para los filtros seleccionados", "SIPAA");
                    break;

                default:
                    ViewerReporte form = new ViewerReporte();
                    RegistroDetalle dtrpt = new RegistroDetalle();
                    //metodo del vic para ejecutar un reporte (segun yo)
                    ReportDocument ReportDoc = Utilerias.ObtenerObjetoReporte(dtReporteRegistroDetalle, this.CompanyName, dtrpt.ResourceName);

                    ReportDoc.SetParameterValue("FechaInicio", dpFechaInicio.Value);
                    ReportDoc.SetParameterValue("FechaFin", dpFechaFin.Value);
                    form.RptDoc = ReportDoc;
                    form.Show();

                   
                    // crear CSV
                    DialogResult Resultado = MessageBox.Show("¿Desea crear el archivo en formato .csv para abrirlo con excel?", "SIPAA", MessageBoxButtons.YesNo);
                    if (Resultado == DialogResult.Yes)
                        creacsv(dtReporteRegistroDetalle);
                    break;
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            RechDashboard rechdb = new RechDashboard();
            rechdb.Show();
            this.Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Esta seguro que desea abandonar la aplicación?", "SIPAA", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        //-----------------------------------------------------------------------------------------------
        //                           C A J A S      D E      T E X T O   
        //-----------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------
        //                                     E V E N T O S
        //-----------------------------------------------------------------------------------------------
        private void FiltrosRegistroDetalle_Load(object sender, EventArgs e)
        {
            //cierra formularios abiertos
            FormCollection formulariosApp = Application.OpenForms;
            foreach (Form f in formulariosApp)
            {
                if (f.Name != "FiltrosRegistroDetalle.cs")
                {
                    f.Hide();
                }
            }

            //llena etiqueta de usuario
            lblusuario.Text = LoginInfo.Nombre;
            Utilerias.cargaimagen(ptbimgusuario);

            //Utilerias.ResizeForm(this, new Size(new Point(sysH, sysW)));
            Utilerias.ResizeForm(this, Utilerias.PantallaSistema());

            if (bprimeravez == true)
            {
                //llenado de combo compañias
                util.cargarcombo(cbCompania, oCompañia.obtCompania2(5, "%"));
                //DataTable dtCompañia = oCompañia.obtCompania2(5, "");
                //cbCompania.DataSource = dtCompañia;
                //cbCompania.DisplayMember = "Descripción";
                //cbCompania.ValueMember = "Clave";
                cbCompania.Text = "Seleccionar Compañia...";

                //llenado de combo ubicaciones
                Utilerias.llenarComboxDataTable(cbUbicacion, oUbicacion.obtenerSonaUbicacion("", 6), "Clave", "Descripción");
                bprimeravez = false;
            }
            //Combo Empleados
            DataTable dtempleados = contenedorempleados.obtenerempleados(7, "");
            Utilerias.llenarComboxDataTable(cbEmpleados, dtempleados, "NoEmpleado", "Nombre");
            
            this.btnImprimirDetalle.Image = global::SIPAA_CS.Properties.Resources.Imprimir;
            cbEmpleados.Focus();
        }

        private void dpFechaFin_ValueChanged(object sender, EventArgs e)
        {
            if (dpFechaInicio.Value > dpFechaFin.Value)
            {
                //Utilerias.ControlNotificaciones(panelTag, lbMensaje, 3, "La fecha de Inicio no puede ser MAYOR a la de Término");
                MessageBox.Show("La fecha de Inicio no puede ser MAYOR a la Final", "SIPPA");
                dpFechaFin.Value = dpFechaInicio.Value;                
                btnImprimirDetalle.Enabled = false;
                dpFechaInicio.Focus();
            }
            else
            {
                btnImprimirDetalle.Enabled = true;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        //-----------------------------------------------------------------------------------------------
        //                                      F U N C I O N E S 
        //-----------------------------------------------------------------------------------------------
        private void creacsv(DataTable dtRpt)
        {



            saveFileDialog.Filter = "csv files (*.csv)|*.csv";
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK && saveFileDialog.FileName.Length > 0)
            {
                bool bandera = false;

                try
                {

                    StreamWriter Texto = new StreamWriter(saveFileDialog.FileName, false, Encoding.UTF8);

                    string cadenaReg = "";
                    cadenaReg = "Reporte de Detalle de Registro ";
                    Texto.WriteLine(cadenaReg);
                    Texto.Write(Texto.NewLine);
                    cadenaReg = "idTrab, Nombre, Compañia, Ubicacion, cvReloj, Fecha_reg, Hora_reg, Reloj ";
                    Texto.WriteLine(cadenaReg);
                    foreach (DataRow row in dtRpt.Rows)
                    {
                        cadenaReg = row[0].ToString() + "," + row[1].ToString() + "," + row[2].ToString() + "," + row[3].ToString() + "," + row[4].ToString() + "," + row[5].ToString() + "," + row[6].ToString() + "," + row[7].ToString();
                        Texto.WriteLine(cadenaReg);
                    }

                    Texto.Close();
                }
                catch
                {

                    bandera = true;
                }
                if (!bandera)
                    MessageBox.Show("El archivo " + saveFileDialog.FileName + "ha sido creado Correctamente, ahora puede abrirlo con excel");
                else
                    MessageBox.Show("No se pudo crear el archivo. Intente de Nuevo");

            }
        }
        //-----------------------------------------------------------------------------------------------
        //                                      R E P O R T E
        //-----------------------------------------------------------------------------------------------
    }
}
