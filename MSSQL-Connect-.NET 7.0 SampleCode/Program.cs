using System.Data;
using System.Data.SqlTypes;
using Microsoft.Data.SqlClient;


namespace MSSQL_Connect_.NET_7._0_SampleCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create Program - AddProgram

            #region CreateProgram
            /* bool isAddedProgram =  BCS.AddProgram("BAIST7", "This is BAIST5 TEST");
             if (isAddedProgram)
             {
                 Console.WriteLine($"Program is Successfully Added");
             }
             else
             {
                 Console.WriteLine($"Failed! ");
             }*/
            #endregion

            #region EnrollStudent
            /*    bool isAddedStudent = BCS.AddStudent("8", "MD", "Cho", "wcho2@nait.ca", "BASIT4");
                if (isAddedStudent)
                {
                    Console.WriteLine("Student is Successfully Added");

                }
                else
                {
                    Console.WriteLine("Error Occured !--Fail!!");
                }*/
            #endregion

            #region FindStudent

            string result = BCS.FindStudent("1");
            Console.WriteLine(result);

            #endregion



        }
    }
}