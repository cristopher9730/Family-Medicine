using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dao
{
    public class SqlDao
    {
        private string connectionString = String.Empty;

        private static SqlDao instance = new SqlDao();

        public SqlDao()
        {
            connectionString = ConfigurationManager.ConnectionStrings["FamilyMedicine-bd"].ConnectionString;
        }

        //Se crea el metodo para manejar una instancia unica
        public static SqlDao ObtenerInstancia()
        {
            if (instance == null)
                instance = new SqlDao();
            return instance;
        }

        public void EjecProcedimientoAlmacenado(SqlOperation operation)
        {
            var lstResult = new List<Dictionary<string, object>>();

            var connection = new SqlConnection(this.connectionString);
            var command = new SqlCommand();

            command.Connection = connection;
            command.CommandText = operation.NombreProcedimiento;
            command.CommandType = CommandType.StoredProcedure;

            foreach (var param in operation.Parametros)
            {
                command.Parameters.Add(param);
            }

            connection.Open();
            command.ExecuteNonQuery();
        }

        public List<Dictionary<string, object>> EjecProcedimientoAlmacenadoConConsulta(SqlOperation operation)
        {
            var lstResult = new List<Dictionary<string, object>>();

            var connection = new SqlConnection(this.connectionString);
            var command = new SqlCommand();

            command.Connection = connection;
            command.CommandText = operation.NombreProcedimiento;
            command.CommandType = CommandType.StoredProcedure;

            foreach (var param in operation.Parametros)
            {
                command.Parameters.Add(param);
            }

            connection.Open();

            var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var dicc = new Dictionary<string, object>();
                    for (var fieldCounter = 0; fieldCounter < reader.FieldCount; fieldCounter++)
                    {
                        dicc.Add(reader.GetName(fieldCounter), reader.GetValue(fieldCounter));
                    }
                    lstResult.Add(dicc);
                }
            }
            return lstResult;

        }
    }
}
