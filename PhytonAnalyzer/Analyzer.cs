using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace PhytonAnalyzer
{
    public class Analyzer
    {
        private List<Tokens> TokenList = new List<Tokens>();
        private Regex EndOfLine = new Regex(@"\r\n", RegexOptions.Compiled);
        public List<Tkn> Tkns = new List<Tkn>();
        public int TabLine, TabCode;
        public bool IsEndOfLine;

        public Analyzer()
        {
            this.TokenList = Tokens.GetTokens().ToList();
        }

        public void Analyze(string code)
        {
            int index = 0;
            int column = 0;
            int line = 1;

            while (index < code.Length)
            {
                Tokens TokenMatch = null;
                int matchLength = 0;

                //Procura na lista de tokens uma expressão regular que se encaixe.
                foreach (var token in TokenList)
                {
                    var triedMatch = token.RegularExpression.Match(code, index);

                    if (triedMatch.Success && triedMatch.Index == index)
                    {
                        TokenMatch = token;
                        matchLength = triedMatch.Length;
                        break;
                    }
                }

                if (TokenMatch != null)
                {
                    if (TokenMatch.Type.Equals("TKN_A_TAB"))
                    {
                        TabLine++;
                    }
                    
                    if (IsEndOfLine) {
                        if (TabCode > TabLine)
                        {
                            Tkns.Add(new Tkn(index, "TKN_F_TAB", "", column, line));
                            TabCode = TabLine;
                        }
                        else if (TabLine > TabCode)
                        {
                            TabCode = TabLine;
                        }
                        TabLine = 0;
                    }

                    if (TokenMatch.Type.Equals("FIM_LINHA"))
                    {
                        IsEndOfLine = true;
                    }
                    else
                    {
                        IsEndOfLine = false;
                    }

                    var value = code.Substring(index, matchLength);
                    if (!TokenMatch.IsIgnored)
                    {
                        Tkns.Add(new Tkn(index, TokenMatch.Type, value, column, line));
                    }

                    var endOfLine = EndOfLine.Match(value);
                    if (endOfLine.Success)
                    {
                        line += 1;
                        column = value.Length - (endOfLine.Index + endOfLine.Length);
                    }
                    else
                    {
                        column += matchLength;
                    }
                    index += matchLength;
                }
                else
                {
                    Tkns.Add(new Tkn(index, "ERRO", "TOKEN INVALIDO ENCONTRADO", column, line));
                    break;
                }
            }
        }
    }
}
