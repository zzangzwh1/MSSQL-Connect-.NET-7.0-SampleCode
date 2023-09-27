using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlTypes;


namespace MSSQL_Connect_.NET_7._0_SampleCode
{
    public class NorthWind
    {
        private static string connectionString = @"Data Source= dev1.baist.ca; initial catalog=Northwind; User Id =wcho2; password=Whdnjsgur1!; ";

        #region North Wind GetCustomersByCountry
        public static void GetCustomersByCountry(string country)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("wcho2.GetCustomersByCountry", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Country", country);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            Console.WriteLine("Country Columns : ");
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                Console.Write($"{reader.GetName(i)};");
                            }
                            Console.WriteLine("");
                            Console.WriteLine("---------------");
                            Console.WriteLine("Country Value : ");
                            while (reader.Read())
                            {
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    Console.Write($"{reader[i]};");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Country is not exists!");
                        }
                    }
                }
            }
        }
        #endregion

        #region NorthWind GetCategory

        public static void GetCategory(int categoryId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("wcho2.GetCategory", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CategoryID", categoryId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            Console.WriteLine("Category Columns : ");
                            for(int i =0; i <reader.FieldCount; i++)
                            {
                                Console.Write($"{reader.GetName(i)};");
                            }
                            Console.WriteLine("");
                            Console.WriteLine("-");
                            Console.WriteLine("Category Value : ");
                            while (reader.Read())
                            {
                                for(int i =0; i<reader.FieldCount; i++)
                                {
                                    Console.Write($"{reader[i]};");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Data Not Found! Try Other Category ID");
                        }
                    }
                }

            }
        }

        #endregion

    }
}
