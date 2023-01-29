using System;
using System.IO;

namespace PhotoManager
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory();
            DirectoryInfo d = new DirectoryInfo(path); //Assuming Test is your Folder

            FileInfo[] Files = d.GetFiles(); //Getting Text files
           
            foreach (FileInfo file in Files)
            {
                string created = Convert.ToString(file.CreationTime);
                string year = created.Substring(6, 4);
                try
                {
                    if (!Directory.Exists(year))
                    {
                        // Try to create the directory.
                        DirectoryInfo di = Directory.CreateDirectory(year);
                    }
                }
                catch (IOException ioex)
                {
                    Console.WriteLine(ioex.Message);
                }
                Console.ReadKey();
            }
            /*
             * 
            int choice ;
            Console.WriteLine("---------Menu---------");
            Console.WriteLine("1. Sort by creation year");
            Console.WriteLine("2. Sort by creation year and month");
            Console.WriteLine("3. Sort by creation year, month and day");
            Console.WriteLine("4. Exit application");
            Console.Write("Chose option: ");
            start:
                try
                { 
                    choice = int.Parse(Console.ReadLine());
            
                }
                catch (Exception ex) 
                {
                    Console.WriteLine(ex.Message);
                    goto start;
                }
            switch (choice)
            {
                case 1: break; 
                case 2: break; 
                case 3: break; 
                case 4:
                    Console.WriteLine("Thank you for using our application!");
                    System.Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Option not listed in the meny");
                    goto start;
            }
            */



        }
    }
}