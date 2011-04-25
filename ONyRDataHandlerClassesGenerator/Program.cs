using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ONyRDataHandlerClassesGenerator
{
    class Program
    {
        private string EntitiyName,
                EntityTypePlural,
                EntityType;

        private enum ErrorCode
        {
            InvalidArg=0, LockedFile
        }

        private string[] properties = new string[] { "EntitiyName", "EntityTypePlural", "EntityType" };

        static void Main(string[] args)
        {
            if(args.Count() != 0)
            {
                if (args.Count() > 1 || args[0] != "-clean")
                {
                    Error();
                }
                else
                {
                    CleanUp();
                }
            }
            else
            {
                Generate();
            }

        }

        private static void CleanUp()
        {
            Console.WriteLine("Welcome to ONyR datahandler classes generator application!");
            Console.WriteLine("Cleaning up...");

            
        }

        private static void Generate()
        {
            Console.WriteLine("Welcome to ONyR datahandler classes generator application!");
            Console.WriteLine("For cleaning the generated code, please run with -clean command line argument!");
            Console.WriteLine("For the proper generaion, please add a few properties.");
        }

        private static void Error(ErrorCode code, string additionalInfo)
        {
            Console.WriteLine("Welcome to ONyR datahandler classes generator application!");

            switch(code)
            {
                case ErrorCode.InvalidArg:
                    Console.WriteLine(String.Format("Commandline argument \"{0}\" is invalid!", additionalInfo));
                    break;
                case ErrorCode.LockedFile:
                    Console.WriteLine(String.Format("The file \"{0}\" cannot be opened!", additionalInfo));
                    break;
            }

            Console.WriteLine("Exiting...");
        }
    }
}
