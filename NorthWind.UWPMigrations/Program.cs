using System;

namespace NorthWind.UWPMigrations
{
    class Program
    {
        static void Main(string[] args)
        {


            //THE ONLY PURPOSE OF THIS PROJECT IS TO HELP US CREATING MIGRATIONS FOR:
            // Northwind.UWPCpreApp
            // NorthWind.DAL.SQLlite
            // It needs a references to NorthWind.DAL.SQLlite and NorthWind.Entitites
            // Install Microsoft.EntityFrameworkCore.Tools
            // Add-Migration InitialCreate -StartupProject NorthWind.UWPMigrations

            Console.WriteLine("Hello World!");
        }
    }
}
