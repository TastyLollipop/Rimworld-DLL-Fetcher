using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace ConsoleApp
{
    public static class Program
    {
        static void Main(string[] args)
        {
            string folderPath = args[0];
            string resultingPath = folderPath + Path.DirectorySeparatorChar + "Results";

            if (!Directory.Exists(folderPath))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[ERROR] > Mod folder is missing");
            }

            else
            {
                if (!Directory.Exists(resultingPath)) Directory.CreateDirectory(resultingPath);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Starting assembly extraction");

                string[] files = Directory.GetFiles(folderPath, "*.dll", SearchOption.AllDirectories);
                foreach (string file in files)
                {
                    FileInfo info = new FileInfo(file);
                    try
                    {
                        File.Copy(file, resultingPath + Path.DirectorySeparatorChar + info.Name);

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"[Assembly] > {info.Name}");
                    }
                    catch { }
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("[Success] > All mod assemblies have been extracted");
                Console.WriteLine("[Info] > Fetch the 'Results' folder inside the mods folder");
            }

            Console.ReadKey();
        }
    }
}
