﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SIPAA_CS.Conexiones;
using System.Data;
using System.Data.SqlClient;

//***********************************************************************************************
//Autor: Jaime Avendaño Vargas
//Fecha creación: 30-Mar-2017       Última Modificacion: dd-mm-aaaa
//Descripción: Administra Días Festivos
//***********************************************************************************************

namespace SIPAA_CS.App_Code
{
   public class RelojChecador
    {
        //variables
        public int    p_opcion;
        public int    p_cvreloj;
        public string p_descripcion;
        public string p_ip;
        public string p_cvvnc;
        public int    p_stactualiza;
        public string p_usuumod;
        public string p_prgumodr;
        public int    p_respuesta;

        public RelojChecador()
        {
            //inician variables
            p_opcion      = 0;
            p_cvreloj     = 0;
            p_descripcion = "";
            p_ip          = "";
            p_cvvnc       = "";
            p_stactualiza = 0;
            p_usuumod     = "";
            p_prgumodr    = "";
            p_respuesta   = 0;

        } // public RelojChecador()

        //metodo data table para llenar grid de busqueda
        public DataTable obtrelojeschecadores(int p_opcion, int p_cvreloj, string p_descripcion, string p_ip, string p_cvvnc, int p_stactualiza, string p_usuumod, string p_prgumodr, string p_ususincchecadas ,string p_ususincusuario)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"usp_rechcreloj_suid";
            cmd.CommandType = CommandType.StoredProcedure;
            Conexion objConexion = new Conexion();
            objConexion.asignarConexion(cmd);

            cmd.Parameters.Add("@p_opcion", SqlDbType.Int).Value = p_opcion;
            cmd.Parameters.Add("@p_cvreloj", SqlDbType.VarChar).Value = p_cvreloj;
            cmd.Parameters.Add("@p_descripcion", SqlDbType.VarChar).Value = p_descripcion;
            cmd.Parameters.Add("@p_ip", SqlDbType.VarChar).Value = p_ip;
            cmd.Parameters.Add("@p_cvvnc", SqlDbType.VarChar).Value = p_cvvnc;
            cmd.Parameters.Add("@p_stactualiza", SqlDbType.Int).Value = p_stactualiza;
            cmd.Parameters.Add("@p_usuumod", SqlDbType.VarChar).Value = p_usuumod;
            cmd.Parameters.Add("@p_prgumod", SqlDbType.VarChar).Value = p_prgumodr;
            cmd.Parameters.Add("@p_ususincchecadas", SqlDbType.VarChar ).Value = p_ususincchecadas;
            cmd.Parameters.Add("@p_ususincusuario",SqlDbType.VarChar ).Value = p_ususincusuario;

            objConexion.asignarConexion(cmd);

            SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

            objConexion.cerrarConexion();

            DataTable dtrelojeschecadores = new DataTable();
            Adapter.Fill(dtrelojeschecadores);
            return dtrelojeschecadores;
        } // public DataTable obtrelojeschecadores(int p_opcion, int p_cvreloj, string p_descripcion, string p_usuumod, string p_prgumodr)

        //metodo insertar, actualizar, eliminar registro, listar x descripción, listar x fecha
        public int udirelojeschecadores(int p_opcion, int p_cvreloj, string p_descripcion, string p_ip, string p_cvvnc, int p_stactualiza, string p_usuumod, string p_prgumodr, bool teclado, bool huella, bool mhuella, bool rostro)
        {
            int p_respuesta = 0;
            int p_respuestaValidacion = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"usp_rechcreloj_suid";
            cmd.CommandType = CommandType.StoredProcedure;
            Conexion objConexion = new Conexion();
            objConexion.asignarConexion(cmd);
            //
            // Valida que no exista el registro (Valida Llave duplicada - Fecha)
            if (p_opcion == 1)
            {
                cmd.Parameters.Add("@p_opcion", SqlDbType.Int).Value = 5; // búsqueda de registro por fecha
                cmd.Parameters.Add("@p_cvreloj", SqlDbType.VarChar).Value = p_cvreloj;
                cmd.Parameters.Add("@p_descripcion", SqlDbType.VarChar).Value = p_descripcion;
                cmd.Parameters.Add("@p_ip", SqlDbType.VarChar).Value = p_ip;
                cmd.Parameters.Add("@p_cvvnc", SqlDbType.VarChar).Value = p_cvvnc;
                cmd.Parameters.Add("@p_stactualiza", SqlDbType.Int).Value = p_stactualiza;
                cmd.Parameters.Add("@p_usuumod", SqlDbType.VarChar).Value = p_usuumod;
                cmd.Parameters.Add("@p_prgumod", SqlDbType.VarChar).Value = p_prgumodr;
                /***
                 * parametros adicionales para el control de sincronizaciones, funcional en proceso reloj checador
                 * */
                cmd.Parameters.Add("@p_ususincusuario", SqlDbType.VarChar).Value = string.Empty;
                cmd.Parameters.Add("@p_ususincchecadas", SqlDbType.VarChar).Value = string.Empty;

                cmd.Parameters.Add("@p_teclado", SqlDbType.Bit).Value = teclado;
                cmd.Parameters.Add("@p_huella", SqlDbType.Bit).Value = huella;
                cmd.Parameters.Add("@p_multiplehuella", SqlDbType.Bit).Value = mhuella;
                cmd.Parameters.Add("@p_rostro", SqlDbType.Bit).Value = rostro;

                objConexion.asignarConexion(cmd);
                //
                p_respuesta = Convert.ToInt32(cmd.ExecuteScalar());
                p_respuesta = 0;
                if (p_respuesta>0)
                {
                    p_respuestaValidacion = 99; // Intento de duplicar un registro
                }
                //
                //objConexion.cerrarConexion();
            }
            if(p_respuesta==0)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@p_opcion", SqlDbType.Int).Value = p_opcion;
                cmd.Parameters.Add("@p_cvreloj", SqlDbType.VarChar).Value = p_cvreloj;
                cmd.Parameters.Add("@p_descripcion", SqlDbType.VarChar).Value = p_descripcion;
                cmd.Parameters.Add("@p_ip", SqlDbType.VarChar).Value = p_ip;
                cmd.Parameters.Add("@p_cvvnc", SqlDbType.VarChar).Value = p_cvvnc;
                cmd.Parameters.Add("@p_stactualiza", SqlDbType.Int).Value = p_stactualiza;
                cmd.Parameters.Add("@p_usuumod", SqlDbType.VarChar).Value = p_usuumod;
                cmd.Parameters.Add("@p_prgumod", SqlDbType.VarChar).Value = p_prgumodr;
                /***
                 * parametros adicionales para el control de sincronizaciones, funcional en proceso reloj checador
                 * */
                cmd.Parameters.Add("@p_ususincusuario", SqlDbType.VarChar).Value = string.Empty;
                cmd.Parameters.Add("@p_ususincchecadas", SqlDbType.VarChar).Value = string.Empty;

                cmd.Parameters.Add("@p_teclado", SqlDbType.Bit).Value = teclado;
                cmd.Parameters.Add("@p_huella", SqlDbType.Bit).Value = huella;
                cmd.Parameters.Add("@p_multiplehuella", SqlDbType.Bit).Value = mhuella;
                cmd.Parameters.Add("@p_rostro", SqlDbType.Bit).Value = rostro;

                objConexion.asignarConexion(cmd);
                //
                p_respuesta = Convert.ToInt32(cmd.ExecuteScalar());
                //
                objConexion.cerrarConexion();
            }
            if(p_respuestaValidacion == 99)
            {
                p_respuesta = p_respuestaValidacion;
            }
            //
            objConexion.cerrarConexion();
            //
            return p_respuesta;
        } // public int uditipohr(int p_opcion, int p_cvreloj, string p_descripcion, string p_usuumod, string p_prgumodr)


        public DataTable RelojesxTrabajador(string sIdTrab, int iCVReloj, int iOpcion, string sUsuumod, string sPrgmod)
        {
          
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"usp_rechtrabreloj_suid";
            cmd.CommandType = CommandType.StoredProcedure;
            Conexion objConexion = new Conexion();
            objConexion.asignarConexion(cmd);

            cmd.Parameters.Add("@p_opcion", SqlDbType.Int).Value = iOpcion;
            cmd.Parameters.Add("@p_cvreloj", SqlDbType.Int).Value = iCVReloj;
            cmd.Parameters.Add("@p_usuumod", SqlDbType.VarChar).Value = sUsuumod;
            cmd.Parameters.Add("@p_prgumod", SqlDbType.VarChar).Value = sPrgmod;
            cmd.Parameters.Add("@p_idtrab", SqlDbType.VarChar).Value = sIdTrab;


            objConexion.asignarConexion(cmd);
            SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
            objConexion.cerrarConexion();

            DataTable dtForReg = new DataTable();
            Adapter.Fill(dtForReg);
            return dtForReg;

        }


        public DataTable CambiaAsociacion(string sIdTrab_Nuevo, string IdTrab_Anterior, int iCVReloj, int iOpcion, DateTime FechaInicio, DateTime FechaFin,  string sUsuumod, string sPrgmod)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"usp_rechtrabreloj_suid";
            cmd.CommandType = CommandType.StoredProcedure;
            Conexion objConexion = new Conexion();
            objConexion.asignarConexion(cmd);

            cmd.Parameters.Add("@p_idtrab", SqlDbType.VarChar).Value = sIdTrab_Nuevo;
            cmd.Parameters.Add("@p_cvreloj", SqlDbType.Int).Value = iCVReloj;
            cmd.Parameters.Add("@p_usuumod", SqlDbType.VarChar).Value = sUsuumod;
            cmd.Parameters.Add("@p_prgumod", SqlDbType.VarChar).Value = sPrgmod;
            cmd.Parameters.Add("@p_opcion", SqlDbType.Int).Value = iOpcion;
            cmd.Parameters.Add("@p_idtrab_anterior", SqlDbType.Int).Value = IdTrab_Anterior;
            cmd.Parameters.Add("@P_FechaInicio", SqlDbType.Date).Value =FechaInicio ;
            cmd.Parameters.Add("@P_FechaFin", SqlDbType.Date).Value =FechaFin;




            objConexion.asignarConexion(cmd);
            SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
            objConexion.cerrarConexion();

            DataTable dtForReg = new DataTable();
            Adapter.Fill(dtForReg);
            return dtForReg;

        }





    } // class DiasFestivos
} // namespace SIPAA_CS.Recursos_Humanos.App_Code
