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

        /**
 Esta seccion de codigo es para ejecutar las operaciones de SQL que envia el Mapper. 
Este ejemplo tambien sirve para ejectuar operaciones de SQL que no devuelven una lista completa.
La logica es asignar los parametros de operation a command y luego ejecutar el metodo de ExecuteReader 
Exectute reader guarda todo lo que retorne el query de SQL. 
Reader tiene varios metodos, entre los cuales tiene un getSqlInt que devuelve el valor de la columna X (en este caso 0) y lo convierte a un Int 
Se puede cambiar el tipo de dato en la firma por cualquier tipo. 
 * */

        public Dictionary<string, object> ExectuteStoreProcedureWithQueryLogin(SqlOperation operation)
        {
            var connection = new SqlConnection(this.connectionString);
            var command = new SqlCommand();

            var correo = operation.Parametros[0];
            var clave = operation.Parametros[1];

            command.Connection = connection;
            command.CommandText = operation.NombreProcedimiento;
            command.CommandType = CommandType.StoredProcedure;

            foreach (var param in operation.Parametros)
            {
                command.Parameters.Add(param);
            }

            connection.Open();

            var reader = command.ExecuteReader();

            var lstResult = new List<Dictionary<string, object>>();


            var dicc = new Dictionary<string, object>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        dicc.Add(reader.GetName(i), reader.GetValue(i));
                    }
                }
            }
            return dicc;
        }
    }
}
