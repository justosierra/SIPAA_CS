﻿namespace SIPAA_CS.Accesos.Reportes
{
    partial class FiltroProcesos
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label label7;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FiltroProcesos));
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label9;
            this.panelTag = new System.Windows.Forms.Panel();
            this.lbMensaje = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnImprimirResumen = new System.Windows.Forms.Button();
            this.btnImprimirDetalle = new System.Windows.Forms.Button();
            this.pnlBusqueda = new System.Windows.Forms.Panel();
            this.cbEstatus = new System.Windows.Forms.ComboBox();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblusuario = new System.Windows.Forms.Label();
            this.ptbimgusuario = new System.Windows.Forms.PictureBox();
            label7 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            this.panelTag.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbimgusuario)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label7.ForeColor = System.Drawing.Color.Gray;
            label7.Image = ((System.Drawing.Image)(resources.GetObject("label7.Image")));
            label7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            label7.Location = new System.Drawing.Point(70, 171);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(157, 17);
            label7.TabIndex = 66;
            label7.Text = "       Imprimir Resumen";
            label7.Visible = false;
            label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.ForeColor = System.Drawing.Color.Gray;
            label4.Image = ((System.Drawing.Image)(resources.GetObject("label4.Image")));
            label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            label4.Location = new System.Drawing.Point(70, 49);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(138, 17);
            label4.TabIndex = 65;
            label4.Text = "       Imprimir Detalle";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(87)))), ((int)(((byte)(155)))));
            label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            label6.Location = new System.Drawing.Point(39, 46);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(83, 16);
            label6.TabIndex = 58;
            label6.Text = "Estatus Proceso";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label9.ForeColor = System.Drawing.Color.Gray;
            label9.Image = ((System.Drawing.Image)(resources.GetObject("label9.Image")));
            label9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            label9.Location = new System.Drawing.Point(5, 0);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(150, 17);
            label9.TabIndex = 41;
            label9.Text = "       Buscar Procesos";
            // 
            // panelTag
            // 
            this.panelTag.BackColor = System.Drawing.Color.Transparent;
            this.panelTag.Controls.Add(this.lbMensaje);
            this.panelTag.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelTag.Location = new System.Drawing.Point(574, 465);
            this.panelTag.Name = "panelTag";
            this.panelTag.Size = new System.Drawing.Size(399, 30);
            this.panelTag.TabIndex = 153;
            this.panelTag.Visible = false;
            // 
            // lbMensaje
            // 
            this.lbMensaje.AutoSize = true;
            this.lbMensaje.BackColor = System.Drawing.Color.Transparent;
            this.lbMensaje.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMensaje.ForeColor = System.Drawing.Color.White;
            this.lbMensaje.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbMensaje.Location = new System.Drawing.Point(5, 5);
            this.lbMensaje.Name = "lbMensaje";
            this.lbMensaje.Size = new System.Drawing.Size(209, 20);
            this.lbMensaje.TabIndex = 26;
            this.lbMensaje.Text = "       Administración de Perfiles    ";
            this.lbMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(211)))), ((int)(((byte)(213)))));
            this.panel1.Controls.Add(label7);
            this.panel1.Controls.Add(label4);
            this.panel1.Controls.Add(this.btnImprimirResumen);
            this.panel1.Controls.Add(this.btnImprimirDetalle);
            this.panel1.Location = new System.Drawing.Point(574, 175);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(399, 252);
            this.panel1.TabIndex = 152;
            // 
            // btnImprimirResumen
            // 
            this.btnImprimirResumen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(211)))), ((int)(((byte)(213)))));
            this.btnImprimirResumen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimirResumen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(211)))), ((int)(((byte)(213)))));
            this.btnImprimirResumen.Image = global::SIPAA_CS.Properties.Resources.Imprimir;
            this.btnImprimirResumen.Location = new System.Drawing.Point(281, 155);
            this.btnImprimirResumen.Name = "btnImprimirResumen";
            this.btnImprimirResumen.Size = new System.Drawing.Size(50, 50);
            this.btnImprimirResumen.TabIndex = 3;
            this.btnImprimirResumen.Tag = "Buscar";
            this.btnImprimirResumen.UseVisualStyleBackColor = false;
            this.btnImprimirResumen.Visible = false;
            this.btnImprimirResumen.Click += new System.EventHandler(this.btnImprimirResumen_Click);
            // 
            // btnImprimirDetalle
            // 
            this.btnImprimirDetalle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(211)))), ((int)(((byte)(213)))));
            this.btnImprimirDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimirDetalle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(211)))), ((int)(((byte)(213)))));
            this.btnImprimirDetalle.Image = global::SIPAA_CS.Properties.Resources.Imprimir;
            this.btnImprimirDetalle.Location = new System.Drawing.Point(281, 32);
            this.btnImprimirDetalle.Name = "btnImprimirDetalle";
            this.btnImprimirDetalle.Size = new System.Drawing.Size(50, 50);
            this.btnImprimirDetalle.TabIndex = 2;
            this.btnImprimirDetalle.Tag = "Buscar";
            this.btnImprimirDetalle.UseVisualStyleBackColor = false;
            this.btnImprimirDetalle.Click += new System.EventHandler(this.btnImprimirDetalle_Click);
            // 
            // pnlBusqueda
            // 
            this.pnlBusqueda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(211)))), ((int)(((byte)(213)))));
            this.pnlBusqueda.Controls.Add(label6);
            this.pnlBusqueda.Controls.Add(this.cbEstatus);
            this.pnlBusqueda.Controls.Add(label9);
            this.pnlBusqueda.Location = new System.Drawing.Point(18, 175);
            this.pnlBusqueda.Name = "pnlBusqueda";
            this.pnlBusqueda.Size = new System.Drawing.Size(477, 252);
            this.pnlBusqueda.TabIndex = 151;
            this.pnlBusqueda.TabStop = true;
            // 
            // cbEstatus
            // 
            this.cbEstatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbEstatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbEstatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(211)))), ((int)(((byte)(213)))));
            this.cbEstatus.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEstatus.FormattingEnabled = true;
            this.cbEstatus.Items.AddRange(new object[] {
            "Seleccionar un Proceso",
            "Activos",
            "Inactivos",
            "Todos"});
            this.cbEstatus.Location = new System.Drawing.Point(42, 66);
            this.cbEstatus.Name = "cbEstatus";
            this.cbEstatus.Size = new System.Drawing.Size(291, 25);
            this.cbEstatus.TabIndex = 57;
            this.cbEstatus.Text = "Seleccionar un Proceso";
            // 
            // btnRegresar
            // 
            this.btnRegresar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(87)))), ((int)(((byte)(155)))));
            this.btnRegresar.BackgroundImage = global::SIPAA_CS.Properties.Resources.ic_reply_white_18dp;
            this.btnRegresar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRegresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegresar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(87)))), ((int)(((byte)(155)))));
            this.btnRegresar.Location = new System.Drawing.Point(917, 0);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(30, 25);
            this.btnRegresar.TabIndex = 150;
            this.btnRegresar.UseVisualStyleBackColor = false;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(87)))), ((int)(((byte)(155)))));
            this.btnMinimizar.BackgroundImage = global::SIPAA_CS.Properties.Resources.ic_remove_white_18dp;
            this.btnMinimizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimizar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(87)))), ((int)(((byte)(155)))));
            this.btnMinimizar.Location = new System.Drawing.Point(975, 1);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(24, 24);
            this.btnMinimizar.TabIndex = 149;
            this.btnMinimizar.TabStop = false;
            this.btnMinimizar.UseVisualStyleBackColor = false;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btnCerrar.BackgroundImage = global::SIPAA_CS.Properties.Resources.ic_clear_white_18dp;
            this.btnCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btnCerrar.Location = new System.Drawing.Point(1000, 1);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(24, 24);
            this.btnCerrar.TabIndex = 148;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Image = global::SIPAA_CS.Properties.Resources.ic_assignment_white_24dp;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(440, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 23);
            this.label3.TabIndex = 147;
            this.label3.Text = "       Reporte Procesos";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblusuario
            // 
            this.lblusuario.AutoSize = true;
            this.lblusuario.BackColor = System.Drawing.Color.Transparent;
            this.lblusuario.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblusuario.ForeColor = System.Drawing.Color.White;
            this.lblusuario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblusuario.Location = new System.Drawing.Point(15, 75);
            this.lblusuario.Name = "lblusuario";
            this.lblusuario.Size = new System.Drawing.Size(52, 20);
            this.lblusuario.TabIndex = 181;
            this.lblusuario.Text = "usuario";
            this.lblusuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ptbimgusuario
            // 
            this.ptbimgusuario.Image = ((System.Drawing.Image)(resources.GetObject("ptbimgusuario.Image")));
            this.ptbimgusuario.InitialImage = ((System.Drawing.Image)(resources.GetObject("ptbimgusuario.InitialImage")));
            this.ptbimgusuario.Location = new System.Drawing.Point(19, 30);
            this.ptbimgusuario.Name = "ptbimgusuario";
            this.ptbimgusuario.Size = new System.Drawing.Size(43, 41);
            this.ptbimgusuario.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbimgusuario.TabIndex = 183;
            this.ptbimgusuario.TabStop = false;
            // 
            // FiltroProcesos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SIPAA_CS.Properties.Resources.f8;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.ptbimgusuario);
            this.Controls.Add(this.lblusuario);
            this.Controls.Add(this.panelTag);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlBusqueda);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.btnMinimizar);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FiltroProcesos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Procesos";
            this.Load += new System.EventHandler(this.FiltroProcesos_Load);
            this.panelTag.ResumeLayout(false);
            this.panelTag.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlBusqueda.ResumeLayout(false);
            this.pnlBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbimgusuario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelTag;
        private System.Windows.Forms.Label lbMensaje;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnImprimirResumen;
        private System.Windows.Forms.Button btnImprimirDetalle;
        private System.Windows.Forms.Panel pnlBusqueda;
        private System.Windows.Forms.ComboBox cbEstatus;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.Button btnMinimizar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblusuario;
        private System.Windows.Forms.PictureBox ptbimgusuario;
    }
}