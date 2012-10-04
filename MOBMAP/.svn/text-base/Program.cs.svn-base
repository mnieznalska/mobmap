using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace MOBMAP
{
    static class Program
    {

        public static string RootPath = null;
        public static string dbPath = null;
        public static string dbFullPath = null;
        public static string dbName = "GpsDb";
        [MTAThread]
        static void Main()
        {
            try
            {
                Program.RootPath = Directory.GetCurrentDirectory();
                dbPath = Program.RootPath + @"\Databases\";
                dbFullPath = dbPath + dbName;

            }
            catch (Exception e)
            {
                Program.RootPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
                dbPath = Program.RootPath + @"\Databases\";
                dbFullPath = dbPath + dbName;
            }
            
            Application.Run(new Form1());
        }
    }
}