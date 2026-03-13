using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace onpe_sql.Controllers.bd
{
    public class clsBD
    {
        private readonly string _cadenaConexion;
        private string _queryActual = "";

        public clsBD(IConfiguration configuration)
        {
            _cadenaConexion = configuration.GetConnectionString("DefaultConnection");
        }

        internal void Sentencia(string sql)
        {
            _queryActual = sql;
        }

        internal DataTable getDataTable()
        {
            DataTable dt = new DataTable();

            if (string.IsNullOrWhiteSpace(_queryActual))
                return dt;

            using SqlConnection cn = new SqlConnection(_cadenaConexion);
            using SqlCommand cmd = new SqlCommand(_queryActual, cn);
            cmd.CommandTimeout = 120;
            using SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);
            return dt;
        }

        internal string[] getRegistro()
        {
            DataTable dt = getDataTable();
            if (dt.Rows.Count == 0) return null;

            return System.Array.ConvertAll(dt.Rows[0].ItemArray, x => x?.ToString().Trim() ?? "");
        }

        internal string[][] getRegistros()
        {
            DataTable dt = getDataTable();
            if (dt.Rows.Count == 0) return null;
            int i = 0;
            string[][] mRegistros = new string[dt.Rows.Count][];
            foreach (DataRow dr in dt.Rows)
            {
                mRegistros[i++] = System.Array.ConvertAll(dr.ItemArray, x => x?.ToString().Trim() ?? "");
            }
            return mRegistros;
        }
    }
}
