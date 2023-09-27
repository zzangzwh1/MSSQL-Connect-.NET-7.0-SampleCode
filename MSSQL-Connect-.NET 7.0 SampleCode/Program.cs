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
                   Console.WriteLine("Error Occurred - FAILED!");
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
                  Console.WriteLine("Error Occurred - FAILED!");
              }*/


            #endregion

            #region FindProgram

            //  BCS.FindProgram("BAIST1");
            #endregion

            #region GetStudentByProgram
            // Students.GetStudentsByProgram("BAIST");

            #endregion


            //---------------------------------Demonstration  --------------------------

            #region Demonstraion-AddProgram

            /*  bool isAddedProgram = Programs.AddProgram("BAIST8", "Thisis BAIST8");

              if (isAddedProgram)
              {
                  Console.WriteLine("Successfully Program is Added");
              }
              else
              {
                  Console.WriteLine($"Failled! ");
              }*/

            #endregion

            #region Demonstration GetProgram
            Console.WriteLine("--- Get Program ---");

            Programs.GetProgram("BASIT4");

            #endregion
            Console.WriteLine();
            #region Demonstration AddStudent
            Console.WriteLine("--- Add Student ---");

            bool isAddStudnet = Students.AddStudent("10", "Mike", "Cho", "", "BAISTfffffffffffffffffffffffffffffffffffffffff");
            if (isAddStudnet)
            {
                Console.WriteLine("Students are successfully Added");
            }
            else
            {
                Console.WriteLine("Failed!");
            }
            #endregion
            Console.WriteLine();

            #region UpdateStudent
            Console.WriteLine("--- Update Student ---");
           bool isStudentUpdated =  Students.UpdateStudent("1", "fsf", "CC", "fsdfds@nait.ca" );
            if (isStudentUpdated)
            {
                Console.WriteLine("Students are successfully Updated!");
            }
            else
            {
                Console.WriteLine("Failed!");
            }
            #endregion

            #region Demonstration Delete
            Console.WriteLine("-- Delete Student ---");
            bool isStudentDelete = Students.DeleteStudent("1");
            if (isStudentDelete)
            {
                Console.WriteLine("Students are successfully Deleted!");
            }
            else
            {
                Console.WriteLine("Failed!");
            }

            #endregion

            #region Demonstration GetStudent
            Console.WriteLine($"-----Get Student---");
            string getStudent = Students.GetStudent("2");

            Console.WriteLine(getStudent);

            #endregion

            #region Demonstration GetStudentsByProgram
            Console.WriteLine("GetStudentsByProgram");

            Students.GetStudentsByProgram("BAIST2");

            #endregion


            #region NorthWind ---GetCustomersByCountry
            //Demonstrtion North Wind
            Console.WriteLine("--------- GetCustomersByCountry --------");
            NorthWind.GetCustomersByCountry("UK");

            #endregion
            Console.WriteLine("");
            Console.WriteLine("");

            #region NorthWind ---GetCategory
            Console.WriteLine("--------- GetCategory --------");
            NorthWind.GetCategory(4);
            #endregion


            Console.ReadLine();

        }
    }
}