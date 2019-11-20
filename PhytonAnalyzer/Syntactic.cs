using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhytonAnalyzer;

namespace PythonAnalyzer
{
    public class Syntactic
    {
        int index;
        String presentToken;
        List<Tkn> tokenList;
        Boolean elif;

        public Syntactic(List<Tkn> tokenList)
        {
            this.tokenList = tokenList;
            this.presentToken = tokenList[0].Type;
            this.index = 0;
            this.elif = false;
        }

        public Tkn ErroToken()
        {
            index--;
            return tokenList[index];
        }

        public Boolean Analysis()
        {
            if (Start())
                return true;
            else
                return false;
        }

        private void nextToken()
        {
            this.index++;
            if (index < tokenList.Count)
                this.presentToken = tokenList[index].Type;
            else
                this.presentToken = null;
        }

        private void backToken()
        {
            this.index--;
            this.presentToken = tokenList[index].Type;
        }

        // Start -> DEF ID (PARAM_LIST) : INDENT PROGRAM EOF 
        private Boolean Start()
        {
            //if (presentToken == "TKN_DEF_FUNCAO")
            //{
            //    nextToken();
                if (presentToken == "TKN_ID")
                {
                    nextToken();
                    if (Param_List())
                    {
                        nextToken();
                        if (presentToken == "TKN_DOIS_PONTOS")
                        {
                            nextToken();
                            if (presentToken == "TKN_IDENT")
                            {
                                nextToken();
                                if (Program())
                                {
                                    nextToken();
                                    if (presentToken == "TKN_EOF")
                                        return true;
                                    else if (presentToken == "TKN_DEIDENT")
                                    {
                                        nextToken();
                                        if (Start())
                                            return true;
                                        else
                                        {
                                            return false;
                                        }
                                    }
                                    else return false;
                                }
                                else return false;
                            }
                            else return false;
                        }
                        else return false;
                    }
                    else return false;
                }
                else return false;
            //}
            //else return false;
        }

        // Param_List -> (Parameters)
        private Boolean Param_List()
        {
            if (presentToken == "TKN_A_PAR")
            {
                nextToken();
                if (Parameters())
                {
                    nextToken();
                    if (presentToken == "TKN_F_PAR")
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
            else
                return false;
        }

        // Parameters -> TYPE ID ADD_PARAMETERS | EMPTY
        private Boolean Parameters()
        {
            if (Type())
            {
                nextToken();
                if (presentToken == "TKN_ID")
                {
                    nextToken();
                    if (Add_Parameters())
                    {
                        return true;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            else
            {
                backToken();
                return true;
            }
        }

        // Add_Parameters -> ,ADD_PARAMETERS | EMPTY
        private Boolean Add_Parameters()
        {
            if (presentToken == "TKN_VIRGULA")
            {
                nextToken();
                if (Parameters())
                    return true;
                else
                    return false;
            }
            else
            {
                backToken();
                return true;
            }
        }


        // Program P -> ATTRIBUTION P | AUTO_OPERATION P | IF P | WHILE P | FOR P | PRINT P | FUNCTION P | EMPTY
        private Boolean Program()
        {

            if (Auto_Operation())
            {
                nextToken();
                if (Program())
                    return true;
                else
                    return false;
            }
            else if (Function())
            {
                nextToken();
                if (Program())
                    return true;
                else
                    return false;
            }
            else if (Attribution())
            {
                nextToken();
                if (Program())
                    return true;
                else
                    return false;
            }
            else if (If_Statment())
            {
                nextToken();
                if (Program())
                    return true;
                else
                    return false;
            }
            else if (While())
            {
                nextToken();
                if (Program())
                    return true;
                else
                    return false;
            }
            else if (For())
            {
                nextToken();
                if (Program())
                    return true;
                else
                    return false;
            }
            else if (Print())
            {
                nextToken();
                if (Program())
                    return true;
                else
                    return false;
            }
            else
            {
                backToken();
                return true;
            }
        }
        // FUNCTION -> ID (ID_LIST)
        // ID_LIST -> ID ADD_ID | EMPTY
        // ADD_ID -> ,ID ADD_ID | EMPTY
        private Boolean Function()
        {
            if (presentToken == "TKN_ID")
            {
                nextToken();
                if (presentToken == "TKN_A_PAR")
                {
                    nextToken();
                    if (ID_List())
                    {
                        nextToken();
                        if (presentToken == "TKN_F_PAR")
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else return false;
                }
                else
                {
                    backToken();
                    return false;
                }
            }
            else return false;
        }

        private Boolean ID_List()
        {
            if (presentToken == "TKN_ID")
            {
                nextToken();
                if (Add_ID())
                    return true;
                else
                    return false;
            }
            else
            {
                backToken();
                return true;
            }
        }

        private Boolean Add_ID()
        {
            if (presentToken == "TKN_VIRGULA")
            {
                nextToken();
                if (presentToken == "TKN_ID")
                {
                    nextToken();
                    if (Add_ID())
                    {
                        return true;
                    }
                    else return false;
                }
                else return false;
            }
            else
            {
                backToken();
                return true;
            }
        }

        // AUTO_OPERATION -> ++ID | --ID | ID AUTO_OPERATION'
        // AUTO_OPERATION' -> ++ | --
        private Boolean Auto_Operation()
        {
            if (presentToken == "TKN_SOMA")
            {
                nextToken();
                if (presentToken == "TKN_SOMA")
                {
                    nextToken();
                    if (presentToken == "TKN_ID")
                        return true;
                    else
                        return false;
                }
                else return false;
            }
            else if (presentToken == "TKN_SUBTR")
            {
                nextToken();
                if (presentToken == "TKN_SUBTR")
                {
                    nextToken();
                    if (presentToken == "TKN_ID")
                        return true;
                    else
                        return false;
                }
                else return false;
            }
            else if (presentToken == "TKN_ID")
            {
                nextToken();
                if (presentToken == "TKN_SOMA")
                {
                    nextToken();
                    if (presentToken == "TKN_SOMA")
                        return true;
                    else
                    {
                        backToken();
                        backToken();
                        return false;
                    }

                }
                else if (presentToken == "TKN_SUBTR")
                {
                    nextToken();
                    if (presentToken == "TKN_SUBTR")
                        return true;
                    else
                    {
                        backToken();
                        backToken();
                        return false;
                    }
                }
                else
                {
                    backToken();
                    return false;
                }
            }
            else return false;
        }

        // PRINT -> PRINT (PRINT') | PRINT PRINT' | PRINT PRINT'
        // PRINT' -> PRINT_LIST | STRING | ID
        // PRINT_LIST -> STRING ADD_PRINT | ID ADD_PRINT
        // ADD_PRINT -> + STRING ADD_PRINT | + ID ADD_PRINT | EMPTY
        private Boolean Print()
        {
            if (presentToken == "TKN_PRINT")
            {
                nextToken();
                if (presentToken == "TKN_A_PAR")
                {
                    nextToken();
                    if (Print_List())
                    {
                        nextToken();
                        if (presentToken == "TKN_F_PAR")
                            return true;
                        else
                            return false;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (presentToken == "TIPO_STRING")
                {
                    return true;
                }
                else if (presentToken == "TKN_ID")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else return false;
        }

        private Boolean Print_List()
        {
            if (presentToken == "TIPO_STRING" || presentToken == "TKN_ID")
            {
                nextToken();
                if (Add_Print())
                    return true;
                else
                    return false;
            }
            else return false;
        }

        private Boolean Add_Print()
        {
            if (presentToken == "TKN_SOMA")
            {
                nextToken();
                if (presentToken == "TKN_ID" || presentToken == "TIPO_STRING")
                {
                    nextToken();
                    if (Add_Print())
                        return true;
                    else
                        return false;
                }
                else return false;
            }
            else
            {
                backToken();
                return true;
            }
        }

        // FOR -> ID IN ID (INTEGER) INDENT PROGRAM DEDENT
        private Boolean For()
        {
            if (presentToken == "TKN_FOR")
            {
                nextToken();
                if (presentToken == "TKN_ID")
                {
                    nextToken();
                    if (presentToken == "TKN_IN")
                    {
                        nextToken();
                        if (presentToken == "TKN_ID")
                        {
                            nextToken();
                            if (presentToken == "TKN_A_PAR")
                            {
                                nextToken();
                                if (presentToken == "TIPO_INT")
                                {
                                    nextToken();
                                    if (presentToken == "TKN_F_PAR")
                                    {
                                        nextToken();
                                        if (presentToken == "TKN_IDENT")
                                        {
                                            nextToken();
                                            if (Program())
                                            {
                                                nextToken();
                                                if (presentToken == "TKN_DEIDENT")
                                                {
                                                    return true;
                                                }
                                                else
                                                {
                                                    return false;
                                                }
                                            }
                                            else return false;
                                        }
                                        else return false;
                                    }
                                    else return false;
                                }
                                else return false;
                            }
                            else return false;
                        }
                        else return false;
                    }
                    else return false;
                }
                else return false;
            }
            else return false;
        }

        // WHILE -> WHILE (CONDITION_LIST) INDENT PROGRAM DEDENT 
        private Boolean While()
        {
            if (presentToken == "TKN_WHILE")
            {
                nextToken();
                if (presentToken == "TKN_A_PAR")
                {
                    nextToken();
                    if (Condition_List())
                    {
                        nextToken();
                        if (presentToken == "TKN_F_PAR")
                        {
                            nextToken();
                            if (presentToken == "TKN_IDENT")
                            {
                                nextToken();
                                if (Program())
                                {
                                    nextToken();
                                    if (presentToken == "TKN_DEIDENT")
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                                else return false;
                            }
                            else return false;
                        }
                        else return false;
                    }
                    else return false;
                }
                else return false;
            }
            else return false;
        }

        // IF_STATEMENT -> IF (CONDITION_LIT) INDENT PROGRAM DEDENT ELSE_ELIF
        // ELSE_ELIF -> ELSE INDENT PROGRAM DEDENT | ELIF IF_STATMENT | EMPTY
        private Boolean If_Statment()
        {
            if (presentToken == "TKN_IF" || elif)
            {
                elif = false;
                nextToken();
                if (presentToken == "TKN_A_PAR")
                {
                    nextToken();
                    if (Condition_List())
                    {
                        nextToken();
                        if (presentToken == "TKN_F_PAR")
                        {
                            nextToken();
                            if (presentToken == "TKN_IDENT")
                            {
                                nextToken();
                                if (Program())
                                {
                                    nextToken();
                                    if (presentToken == "TKN_DEIDENT")
                                    {
                                        nextToken();
                                        if (else_elif())
                                            return true;
                                        else
                                            return false;
                                    }
                                    else if (presentToken == "TKN_EOF")
                                    {
                                        backToken();
                                        return true;
                                    }
                                    else if (presentToken == "TKN_ELSE")
                                        if (else_elif())
                                            return true;
                                        else
                                            return false;
                                    else
                                        return false;
                                }
                                else return false;
                            }
                            else return false;
                        }
                        else return false;
                    }
                    else return false;
                }
                else return false;
            }
            else return false;
        }

        private Boolean else_elif()
        {
            if (presentToken == "TKN_ELSE")
            {
                nextToken();
                if (presentToken == "TKN_IDENT")
                {
                    nextToken();
                    if (Program())
                    {
                        nextToken();
                        if (presentToken == "TKN_DEIDENT")
                            return true;
                        else if (presentToken == "TKN_EOF")
                        {
                            backToken();
                            return true;
                        }
                        else
                            return false;
                    }
                    else return false;
                }
                else return false;
            }
            else if (presentToken == "TKN_ELIF")
            {
                elif = true;
                if (If_Statment())
                    return true;
                else
                    return false;
            }
            else
            {
                backToken();
                return true;
            }
        }

        // Condition_List -> EXP ADD_CONDITION 
        // Add_Condition -> && EXP | || EXP | EMPTY 
        // Exp_Conditional E -> EXP == EXP | EXP != EXP | EXP > EXP | EXP < EXP | EXP >= EXP | EXP <= EXP 

        private Boolean Condition_List()
        {
            if (Exp_Conditional())
            {
                nextToken();
                if (Add_Condition())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private Boolean Add_Condition()
        {
            if (presentToken == "TK.VERTBAR" || presentToken == "TK.AMPER")
            {
                nextToken();
                if (Exp_Conditional())
                    return true;
                else
                    return false;
            }
            else
            {
                backToken();
                return true;
            }
        }

        private Boolean Exp_Conditional()
        {
            if (Expression())
            {
                nextToken();
                if (presentToken == "TKN_ATRIBUICAOEQUAL" || presentToken == "TK.NOTEQUAL" || presentToken == "TK.LESS" ||
                        presentToken == "TK.GREATER" || presentToken == "TK.LESSEQUAL" || presentToken == "TK.GREATEREQUAL")
                {
                    nextToken();
                    if (Expression())
                        return true;
                    else
                        return false;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        // Attribution ->    ID = FUNCTION | ID = EXP | ID += EXP | ID -= EXP | ID *= EXP | ID /= EXP 
        private Boolean Attribution()
        {
            if (presentToken == "TKN_ID")
            {
                nextToken();
                if (presentToken == "TKN_ATRIBUICAO")
                {
                    nextToken();
                    if (Function())
                        return true;
                    else if (Expression())
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
            else
                return false;
        }

        // Exp_Attrib E -> E + E | E-E | E * E | E / E | E ^ E | E and E | E or E | id | ( E ) | TYPE
        // Fatorando
        // Exp_Attrib E -> E E' | id | ( E ) | TYPE em que E' = Exp_Attrib_1
        // Exp_Attrib_1 E' -> + E | - E | * E | / E | ^ E | and E | or E 
        public Boolean Expression()
        {
            if (presentToken == "TKN_ID" || Type())
            {
                nextToken();
                if (presentToken == "TKN_AND" || presentToken == "TKN_OR" || presentToken == "TKN_MULT" ||
                    presentToken == "TKN_DIV" || presentToken == "TKN_SOMA"
                    || presentToken == "TKN_SUBTR")
                {
                    nextToken();
                    if (Expression())
                        return true;
                    else
                        return false;
                }
                else
                {
                    backToken();
                    return true;
                }

            }
            else if (presentToken == "TKN_A_PAR")
            {
                nextToken();
                if (Expression())
                {
                    nextToken();
                    if (presentToken == "TKN_F_PAR")
                    {
                        return true;
                    }
                    else return false;
                }
                else return false;
            }
            else return false;
        }

        private Boolean Type()
        {
            if (presentToken == "TIPO_FLOAT" || presentToken == "TIPO_INT" || presentToken == "TIPO_STRING")
                return true;
            else
                return false;
        }
    }
}
