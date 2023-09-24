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


            /*   string result = BCS.FindStudent("1");
               Console.WriteLine(result);*/

            #endregion

            #region ModifyStudent
            /*   bool isModifyStudent = BCS.ModifyStudent("1", "MC", "CHOI", "wcho2@nait.ca");
               if (isModifyStudent)
               {
                   Console.WriteLine("Successfully Modifed!");
               }
               else
               {
                   Console.WriteLine("Error Occured - FAILED!");
               }*/

            #endregion

            #region RemoveStudent

          /*  bool isRemoveStudent = BCS.RemoveStudent("8");
            if (isRemoveStudent)
            {
                Console.WriteLine("Succesfully Removed!");
            }
            else
            {
                Console.WriteLine("Error Occured - FAILED!");
            }*/


            #endregion

            #region FindProgram

            BCS.FindProgram("BAIST");
            #endregion 



        }
    }
}