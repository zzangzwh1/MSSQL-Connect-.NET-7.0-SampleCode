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
    public class Programs
    {
        public static bool AddProgram(string programCode, string description)
        {
            using (SqlConnection conn = new SqlConnection(BCS.connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("AddProgram", conn))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ProgramCode", programCode);
                        command.Parameters.AddWithValue("@Description", description);
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error Occured In @AddProgram : {ex.Message}");
                        return false;
                    }
                    finally
                    {
                        conn.Close();
                    }



                }

            }
            return true;
        }
        public static void GetProgram(string programCode)
        {
            using (SqlConnection conn = new SqlConnection(BCS.connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("GetProgram", conn))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ProgramCode", programCode);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    Console.Write($"{reader.GetName(i)}\t");
                                }
                                Console.WriteLine();

                                while (reader.Read())
                                {
                                    for (int i = 0; i < reader.FieldCount; i++)
                                    {
                                        Console.Write($"{reader[i]}\t\t");
                                    }

                                }

                            }
                            else
                            {
                                Console.WriteLine("No data Found.");

                            }
                        }
                          
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine($"Error Occurreed - GetProgram : {ex.Message}");
                    }
                    finally
                    {
                        conn.Close();
                    }
                  
                }
            }

        }
        

    }
}

