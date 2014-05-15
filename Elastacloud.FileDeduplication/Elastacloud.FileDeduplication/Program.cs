using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elastacloud.FileDeduplication
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Usage: Elastacloud.FileDeduplication.exe path/to/files");
            }

            var baseDirectory = args[0];
            var files = Directory.GetFiles(baseDirectory);

            var content = new FileContentInfoBuilder().Parse(files);

            var filesGroupedByContentEquality = content.GroupBy(file => file.Hash);
            foreach (var group in filesGroupedByContentEquality)
            {
                if (group.Count() > 1)
                {
                    Console.Beep();
                    Console.ForegroundColor = ConsoleColor.White;Console.BackgroundColor= ConsoleColor.Red;
                    Console.WriteLine("FOUND DUPLICATE");
                }

                Console.WriteLine("The group {0} has {1} files: {2}", group.Key, group.Count(), 
                    string.Join(", ", group.Select(g=>g.Path).ToArray()));

                Console.ResetColor();
            }

            Console.ReadLine();
        }
    }
}
