using System;
using System.IO;

namespace PhytonAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            var wat = System.Reflection.Assembly.GetExecutingAssembly().Location;
            //string lines = File.ReadAllText(@"C:\temp\code.py");
            string lines = File.ReadAllText(@"D:\temp\Csharp\PhytonAnalyzer\PhytonAnalyzer\Codes\code.py");

            Analyzer analyzer = new Analyzer();
            analyzer.Analyze(lines);

            foreach (Tkn tkn in analyzer.Tkns)
            {
                Console.WriteLine(tkn.ToString());
            }
            Console.ReadKey();
        }
    }
}
