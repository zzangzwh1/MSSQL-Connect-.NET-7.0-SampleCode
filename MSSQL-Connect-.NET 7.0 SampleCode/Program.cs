﻿using System.Data;
using System.Data.SqlTypes;
using Microsoft.Data.SqlClient;


namespace MSSQL_Connect_.NET_7._0_SampleCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create Program - AddProgram
  
            bool isAddedProgram =  BCS.AddProgram("BAIST6", "This is BAIST5 TEST");
            if (isAddedProgram)
            {
                Console.WriteLine($"Program is Successfully Added");
            }
            else
            {
                Console.WriteLine($"Failed! ");
            }
        }
    }
}