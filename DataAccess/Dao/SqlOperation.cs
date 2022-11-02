using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dao
{
    public class SqlOperation
    {
        public string NombreProcedimiento { get; set; }
        public List<SqlParameter> Parametros;

        public SqlOperation()
        {
            Parametros = new List<SqlParameter>();
        }

        public void AddVarcharParam(string ParamName, string ParamValue)
        {
            Parametros.Add(new SqlParameter("@" + ParamName, ParamValue));
        }

        public void AddIntergerParam(string ParamName, int ParamValue)
        {
            Parametros.Add(new SqlParameter("@" + ParamName, ParamValue));
        }
    }
}
