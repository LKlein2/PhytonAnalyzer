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

        bool IsEndOfLine, IsCounting;
        int contador1, contador2;

        public Analyzer()
        {
            this.TokenList = Tokens.GetTokens().ToList();
        }

        public void Analyze(string code)
        {
            int tknNmb = 0;
            int index = 0;
            int column = 0;
            int line = 1;

            while (index < code.Length)
            {
                Tokens TokenMatch = null;
                int matchLength = 0;

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
                    if (TokenMatch.Type.Equals("TKN_A_TAB") && (IsCounting || IsEndOfLine))
                    {
                        contador1++;
                        IsCounting = true;
                    }
                    else if (TokenMatch.Type.Equals("TKN_A_TAB"))
                    {
                        tknNmb++;
                        Tkns.Add(new Tkn(tknNmb, "ERRO", "TOKEN INVALIDO ENCONTRADO", column, line));
                        break;
                    }
                    else if (IsCounting || IsEndOfLine)
                    {
                        IsCounting = false;
                        if (contador1 > contador2)
                        {
                            for (int i = 0 ; i < (contador1 - contador2) ; i++)
                            {
                                tknNmb++;
                                Tkns.Add(new Tkn(tknNmb, "TKN_INDENT", "", column, line));
                            }
                            contador2 = contador1;
                        }
                        else if (contador2 > contador1)
                        {
                            for (int i = 0; i < (contador2 - contador1); i++)
                            {
                                tknNmb++;
                                Tkns.Add(new Tkn(tknNmb, "TKN_DEDENT", "", column, line));
                            }
                            contador2 = contador1;
                        }
                        contador1 = 0;
                    }
                    IsEndOfLine = (TokenMatch.Type.Equals("TKN_FIM_LINHA"));

                    var value = code.Substring(index, matchLength);
                    if (!TokenMatch.IsIgnored)
                    {   if (TokenMatch.Type.Equals("TKN_FIM_LINHA"))
                        {
                            tknNmb++;
                            Tkns.Add(new Tkn(tknNmb, TokenMatch.Type, "{ FIM_LINHA }", column, line));
                        }
                        else
                        {
                            tknNmb++;
                            Tkns.Add(new Tkn(tknNmb, TokenMatch.Type, "{ " + value + " }", column, line));
                        }
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
                    Tkns.Add(new Tkn(tknNmb, "ERRO", "TOKEN INVALIDO ENCONTRADO", column, line));
                    break;
                }
            }
            tknNmb++;
            Tkns.Add(new Tkn(tknNmb, "TKN_EOF", "{ EOF }", column, line));
        }
    }
}
