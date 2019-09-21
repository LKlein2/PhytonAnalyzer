using System;
using System.Collections.Generic;
using System.Text;

namespace PhytonAnalyzer
{
    public class Tkn
    {
        public int Index { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public int Column { get; set; }
        public int Line { get; set; }

        public Tkn(int index, string type, string value, int column, int line)
        {
            Index = index;
            Type = type;
            Value = value;
            Column = column;
            Line = line;
        }

        public override string ToString()
        {
            return ($"{Index} TOKEN: {Type} VALOR: {Value} COL: {Column} LINE: {Line}");
        }
    }
}
