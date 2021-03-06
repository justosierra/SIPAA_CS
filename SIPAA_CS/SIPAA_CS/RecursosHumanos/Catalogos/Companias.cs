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

using static SIPAA_CS.App_Code.Usuario;



//***********************************************************************************************
//Autor: Noe Alvarez Marquina
//Fecha creación:dd-mm-aaaa       Última Modificacion: dd-mm-aaaa
//Descripción: Lee la tabla de compañias de SONARH
//***********************************************************************************************

namespace SIPAA_CS.RecursosHumanos.Catalogos
{

    #region variables


    #endregion

    public partial class Companias : Form
    {
        public Companias()
        {
            InitializeComponent();
        }

        SonaCompania companias = new SonaCompania();

        //-----------------------------------------------------------------------------------------------
        //                                      C O M B O S
        //-----------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------
        //                                      G R I D // S
        //-----------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------
        //                                     B O T O N E S
        //-----------------------------------------------------------------------------------------------

        //boton buscar compañia 
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //llena grid
            fgcomp(6,txtcomp.Text.Trim());

            txtcomp.Text = "";
            txtcomp.Focus();
        }

        //boton minimizar
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        //boton regresar
        private void btnregresar_Click(object sender, EventArgs e)
        {
            RechDashboard rechdb = new RechDashboard();
            rechdb.Show();
            this.Close();
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

            }
        }
        //-----------------------------------------------------------------------------------------------
        //                           C A J A S      D E      T E X T O   
        //-----------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------
        //                                     E V E N T O S
        //-----------------------------------------------------------------------------------------------
        private void frmCompanias_Load(object sender, EventArgs e)
        {
            //Rezise de la Forma
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

            //llena etiqueta de usuario
            lblusuario.Text = LoginInfo.Nombre;
            Utilerias.cargaimagen(ptbimgusuario);

            //inicializa tool tip
            ftooltip();

            txtcomp.Focus();

            //llena grid
            fgcomp(6,"");
        }
        //-----------------------------------------------------------------------------------------------
        //                                      F U N C I O N E S 
        //-----------------------------------------------------------------------------------------------
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
            toolTip1.SetToolTip(this.btnbuscar, "Buscar Registros");
        }
        //llena grid compañias
        private void fgcomp(int iopc, string sbusq)
        {
            DataTable dtcompania = companias.obtcomp(iopc, sbusq);
            dgvcomp.DataSource = dtcompania;

            dgvcomp.Columns[0].Visible = false;//clave
            dgvcomp.Columns[1].Width = 395;//descripción
            dgvcomp.Columns[2].Width = 130;//rfc
            dgvcomp.ClearSelection();
        }


    }
}
