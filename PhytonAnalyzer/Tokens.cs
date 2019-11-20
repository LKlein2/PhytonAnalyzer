using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PhytonAnalyzer
{
    public class Tokens
    {
        public bool IsIgnored { get; set; }
        public Regex RegularExpression { get; set; }
        public string Type { get; set; }

        public Tokens(string type, Regex regularExpression) : this(type, regularExpression, false)
        {
        }

        public Tokens(string type, Regex regularExpression, bool isIgnored)
        {
            this.Type = type;
            this.RegularExpression = regularExpression;
            this.IsIgnored = isIgnored;
        }

        public static IEnumerable<Tokens> GetTokens()
        {
            List<Tokens> tokenList = new List<Tokens>();

            tokenList.Add(new Tokens("TKN_FIM_LINHA", new Regex(@"\r\n")));
            tokenList.Add(new Tokens("TKN_A_TAB", new Regex(@"\t"), true));

            //IGNORAR
            tokenList.Add(new Tokens("ESPACO_BRANCO", new Regex(@"\s"), true));

            //TIPOS
            //tokenList.Add(new Tokens("TIPO_STRING", new Regex(@"[a-zA-Z\s+]+")));
            tokenList.Add(new Tokens("TIPO_STRING", new Regex(("\"") + @"(\w+)" + ("\""))));
            tokenList.Add(new Tokens("TIPO_FLOAT", new Regex(@"\d+(\.\d{1,2})m?")));
            tokenList.Add(new Tokens("TIPO_INT", new Regex(@"\d+")));

            //OPERADORES ARITMETICOS
            tokenList.Add(new Tokens("TKN_SOMA", new Regex(@"[+]")));
            tokenList.Add(new Tokens("TKN_SUBTR", new Regex(@"[-]")));
            tokenList.Add(new Tokens("TKN_MULT", new Regex(@"[*]")));
            tokenList.Add(new Tokens("TKN_DIV", new Regex(@"[/]")));
            tokenList.Add(new Tokens("TKN_ATRIBUICAO", new Regex(@"[=]")));
            tokenList.Add(new Tokens("TKN_ATRIBUI", new Regex(@".\s=|.=")));
            tokenList.Add(new Tokens("TKN_MULTIPLICA", new Regex(@".\s\*\s.|.\*.")));
            tokenList.Add(new Tokens("TKN_DIVIDE", new Regex(@".\s/|./")));
            tokenList.Add(new Tokens("TKN_SOMA", new Regex(@".\s\+|.\+")));
            tokenList.Add(new Tokens("TKN_DIMINUI", new Regex(@".\s-|.-")));
            tokenList.Add(new Tokens("TKN_LISTA_VAZIA", new Regex(@"\[\]")));
            tokenList.Add(new Tokens("TKN_DEF_FUNCAO", new Regex(@"def")));

            //OPERADORES LOGICOS
            tokenList.Add(new Tokens("TKN_COMP_IGUAL", new Regex(@"==")));
            tokenList.Add(new Tokens("TKN_COMP_DIFERENTE", new Regex(@"!=")));
            tokenList.Add(new Tokens("TKN_COMP_MENOR_IGUAL", new Regex(@"<=")));
            tokenList.Add(new Tokens("TKN_COMP_MAIOR_IGUAL", new Regex(@">=")));
            tokenList.Add(new Tokens("TKN_COMP_MAIOR", new Regex(@">")));
            tokenList.Add(new Tokens("TKN_COMP_MENOR", new Regex(@"<")));

            tokenList.Add(new Tokens("TKN_AND", new Regex(@"and ")));
            tokenList.Add(new Tokens("TKN_OR", new Regex(@"or ")));

            //LACOES E CONDICODICOES E O PRINT
            tokenList.Add(new Tokens("TKN_IF", new Regex(@"\b(if)\s")));
            tokenList.Add(new Tokens("TKN_PRINT", new Regex(@"\b(print)")));
            tokenList.Add(new Tokens("TKN_FOR", new Regex(@"\b(for .)\s")));
            tokenList.Add(new Tokens("TKN_WHILE", new Regex(@"\b(while)\s")));
            tokenList.Add(new Tokens("TKN_DO", new Regex(@"\b(do)\s")));
            tokenList.Add(new Tokens("TKN_IN", new Regex(@"\b(in)\s")));
            tokenList.Add(new Tokens("TKN_RANGE", new Regex(@"\b(range)\s")));
            tokenList.Add(new Tokens("TKN_ELIF", new Regex(@"\b(elif)")));
            tokenList.Add(new Tokens("TKN_ELSE", new Regex(@"\b(else)")));
            tokenList.Add(new Tokens("TKN_BREAK", new Regex(@"\b(break)")));

            //Marcadores
            tokenList.Add(new Tokens("TKN_A_CON", new Regex(@"\[")));
            tokenList.Add(new Tokens("TKN_F_CON", new Regex(@"\]")));
            tokenList.Add(new Tokens("TKN_PONTO", new Regex(@"\.")));
            tokenList.Add(new Tokens("TKN_VIRGULA", new Regex(@"\,")));
            tokenList.Add(new Tokens("TKN_DOIS_PONTOS", new Regex(@"\:")));
            tokenList.Add(new Tokens("TKN_A_PAR", new Regex(@"\(")));
            tokenList.Add(new Tokens("TKN_F_PAR ", new Regex(@"\)")));
            tokenList.Add(new Tokens("TKN_ID", new Regex(@"[A-Za-z_][a-zA-Z0-9_]+")));
            tokenList.Add(new Tokens("TKN_ID", new Regex(@"[a-zA-Z]")));
            return tokenList;
        }
    }
}   