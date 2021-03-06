﻿using SIPAA_CS.Conexiones;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIPAA_CS.App_Code
{
    class Usuario
    {

        public string CVUsuario;
        public int Idtrab;
        public string Nombre;
        public string Pass;
        public int StUsuario;
        public string UsuuMod;
        public DateTime FhumMod;
        public string PrguMod;
        public int st;
        public int enc;
        public int opcion;




        public List<Usuario> ObtenerUsuariosxBusqueda(string sNombre, string sIdTrab)
        {
            List<Usuario> ltUsuarios = new List<Usuario>();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"usp_acceusuario_suid";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@p_cvusuario", SqlDbType.VarChar).Value = "";
            cmd.Parameters.Add("@p_nombre", SqlDbType.VarChar).Value = sNombre;
            cmd.Parameters.Add("@p_idtrab", SqlDbType.VarChar).Value = sIdTrab;
            cmd.Parameters.Add("@p_passw", SqlDbType.VarChar).Value = "";
            cmd.Parameters.Add("@p_stusuario", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@p_usuumod", SqlDbType.VarChar).Value = "";
            cmd.Parameters.Add("@p_prgumod", SqlDbType.VarChar).Value = "";
            cmd.Parameters.Add("@p_opcion", SqlDbType.Int).Value = 13;

        

            Conexion objConexion = new Conexion();
            objConexion.asignarConexion(cmd);

            SqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {

                Usuario objUsuario = new Usuario();
                objUsuario.CVUsuario = reader.GetString(reader.GetOrdinal("CVUSUARIO"));
                objUsuario.Idtrab = reader.GetInt32(reader.GetOrdinal("IDTRAB"));
                objUsuario.Nombre = reader.GetString(reader.GetOrdinal("NOMBRE"));
                objUsuario.Pass = reader.GetString(reader.GetOrdinal("PASSW"));
                objUsuario.UsuuMod = reader.GetString(reader.GetOrdinal("USUUMOD"));
                objUsuario.FhumMod = reader.GetDateTime(reader.GetOrdinal("FHUMOD"));
                objUsuario.PrguMod = reader.GetString(reader.GetOrdinal("PRGUMOD"));


                ltUsuarios.Add(objUsuario);
            }

            objConexion.cerrarConexion();

            return ltUsuarios;

        }


        public DataTable ObtenerDataTableUsuarios(List<Usuario> ltUsuario)
        {


            DataTable dtUsuarios = new DataTable();
            dtUsuarios.Columns.Add("CvUsuario");
            dtUsuarios.Columns.Add("IdTrab");
            dtUsuarios.Columns.Add("Nombre");

            for (int iContador = 0; iContador < ltUsuario.Count(); iContador++)
            {

                Usuario objUsuarioActual = new Usuario();
                objUsuarioActual = ltUsuario.ElementAt(iContador);
                DataRow row = dtUsuarios.NewRow();
                row["CvUsuario"] = objUsuarioActual.CVUsuario.ToString();
                row["IdTrab"] = objUsuarioActual.Idtrab.ToString();
                row["Nombre"] = objUsuarioActual.Nombre;

                dtUsuarios.Rows.Add(row);

            }


            return dtUsuarios;

        }


        public void AsignarPerfilaUsuario(string iCVUsuario, int iCVPerfil,int iOpcion, string sUsuuMod, string sPrguMod)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "usp_acceusuper_suid";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@P_CVUsuario", SqlDbType.VarChar).Value = iCVUsuario;
            cmd.Parameters.Add("@P_CvPerfil", SqlDbType.Int).Value = iCVPerfil;
            cmd.Parameters.Add("@P_USUUMOD", SqlDbType.VarChar).Value = sUsuuMod;
            cmd.Parameters.Add("@P_PRGUMOD", SqlDbType.VarChar).Value = sPrguMod;
            cmd.Parameters.Add("@P_opcion", SqlDbType.Int).Value = iOpcion;

            Conexion objConexion = new Conexion();
            objConexion.asignarConexion(cmd);

            cmd.ExecuteNonQuery();

            objConexion.cerrarConexion();


        }



        public List<string> ObtenerListaModulosxUsuario(string CVUsuario,int iOpcion)
        {

            List<string> ltModulosxUsuario = new List<string>();
            Conexion objConexion = new Conexion();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"usp_accepermisos_s";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@P_cvusuario", SqlDbType.VarChar).Value = CVUsuario;
            cmd.Parameters.Add("@P_cvmodulo", SqlDbType.VarChar).Value = "CS";
            cmd.Parameters.Add("@P_opcion", SqlDbType.Int).Value = iOpcion;
           
            objConexion.asignarConexion(cmd);
            SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
            objConexion.cerrarConexion();

            DataTable dt = new DataTable();
            Adapter.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {
                string str = row[1].ToString();
                if (!ltModulosxUsuario.Contains(str))
                    {
                        ltModulosxUsuario.Add(str.Trim());
                    }             
            }
            return ltModulosxUsuario;
            
        }

        public Usuario ObtenerListaTrabajadorUsuario(int opcion, int Idtrab)
        {
            SqlCommand cmd = new SqlCommand();
            Conexion objConexion = new Conexion();
            Usuario objusuario = new Usuario();
            

            cmd.CommandText = "usp_sonatrabajador_s";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@p_opcion", SqlDbType.VarChar).Value = opcion;
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Idtrab;
            cmd.Parameters.Add("@Nom", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Sta", SqlDbType.Int, 50).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Enc", SqlDbType.Int, 50).Direction = ParameterDirection.Output;
            objConexion.asignarConexion(cmd);
            cmd.ExecuteNonQuery();

            objusuario.Nombre = Convert.ToString(cmd.Parameters["@Nom"].Value.ToString());
            objusuario.st = Convert.ToInt32(cmd.Parameters["@Sta"].Value.ToString());
            objusuario.enc = Convert.ToInt32(cmd.Parameters["@Enc"].Value.ToString());
            
            objConexion.cerrarConexion();
            return objusuario;
        }

        public int AsignarAccesoUsuario(string cvusuario, int idtrab, string nombre, string passw, int stusuario, string usuumod, string prgmod, int opcion)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "usp_acceusuario_suid";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@p_cvusuario", SqlDbType.VarChar).Value = cvusuario;
            cmd.Parameters.Add("@p_idtrab", SqlDbType.Int).Value = idtrab;
            cmd.Parameters.Add("@p_nombre", SqlDbType.VarChar).Value = nombre;
            cmd.Parameters.Add("@p_passw", SqlDbType.VarChar).Value = passw;
            cmd.Parameters.Add("@p_stusuario", SqlDbType.Int).Value = stusuario;
            cmd.Parameters.Add("@p_usuumod", SqlDbType.VarChar).Value = usuumod;
            cmd.Parameters.Add("@p_prgumod", SqlDbType.VarChar).Value = prgmod;
            cmd.Parameters.Add("@p_opcion", SqlDbType.VarChar).Value = opcion;

            Conexion objConexion = new Conexion();
            objConexion.asignarConexion(cmd);

            int regreso = Convert.ToInt32(cmd.ExecuteScalar());

            objConexion.cerrarConexion();

            return regreso;
        }

        //valida usuario activo
        public int ivalusuactivo(int iidtrab, int iopcion)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "usp_acceusuario_suid";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@p_cvusuario", SqlDbType.VarChar).Value = "";
            cmd.Parameters.Add("@p_idtrab", SqlDbType.Int).Value = iidtrab;
            cmd.Parameters.Add("@p_nombre", SqlDbType.VarChar).Value = "";
            cmd.Parameters.Add("@p_passw", SqlDbType.VarChar).Value = "";
            cmd.Parameters.Add("@p_stusuario", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@p_usuumod", SqlDbType.VarChar).Value = "";
            cmd.Parameters.Add("@p_prgumod", SqlDbType.VarChar).Value = "";
            cmd.Parameters.Add("@p_opcion", SqlDbType.VarChar).Value = iopcion;

            Conexion objConexion = new Conexion();
            objConexion.asignarConexion(cmd);

            int regreso = Convert.ToInt32(cmd.ExecuteScalar());

            objConexion.cerrarConexion();

            return regreso;
        }

        public DataTable ObtenerAccesosUsuario(string cvusuario, int idtrab, string nombre, string passw, int stusuario, string usuumod, string prgmod, int opcion)
        {

            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = @"SELECT CVUSUARIO
                                        ,IDTRAB
                                        ,NOMBRE
                                        ,STUSUARIO                                 
                                  FROM [dbo].[ACCECUSUARIO] 
                                    WHERE CVUSUARIO LIKE '%'+ @CVUsuario +'%' ";
            //cmd.CommandText = "sp_AdministracionAccesoUsuario";

            cmd.Parameters.Add("@CVUsuario", SqlDbType.VarChar).Value = cvusuario;
            //cmd.Parameters.Add("@IdTrab", SqlDbType.Int).Value = idtrab;
            //cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = nombre;
            //cmd.Parameters.Add("@Passw", SqlDbType.VarChar).Value = passw;
            //cmd.Parameters.Add("@StUsuario", SqlDbType.Int).Value = stusuario;
            //cmd.Parameters.Add("@UsuUmod", SqlDbType.VarChar).Value = usuumod;
            //cmd.Parameters.Add("@PrguMod", SqlDbType.VarChar).Value = prgmod;
            //cmd.Parameters.Add("@Opcion", SqlDbType.Int).Value = opcion;

            Conexion objConexion = new Conexion();
            objConexion.asignarConexion(cmd);

            SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

            objConexion.cerrarConexion();

            DataTable dgvAccesoUsu = new DataTable();

            Adapter.Fill(dgvAccesoUsu);

            return dgvAccesoUsu;
        }

        public int EliminarAccesoUsuario(string cvusuario, string idtrab, string nombre, string passw, int stusuario, string usuumod, string prgmod, int opcion)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "usp_acceusuario_suid";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@p_cvusuario", SqlDbType.VarChar).Value = cvusuario;
                cmd.Parameters.Add("@p_IdTrab", SqlDbType.VarChar).Value = idtrab;
                cmd.Parameters.Add("@p_Nombre", SqlDbType.VarChar).Value = nombre;
                cmd.Parameters.Add("@p_Passw", SqlDbType.VarChar).Value = passw;
                cmd.Parameters.Add("@p_StUsuario", SqlDbType.Int).Value = stusuario;
                cmd.Parameters.Add("@p_UsuUmod", SqlDbType.VarChar).Value = usuumod;
                cmd.Parameters.Add("@p_PrguMod", SqlDbType.VarChar).Value = prgmod;
                cmd.Parameters.Add("@p_Opcion", SqlDbType.Int).Value = opcion;

                Conexion objConexion = new Conexion();
                objConexion.asignarConexion(cmd);

                //cmd.ExecuteNonQuery();
                int regreso = Convert.ToInt32(cmd.ExecuteScalar());

                objConexion.cerrarConexion();

                return regreso;
            }
            catch (Exception)
            {

                return 0;
            }
            
        }

        public static class LoginInfo
        {
            public static string IdTrab;
            public static string Nombre;
            public static DataTable dtPermisosTrabajador;
            public static int iconexion;

            public static string cvusuario;
        }


        public DataTable ObtenerListaUsuarios(string cvusuario, int idtrab, string nombre, string pass, int stusuario, string usumod, string prgmod,int opcion)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"usp_acceusuario_suid";
            cmd.CommandType = CommandType.StoredProcedure;
            Conexion objConexion = new Conexion();
            objConexion.asignarConexion(cmd);

            cmd.Parameters.Add("@p_cvusuario", SqlDbType.VarChar).Value = cvusuario;
            cmd.Parameters.Add("@p_idtrab", SqlDbType.Int).Value = idtrab;
            cmd.Parameters.Add("@p_nombre", SqlDbType.VarChar).Value = nombre;
            cmd.Parameters.Add("@p_passw", SqlDbType.VarChar).Value = pass;
            cmd.Parameters.Add("@p_stusuario", SqlDbType.Int).Value = stusuario;
            cmd.Parameters.Add("@p_usuumod", SqlDbType.VarChar).Value = usumod;
            cmd.Parameters.Add("@p_prgumod", SqlDbType.VarChar).Value = prgmod;
            cmd.Parameters.Add("@p_opcion", SqlDbType.Int).Value = opcion;


            objConexion.asignarConexion(cmd);

            SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

            objConexion.cerrarConexion();

            DataTable dtUsuario = new DataTable();
            Adapter.Fill(dtUsuario);
            return dtUsuario;
        }

        public void AsignarCompaniaUsuario(string cvusuario, string idcompania, string usuumod, string prgumod, int opcion)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "usp_accetusucom_suid";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@p_cvusuario", SqlDbType.VarChar).Value = cvusuario;
            cmd.Parameters.Add("@p_idcompania", SqlDbType.VarChar).Value = idcompania;
            cmd.Parameters.Add("@p_usuumod", SqlDbType.VarChar).Value = usuumod;
            cmd.Parameters.Add("@p_prgumod", SqlDbType.VarChar).Value = prgumod;
            cmd.Parameters.Add("@p_opcion", SqlDbType.Int).Value = opcion;

            Conexion objConexion = new Conexion();
            objConexion.asignarConexion(cmd);

            cmd.ExecuteNonQuery();
            objConexion.cerrarConexion();
            
        }

        public void AsignarAreaUsuario(string cvusuario, string idcompania, string idplanta, string usuumod,string prgumod, int opcion)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "usp_accetusuare_suid";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@p_cvusuario", SqlDbType.VarChar).Value = cvusuario;
            cmd.Parameters.Add("@p_idcompania", SqlDbType.VarChar).Value = idcompania;
            cmd.Parameters.Add("@p_idplanta", SqlDbType.VarChar).Value = idplanta;
            cmd.Parameters.Add("@p_usuumod", SqlDbType.VarChar).Value = usuumod;
            cmd.Parameters.Add("@p_prgumod", SqlDbType.VarChar).Value = prgumod;
            cmd.Parameters.Add("@p_opcion", SqlDbType.VarChar).Value = opcion;

            Conexion objConexion = new Conexion();
            objConexion.asignarConexion(cmd);

            cmd.ExecuteNonQuery();
            objConexion.cerrarConexion();

        }

        public void AsignarUbicacionUsuario(string cvusuario, string idubicacion, string usuumod, string prgumod, int opcion)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "usp_accetusuubi_suid";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@p_cvusuario", SqlDbType.VarChar).Value = cvusuario;
            cmd.Parameters.Add("@p_idubicacion", SqlDbType.VarChar).Value = idubicacion;
            cmd.Parameters.Add("@p_usuumod", SqlDbType.VarChar).Value = usuumod;
            cmd.Parameters.Add("@p_prgumod", SqlDbType.VarChar).Value = prgumod;
            cmd.Parameters.Add("@p_opcion", SqlDbType.Int).Value = opcion;

            Conexion objConexion = new Conexion();
            objConexion.asignarConexion(cmd);

            cmd.ExecuteNonQuery();
            objConexion.cerrarConexion();

        }

        public void AsignarDepartamentosUsuario(string cvusuario, string iddepartamento, string usuumod, string prgumod, int opcion)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "usp_accetusudep_suid";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@p_cvusuario", SqlDbType.VarChar).Value = cvusuario;
            cmd.Parameters.Add("@p_iddepartamento", SqlDbType.VarChar).Value = iddepartamento;
            cmd.Parameters.Add("@p_usuumod", SqlDbType.VarChar).Value = usuumod;
            cmd.Parameters.Add("@p_prgumod", SqlDbType.VarChar).Value = prgumod;
            cmd.Parameters.Add("@p_opcion", SqlDbType.Int).Value = opcion;

            Conexion objConexion = new Conexion();
            objConexion.asignarConexion(cmd);

            cmd.ExecuteNonQuery();
            objConexion.cerrarConexion();

        }

        public DataTable ReporteUsuarios(string cvusuario, int idtrab, string nombre, string passw, string stusuario, string usuumod, string prgmod, int opcion)
        {

            Conexion objConexion = new Conexion();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"usp_acceusuario_suid";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@p_cvusuario", SqlDbType.VarChar).Value = cvusuario;
            cmd.Parameters.Add("@p_idtrab", SqlDbType.Int).Value = idtrab;
            cmd.Parameters.Add("@p_nombre", SqlDbType.VarChar).Value = nombre;
            cmd.Parameters.Add("@p_passw", SqlDbType.VarChar).Value = passw;
            cmd.Parameters.Add("@p_stusuario", SqlDbType.VarChar).Value = stusuario;
            cmd.Parameters.Add("@p_usuumod", SqlDbType.VarChar).Value = usuumod;
            cmd.Parameters.Add("@p_prgumod", SqlDbType.VarChar).Value = prgmod;
            cmd.Parameters.Add("@p_opcion", SqlDbType.Int).Value = opcion;



            objConexion.asignarConexion(cmd);
            SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
            objConexion.cerrarConexion();

            DataTable dtIncidencia = new DataTable();
            Adapter.Fill(dtIncidencia);

            return dtIncidencia;
        }

        public Usuario ObtenerDatosUsuario(string cvusuario, int idtrab, string nombre, string passw, string stusuario, string usuumod, string prgmod, int opcion)
        {
            SqlCommand cmd = new SqlCommand();
            Conexion objConexion = new Conexion();
            Usuario objusuario = new Usuario();


            cmd.CommandText = "usp_acceusuario_suid";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@p_cvusuario", SqlDbType.VarChar).Value = cvusuario;
            cmd.Parameters.Add("@p_idtrab", SqlDbType.Int).Value = idtrab;
            cmd.Parameters.Add("@p_nombre", SqlDbType.VarChar).Value = nombre;
            cmd.Parameters.Add("@p_passw", SqlDbType.VarChar).Value = passw;
            cmd.Parameters.Add("@p_stusuario", SqlDbType.VarChar).Value = stusuario;
            cmd.Parameters.Add("@p_usuumod", SqlDbType.VarChar).Value = usuumod;
            cmd.Parameters.Add("@p_prgumod", SqlDbType.VarChar).Value = prgmod;
            cmd.Parameters.Add("@p_opcion", SqlDbType.Int).Value = opcion;
            objConexion.asignarConexion(cmd);
            cmd.ExecuteNonQuery();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                // Usuario objUsuario = new Usuario();

                objusuario.Nombre = reader.GetString(reader.GetOrdinal("NOMBRE"));
            }

            objConexion.cerrarConexion();
            return objusuario;
        }

        public static class Permisos
        {
            public static Dictionary<string, int> dcPermisos;
        }

        public int iactpw(int iopcion, string susurio, string pwnuevo, string susumodif, string sprgmodif, string snombre, string sidtrab, string sstusuario)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "usp_acceusuario_suid";
            cmd.CommandType = CommandType.StoredProcedure;
            Conexion objConexion = new Conexion();
            objConexion.asignarConexion(cmd);

            cmd.Parameters.Add("@p_cvusuario", SqlDbType.VarChar).Value = susurio;
            cmd.Parameters.Add("@p_idtrab", SqlDbType.VarChar).Value = sidtrab;
            cmd.Parameters.Add("@p_nombre", SqlDbType.VarChar).Value = snombre;
            cmd.Parameters.Add("@p_passw", SqlDbType.VarChar).Value = pwnuevo;
            cmd.Parameters.Add("@p_stusuario", SqlDbType.VarChar).Value = sstusuario;
            cmd.Parameters.Add("@p_usuumod", SqlDbType.VarChar).Value = susumodif;
            cmd.Parameters.Add("@p_prgumod", SqlDbType.VarChar).Value = sprgmodif;
            cmd.Parameters.Add("@p_opcion", SqlDbType.Int).Value = iopcion;
            objConexion.asignarConexion(cmd);

            int regreso = Convert.ToInt32(cmd.ExecuteScalar());
            objConexion.cerrarConexion();
            return regreso;

        }

        public DataTable irstpwd(int iopcion, string scveusuario, string pwnuevo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "usp_acceusuario_suid";
            cmd.CommandType = CommandType.StoredProcedure;
            Conexion objConexion = new Conexion();
            objConexion.asignarConexion(cmd);

            cmd.Parameters.Add("@p_cvusuario", SqlDbType.VarChar).Value = scveusuario;
            cmd.Parameters.Add("@p_idtrab", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@p_nombre", SqlDbType.VarChar).Value = "";
            cmd.Parameters.Add("@p_passw", SqlDbType.VarChar).Value = pwnuevo;
            cmd.Parameters.Add("@p_stusuario", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@p_usuumod", SqlDbType.VarChar).Value = "";
            cmd.Parameters.Add("@p_prgumod", SqlDbType.VarChar).Value = "";
            cmd.Parameters.Add("@p_opcion", SqlDbType.Int).Value = iopcion;
            objConexion.asignarConexion(cmd);

            SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

            objConexion.cerrarConexion();

            DataTable dtusuario = new DataTable();
            Adapter.Fill(dtusuario);
            return dtusuario;

        }

        //llena dgv,cb cambiar perfil del usuario
        public DataTable dtdatos(string scvusuario, string sidtrab, string snombre, string spassw,
                                 string sstusuario,  string susuumod, string sprgumod, int iopcion)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"usp_acceusuario_suid";
            cmd.CommandType = CommandType.StoredProcedure;
            Conexion objConexion = new Conexion();
            objConexion.asignarConexion(cmd);

            cmd.Parameters.Add("@p_cvusuario", SqlDbType.VarChar).Value = scvusuario;
            cmd.Parameters.Add("@p_idtrab", SqlDbType.VarChar).Value = sidtrab;
            cmd.Parameters.Add("@p_nombre", SqlDbType.VarChar).Value = snombre;
            cmd.Parameters.Add("@p_passw", SqlDbType.VarChar).Value = spassw;
            cmd.Parameters.Add("@p_stusuario", SqlDbType.VarChar).Value = sstusuario;
            cmd.Parameters.Add("@p_usuumod", SqlDbType.VarChar).Value = susuumod;
            cmd.Parameters.Add("@p_prgumod", SqlDbType.VarChar).Value = sprgumod;
            cmd.Parameters.Add("@p_opcion", SqlDbType.Int).Value = iopcion;
            objConexion.asignarConexion(cmd);

            SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
            objConexion.cerrarConexion();

            DataTable dtdgvcboscorreo = new DataTable();
            Adapter.Fill(dtdgvcboscorreo);
            return dtdgvcboscorreo;
        }

        //actualiza perfil
        public int idatact(string scvusuario, string sidtrab, string snombre, string spassw,
                           string sstusuario, string susuumod, string sprgumod, int iopcion)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "usp_acceusuario_suid";
            cmd.CommandType = CommandType.StoredProcedure;
            Conexion objConexion = new Conexion();
            objConexion.asignarConexion(cmd);

            cmd.Parameters.Add("@p_cvusuario", SqlDbType.VarChar).Value = scvusuario;
            cmd.Parameters.Add("@p_idtrab", SqlDbType.VarChar).Value = sidtrab;
            cmd.Parameters.Add("@p_nombre", SqlDbType.VarChar).Value = snombre;
            cmd.Parameters.Add("@p_passw", SqlDbType.VarChar).Value = spassw;
            cmd.Parameters.Add("@p_stusuario", SqlDbType.VarChar).Value = sstusuario;
            cmd.Parameters.Add("@p_usuumod", SqlDbType.VarChar).Value = susuumod;
            cmd.Parameters.Add("@p_prgumod", SqlDbType.VarChar).Value = sprgumod;
            cmd.Parameters.Add("@p_opcion", SqlDbType.Int).Value = iopcion;
            objConexion.asignarConexion(cmd);

            int regreso = Convert.ToInt32(cmd.ExecuteScalar());
            objConexion.cerrarConexion();
            return regreso;

        }
    }

}
