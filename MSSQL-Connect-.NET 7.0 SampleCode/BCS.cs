﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlTypes;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace MSSQL_Connect_.NET_7._0_SampleCode
{
    public class BCS
    {

        //global connection string is initialized so it can access to multiple methods 
        public static string connectionString = @"Data Source= dev1.baist.ca; initial catalog=wcho2; User Id =wcho2; password=Whdnjsgur1!; ";
 
       

        #region CreateProgram
        public static bool CreateProgram(string programCode, string description)
        {
            //Persist Security Info=False; Integrated Security=True; not required 
            //for local :Persist Security Info=False; Integrated Security=True

            /*
              Used using Statement
                because using statement implement IDispososable interface
                which it manage database connection and help automatically dispose when its out of scope
                it also helps prevent resource leaking. 
                connection will be automaillaly dispose so i believe connection.close() is not necessary
                but i added so it looks more clear
             */

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
                        Console.WriteLine($"Error Occurred - {ex.Message}");
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

        #region EnrollStudent
        public static bool EnrollStudent(string studentId, string firstName, string lastName, string email, string programCode)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("EnrollStudent", connection))
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

        #region FindStudent
        public static string FindStudent(string studentID)
        {
            StringBuilder strings = new StringBuilder();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("FindStudent", connection))
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

        #region ModifyStudent
        public static bool ModifyStudent(string studentId, string firstName, string lastName, string email)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("ModifyStudent", conn))
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

        #region  RemoveStudent
        public static bool RemoveStudent(string studentId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("RemoveStudent", conn))
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

        #region FindProgram

        public static void FindProgram(string programCode)
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("FindProgram", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    try
                    {

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
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error Occurred {ex.Message}");
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        #endregion


       
      

    }
}

