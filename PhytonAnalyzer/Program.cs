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
            //string lines = File.ReadAllText(@"D:\temp\Csharp\PhytonAnalyzer\PhytonAnalyzer\Codes\code.py");
            //string lines = File.ReadAllText(@"C:\Users\Lucas\Source\Repos\LKlein2\PhytonAnalyzer\PhytonAnalyzer\Codes\code.py");
            //string lines = File.ReadAllText(@"C:\Users\lucas.klein\Source\Repos\PhytonAnalyzer\PhytonAnalyzer\Codes\code.py");
            Console.WriteLine("Informe o caminho do diretorio de saída:");
            var outDir = Console.ReadLine();

            Console.WriteLine("Informe o caminho do arquivo de entrada:");
            var inDir = Console.ReadLine();
            string lines = File.ReadAllText(inDir);

            Analyzer analyzer = new Analyzer();
            analyzer.Analyze(lines);

            using (StreamWriter file = new System.IO.StreamWriter(outDir + @"\output.txt"))
            {
                foreach (Tkn tkn in analyzer.Tkns)
                {
                    file.WriteLine(tkn.ToString());
                }
            }
        }
    }
}
