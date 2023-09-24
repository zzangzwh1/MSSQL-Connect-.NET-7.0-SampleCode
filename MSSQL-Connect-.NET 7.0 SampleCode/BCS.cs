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
        //global connection string is initialized so it can access to multiple methods
        private static string connectionString = @"Data Source= dev1.baist.ca; Initial Catalog=wcho2; User ID=wcho2; Password=Whdnjsgur1!;  ";

        #region AddProgram Through CreateProgram Procedure
        public static bool AddProgram(string programCode, string description)
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
                        Console.WriteLine($"Error Occurs - {ex.Message}");
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

        #region Add Student using the stored procedure Enroll Student

        public static bool AddStudent(string studentId, string firstName, string lastName, string email, string programCode)
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
                        Console.WriteLine($"Error Occured - {ex.Message}");
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


    }
}
