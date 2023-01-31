using System;
using System.IO;
using static System.Net.WebRequestMethods;

namespace PhotoManager
{
    internal class Program
    {
        public static string path = Directory.GetCurrentDirectory();

        static void Main(string[] args)
        {
            DirectoryInfo d = new DirectoryInfo(path); //Assuming Test is your Folder
            Console.Write("Please provide file extension ex: '.jpg': ");
            string FileExt = "*" + Console.ReadLine();
            FileInfo[] Files = d.GetFiles(FileExt); //Getting Text files    
          
            if (Files.Length == 0)
            {
                Console.WriteLine("No files in current directory or wrong extension.");
                Console.WriteLine("Check everything again and re-run the program.");
                System.Environment.Exit(1);
            }
         
            int choice ;
            bool sYear = false;
            bool sMonth = false;
            bool sDay = false;
            Console.WriteLine("---------Menu---------");
            Console.WriteLine("1. Sort by creation year");
            Console.WriteLine("2. Sort by creation year and month");
            Console.WriteLine("3. Sort by creation year, month and day");
            Console.WriteLine("4. Exit application");
            while (true)
            {
                Console.Write("Chose option: ");            
                try
                {
                    choice = int.Parse(Console.ReadLine());


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }


                switch (choice)
                {
                    case 1:
                        sYear = true;
                        break;
                    case 2:
                        sYear = true;
                        sMonth = true;
                        break;
                    case 3:
                        sYear = true;
                        sMonth = true;
                        sDay = true;
                        break;
                    case 4:
                        Console.WriteLine("Thank you for using our application");
                        System.Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Option not listed in the menu");
                        continue;
                }
                break;
            }
            SortFiles(Files, sYear, sMonth, sDay);

        }


        public static void SortFiles(FileInfo[] files, bool sYear, bool sMonth, bool sDay)
        {
            int counter = 0;
            string folder_path;
            string date = "";
            foreach (FileInfo file in files)
            {
                // get the creation date and then try to get year of the file creation
                // after that create a variable to store the path for creating a folder
                string created = Convert.ToString(file.CreationTime);
                // if sDay is true means the rest is also true, less typing
                if (sDay == true)
                {
                    date = created.Substring(6, 4) + "\\" + created.Substring(3, 2) + "\\" + created.Substring(0, 2);
                    folder_path = Path.Combine(path, date);
                }
                else if (sMonth == true)
                {
                    date = created.Substring(6, 4) + "\\" + created.Substring(3, 2);
                    folder_path = Path.Combine(path, date);


                }
                else
                {
                    date = created.Substring(6, 4);
                    folder_path = Path.Combine(path, date);
                }
                
                try
                {
                    if (!Directory.Exists(folder_path))
                    {
                        DirectoryInfo di = Directory.CreateDirectory(folder_path);
                    }
                    System.IO.File.Move(file.Name, folder_path + "\\" + file.Name);
                    
                }
                catch (IOException ioex)
                {
                    Console.WriteLine(ioex.Message);
                    counter++;

                }
            }
            if (counter == 0)
            {

                Console.WriteLine("\nAll files were moved succesfully. Thank you for using our program!");
            }
            else
            {
                Console.WriteLine(counter + " errors occured. Check the progress in appropriate directory.");
            }
            
        }
    }
}