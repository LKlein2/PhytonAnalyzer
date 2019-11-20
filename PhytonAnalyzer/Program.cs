using PythonAnalyzer;
using System;
using System.IO;

namespace PhytonAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            var wat = System.Reflection.Assembly.GetExecutingAssembly().Location;
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

            Syntactic syntactic = new Syntactic(analyzer.Tkns);
            if (syntactic.Analysis())
            {
                Console.WriteLine("Análise sintática foi concluida com sucesso.");
            }
            else
            {
                Tkn erro = syntactic.ErroToken();
                Console.WriteLine("Ocorreu um erro na análise sintática:");
                Console.WriteLine(erro.ToString());
            }
        }
    }
}
