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
    public class Students
    {
        #region GetStudentsByProgram
        public static void GetStudentsByProgram(string programCode)
        {
            StringBuilder sBuilder = new StringBuilder();
   
            using (SqlConnection conn = new SqlConnection(BCS.connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("GetStudentsByProgram", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProgramCode", programCode);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                if (reader.FieldCount - 2 == i)
                                {
                                    Console.Write($"{reader.GetName(i)} \t\t\t");
                                }
                                else
                                {

                                    Console.Write($"{reader.GetName(i)} \t");
                                }


                            }
                            Console.WriteLine("");
                            while (reader.Read())
                            {
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    Console.Write($"{reader[i]}\t\t");
                                    //list.Add(reader[i].ToString());
                                    if (reader[i].ToString() == "")
                                    {
                                        Console.Write($"{reader[i]}\t");
                                    }
                                }

                                Console.WriteLine();
                            }
                        }

                        else
                        {
                            Console.WriteLine($"No Data Found!");
                        }

                      

                    }
                }
            }

     
        }
    }
    #endregion
}
