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
//Fecha creación: 04-Abril-2017       Última Modificacion: dd-mm-aaaa
//Descripción: Desbloqueo de Incidencias
//***********************************************************************************************

namespace SIPAA_CS.App_Code.RecursosHumanos.Procesos
{
    class DesbloqueaIncidencias
    {
        //variables
        public int iOpcion;
        public string sUsuumod;
        public string sPrgumodr;


        public DesbloqueaIncidencias()
        {
            iOpcion = 0;
            sUsuumod = "";
            sPrgumodr = "";

        }

        public DataTable dtfecperiodo(int iopcion, int icveperiodo, string susumod, string sprultmodid)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"usp_rechtinccalif_suid";
            cmd.CommandType = CommandType.StoredProcedure;
            Conexion objConexion = new Conexion();
            objConexion.asignarConexion(cmd);

            cmd.Parameters.Add("@p_opcion", SqlDbType.Int).Value = iopcion;
            cmd.Parameters.Add("@p_idtrab", SqlDbType.Int).Value = icveperiodo;
            cmd.Parameters.Add("@p_fini", SqlDbType.VarChar).Value = "";
            cmd.Parameters.Add("@p_ffin", SqlDbType.VarChar).Value = "";
            cmd.Parameters.Add("@p_idtrabsup", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@p_idtrabdir", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@p_idtrabsupn", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@p_idtrabdirn", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@p_usuumod", SqlDbType.VarChar).Value = susumod;
            cmd.Parameters.Add("@p_prgumod", SqlDbType.VarChar).Value = sprultmodid;
            objConexion.asignarConexion(cmd);

            SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
            objConexion.cerrarConexion();

            DataTable dtfecperiod = new DataTable();
            Adapter.Fill(dtfecperiod);
            return dtfecperiod;
        }

        public DataTable dttrabsupdir(int iopcion, string sfecini, string fecfin, int itrab, string susumod, string sprultmodid, int iformapago)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"usp_rechtinccalif_suid";
            cmd.CommandType = CommandType.StoredProcedure;
            Conexion objConexion = new Conexion();
            objConexion.asignarConexion(cmd);

            cmd.Parameters.Add("@p_opcion", SqlDbType.Int).Value = iopcion;
            cmd.Parameters.Add("@p_idtrab", SqlDbType.Int).Value = itrab;
            cmd.Parameters.Add("@p_fini", SqlDbType.VarChar).Value = sfecini;
            cmd.Parameters.Add("@p_ffin", SqlDbType.VarChar).Value = fecfin;
            cmd.Parameters.Add("@p_idtrabsup", SqlDbType.Int).Value = iformapago;
            cmd.Parameters.Add("@p_idtrabdir", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@p_idtrabsupn", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@p_idtrabdirn", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@p_usuumod", SqlDbType.VarChar).Value = susumod;
            cmd.Parameters.Add("@p_prgumod", SqlDbType.VarChar).Value = sprultmodid;
            objConexion.asignarConexion(cmd);

            SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
            objConexion.cerrarConexion();

            DataTable dtfecperiod = new DataTable();
            Adapter.Fill(dtfecperiod);
            return dtfecperiod;
        }

        //actualiza supervisor y director nuevo
        public int actsupdir(int iopcion, int itrab, string sfecini, string fecfin, int iidtrabsupn, int iidtrabdirn, string susumod, string sprultmodid, int iformapago)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"usp_rechtinccalif_suid";
            cmd.CommandType = CommandType.StoredProcedure;
            Conexion objConexion = new Conexion();
            objConexion.asignarConexion(cmd);

            cmd.Parameters.Add("@p_opcion", SqlDbType.Int).Value = iopcion;
            cmd.Parameters.Add("@p_idtrab", SqlDbType.Int).Value = itrab;
            cmd.Parameters.Add("@p_fini", SqlDbType.VarChar).Value = sfecini;
            cmd.Parameters.Add("@p_ffin", SqlDbType.VarChar).Value = fecfin;
            cmd.Parameters.Add("@p_idtrabsup", SqlDbType.Int).Value = iformapago;
            cmd.Parameters.Add("@p_idtrabdir", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@p_idtrabsupn", SqlDbType.Int).Value = iidtrabsupn;
            cmd.Parameters.Add("@p_idtrabdirn", SqlDbType.Int).Value = iidtrabdirn;
            cmd.Parameters.Add("@p_usuumod", SqlDbType.VarChar).Value = susumod;
            cmd.Parameters.Add("@p_prgumod", SqlDbType.VarChar).Value = sprultmodid;
            objConexion.asignarConexion(cmd);

            int iverifact = Convert.ToInt32(cmd.ExecuteScalar());
            objConexion.cerrarConexion();
            return iverifact;
        }

        public DataTable obtActualizaIncidencias(int iOpcion, int idTrab, string dFini, string dFfin, string usuario)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"usp_rechtinccalif_suid";
            cmd.CommandType = CommandType.StoredProcedure;
            Conexion objConexion = new Conexion();
            objConexion.asignarConexion(cmd);
            iOpcion = 11;

            cmd.Parameters.Add("@p_opcion", SqlDbType.Int).Value = iOpcion;
            cmd.Parameters.Add("@p_idtrab", SqlDbType.Int).Value = idTrab;
            cmd.Parameters.Add("@p_fini", SqlDbType.NChar).Value = dFini;
            cmd.Parameters.Add("@p_ffin", SqlDbType.NChar).Value = dFfin;
            cmd.Parameters.Add("@p_idtrabsup", SqlDbType.Int).Value = idTrab;
            cmd.Parameters.Add("@p_idtrabdir", SqlDbType.Int).Value = idTrab;
            cmd.Parameters.Add("@p_idtrabsupn", SqlDbType.Int).Value = idTrab;
            cmd.Parameters.Add("@p_idtrabdirn", SqlDbType.Int).Value = idTrab;
            cmd.Parameters.Add("@p_usuumod", SqlDbType.NChar).Value = usuario;
            cmd.Parameters.Add("@p_prgumod", SqlDbType.NChar).Value = "DesbloquearIncidencias";

            objConexion.asignarConexion(cmd);

            SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

            objConexion.cerrarConexion();

            DataTable dtActIncidencias = new DataTable();
            Adapter.Fill(dtActIncidencias);
            return dtActIncidencias;
        }


        //metodo data table para llenar el grid/combo de busqueda
        //public DataTable obtPeriodosProcesoIncidencia(int iOpcion, int iIdFormaPago, string sFechaInicioReg, string sFechaFinReg, string sDescripcion, int iStPeriodoProceso, string sUsuumod, string sPrgumodr)
        //{
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandText = @"usp_rechtperiodopro_suid";
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    Conexion objConexion = new Conexion();
        //    objConexion.asignarConexion(cmd);

        //    cmd.Parameters.Add("@p_opcion", SqlDbType.Int).Value = iOpcion;
        //    cmd.Parameters.Add("@p_idformapago", SqlDbType.Int).Value = iIdFormaPago;
        //    cmd.Parameters.Add("@p_fhinireg", SqlDbType.VarChar).Value = sFechaInicioReg;
        //    cmd.Parameters.Add("@p_fhfinreg", SqlDbType.VarChar).Value = sFechaFinReg;
        //    cmd.Parameters.Add("@p_descripcion", SqlDbType.VarChar).Value = sDescripcion;
        //    cmd.Parameters.Add("@p_stperiodopro", SqlDbType.Int).Value = iStPeriodoProceso;
        //    cmd.Parameters.Add("@p_usuumod", SqlDbType.VarChar).Value = sUsuumod;
        //    cmd.Parameters.Add("@p_prgumod", SqlDbType.VarChar).Value = sPrgumodr;

        //    objConexion.asignarConexion(cmd);

        //    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

        //    objConexion.cerrarConexion();

        //    DataTable dtPeriodosProcesoIncidencia = new DataTable();
        //    Adapter.Fill(dtPeriodosProcesoIncidencia);
        //    return dtPeriodosProcesoIncidencia;
        //}

        //public DataTable obtNombreEmpleado(string idTrab, int iOpcion /*, int sStatus, int iEnc, string sNombre*/)
        //{
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandText = @"usp_acceusuario_suid";
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    Conexion objConexion = new Conexion();
        //    objConexion.asignarConexion(cmd);
        //    iOpcion = 14;

        //    cmd.Parameters.Add("@p_cvusuario", SqlDbType.Int).Value = idTrab; //No se ocupa
        //    cmd.Parameters.Add("@p_idtrab", SqlDbType.Int).Value = idTrab;
        //    cmd.Parameters.Add("@p_nombre", SqlDbType.Int).Value = idTrab; //No se ocupa
        //    cmd.Parameters.Add("@p_passw", SqlDbType.Int).Value = idTrab; //No se ocupa
        //    cmd.Parameters.Add("@p_stusuario", SqlDbType.Int).Value = idTrab; //No se ocupa
        //    cmd.Parameters.Add("@p_usuumod", SqlDbType.Int).Value = idTrab; //No se ocupa
        //    cmd.Parameters.Add("@p_prgumod", SqlDbType.Int).Value = idTrab; //No se ocupa
        //    cmd.Parameters.Add("@p_opcion", SqlDbType.Int).Value = iOpcion;

        //    objConexion.asignarConexion(cmd);

        //    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

        //    objConexion.cerrarConexion();

        //    DataTable dtNombreEmpleado = new DataTable();
        //    Adapter.Fill(dtNombreEmpleado);
        //    return dtNombreEmpleado;
        //}

        //public DataTable obtObtieneSupyDir(int iOpcion, int idTrab, string dFini, string dFfin/*, int idTrabSup, int idTrabDir, int idTrabSupn, int idTrabDirn*/)
        //{
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandText = @"usp_rechtinccalif_suid";
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    Conexion objConexion = new Conexion();
        //    objConexion.asignarConexion(cmd);
        //    iOpcion = 4;

        //    cmd.Parameters.Add("@p_opcion", SqlDbType.Int).Value = iOpcion;
        //    cmd.Parameters.Add("@p_idtrab", SqlDbType.Int).Value = idTrab;
        //    cmd.Parameters.Add("@p_fini", SqlDbType.NChar).Value = dFini;
        //    cmd.Parameters.Add("@p_ffin", SqlDbType.NChar).Value = dFfin;
        //    cmd.Parameters.Add("@p_idtrabsup", SqlDbType.Int).Value = idTrab;
        //    cmd.Parameters.Add("@p_idtrabdir", SqlDbType.Int).Value = idTrab;
        //    cmd.Parameters.Add("@p_idtrabsupn", SqlDbType.Int).Value = idTrab;
        //    cmd.Parameters.Add("@p_idtrabdirn", SqlDbType.Int).Value = idTrab;
        //    cmd.Parameters.Add("@p_usuumod", SqlDbType.NChar).Value = "JAV";
        //    cmd.Parameters.Add("@p_prgumod", SqlDbType.NChar).Value = "SQL";

        //    objConexion.asignarConexion(cmd);

        //    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

        //    objConexion.cerrarConexion();

        //    DataTable dtNombreEmpleado = new DataTable();
        //    Adapter.Fill(dtNombreEmpleado);
        //    return dtNombreEmpleado;
        //}

        //public DataTable obtActualizaSudyDir(int iOpcion, int idTrab, string dFini, string dFfin, int idTrabSupn, int idTrabDirn/*, int idTrabSupn, int idTrabDirn*/)
        //{
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandText = @"usp_rechtinccalif_suid";
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    Conexion objConexion = new Conexion();
        //    objConexion.asignarConexion(cmd);
        //    iOpcion = 2;


        //    cmd.Parameters.Add("@p_opcion", SqlDbType.Int).Value = iOpcion;
        //    cmd.Parameters.Add("@p_idtrab", SqlDbType.Int).Value = idTrab;
        //    cmd.Parameters.Add("@p_fini", SqlDbType.NChar).Value = dFini;
        //    cmd.Parameters.Add("@p_ffin", SqlDbType.NChar).Value = dFfin;
        //    cmd.Parameters.Add("@p_idtrabsup", SqlDbType.Int).Value = idTrab;
        //    cmd.Parameters.Add("@p_idtrabdir", SqlDbType.Int).Value = idTrab;
        //    cmd.Parameters.Add("@p_idtrabsupn", SqlDbType.Int).Value = idTrabSupn;
        //    cmd.Parameters.Add("@p_idtrabdirn", SqlDbType.Int).Value = idTrabDirn;
        //    cmd.Parameters.Add("@p_usuumod", SqlDbType.NChar).Value = "JAV";
        //    cmd.Parameters.Add("@p_prgumod", SqlDbType.NChar).Value = "SQL";

        //    objConexion.asignarConexion(cmd);

        //    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

        //    objConexion.cerrarConexion();

        //    DataTable dtNombreEmpleado = new DataTable();
        //    Adapter.Fill(dtNombreEmpleado);
        //    return dtNombreEmpleado;
        //}

        //public DataTable obtActualizaSudyDir2(int iOpcion, int idTrab, string dFini, string dFfin, int idTrabSupn, int idTrabDirn/*, int idTrabSupn, int idTrabDirn*/)
        //{
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandText = @"usp_rechtinccalif_d_suid";
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    Conexion objConexion = new Conexion();
        //    objConexion.asignarConexion(cmd);
        //    iOpcion = 2;

        //    cmd.Parameters.Add("@p_idtrab", SqlDbType.Int).Value = idTrab;
        //    cmd.Parameters.Add("@p_opcion", SqlDbType.Int).Value = iOpcion;
        //    cmd.Parameters.Add("@p_FechaInicio", SqlDbType.NChar).Value = dFini;
        //    cmd.Parameters.Add("@p_FechaFin", SqlDbType.NChar).Value = dFfin;
        //    cmd.Parameters.Add("@p_idtrabsup", SqlDbType.Int).Value = idTrabSupn;
        //    cmd.Parameters.Add("@p_idtrabdir", SqlDbType.Int).Value = idTrabDirn;
        //    //cmd.Parameters.Add("@p_idtrabsupn", SqlDbType.Int).Value = idTrabSupn;
        //    //cmd.Parameters.Add("@p_idtrabdirn", SqlDbType.Int).Value = idTrabDirn;
        //    cmd.Parameters.Add("@p_cvincidencia", SqlDbType.Int).Value = 0;
        //    cmd.Parameters.Add("@p_tiempoemp", SqlDbType.Int).Value = 0;
        //    cmd.Parameters.Add("@p_tiempoprof", SqlDbType.Int).Value = 0;
        //    cmd.Parameters.Add("@p_stsup", SqlDbType.Int).Value = 0;
        //    cmd.Parameters.Add("@p_fhautsup", SqlDbType.NChar).Value = dFfin;
        //    cmd.Parameters.Add("@p_stdir", SqlDbType.Int).Value = 0;
        //    cmd.Parameters.Add("@p_premiopunt", SqlDbType.Int).Value = 0;
        //    cmd.Parameters.Add("@p_premioasis", SqlDbType.Int).Value = 0;
        //    cmd.Parameters.Add("@p_stinc", SqlDbType.Int).Value = 0;
        //    cmd.Parameters.Add("@p_archivo", SqlDbType.NChar).Value = dFfin;
        //    cmd.Parameters.Add("@p_fhautdir", SqlDbType.NChar).Value = dFfin;
        //    cmd.Parameters.Add("@p_usuumod", SqlDbType.NChar).Value = "JAV";
        //    cmd.Parameters.Add("@p_prgumod", SqlDbType.NChar).Value = "SQL";

        //    objConexion.asignarConexion(cmd);

        //    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

        //    objConexion.cerrarConexion();

        //    DataTable dtNombreEmpleado = new DataTable();
        //    Adapter.Fill(dtNombreEmpleado);
        //    return dtNombreEmpleado;
        //}



        ////metodo data table para llenar grid de busqueda
        //public DataTable obtIncidencias(int iOpcion, int idTrab, string dFini, string dFfin)
        //{
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandText = @"usp_rechtinccalif_suid";
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    Conexion objConexion = new Conexion();
        //    objConexion.asignarConexion(cmd);

        //    cmd.Parameters.Add("@p_opcion", SqlDbType.Int).Value = iOpcion;
        //    cmd.Parameters.Add("@p_idtrab", SqlDbType.Int).Value = idTrab;
        //    cmd.Parameters.Add("@p_fini", SqlDbType.NChar).Value = dFini;
        //    cmd.Parameters.Add("@p_ffin", SqlDbType.NChar).Value = dFfin;
        //    cmd.Parameters.Add("@p_idtrabsup", SqlDbType.Int).Value = idTrab;
        //    cmd.Parameters.Add("@p_idtrabdir", SqlDbType.Int).Value = idTrab;
        //    cmd.Parameters.Add("@p_idtrabsupn", SqlDbType.Int).Value = idTrab;
        //    cmd.Parameters.Add("@p_idtrabdirn", SqlDbType.Int).Value = idTrab;
        //    cmd.Parameters.Add("@p_usuumod", SqlDbType.NChar).Value = "JAV";
        //    cmd.Parameters.Add("@p_prgumod", SqlDbType.NChar).Value = "SQL";

        //    objConexion.asignarConexion(cmd);

        //    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

        //    objConexion.cerrarConexion();

        //    DataTable dtIncidencias = new DataTable();
        //    Adapter.Fill(dtIncidencias);
        //    return dtIncidencias;
        //} // public DataTable obtrelojeschecadores(int p_opcion, int p_cvreloj, string p_descripcion, string p_usuumod, string p_prgumodr)

    }
}
