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
        #region AddStudent
        public static bool AddStudent(string studentId, string firstName, string lastName, string email, string programCode)
        {
            if (email == "")
                email = null;
            using (SqlConnection connection = new SqlConnection(BCS.connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("AddStudent", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    // AddwithValue not necessary define the valuetype because i will be inserting data through the paramter
                    // however if i decide to you command.parameters.add() then i need to insert value type that matches with the procedure
                    try
                    {
                        command.Parameters.AddWithValue("@StudentID", studentId);
                        command.Parameters.AddWithValue("@FirstName", firstName);
                        command.Parameters.AddWithValue("@LastName", lastName);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@ProgramCode", programCode);

                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error Occurred - {ex.Message}");
                        return false;

                    }
                    finally
                    {
                        connection.Close();
                    }



                }

            }
            return true;
        }

        #endregion

        #region UpdateStudent
        public static bool UpdateStudent(string studentId, string firstName, string lastName, string email)
        {
            if (email == "")
                email = null;
            using (SqlConnection conn = new SqlConnection(BCS.connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("UpdateStudent", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        command.Parameters.AddWithValue("@StudentID", studentId);
                        command.Parameters.AddWithValue("@FirstName", firstName);
                        command.Parameters.AddWithValue("@LastName", lastName);

                        command.Parameters.AddWithValue("@Email", email);
                        command.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error Occurred {ex.Message}");
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

        #endregion

        #region DeleteStudent
        public static bool DeleteStudent(string studentId)
        {
            using (SqlConnection conn = new SqlConnection(BCS.connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("DeleteStudent", conn))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@StudentID", studentId);
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error Occurred {ex.Message}");
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

        #endregion

        #region FindStudent
        public static string GetStudent(string studentID)
        {
            StringBuilder strings = new StringBuilder();
            using (SqlConnection connection = new SqlConnection(BCS.connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("GetStudent", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    try
                    {

                        command.Parameters.AddWithValue("@StudentID", studentID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    //if condition added so result output present equally
                                    if (i == reader.FieldCount - 2)
                                    {
                                        Console.Write($"{reader.GetName(i)}\t\t\t");
                                    }
                                    else
                                    {

                                        Console.Write($"{reader.GetName(i)}\t");
                                    }
                                }
                                Console.WriteLine();
                                while (reader.Read())
                                {

                                    for (int i = 0; i < reader.FieldCount; i++)
                                    {
                                        strings.Append(reader[i].ToString());
                                        strings.Append("\t\t");

                                    }
                                }

                            }
                            else
                            {
                                Console.WriteLine("No Data Found");
                            }



                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error Occurred {ex.Message}");
                    }
                    finally
                    {
                        connection.Close();
                    }



                }
            }
            return strings.ToString();
        }
        #endregion

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
