﻿using SIPAA_CS.Conexiones;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIPAA_CS.App_Code
{
    class Modulo
    {
        public int idModulo;
        public string CVModulo;
        public string Descripcion;
        public string cvindModulo;
        public int steli;
        public int stcre;
        public int stact;
        public int stimp;
        public int stlec;
        public int Orden;
        public string Ambiente;
        public string strModulo;
        public string UsuuMod;
        public DateTime FhuMod;
        public string PrguMod;
        public int Estatus;
        

        public DataTable ObtenerListModulos(string CVModulo,string Descripcion,string Ambiente,string Modulo,string Estatus)
        {

            List<Modulo> ltModulos = new List<Modulo>();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"usp_accemodulo_S";
            cmd.CommandType = CommandType.StoredProcedure;
            Conexion objConexion = new Conexion();
            cmd.Parameters.Add("CVModulo",SqlDbType.VarChar).Value = CVModulo;
            cmd.Parameters.Add("Descripcion", SqlDbType.VarChar).Value = Descripcion;
            cmd.Parameters.Add("Ambiente", SqlDbType.VarChar).Value = Ambiente;
            cmd.Parameters.Add("Modulo", SqlDbType.VarChar).Value = Modulo;
            cmd.Parameters.Add("Estatus", SqlDbType.VarChar).Value = Estatus;

            objConexion.asignarConexion(cmd);
            SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
            objConexion.cerrarConexion();

            DataTable dt = new DataTable();
            Adapter.Fill(dt);

            return dt;

        }


        public Modulo ObtenerPermisosxModulo(string CVModulo,int CVPerfil)
        { 
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"usp_rechpermisos_s";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("cv", SqlDbType.VarChar).Value = CVPerfil.ToString();
            cmd.Parameters.Add("CVModulo", SqlDbType.VarChar).Value = CVModulo;
            cmd.Parameters.Add("Opcion", SqlDbType.VarChar).Value = 2;

            Conexion objConexion = new Conexion();
            objConexion.asignarConexion(cmd);

            SqlDataReader reader = cmd.ExecuteReader();
            Modulo objModulo = new Modulo();

            while (reader.Read())
            {

                
                objModulo.CVModulo = reader.GetString(reader.GetOrdinal("CVMODULO"));
                objModulo.steli = reader.GetInt32(reader.GetOrdinal("steli"));
                objModulo.stact = reader.GetInt32(reader.GetOrdinal("stact"));
                objModulo.stlec = reader.GetInt32(reader.GetOrdinal("stlec"));
                objModulo.stcre = reader.GetInt32(reader.GetOrdinal("stcre"));
                objModulo.stimp = reader.GetInt32(reader.GetOrdinal("stimp"));
            }

            objConexion.cerrarConexion();

            return objModulo;

        }

        public DataTable ObtenerDataTableModulo(List<Modulo> ltModulos)
        {


            DataTable dtModulos = new DataTable();
            dtModulos.Columns.Add("IdModulo");
            dtModulos.Columns.Add("CVModulo");
            dtModulos.Columns.Add("Descripción");
            dtModulos.Columns.Add("Orden");
            dtModulos.Columns.Add("Ambiente");
            dtModulos.Columns.Add("Módulo");
            dtModulos.Columns.Add("Estatus");




            for (int iContador = 0; iContador < ltModulos.Count(); iContador++)
            {
                Modulo objModuloActual = new Modulo();
                objModuloActual = ltModulos.ElementAt(iContador);
                DataRow row = dtModulos.NewRow();
                row["IdModulo"] = objModuloActual.idModulo.ToString();
                row["CVModulo"] = objModuloActual.CVModulo.ToString();
                row["Descripción"] = objModuloActual.Descripcion.ToString();
                row["Orden"] = objModuloActual.Orden;
                row["Ambiente"] = objModuloActual.Ambiente.ToString();
                row["Módulo"] = objModuloActual.strModulo.ToString();
                if (objModuloActual.Estatus != 0)
                {
                    row["Estatus"] = "Activo";
                }
                else {
                    row["Estatus"] = "InActivo";
                }

             

                dtModulos.Rows.Add(row);

            }


            return dtModulos;

        }


      

        public List<string> obtenerModulosxPerfil(int iCVPerfil,int iOpcion)
        {

            List<string> ltModulosxPerfil = new List<string>();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"usp_accepermod_suid";
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.Add("@P_CVPerfil", SqlDbType.Int).Value = iCVPerfil;
            cmd.Parameters.Add("@P_CVModulo", SqlDbType.VarChar).Value = "";
            cmd.Parameters.Add("@P_usuumod", SqlDbType.VarChar).Value = "";
            cmd.Parameters.Add("@P_prgumod", SqlDbType.VarChar).Value = "";
            cmd.Parameters.Add("@P_stact", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@P_steli", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@P_stcre", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@P_stlec", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@P_stimp", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@P_Opcion", SqlDbType.Int).Value = iOpcion;

        

            Conexion objConexion = new Conexion();
            objConexion.asignarConexion(cmd);

            SqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {
                Modulo objModulo = new Modulo();
                objModulo.CVModulo = reader.GetString(reader.GetOrdinal("CVMODULO"));
                //objModulo.steli = reader.GetInt32(reader.GetOrdinal("steli"));
                //objModulo.stact = reader.GetInt32(reader.GetOrdinal("stact"));
                //objModulo.stlec = reader.GetInt32(reader.GetOrdinal("stlec"));
                //objModulo.stimp = reader.GetInt32(reader.GetOrdinal("stimp"));
                //objModulo.stcre = reader.GetInt32(reader.GetOrdinal("stcre"));


                ltModulosxPerfil.Add(objModulo.CVModulo);
            }

            objConexion.cerrarConexion();

            return ltModulosxPerfil;
        }


        public DataTable obtenerModulosxCvPerfil(int CVPerfil)
        {

            List<string> ltModulosxPerfil = new List<string>();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"usp_accepermod_suid";
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.Add("@P_cvperfil", SqlDbType.Int).Value = CVPerfil;
            cmd.Parameters.Add("@P_cvmodulo", SqlDbType.VarChar).Value = "";
            cmd.Parameters.Add("@P_usuumod", SqlDbType.VarChar).Value = "";
            cmd.Parameters.Add("@P_prgumod", SqlDbType.VarChar).Value = "";
            cmd.Parameters.Add("@P_stact", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@P_steli", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@P_stcre", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@P_stimp", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@P_stlec", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@P_Opcion", SqlDbType.Int).Value = 5;
            

          

            Conexion objConexion = new Conexion();

            objConexion.asignarConexion(cmd);

            SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

            objConexion.cerrarConexion();

            DataTable dtModulo = new DataTable();
            Adapter.Fill(dtModulo);

            return dtModulo;
        }


        public static DataTable ObtenerPermisosxUsuario(string sCVUsuario,string sCvModulo)
        {

            DataTable dtPermisos = new DataTable();

            dtPermisos.PrimaryKey = new DataColumn[] { dtPermisos.Columns["CVModulo"] };

            List<Modulo> ltModulos = new List<Modulo>();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"usp_accepermisos_s";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@p_cvusuario", SqlDbType.VarChar).Value = sCVUsuario;
            cmd.Parameters.Add("@p_cvmodulo", SqlDbType.VarChar).Value = sCvModulo;
            cmd.Parameters.Add("@p_Opcion", SqlDbType.VarChar).Value = 4;
            Conexion objConexion = new Conexion();
            objConexion.asignarConexion(cmd);

            SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
            Adapter.Fill(dtPermisos);
            objConexion.cerrarConexion();

            return dtPermisos;

        }


        public static void CambioEstatusPermiso(DataRow row,int valorEstatus ,string ColumnaDataTable) {
            if (valorEstatus == 1)
            {
                row[ColumnaDataTable] = 1;
            }
        }

        public DataTable ObtenerModulo(string idmodulo, string cvindmodulo, string cvmodulo, string descripcion, string orden, string ambiente, string cvtipomodulo, string rutaacceso, string stmodulo, string usuumod, string prgumod, int opcion)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "usp_accemodulo_suid";
            cmd.CommandType = CommandType.StoredProcedure;
            Conexion objConexion = new Conexion();
            objConexion.asignarConexion(cmd);

            cmd.Parameters.Add("@p_idmodulo", SqlDbType.VarChar).Value = idmodulo;
            cmd.Parameters.Add("@p_cvindmodulo", SqlDbType.VarChar).Value = cvindmodulo;
            cmd.Parameters.Add("@p_cvmodulo", SqlDbType.VarChar).Value = cvmodulo;
            cmd.Parameters.Add("@p_descripcion", SqlDbType.VarChar).Value = descripcion;
            cmd.Parameters.Add("@p_orden", SqlDbType.VarChar).Value = orden;
            cmd.Parameters.Add("@p_ambiente", SqlDbType.VarChar).Value = ambiente;
            cmd.Parameters.Add("@p_cvtipomodulo", SqlDbType.VarChar).Value = cvtipomodulo;
            cmd.Parameters.Add("@p_rutaaaceso", SqlDbType.VarChar).Value = rutaacceso;
            cmd.Parameters.Add("@p_stmodulo", SqlDbType.VarChar).Value = stmodulo;
            cmd.Parameters.Add("@p_usuumod", SqlDbType.VarChar).Value = usuumod;
            cmd.Parameters.Add("@p_prgumod", SqlDbType.VarChar).Value = prgumod;
            cmd.Parameters.Add("@p_opcion", SqlDbType.Int).Value = opcion;


            objConexion.asignarConexion(cmd);

            SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

            objConexion.cerrarConexion();

            DataTable dtModulo = new DataTable();
            Adapter.Fill(dtModulo);
            return dtModulo;
        }

        public int CrearModulo(string idmodulo, string cvindmodulo, string cvmodulo, string descripcion, string orden, string ambiente, string cvtipomodulo, string rutaacceso, string stmodulo, string usuumod, string prgumod, int opcion)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "usp_accemodulo_suid";
            cmd.CommandType = CommandType.StoredProcedure;
            Conexion objConexion = new Conexion();
            objConexion.asignarConexion(cmd);

            cmd.Parameters.Add("@p_idmodulo", SqlDbType.VarChar).Value = idmodulo;
            cmd.Parameters.Add("@p_cvindmodulo", SqlDbType.VarChar).Value = cvindmodulo;
            cmd.Parameters.Add("@p_cvmodulo", SqlDbType.VarChar).Value = cvmodulo;
            cmd.Parameters.Add("@p_descripcion", SqlDbType.VarChar).Value = descripcion;
            cmd.Parameters.Add("@p_orden", SqlDbType.VarChar).Value = orden;
            cmd.Parameters.Add("@p_ambiente", SqlDbType.VarChar).Value = ambiente;
            cmd.Parameters.Add("@p_cvtipomodulo", SqlDbType.VarChar).Value = cvtipomodulo;
            cmd.Parameters.Add("@p_rutaaaceso", SqlDbType.VarChar).Value = rutaacceso;
            cmd.Parameters.Add("@p_stmodulo", SqlDbType.VarChar).Value = stmodulo;
            cmd.Parameters.Add("@p_usuumod", SqlDbType.VarChar).Value = usuumod;
            cmd.Parameters.Add("@p_prgumod", SqlDbType.VarChar).Value = prgumod;
            cmd.Parameters.Add("@p_opcion", SqlDbType.Int).Value = opcion;

            objConexion.asignarConexion(cmd);

            int response = Convert.ToInt32(cmd.ExecuteScalar());

            objConexion.cerrarConexion();

            return response;

        }

        public DataTable ReporteModulos(string idmodulo, string cvindmodulo, string cvmodulo, string descripcion, string orden, string ambiente, string cvtipomodulo, string rutaacceso, string stmodulo, string usuumod, string prgumod, int opcion)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "usp_accemodulo_suid";
            cmd.CommandType = CommandType.StoredProcedure;
            Conexion objConexion = new Conexion();
            objConexion.asignarConexion(cmd);

            cmd.Parameters.Add("@p_idmodulo", SqlDbType.VarChar).Value = idmodulo;
            cmd.Parameters.Add("@p_cvindmodulo", SqlDbType.VarChar).Value = cvindmodulo;
            cmd.Parameters.Add("@p_cvmodulo", SqlDbType.VarChar).Value = cvmodulo;
            cmd.Parameters.Add("@p_descripcion", SqlDbType.VarChar).Value = descripcion;
            cmd.Parameters.Add("@p_orden", SqlDbType.VarChar).Value = orden;
            cmd.Parameters.Add("@p_ambiente", SqlDbType.VarChar).Value = ambiente;
            cmd.Parameters.Add("@p_cvtipomodulo", SqlDbType.VarChar).Value = cvtipomodulo;
            cmd.Parameters.Add("@p_rutaaaceso", SqlDbType.VarChar).Value = rutaacceso;
            cmd.Parameters.Add("@p_stmodulo", SqlDbType.VarChar).Value = stmodulo;
            cmd.Parameters.Add("@p_usuumod", SqlDbType.VarChar).Value = usuumod;
            cmd.Parameters.Add("@p_prgumod", SqlDbType.VarChar).Value = prgumod;
            cmd.Parameters.Add("@p_opcion", SqlDbType.Int).Value = opcion;

            objConexion.asignarConexion(cmd);

            SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

            objConexion.cerrarConexion();

            DataTable dtModulo = new DataTable();
            Adapter.Fill(dtModulo);
            return dtModulo;
        }


        public DataTable ObtenerTipoModulo(int iOpcion,int cvTipo,string sDescripcion,string sEstatus
                                            ,string usuumod,string fhumod,string prgumod)
        {

           
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"usp_accetipomodulo_suid";
            cmd.CommandType = CommandType.StoredProcedure;
            Conexion objConexion = new Conexion();
            cmd.Parameters.Add("@P_Opcion", SqlDbType.VarChar).Value = iOpcion;
            cmd.Parameters.Add("@P_cvtipomodulo", SqlDbType.VarChar).Value = cvTipo;
            cmd.Parameters.Add("@P_descripcion", SqlDbType.VarChar).Value = sDescripcion;
            cmd.Parameters.Add("@P_stmodulo", SqlDbType.VarChar).Value = sEstatus;
            cmd.Parameters.Add("@P_usuumod", SqlDbType.VarChar).Value = usuumod;
            cmd.Parameters.Add("@P_fhumod", SqlDbType.VarChar).Value = fhumod;
            cmd.Parameters.Add("@P_prgumod", SqlDbType.VarChar).Value = prgumod;

            objConexion.asignarConexion(cmd);
            SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
            objConexion.cerrarConexion();

            DataTable dt = new DataTable();
            Adapter.Fill(dt);

            return dt;

        }

    }
}
