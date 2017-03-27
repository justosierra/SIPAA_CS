﻿namespace SIPAA_CS.RecursosHumanos
{
    partial class RechDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RechDashboard));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.MenuAccesos = new System.Windows.Forms.MenuStrip();
            this.msCatalogo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCompanias = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDepartamentos = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUbicacion = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPuestos = new System.Windows.Forms.ToolStripMenuItem();
            this.empleadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formasDeRegistroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.incapacidadRepresentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mensajesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.areasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.incidenciasNominaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diasFestivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mensajesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tipoHorarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tipoIncidenciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asignacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAsignacionCompania = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAsignacionArea = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panelMenu.SuspendLayout();
            this.MenuAccesos.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(62)))), ((int)(((byte)(120)))));
            this.panelMenu.Controls.Add(this.panel3);
            this.panelMenu.Controls.Add(this.MenuAccesos);
            this.panelMenu.Location = new System.Drawing.Point(0, 97);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(1024, 32);
            this.panelMenu.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.panel3.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.panel3.Location = new System.Drawing.Point(0, 31);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1024, 1);
            this.panel3.TabIndex = 26;
            // 
            // MenuAccesos
            // 
            this.MenuAccesos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(62)))), ((int)(((byte)(120)))));
            this.MenuAccesos.Dock = System.Windows.Forms.DockStyle.None;
            this.MenuAccesos.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuAccesos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msCatalogo,
            this.asignacionesToolStripMenuItem});
            this.MenuAccesos.Location = new System.Drawing.Point(27, 3);
            this.MenuAccesos.Name = "MenuAccesos";
            this.MenuAccesos.Size = new System.Drawing.Size(339, 26);
            this.MenuAccesos.TabIndex = 5;
            this.MenuAccesos.TabStop = true;
            // 
            // msCatalogo
            // 
            this.msCatalogo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCompanias,
            this.tsmiDepartamentos,
            this.tsmiUbicacion,
            this.tsmiPuestos,
            this.empleadosToolStripMenuItem,
            this.formasDeRegistroToolStripMenuItem,
            this.incapacidadRepresentaToolStripMenuItem,
            this.mensajesToolStripMenuItem,
            this.areasToolStripMenuItem,
            this.incidenciasNominaToolStripMenuItem,
            this.diasFestivoToolStripMenuItem,
            this.mensajesToolStripMenuItem1,
            this.tipoHorarioToolStripMenuItem,
            this.tipoIncidenciaToolStripMenuItem});
            this.msCatalogo.ForeColor = System.Drawing.Color.White;
            this.msCatalogo.Image = global::SIPAA_CS.Properties.Resources.ic_view_list_white_18dp;
            this.msCatalogo.Name = "msCatalogo";
            this.msCatalogo.Size = new System.Drawing.Size(108, 22);
            this.msCatalogo.Tag = "frmCatalogos";
            this.msCatalogo.Text = "Catalogos";
            // 
            // tsmiCompanias
            // 
            this.tsmiCompanias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(62)))), ((int)(((byte)(120)))));
            this.tsmiCompanias.ForeColor = System.Drawing.Color.White;
            this.tsmiCompanias.Image = ((System.Drawing.Image)(resources.GetObject("tsmiCompanias.Image")));
            this.tsmiCompanias.Name = "tsmiCompanias";
            this.tsmiCompanias.Size = new System.Drawing.Size(246, 22);
            this.tsmiCompanias.Tag = "frmCompania";
            this.tsmiCompanias.Text = "Compañias";
            this.tsmiCompanias.Click += new System.EventHandler(this.tsmiCompanias_Click);
            // 
            // tsmiDepartamentos
            // 
            this.tsmiDepartamentos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(62)))), ((int)(((byte)(120)))));
            this.tsmiDepartamentos.ForeColor = System.Drawing.Color.White;
            this.tsmiDepartamentos.Image = ((System.Drawing.Image)(resources.GetObject("tsmiDepartamentos.Image")));
            this.tsmiDepartamentos.Name = "tsmiDepartamentos";
            this.tsmiDepartamentos.Size = new System.Drawing.Size(246, 22);
            this.tsmiDepartamentos.Tag = "frmDepartamentos";
            this.tsmiDepartamentos.Text = "Departamentos";
            this.tsmiDepartamentos.Click += new System.EventHandler(this.tsmiDepartamentos_Click);
            // 
            // tsmiUbicacion
            // 
            this.tsmiUbicacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(62)))), ((int)(((byte)(120)))));
            this.tsmiUbicacion.ForeColor = System.Drawing.Color.White;
            this.tsmiUbicacion.Image = ((System.Drawing.Image)(resources.GetObject("tsmiUbicacion.Image")));
            this.tsmiUbicacion.Name = "tsmiUbicacion";
            this.tsmiUbicacion.Size = new System.Drawing.Size(246, 22);
            this.tsmiUbicacion.Tag = "frmUbicacion";
            this.tsmiUbicacion.Text = "Ubicación";
            this.tsmiUbicacion.Click += new System.EventHandler(this.tsmiUbicacion_Click);
            // 
            // tsmiPuestos
            // 
            this.tsmiPuestos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(62)))), ((int)(((byte)(120)))));
            this.tsmiPuestos.ForeColor = System.Drawing.Color.White;
            this.tsmiPuestos.Image = ((System.Drawing.Image)(resources.GetObject("tsmiPuestos.Image")));
            this.tsmiPuestos.Name = "tsmiPuestos";
            this.tsmiPuestos.Size = new System.Drawing.Size(246, 22);
            this.tsmiPuestos.Tag = "frmPuestos";
            this.tsmiPuestos.Text = "Puestos";
            this.tsmiPuestos.Click += new System.EventHandler(this.tsmiPuestos_Click);
            // 
            // empleadosToolStripMenuItem
            // 
            this.empleadosToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(62)))), ((int)(((byte)(120)))));
            this.empleadosToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.empleadosToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("empleadosToolStripMenuItem.Image")));
            this.empleadosToolStripMenuItem.Name = "empleadosToolStripMenuItem";
            this.empleadosToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.empleadosToolStripMenuItem.Text = "Empleados";
            this.empleadosToolStripMenuItem.Click += new System.EventHandler(this.empleadosToolStripMenuItem_Click);
            // 
            // formasDeRegistroToolStripMenuItem
            // 
            this.formasDeRegistroToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(62)))), ((int)(((byte)(120)))));
            this.formasDeRegistroToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.formasDeRegistroToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("formasDeRegistroToolStripMenuItem.Image")));
            this.formasDeRegistroToolStripMenuItem.Name = "formasDeRegistroToolStripMenuItem";
            this.formasDeRegistroToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.formasDeRegistroToolStripMenuItem.Text = "Formas de Registro";
            this.formasDeRegistroToolStripMenuItem.Click += new System.EventHandler(this.formasDeRegistroToolStripMenuItem_Click);
            // 
            // incapacidadRepresentaToolStripMenuItem
            // 
            this.incapacidadRepresentaToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(62)))), ((int)(((byte)(120)))));
            this.incapacidadRepresentaToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.incapacidadRepresentaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("incapacidadRepresentaToolStripMenuItem.Image")));
            this.incapacidadRepresentaToolStripMenuItem.Name = "incapacidadRepresentaToolStripMenuItem";
            this.incapacidadRepresentaToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.incapacidadRepresentaToolStripMenuItem.Tag = "frmIncapacidad_Representa";
            this.incapacidadRepresentaToolStripMenuItem.Text = "Incapacidad Representa";
            this.incapacidadRepresentaToolStripMenuItem.Click += new System.EventHandler(this.incapacidadRepresentaToolStripMenuItem_Click);
            // 
            // mensajesToolStripMenuItem
            // 
            this.mensajesToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(62)))), ((int)(((byte)(120)))));
            this.mensajesToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.mensajesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("mensajesToolStripMenuItem.Image")));
            this.mensajesToolStripMenuItem.Name = "mensajesToolStripMenuItem";
            this.mensajesToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.mensajesToolStripMenuItem.Text = "Mensajes";
            this.mensajesToolStripMenuItem.Click += new System.EventHandler(this.mensajesToolStripMenuItem_Click);
            // 
            // areasToolStripMenuItem
            // 
            this.areasToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(62)))), ((int)(((byte)(120)))));
            this.areasToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.areasToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("areasToolStripMenuItem.Image")));
            this.areasToolStripMenuItem.Name = "areasToolStripMenuItem";
            this.areasToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.areasToolStripMenuItem.Tag = "frmCompania_Plantel";
            this.areasToolStripMenuItem.Text = "Áreas";
            this.areasToolStripMenuItem.Click += new System.EventHandler(this.areasToolStripMenuItem_Click);
            // 
            // incidenciasNominaToolStripMenuItem
            // 
            this.incidenciasNominaToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(62)))), ((int)(((byte)(120)))));
            this.incidenciasNominaToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.incidenciasNominaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("incidenciasNominaToolStripMenuItem.Image")));
            this.incidenciasNominaToolStripMenuItem.Name = "incidenciasNominaToolStripMenuItem";
            this.incidenciasNominaToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.incidenciasNominaToolStripMenuItem.Tag = "frmIncidenciasNom";
            this.incidenciasNominaToolStripMenuItem.Text = "Incidencias Nomina";
            // 
            // diasFestivoToolStripMenuItem
            // 
            this.diasFestivoToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(62)))), ((int)(((byte)(120)))));
            this.diasFestivoToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.diasFestivoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("diasFestivoToolStripMenuItem.Image")));
            this.diasFestivoToolStripMenuItem.Name = "diasFestivoToolStripMenuItem";
            this.diasFestivoToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.diasFestivoToolStripMenuItem.Tag = "frmDiasFestivos";
            this.diasFestivoToolStripMenuItem.Text = "Días Festivos";
            this.diasFestivoToolStripMenuItem.Click += new System.EventHandler(this.diasFestivoToolStripMenuItem_Click);
            // 
            // mensajesToolStripMenuItem1
            // 
            this.mensajesToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(62)))), ((int)(((byte)(120)))));
            this.mensajesToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.mensajesToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("mensajesToolStripMenuItem1.Image")));
            this.mensajesToolStripMenuItem1.Name = "mensajesToolStripMenuItem1";
            this.mensajesToolStripMenuItem1.Size = new System.Drawing.Size(246, 22);
            this.mensajesToolStripMenuItem1.Tag = "frmMensajes";
            this.mensajesToolStripMenuItem1.Text = "Mensajes";
            // 
            // tipoHorarioToolStripMenuItem
            // 
            this.tipoHorarioToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(62)))), ((int)(((byte)(120)))));
            this.tipoHorarioToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.tipoHorarioToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("tipoHorarioToolStripMenuItem.Image")));
            this.tipoHorarioToolStripMenuItem.Name = "tipoHorarioToolStripMenuItem";
            this.tipoHorarioToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.tipoHorarioToolStripMenuItem.Tag = "frmTipoHorario";
            this.tipoHorarioToolStripMenuItem.Text = "Tipo Horario";
            // 
            // tipoIncidenciaToolStripMenuItem
            // 
            this.tipoIncidenciaToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(62)))), ((int)(((byte)(120)))));
            this.tipoIncidenciaToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.tipoIncidenciaToolStripMenuItem.Image = global::SIPAA_CS.Properties.Resources.ic_view_carousel_white_24dp;
            this.tipoIncidenciaToolStripMenuItem.Name = "tipoIncidenciaToolStripMenuItem";
            this.tipoIncidenciaToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.tipoIncidenciaToolStripMenuItem.Tag = "frmIncidenciasTipos";
            this.tipoIncidenciaToolStripMenuItem.Text = "Tipos de Incidencia";
            this.tipoIncidenciaToolStripMenuItem.Click += new System.EventHandler(this.tipoIncidenciaToolStripMenuItem_Click);
            // 
            // asignacionesToolStripMenuItem
            // 
            this.asignacionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAsignacionCompania,
            this.tsmAsignacionArea});
            this.asignacionesToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.asignacionesToolStripMenuItem.Image = global::SIPAA_CS.Properties.Resources.ic_compare_arrows_white_24dp;
            this.asignacionesToolStripMenuItem.Name = "asignacionesToolStripMenuItem";
            this.asignacionesToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.asignacionesToolStripMenuItem.Tag = "frmAsignaciones";
            this.asignacionesToolStripMenuItem.Text = "Asignaciones";
            // 
            // tsmAsignacionCompania
            // 
            this.tsmAsignacionCompania.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(62)))), ((int)(((byte)(120)))));
            this.tsmAsignacionCompania.ForeColor = System.Drawing.Color.White;
            this.tsmAsignacionCompania.Image = global::SIPAA_CS.Properties.Resources.ic_compare_arrows_white_24dp;
            this.tsmAsignacionCompania.Name = "tsmAsignacionCompania";
            this.tsmAsignacionCompania.Size = new System.Drawing.Size(231, 22);
            this.tsmAsignacionCompania.Tag = "frmCompaniasUsuario";
            this.tsmAsignacionCompania.Text = "Asignacion Compañia";
            this.tsmAsignacionCompania.Click += new System.EventHandler(this.tsmAsignacionCompania_Click);
            // 
            // tsmAsignacionArea
            // 
            this.tsmAsignacionArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(62)))), ((int)(((byte)(120)))));
            this.tsmAsignacionArea.ForeColor = System.Drawing.Color.White;
            this.tsmAsignacionArea.Image = global::SIPAA_CS.Properties.Resources.ic_compare_arrows_white_24dp;
            this.tsmAsignacionArea.Name = "tsmAsignacionArea";
            this.tsmAsignacionArea.Size = new System.Drawing.Size(231, 22);
            this.tsmAsignacionArea.Tag = "frmAreasUsuario";
            this.tsmAsignacionArea.Text = "Asignacion Área";
            this.tsmAsignacionArea.Click += new System.EventHandler(this.tsmAsignacionArea_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(87)))), ((int)(((byte)(155)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(87)))), ((int)(((byte)(155)))));
            this.button1.Image = global::SIPAA_CS.Properties.Resources.ic_reply_white_18dp;
            this.button1.Location = new System.Drawing.Point(920, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 24);
            this.button1.TabIndex = 144;
            this.button1.TabStop = false;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(87)))), ((int)(((byte)(155)))));
            this.button2.BackgroundImage = global::SIPAA_CS.Properties.Resources.ic_remove_white_18dp;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(87)))), ((int)(((byte)(155)))));
            this.button2.Location = new System.Drawing.Point(970, 1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(24, 24);
            this.button2.TabIndex = 143;
            this.button2.TabStop = false;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.button3.BackgroundImage = global::SIPAA_CS.Properties.Resources.ic_clear_white_18dp;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.button3.Location = new System.Drawing.Point(995, 1);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(24, 24);
            this.button3.TabIndex = 142;
            this.button3.TabStop = false;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Image = global::SIPAA_CS.Properties.Resources.ic_keyboard_arrow_right_white_18dp;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(413, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(249, 23);
            this.label3.TabIndex = 145;
            this.label3.Text = "       Recursos Humanos                  ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RechDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SIPAA_CS.Properties.Resources.f8;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.panelMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RechDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RechDashboard";
            this.Load += new System.EventHandler(this.RechDashboard_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.MenuAccesos.ResumeLayout(false);
            this.MenuAccesos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.MenuStrip MenuAccesos;
        private System.Windows.Forms.ToolStripMenuItem msCatalogo;
        private System.Windows.Forms.ToolStripMenuItem tsmiCompanias;
        private System.Windows.Forms.ToolStripMenuItem tsmiDepartamentos;
        private System.Windows.Forms.ToolStripMenuItem tsmiUbicacion;
        private System.Windows.Forms.ToolStripMenuItem tsmiPuestos;
        private System.Windows.Forms.ToolStripMenuItem empleadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formasDeRegistroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem incapacidadRepresentaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mensajesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem areasToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolStripMenuItem incidenciasNominaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diasFestivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mensajesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tipoHorarioToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem tipoIncidenciaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asignacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmAsignacionCompania;
        private System.Windows.Forms.ToolStripMenuItem tsmAsignacionArea;
    }
}