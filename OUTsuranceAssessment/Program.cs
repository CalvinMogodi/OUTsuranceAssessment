using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OUTsuranceAssessment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Started");
            FileManager fileManager = new FileManager();
            Console.WriteLine("Processing ...");
            if (fileManager.ReadCSVAndWriteTextFile())           
                Console.WriteLine("Completed");
            else
                Console.WriteLine("Failed");
        }
    }
}
