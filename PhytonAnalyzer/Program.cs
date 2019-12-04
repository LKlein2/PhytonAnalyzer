using PythonAnalyzer;
using System;
using System.IO;
using System.Linq;

namespace PhytonAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            var wat = System.Reflection.Assembly.GetExecutingAssembly().Location;
            Console.WriteLine("Informe o caminho do diretorio de saída:");
            var outDir = Console.ReadLine();
            //var outDir = "C:\\Temp";

            Console.WriteLine("Informe o caminho do arquivo de entrada:");
            var inDir = Console.ReadLine();
            //var inDir = "C:\\Temp\\code.py";
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

            var teste = analyzer.Tkns.Select(tk => tk.Type);

            Syntactic syntactic = new Syntactic(analyzer.Tkns);
            if (syntactic.Analyze())
            {
                Console.WriteLine("Análise sintática foi concluida com sucesso.");
            }
            else
            {
                Console.WriteLine("Ocorreu um erro na análise sintática no token número " + syntactic.index);
            }
            Console.ReadKey();
        }
    }
}
