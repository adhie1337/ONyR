using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ONyRDataHandlerClassesGenerator
{
    class Program
    {
        private static Dictionary<String, String> properties = new Dictionary<String, String>();

        private const string TEMPLATE_FILE_NAME = "Templates.txt";

        private enum ErrorCode
        {
            InvalidArg=0, LockedFile
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to ONyR datahandler classes generator application!");

            if(args.Count() != 0)
            {
                if (args.Count() > 1 || args[0] != "-clean")
                {
                    Error(ErrorCode.InvalidArg, args[0]);
                }
                else
                {
                    CleanUp();
                }
            }
            else
            {
                properties["DataTableName"] = null;
                properties["EntityType"] = null;
                properties["EntityTypePlural"] = null;

                Generate();
            }

            Console.WriteLine("Done! Bye-bye!");
            Console.ReadKey();
        }

        private static void CleanUp()
        {
            Console.WriteLine("Cleaning up...");
            DeleteDirectory("generated");
            Directory.CreateDirectory("generated");
        }

        private static void Generate()
        {
            Console.WriteLine("For cleaning the generated code, please run with -clean command line argument!");
            Console.WriteLine("For the proper generaion, please add a few properties.");

            string[] keys = properties.Keys.ToArray();

            foreach (string actProperty in keys)
            {
                bool correct = false;
                do
                {
                    Console.Write(actProperty + ": ");
                    properties[actProperty] = Console.ReadLine().Trim();
                    Console.Write(String.Format("\"{0}\" = \"{1}\".\nIs that correct(y/n)? ", actProperty, properties[actProperty]));
                    string answer = Console.ReadLine().Trim().ToLower();
                    correct = answer == "y" || answer == "";
                }
                while (!correct);
            }

            CleanUp();

            StreamReader reader = new StreamReader(TEMPLATE_FILE_NAME);
            StreamWriter writer = null;
            string directoryname = null;

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();

                if (line.StartsWith("//@"))
                {
                    if (line.StartsWith("//@templatename:"))
                    {
                        if (writer != null)
                        {
                            writer.Close();
                        }

                        Console.WriteLine("Writing file: {0}", FormatLine(line.Substring("//@templatename:".Length)));
                    }
                    else if (line.StartsWith("//@filename:"))
                    {
                        SwitchDirectory(directoryname);
                        string filename = FormatLine(line.Substring("//@filename:".Length));
                        writer = new StreamWriter(filename);
                    }
                    else if (line.StartsWith("//@directory:"))
                    {
                        directoryname = FormatLine(line.Substring("//@directory:".Length));
                    }
                }
                else
                {
                    writer.WriteLine(FormatLine(line, false));
                }
            }

            if (writer != null)
            {
                writer.Close();
            }

            if (reader != null)
            {
                reader.Close();
            }
        }

        private static void Error(ErrorCode code, string additionalInfo=null)
        {
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

        private static string FormatLine(string line, bool trim=true)
        {
            string[] keys = properties.Keys.ToArray();

            foreach (string actProperty in keys)
            {
                line = line.Replace(String.Format("<<{0}>>", actProperty), properties[actProperty]);
            }

            return trim ? line.Trim() : line;
        }

        private static void SwitchDirectory(string directoryName)
        {
            string current = Directory.GetCurrentDirectory();
            
            if (current.IndexOf("generated") != -1)
            {
                Directory.SetCurrentDirectory(current.Substring(0, current.IndexOf("generated") - 1));
                Directory.SetCurrentDirectory("generated");
            }
            else
            {
                Directory.SetCurrentDirectory("generated");
            }

            if (!Directory.Exists(directoryName))
            {
                Directory.CreateDirectory(directoryName);
            }

            Directory.SetCurrentDirectory(directoryName);

        }

        private static void DeleteDirectory(String directoryName)
        {
            string baseDirectory = Directory.GetCurrentDirectory();

            if (Directory.Exists(directoryName))
            {
                Directory.SetCurrentDirectory(directoryName);
                string[] directories = Directory.GetDirectories(Directory.GetCurrentDirectory());

                foreach (string dir in directories)
                {
                    DeleteDirectory(dir);
                }

                directories = Directory.GetFiles(Directory.GetCurrentDirectory());

                foreach (string dir in directories)
                {
                    File.Delete(dir);
                }

                Directory.SetCurrentDirectory(baseDirectory);
                Directory.Delete(directoryName);
            }
        }
    }
}
