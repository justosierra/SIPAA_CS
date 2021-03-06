﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CrystalDecisions.CrystalReports.Engine;
using SIPAA_CS.Properties;
using SIPAA_CS.Conexiones;
using SIPAA_CS.App_Code;
using SIPAA_CS.App_Code.RecursosHumanos.Catalogos;
using SIPAA_CS.RecursosHumanos.DataSets;
using static SIPAA_CS.App_Code.Usuario;
using System.IO;

//***********************************************************************************************
//Autor: Marco Dupont
//Fecha creación: 17-Mar-2017       Última Modificacion: dd-mm-aaaa
//Descripción: Administra Formas de Registro Empleado
//***********************************************************************************************

namespace SIPAA_CS.RecursosHumanos.Reportes
{
    public partial class FiltroTrabPerfil : Form
    {
        #region

        int iIDT; //Id del Trabajdor
        int iIDC; //Id de la Compañia
        int IIDU; //Id de la Ubicación
        int IACT; //Status del Trabajador
        int ISTC; //Checa (si/no)

        #endregion


        Utilerias Util = new Utilerias();
        SonaCompania CComUbi = new SonaCompania();
        RepTrabPerfil CTrabPerf = new RepTrabPerfil();
        SonaTrabajador CSonaTrab = new SonaTrabajador();

        public FiltroTrabPerfil()
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
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (cboEmpleados.SelectedIndex == 0 && cboCia.SelectedIndex == 0 && cboUbicacion.SelectedIndex == 0)
            {
                MessageBox.Show("Debe Seleccionar Trabajador, Compañia o Ubicación");
                cboEmpleados.Focus();
            }
            else
            {
                if (cboEmpleados.SelectedIndex == 0)
                {
                    iIDT = 0;                    
                }
                else
                {
                    iIDT = Int32.Parse(cboEmpleados.SelectedValue.ToString());
                }
                iIDC = Int32.Parse(cboCia.SelectedValue.ToString());
                IIDU = Int32.Parse(cboUbicacion.SelectedValue.ToString());
                IACT = Int32.Parse(cboStatus.SelectedIndex.ToString());
                ISTC = Int32.Parse(CbCheca.SelectedIndex.ToString());




                DataTable dtRpt = CTrabPerf.PerfilTrab_S(4, iIDT, iIDC, IIDU, IACT, ISTC);

                ViewerReporte form = new ViewerReporte();
                RTrabPerfil dtsRep = new RTrabPerfil();
                ReportDocument ReportDoc = Utilerias.ObtenerObjetoReporte(dtRpt, this.CompanyName, dtsRep.ResourceName);

                form.RptDoc = ReportDoc;
                form.Show();

            }

            ////Prueba Reporte Incidencias pasadas a Nomina
            //Incidencia objIncidencia = new Incidencia();
            //DataTable dtIncidencia = objIncidencia.ReporteIncidenciasPasadasNomina("%", DateTime.Parse("2017-02-05"), DateTime.Parse("2017-04-01"), "%", "%", "%");

            //ViewerReporte form = new ViewerReporte();
            //IncidenciasPasadasNomina rptIncidencia = new IncidenciasPasadasNomina();
            //ReportDocument ReportDoc = Utilerias.ObtenerObjetoReporte(dtIncidencia, "RecursosHumanos", rptIncidencia.ResourceName);

            //ReportDoc.SetParameterValue("FechaActual", DateTime.Now.ToString("dd/MM/yyyy"));
            //form.RptDoc = ReportDoc;
            //form.Show();
        }

        //imprime reporte de "detalle de horario"
        private void btnimpdethr_Click(object sender, EventArgs e)
        {
            if (cboEmpleados.SelectedIndex == 0 && cboCia.SelectedIndex == 0 && cboUbicacion.SelectedIndex == 0)
            {

                DialogResult result = MessageBox.Show("Selecciona Trabajador, Compañia o Ubicación", "SIPAA", MessageBoxButtons.OK);
                cboEmpleados.Focus();
            }
            else
            {
                if (cboEmpleados.SelectedIndex == 0)
                {
                    iIDT = 0;

                }
                else
                {
                    iIDT = Int32.Parse(cboEmpleados.SelectedValue.ToString());
                }
                iIDC = Int32.Parse(cboCia.SelectedValue.ToString());
                IIDU = Int32.Parse(cboUbicacion.SelectedValue.ToString());
                IACT = Int32.Parse(cboStatus.SelectedIndex.ToString());
                ISTC = Int32.Parse(CbCheca.SelectedIndex.ToString());

                DataTable dtrepdethr = CTrabPerf.DetHorario(6, iIDT, iIDC, IIDU, IACT, ISTC);

                ViewerReporte form = new ViewerReporte();
                DetalleHr RepDetHr = new DetalleHr();
                ReportDocument ReportDoc = Utilerias.ObtenerObjetoReporte(dtrepdethr, this.CompanyName, RepDetHr.ResourceName);

                form.RptDoc = ReportDoc;
                form.Show();

                // crear CSV
                DialogResult Resultado = MessageBox.Show("¿Desea crear el archivo en formato .csv para abrirlo con excel?", "SIPAA", MessageBoxButtons.YesNo);
                if (Resultado == DialogResult.Yes)
                    creacsv(dtrepdethr);

           

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
            DialogResult result = MessageBox.Show("¿Seguro que desea salir?", "SIPAA", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (result == DialogResult.No)
            {

            }

        }
        //-----------------------------------------------------------------------------------------------
        //                           C A J A S      D E      T E X T O   
        //-----------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------
        //                                     E V E N T O S
        //-----------------------------------------------------------------------------------------------

        private void FiltroTrabPerfil_Load(object sender, EventArgs e)
        {
            //cierra formularios abiertos
            FormCollection formulariosApp = Application.OpenForms;
            foreach (Form f in formulariosApp)
            {
                if (f.Name != "FiltroTrabPerfil.cs")
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

            //LLENA COMBOS
            DataTable dtCompania = CComUbi.obtcomp(5, "");
            Utilerias.llenarComboxDataTable(cboCia,dtCompania,"Clave", "Descripción");

            DataTable dtUbicacion = CComUbi.ObtenerUbicacionPlantel(5, "");
            Utilerias.llenarComboxDataTable(cboUbicacion, dtUbicacion, "IdUbicacion", "Descripción");
            
            DataTable dtEmpleado = CSonaTrab.obtenerempleados(7, "");
            Utilerias.llenarComboxDataTable(cboEmpleados, dtEmpleado, "NoEmpleado", "Nombre");

            cboStatus.SelectedIndex = 2;
            CbCheca.SelectedIndex = 2;
            cboStatus.Focus();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        //-----------------------------------------------------------------------------------------------
        //                                  S U B R U T I N A S
        //-----------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------
        //                                      F U N C I O N E S 
        //-----------------------------------------------------------------------------------------------
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
            //toolTip1.SetToolTip(this.btnAgregar, "Agrega Registro");
            //toolTip1.SetToolTip(this.btnBuscar, "Busca Registro");
            //toolTip1.SetToolTip(this.btnGuardar, "Guarda Registro");
            //toolTip1.SetToolTip(this.btnEditar, "Edita Registro");
            //toolTip1.SetToolTip(this.btnEliminar, "Elimina Registro");
            //toolTip1.SetToolTip(this.btnActiva, "Activa Registro");
        }

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            IACT = Int32.Parse(cboStatus.SelectedIndex.ToString());
            DataTable dtEmpleado = CSonaTrab.obtenerempleados(7, "");
            Utilerias.llenarComboxDataTable(cboEmpleados, dtEmpleado, "NoEmpleado", "Nombre");

        }




        //-----------------------------------------------------------------------------------------------
        //                                  S U B R U T I N A S
        //-----------------------------------------------------------------------------------------------
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
                    cadenaReg = "Reporte Trabajador Perfil ";
                    Texto.WriteLine(cadenaReg);
                    Texto.Write(Texto.NewLine);
                    cadenaReg = "IdTrab, Nombre, Estatus, Checa , Día, Hr Entrada, Hr Salida, Horario, Nombre Supervisor, Nombre Dir, Tiempo Comida, # horas , Asociación, Ubicación ";
                    Texto.WriteLine(cadenaReg);
                    Texto.Write(Texto.NewLine);

                    foreach (DataRow row in dtRpt.Rows)
                    {
                        cadenaReg = row[0].ToString() + "," + row[1].ToString() + "," + row[2].ToString()+ "," + row[3].ToString() + "," + row[4].ToString() + "," + row[5].ToString()
                            + "," + row[6].ToString() + "," + row[7].ToString() + "," + row[8].ToString() + "," + row[9].ToString() + "," + row[10].ToString() + "," + row[11].ToString()
                            + "," + row[12].ToString() + "," + row[13].ToString();
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
    }
}
