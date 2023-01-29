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
            Console.Write("Please provide file extension ex: '.jpg': ");
            string FileExt = "*" + Console.ReadLine();
            FileInfo[] Files = d.GetFiles(FileExt); //Getting Text files
           
            foreach (FileInfo file in Files)
            {
                Console.WriteLine(file);
                // get the creation date and then try to get year of the file creation
                // after that create a variable to store the path for creating a folder
                string created = Convert.ToString(file.CreationTime);
                string year = created.Substring(6, 4);
                string year_path = Path.Combine(path, year);
                try
                {
                    if (Directory.Exists(year_path))
                    {
                        // Try to create the directory.
                        Console.WriteLine("Directory exists");
                        
                        
                    }
                    else
                    {
                        Console.WriteLine("Directory does not exist");
                        DirectoryInfo di = Directory.CreateDirectory(year_path);
                    }
                    try
                    {
                        File.Move(file.Name, year_path+"\\"+file.Name);
                        Console.WriteLine("Moved");
                    }
                    catch (Exception e)
                    { 
                        Console.WriteLine("File could not be moved");
                        Console.WriteLine(e.Message);
                    }
                    
                }
                catch (IOException ioex)
                {
                    Console.WriteLine(ioex.Message);

                }
            }
            Console.ReadKey();
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