﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/*
 * Write a program to traverse the directory C:\WINDOWS
 * and all its subdirectories recursively and 
 * to display all files matching the mask *.exe. Use the class System.IO.Directory.
*/

namespace TraverseDirectory
{
    class Program
    {
        static Queue<string> exeFiles = new Queue<string>();

        static void Main(string[] args)
        {
            string path = "C:\\Windows";

            GetDirectories(path);

            Console.WriteLine(string.Join("\n", exeFiles));
        }

        private static void GetDirectories(string path)
        {
            try
            {
                GetFilesFromDirectory(path);

                string[] currentDirectories = Directory.GetDirectories(path);
                foreach (var directory in currentDirectories)
                {
                    GetDirectories(directory);
                }
            }
            catch (UnauthorizedAccessException)
            {
                return;
            }
        }
  
        private static void GetFilesFromDirectory(string path)
        {
            string[] currentPathFiles = Directory.GetFiles(path);
            foreach (var file in currentPathFiles)
            {
                if (file.EndsWith(".exe"))
                {
                    exeFiles.Enqueue(file);
                }
            }
        }
    }
}
