using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlTypes;
using Microsoft.Data.SqlClient;

namespace MSSQL_Connect_.NET_7._0_SampleCode
{
    public class BCS
    {
        // global Connection String;
       private static string connectionString = "";
        #region AddProgram Through CreateProgram Procedure
        public static bool AddProgram(string programCode, string description)
        {
            //Persist Security Info=False; Integrated Security=True; not required 
            //for local :Persist Security Info=False; Integrated Security=True
           

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("CreateProgram", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        command.Parameters.Add("@ProgramCode", SqlDbType.VarChar).Value = programCode;
                        command.Parameters.Add("@Description", SqlDbType.VarChar).Value = description;

                        command.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error Occure - {ex.Message}");
                        return false;
                    }
                    finally
                    {
                        conn.Close();

                    }

                }
            }
            return true;
            // Console.WriteLine("Success");
        }
        #endregion 
    }
}
