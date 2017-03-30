﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIPAA_CS.Conexiones;
using System.Data;
using System.Data.SqlClient;

namespace SIPAA_CS.App_Code
{
    class Incidencia
    {
        //SE DECLARAN VARIABLES
        public int CVIncidencia;
        public string Descripcion;
        public int CVRepresenta;
        public string Representa;
        public string UsuuMod;
        public string Estatus;
        public DateTime FhuMod;
        public string PrguMod;
        public int CVTipo;
        public string TipoIncidencia;


        public DataTable ObtenerRepresentaxIncidencia(Incidencia objIncidencia,int Opcion) {

            Conexion objConexion = new Conexion();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"usp_rechincapacidadrepresenta_SUID";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("P_incidencia", SqlDbType.VarChar).Value = objIncidencia.Descripcion;
            cmd.Parameters.Add("P_representa", SqlDbType.VarChar).Value = objIncidencia.Representa;
            cmd.Parameters.Add("cvrepresenta", SqlDbType.Int).Value = objIncidencia.CVRepresenta;
            cmd.Parameters.Add("Opcion", SqlDbType.VarChar).Value = Opcion;
            cmd.Parameters.Add("usuumod", SqlDbType.VarChar).Value = objIncidencia.UsuuMod;
            cmd.Parameters.Add("prgumod", SqlDbType.VarChar).Value = objIncidencia.PrguMod;

            objConexion.asignarConexion(cmd);
            SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
            objConexion.cerrarConexion();

            DataTable dtIncidencia = new DataTable();
            Adapter.Fill(dtIncidencia);

            return dtIncidencia;
        }


        public DataTable ObtenerIncidenciaxTipo(Incidencia objIncidencia, int Opcion)
        {

            Conexion objConexion = new Conexion();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"usp_rechtipoincidencia_suid";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("P_cvincidencia", SqlDbType.Int).Value = objIncidencia.CVIncidencia;
            cmd.Parameters.Add("P_incidencia", SqlDbType.VarChar).Value = objIncidencia.Descripcion;
            cmd.Parameters.Add("P_cvtipo", SqlDbType.Int).Value = objIncidencia.CVTipo;
            cmd.Parameters.Add("P_tipo", SqlDbType.VarChar).Value = objIncidencia.TipoIncidencia;
            cmd.Parameters.Add("P_estatus", SqlDbType.VarChar).Value = objIncidencia.Estatus;
            cmd.Parameters.Add("P_Opcion", SqlDbType.Int).Value = Opcion;
            cmd.Parameters.Add("usuumod", SqlDbType.VarChar).Value = objIncidencia.UsuuMod;
            cmd.Parameters.Add("prgumod", SqlDbType.VarChar).Value = objIncidencia.PrguMod;

            objConexion.asignarConexion(cmd);
            SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
            objConexion.cerrarConexion();

            DataTable dtIncidencia = new DataTable();
            Adapter.Fill(dtIncidencia);

            return dtIncidencia;
        }


        public DataTable ReporteRegistroGeneradoDetalle(string sIdTrab,DateTime dtFechaInicio
                                                        ,DateTime dtFechaFin,string sUbicacion
                                                        ,string sCompania)
        {

            Conexion objConexion = new Conexion();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"usp_rechregistrogeneradodetalle_s";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("P_idtrab", SqlDbType.VarChar).Value = sIdTrab;
            cmd.Parameters.Add("P_fechainicio", SqlDbType.DateTime).Value = dtFechaInicio;
             cmd.Parameters.Add("P_fechafin", SqlDbType.DateTime).Value = dtFechaFin;
             cmd.Parameters.Add("P_Ubicacion", SqlDbType.VarChar).Value = sUbicacion ;
             cmd.Parameters.Add("P_Compania", SqlDbType.VarChar).Value = sCompania;


            objConexion.asignarConexion(cmd);
            SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
            objConexion.cerrarConexion();

            DataTable dtIncidencia = new DataTable();
            Adapter.Fill(dtIncidencia);

            return dtIncidencia;
        }

    }
}
