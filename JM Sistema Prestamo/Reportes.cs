using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient; 

namespace JM_Sistema_Prestamo
{
    class Reportes
    {
        private DBConnection dbc;

        public Reportes()
        {
            this.dbc = new DBConnection(); 
        }

        public DataTable CuotasPendientesReporte(string d1, string d2)
        {
            string sql = String.Format("SELECT PRESTAMOID AS PRESTAMO ,c.CL_NOMBRE,CONVERT(VARCHAR(15), HI_FECHA, 105) as FECHA,HI_DOCUM AS CUOTA ,CONVERT(varchar,CAST(HI_CAPITAL AS MONEY),1) AS CAPITAL,CONVERT(varchar,CAST(HI_BALCAP AS MONEY),1) AS 'B. CAPITAL' ,CONVERT(varchar,CAST(HI_INTERES AS MONEY),1) as INTERES ,CONVERT(varchar,CAST(HI_BALINT AS MONEY),1) AS 'B. INTERES' FROM historia h inner join clientes c on (c.CL_CODIGO=h.CL_CODIGO and c.CL_ACTUAL>0) where HI_FECHA>='{0}' and HI_FECHA <='{1}' and HI_TIPO='F' and ( HI_BALCAP>0 or HI_BALINT >0)", d1, d2);
            DataTable dtp = dbc.query(sql);
            return dtp;
        }

        public DataTable DataCreditoReporte()
        {
            string sql = "SELECT p.PRESTAMOID as PRESTAMO, p.CL_CODIGO as CEDULA,c.CL_NOMBRE as 'NOMBRE Y APELLIDOS',c.CL_DIREC1 as DIRECCION,c.CL_TELEF1 as TELEFONO1,c.CL_TELEF2 as TELEFONO2," +
                " case when CO_CAVEN > 0 then 'S' else 'N' end as STATUS,CONVERT(VARCHAR(15), p.CO_FECHA , 105) as 'PRESTAMO FECHA',CONVERT(varchar,CAST(p.CO_CAPITAL AS MONEY),1) AS 'PRESTAMO MONTO',p.CO_CANPAG as 'CANTIDAD CUOTAS',CONVERT(varchar,CAST(p.CO_ACTUAL AS MONEY),1) AS BALANCE, CONVERT(varchar,CAST((CO_CAPITAL/CO_CANPAG) AS MONEY),1) AS 'MONTO CUOTAS', CONVERT(varchar,CAST(p.CO_CAVEN AS MONEY),1) AS ATRASO" +
                " from prestamos p  inner join clientes c on (p.CL_CODIGO=c.CL_CODIGO)  order by c.CL_NOMBRE";

            DataTable dt = dbc.query(sql);
            return dt;
        }



        public DataTable BalanceClienteReporte()
        {
            string sql = String.Format("SELECT CL_CODIGO as CEDULA ,CL_NOMBRE as Nombre,CONVERT(varchar,CAST(CL_ACTUAL AS MONEY),1) AS CAPITAL,CONVERT(varchar,CAST(CL_INTERES AS MONEY),1) AS Interes   FROM  clientes where CL_ACTUAL>0 order by CL_ACTUAL desc");
            DataTable dtp = dbc.query(sql);
            return dtp;
        }

        public SqlDataReader BalanceClienteReporteSUMA()
        {
            string sql = String.Format("SELECT CONVERT(varchar,CAST(SUM(CL_CAPITAL) AS MONEY),1) AS CAPITAL   FROM  clientes where CL_ACTUAL>0");
            SqlDataReader dtp = dbc.query_single(sql);
            return dtp;
        }

        public SqlDataReader CuotasPendientesReporteSUMA(string d1, string d2)
        {
            //"SELECT CONVERT(varchar, CAST(sum(HE_MONTO)  as Money), 1) as Capital ,CONVERT(varchar, CAST(sum(HE_DESC)  as Money), 1) as Interes ,CONVERT(varchar, CAST(sum(HE_MORA)  as Money), 1) as Mora   FROM  recibos where HE_FECHA >='" + d1 + "' and HE_FECHA <='" + d2 + "'  "
            string sql = String.Format("SELECT CONVERT(varchar,CAST(SUM(HI_CAPITAL) AS MONEY),1) AS CAPITAL,CONVERT(varchar,CAST(SUM(HI_BALCAP) AS MONEY),1) AS BCAPITAL ,CONVERT(varchar,CAST(SUM(HI_INTERES) AS MONEY),1) as INTERES ,CONVERT(varchar,CAST(SUM(HI_BALINT) AS MONEY),1) AS BINTERES FROM historia where HI_FECHA>='{0}' and HI_FECHA <='{1}' and HI_TIPO='F' and ( HI_BALCAP>0 or HI_BALINT >0)", d1, d2);
            SqlDataReader dtp = dbc.query_single(sql);
            return dtp;
        }

        public SqlDataAdapter getPrestamoMoraCuotas(string fecha, string pid)
        {
            string sql = String.Format("SELECT HISTORIAID,h.PRESTAMOID,CL_NOMBRE,HI_DOCUM as CUOTA,h.CL_CODIGO,HI_BALCAP as Capital, HI_BALINT as Interes FROM historia h inner join clientes c on (h.CL_CODIGO=c.CL_CODIGO) WHERE PRESTAMOID={1}  and HI_FECHA <='{0}'  and HI_BALCAP>0 and HI_TIPO='F'  ", fecha, pid);
            SqlDataAdapter dtp = dbc.dt_query(sql);
            return dtp;

        }

        public SqlDataAdapter getPrestamoMoraList(string fecha, string tipo)
        {
            string sql = String.Format("SELECT DISTINCT h.PRESTAMOID as PRESTAMO FROM historia h inner join prestamos p  on (p.PRESTAMOID=h.PRESTAMOID and p.CO_TIPPAG='{1}') where HI_FECHA <='{0}'  and HI_BALCAP>0 and HI_TIPO='F' ",fecha,tipo);
            SqlDataAdapter dtp = dbc.dt_query(sql);
            return dtp;
        }

        public SqlDataAdapter getPrestamoClienteLista()
        {
            string hoy = DateTime.Now.ToString("yyyy-MM-dd");
            string sql = String.Format("SELECT DISTINCT CL_CODIGO as CODIGO FROM historia  where HI_FECHA <'{0}'  and HI_BALCAP>0 and HI_TIPO='F' ", hoy);
            SqlDataAdapter dtp = dbc.dt_query(sql);
            return dtp;
        }

        public SqlDataAdapter getPrestamoClienteCap( string codigo)
        {
            string fecha = DateTime.Now.ToString("yyyy-MM-dd");
            string sql = String.Format("SELECT HISTORIAID,h.PRESTAMOID,HI_DOCUM as CUOTACL_CODIGO,HI_BALCAP as Capital, HI_BALINT as Interes FROM historia  WHERE CL_CODIGO={1}  and HI_FECHA <'{0}'  and HI_BALCAP>0 and HI_TIPO='F'  ", fecha, codigo);
            SqlDataAdapter dtp = dbc.dt_query(sql);
            return dtp;

        }
        public DataTable GastosOperacionalesReporte(string d1, string d2)
        {
            string sql = String.Format("SELECT GASTOID AS GASTO,CONVERT(VARCHAR(15), FECHA, 105) AS FECHA,CONCEPTO,DETALLE ,CONVERT(varchar,CAST(CANTIDAD AS MONEY),1) AS CANTIDAD FROM gastos where FECHA>='{0}' and FECHA <='{1}'", d1, d2);
            DataTable dtp = dbc.query(sql);
            return dtp;
        }

        public void setUpdateCuotaMora(string hid, double mora )
        {
            string sqlIns = "UPDATE historia set HI_MORA=@HI_MORA  WHERE HISTORIAID=@HISTORIAID ";

            SqlCommand cmdIns = new SqlCommand(sqlIns);
            cmdIns.Parameters.AddWithValue("@HI_MORA", mora);
            cmdIns.Parameters.AddWithValue("@HISTORIAID", hid); 
            dbc.query(cmdIns);
        }

        public void setUpdatePrestamoMora(string pid, double mora)
        {
            string sqlIns = "UPDATE prestamos set CO_MORA=@CO_MORA  WHERE PRESTAMOID=@PRESTAMOID";

            SqlCommand cmdIns = new SqlCommand(sqlIns);
            cmdIns.Parameters.AddWithValue("@CO_MORA", mora);
            cmdIns.Parameters.AddWithValue("@PRESTAMOID", pid);
            dbc.query(cmdIns);
            
        }

        public void setUpdatePrestamoCapVen(string pid,double cap,double interes)
        {
            string sqlIns = "UPDATE prestamos set  CO_CAVEN=@CO_CAVEN, CO_BALI=@CO_BALI  WHERE PRESTAMOID=@PRESTAMOID";

            SqlCommand cmdIns = new SqlCommand(sqlIns); 
            cmdIns.Parameters.AddWithValue("@CO_CAVEN", cap);
            cmdIns.Parameters.AddWithValue("@CO_BALI", interes);
            cmdIns.Parameters.AddWithValue("@PRESTAMOID", pid);
            dbc.query(cmdIns);
        }

        

       
    }
}
