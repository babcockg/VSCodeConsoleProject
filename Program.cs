using System;
using System.IO;

namespace VSCodeConsoleApp
{
    class Program
    {
        int depth = 0;

        public string spc ( int width )
        {
            return new string ( '.' , width*2 );
        }

        public void EnumerateDirectory(DirectoryInfo dir)
        {
            depth ++;
            try
            {
                System.Console.WriteLine($"{spc(depth)}{dir.FullName}");

                var files = dir.GetFiles();
                foreach ( var file in files )
                {
                    System.Console.WriteLine($"{spc(depth+1)}{file.Name}");
                }
                var subDirectories = dir.GetDirectories();
                foreach (var subDirectory in subDirectories)
                {
                    EnumerateDirectory(subDirectory);
                }
            }
            catch 
            {

            }
            depth --;
        }

        static void Main(string[] args)
        {
            Program prog = new Program();
            prog.EnumerateDirectory(new DirectoryInfo(@"C:\"));
        }
    }
}
