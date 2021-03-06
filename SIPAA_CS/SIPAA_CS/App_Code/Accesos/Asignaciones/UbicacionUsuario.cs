﻿using SIPAA_CS.Conexiones;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIPAA_CS.App_Code.Accesos.Asignaciones
{
    class UbicacionUsuario
    {

        public UbicacionUsuario()
        {

        }
        //VALIDA PERMISO HUBICACION DE UN USUARIO
        public List<string> ObtenerUbicacionesxUsuario(string cvusuario, string ubicacion, string usuumod, string prgumod, int opcion)
        {

            List<string> ltUbicacionesxUsuario = new List<string>();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "usp_accetusuubi_suid";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@p_cvusuario", SqlDbType.VarChar).Value = cvusuario;
            cmd.Parameters.Add("@p_idubicacion", SqlDbType.VarChar).Value = ubicacion;
            cmd.Parameters.Add("@p_usuumod", SqlDbType.VarChar).Value = usuumod;
            cmd.Parameters.Add("@p_prgumod", SqlDbType.VarChar).Value = prgumod;
            cmd.Parameters.Add("@p_opcion", SqlDbType.Int).Value = opcion;

            Conexion objConexion = new Conexion();
            objConexion.asignarConexion(cmd);

            SqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {

                int idubicacion = reader.GetInt32(reader.GetOrdinal("idubicacion"));
                string idu = Convert.ToString(idubicacion);
                ltUbicacionesxUsuario.Add(idu);

                //MUESTRA LAS UBICACIONES ASIGNADAS A UN USUARIO
                Console.WriteLine(idubicacion);


            }

            objConexion.cerrarConexion();

            return ltUbicacionesxUsuario;

        }
        public DataTable ReporteUbicacionUsuarios(string cvusuario,string idubicacion, string usuumod, string prgumod, int opcion)
        {

            Conexion objConexion = new Conexion();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"usp_accetusuubi_suid";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@p_cvusuario", SqlDbType.VarChar).Value = cvusuario;
            cmd.Parameters.Add("@p_idubicacion", SqlDbType.VarChar).Value = idubicacion;
            cmd.Parameters.Add("@p_usuumod", SqlDbType.VarChar).Value = usuumod;
            cmd.Parameters.Add("@p_prgumod", SqlDbType.VarChar).Value = prgumod;
            cmd.Parameters.Add("@p_opcion", SqlDbType.Int).Value = opcion;

            objConexion.asignarConexion(cmd);
            SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
            objConexion.cerrarConexion();

            DataTable dtCompanias = new DataTable();
            Adapter.Fill(dtCompanias);

            return dtCompanias;
        }

    }

}
