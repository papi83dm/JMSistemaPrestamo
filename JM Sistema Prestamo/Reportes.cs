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

        public SqlDataReader CuotasPendientesReporteSUMA(string d1, string d2)
        {
            //"SELECT CONVERT(varchar, CAST(sum(HE_MONTO)  as Money), 1) as Capital ,CONVERT(varchar, CAST(sum(HE_DESC)  as Money), 1) as Interes ,CONVERT(varchar, CAST(sum(HE_MORA)  as Money), 1) as Mora   FROM  recibos where HE_FECHA >='" + d1 + "' and HE_FECHA <='" + d2 + "'  "
            string sql = String.Format("SELECT CONVERT(varchar,CAST(SUM(HI_CAPITAL) AS MONEY),1) AS CAPITAL,CONVERT(varchar,CAST(SUM(HI_BALCAP) AS MONEY),1) AS BCAPITAL ,CONVERT(varchar,CAST(SUM(HI_INTERES) AS MONEY),1) as INTERES ,CONVERT(varchar,CAST(SUM(HI_BALINT) AS MONEY),1) AS BINTERES FROM historia where HI_FECHA>='{0}' and HI_FECHA <='{1}' and HI_TIPO='F' and ( HI_BALCAP>0 or HI_BALINT >0)", d1, d2);
            SqlDataReader dtp = dbc.query_single(sql);
            return dtp;
        }

        public DataTable GastosOperacionalesReporte(string d1, string d2)
        {
            string sql = String.Format("SELECT GASTOID AS GASTO,CONVERT(VARCHAR(15), FECHA, 105) AS FECHA,CONCEPTO,DETALLE ,CONVERT(varchar,CAST(CANTIDAD AS MONEY),1) AS CANTIDAD FROM gastos where FECHA>='{0}' and FECHA <='{1}'", d1, d2);
            DataTable dtp = dbc.query(sql);
            return dtp;
        }
    }
}
