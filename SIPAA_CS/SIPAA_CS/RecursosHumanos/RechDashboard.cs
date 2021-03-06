﻿using SIPAA_CS.App_Code;
using SIPAA_CS.RecursosHumanos.Asignaciones;
using SIPAA_CS.RecursosHumanos.Catalogos;
using SIPAA_CS.RecursosHumanos.Procesos;
using SIPAA_CS.RecursosHumanos.Reportes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static SIPAA_CS.App_Code.Usuario;
using System.Data;
using SIPAA_CS.Properties;

using SIPAA_CS.App_Code.Accesos.Catalogos;

namespace SIPAA_CS.RecursosHumanos
{
    public partial class RechDashboard : Form
    {
        Usuarioap cusuarioap = new Usuarioap();
        Utilerias cutilerias = new Utilerias();
        string sultacceso;


        public RechDashboard()
        {
            InitializeComponent();
        }

       /* Perfil Perf = new Perfil();
        Usuario usuario = new Usuario();
        Utilerias Util = new Utilerias();
        */
        private void RechDashboard_Load(object sender, EventArgs e)
        {
            //variables datos del usuario
            DataTable datosusuario = cusuarioap.dtdatos(4, LoginInfo.cvusuario, 0, "", "", 0, "", 0, 0, "", "", "", "", "", "", 0, 0, "", "", "", "");
            sultacceso = datosusuario.Rows[0][5].ToString();
            lblacceso.Text = sultacceso;

            //inicia tool tip
            ftooltip();

            int sysH = SystemInformation.PrimaryMonitorSize.Height;
            int sysW = SystemInformation.PrimaryMonitorSize.Width;
            Utilerias.ResizeForm(this, new Size(new Point(sysH, sysW)));

            /*Dashboard form = new Dashboard();
            form.Enabled = false; */

            lblusuario.Text = LoginInfo.Nombre;
          

            Usuario objUsuario = new Usuario();

            // cargaMenu(0, null, MsMenu);

            CrearMenu();

            Utilerias.cargaimagen(ptbimgusuario);

            if (LoginInfo.iconexion == 1) { lblconexion.Visible = true; } else { lblconexion.Visible = false; }
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

        private void button1_Click(object sender, EventArgs e)
        {
            Dashboard dasb = new Dashboard();
            dasb.Show();
            this.Close();
        }

        //menu strip dinamico
        //private void cargaMenu(Int32 IdMaster, ToolStripMenuItem MenuPadre, MenuStrip Menu)
        //{

        //    DataTable menudin = new DataTable();
        //    menudin = Perf.dtmenudinamicocs(6,LoginInfo.IdTrab,"RECH");
        //    DataView DatosHijos = new DataView(menudin);
            
        //    DatosHijos.RowFilter = menudin.Columns["cvindmodulo"].ColumnName + "=" + IdMaster;

        //    foreach (DataRowView fila in DatosHijos)
        //    {
        //        ToolStripMenuItem MenuHijo = new ToolStripMenuItem();
        //        MenuHijo.Text = fila["descripcion"].ToString();
        //        MenuHijo.Name = fila["rutaaaceso"].ToString();
        //        MenuHijo.BackColor = Color.FromArgb(10, 62, 120);
        //        MenuHijo.ForeColor = Color.White;
        //        MenuHijo.Font = new Font("Arial", 12);
        //        MenuHijo.Image = Resources.ic_view_carousel_white_24dp;

        //        //modifica iconos
        //        if ((MenuHijo.Text = fila["descripcion"].ToString()) == "Catalogos")
        //        {
        //            MenuHijo.Image = Resources.ic_view_carousel_white_24dp;
        //        }
        //        else if ((MenuHijo.Text = fila["descripcion"].ToString()) == "Asignaciones")
        //        {
        //            MenuHijo.Image = Resources.ic_compare_arrows_white_24dp;
        //        }
        //        else if ((MenuHijo.Text = fila["descripcion"].ToString()) == "Reportes")
        //        {
        //            MenuHijo.Image = Resources.ic_assignment_white_24dp;
        //        }
        //        else if ((MenuHijo.Text = fila["descripcion"].ToString()) == "Procesos")
        //        {
        //            MenuHijo.Image = Resources.ic_assignment_white_24dp;
        //        }
        //        else
        //        {
        //            MenuHijo.Image = Resources.ic_view_carousel_white_24dp;
        //        }


        //        MenuHijo.Font = new Font(MenuHijo.Font, FontStyle.Regular);

        //        MenuHijo.Click += new EventHandler(Event);

        //        if (MenuPadre == null)
        //        {
        //            Menu.Items.Add(MenuHijo);
        //        }
        //        else
        //        {
        //            MenuPadre.DropDownItems.Add(MenuHijo);
        //        }

        //        cargaMenu(int.Parse(fila["idmodulo"].ToString()), MenuHijo, Menu);
        //    }
        //}


    

        public void CrearMenu()
        {
            Perfil objPer = new Perfil();
            DataTable dt = objPer.ReportePerfilesModulos("RECH", "%", LoginInfo.IdTrab, "CS", 0, 0, 0, 0, 0, 14);
            DataTable dtEncabezados = Utilerias.CrearEncabezados(dt);
            Utilerias.ProcesoMenu(dtEncabezados, LoginInfo.IdTrab, "RECH", null, MsMenu,paneltitulo.BackColor);
        }



     
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
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
            toolTip1.SetToolTip(this.button3, "Cerrar Sistema");
            toolTip1.SetToolTip(this.button2, "Minimizar Sistema");
            toolTip1.SetToolTip(this.button1, "Regresar");
        }

    }
}
