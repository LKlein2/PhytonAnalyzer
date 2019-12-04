using PhytonAnalyzer;
using System;
using System.Collections.Generic;
using System.Text;

namespace PythonAnalyzer
{
    public class Syntactic
    {
        // DEFINE TOKENS

        List<Tkn> TokenList;

        int TK1 = 1;   // tkn_def
        int TK2 = 2;   // tkn_if
        int TK3 = 3;   // tkn_a_par
        int TK4 = 4;   // tkn_f_par
        int TK5 = 5;   // tkn_dois_pontos
        int TK6 = 6;   // tkn_fim_linha
        int TK7 = 7;   // tkn_indent
        int TK8 = 8;   // eof
        int TK9 = 9;   // tkn_dedent
        int TK10 = 10; // tkn_id
        int TK11 = 11; // tkn_print
        int TK12 = 12; // tipo_string
        int TK13 = 13; // tkn_soma
        int TK14 = 14; // tkn_for
        int TK15 = 15; // tkn_in
        int TK16 = 16; // tkn_range
        int TK17 = 17; // tipo_int
        int TK18 = 18; // tkn_while
        int TK19 = 19; // tkn_else
        int TK20 = 20; // tkn_elif
        int TK21 = 21; // tkn_comp_igual
        int TK22 = 22; // tkn_comp_diferente
        int TK23 = 23; // tkn_comp_maior
        int TK24 = 24; // tkn_comp_menor
        int TK25 = 25; // tkn_comp_maior_igual
        int TK26 = 26; // tkn_comp_menor_igual
        int TK27 = 27; // tkn_dimin
        int TK28 = 28; // tkn_mult
        int TK29 = 29; // tkn_div
        int TK30 = 30; // tkn_and
        int TK31 = 31; // tkn_or
        int TK32 = 32; // tkn_atribuicao
        int TK33 = 33; // tipo_float

        // Variáveis Globais <o>

        int tk;
        public int index = 0;

        public Syntactic(List<Tkn> tokenList)
        {
            this.TokenList = tokenList;
        }

        public bool Analyze()
        {
            getToken();
            return (START() == 1);
        }

        //Implemente aqui a sua função getToken()

        void getToken()
        {
            string currentToken = TokenList[index].Type.Trim();

            if (currentToken.ToLower().Equals("tkn_def             ".Trim())) tk = 1;
            if (currentToken.ToLower().Equals("tkn_id              ".Trim())) tk = 2;
            if (currentToken.ToLower().Equals("tkn_a_par           ".Trim())) tk = 3;
            if (currentToken.ToLower().Equals("tkn_f_par           ".Trim())) tk = 4;
            if (currentToken.ToLower().Equals("tkn_dois_pontos     ".Trim())) tk = 5;
            if (currentToken.ToLower().Equals("tkn_fim_linha       ".Trim())) tk = 6;
            if (currentToken.ToLower().Equals("tkn_indent          ".Trim())) tk = 7;
            if (currentToken.ToLower().Equals("tkn_eof             ".Trim())) tk = 8;
            if (currentToken.ToLower().Equals("tkn_dedent          ".Trim())) tk = 9;
            if (currentToken.ToLower().Equals("tkn_print           ".Trim())) tk = 10;
            if (currentToken.ToLower().Equals("tipo_string         ".Trim())) tk = 11;
            if (currentToken.ToLower().Equals("tkn_soma            ".Trim())) tk = 12;
            if (currentToken.ToLower().Equals("tkn_for             ".Trim())) tk = 13;
            if (currentToken.ToLower().Equals("tkn_in              ".Trim())) tk = 14;
            if (currentToken.ToLower().Equals("tkn_range           ".Trim())) tk = 15;
            if (currentToken.ToLower().Equals("tipo_int            ".Trim())) tk = 16;
            if (currentToken.ToLower().Equals("tkn_while           ".Trim())) tk = 17;
            if (currentToken.ToLower().Equals("tkn_if              ".Trim())) tk = 18;
            if (currentToken.ToLower().Equals("tkn_else            ".Trim())) tk = 19;
            if (currentToken.ToLower().Equals("tkn_elif            ".Trim())) tk = 20;
            if (currentToken.ToLower().Equals("tkn_comp_igual      ".Trim())) tk = 21;
            if (currentToken.ToLower().Equals("tkn_comp_diferente  ".Trim())) tk = 22;
            if (currentToken.ToLower().Equals("tkn_comp_maior      ".Trim())) tk = 23;
            if (currentToken.ToLower().Equals("tkn_comp_menor      ".Trim())) tk = 24;
            if (currentToken.ToLower().Equals("tkn_comp_maior_igual".Trim())) tk = 25;
            if (currentToken.ToLower().Equals("tkn_comp_menor_igual".Trim())) tk = 26;
            if (currentToken.ToLower().Equals("tkn_dimin           ".Trim())) tk = 27;
            if (currentToken.ToLower().Equals("tkn_mult            ".Trim())) tk = 28;
            if (currentToken.ToLower().Equals("tkn_div             ".Trim())) tk = 29;
            if (currentToken.ToLower().Equals("tkn_and             ".Trim())) tk = 30;
            if (currentToken.ToLower().Equals("tkn_or              ".Trim())) tk = 31;
            if (currentToken.ToLower().Equals("tkn_atribuicao      ".Trim())) tk = 32;
            if (currentToken.ToLower().Equals("tipo_float          ".Trim())) tk = 33;

            index++;
        }

        //START -> tkn_def tkn_id tkn_a_par tkn_f_par tkn_dois_pontos tkn_fim_linha tkn_indent P END | P eof 
        int START()
        {
            if (tk == TK1)
            {// tkn_def
                getToken();
                if (tk == TK2)
                {// tkn_id
                    getToken();
                    if (tk == TK3)
                    {// tkn_a_par
                        getToken();
                        if (tk == TK4)
                        {// tkn_f_par
                            getToken();
                            if (tk == TK5)
                            {// tkn_dois_pontos
                                getToken();
                                if (tk == TK6)
                                {// tkn_fim_linha
                                    getToken();
                                    if (tk == TK7)
                                    {// tkn_indent
                                        getToken();
                                        if (P() == 1)
                                        {
                                            if (END() == 1)
                                            {
                                                return 1;
                                            }
                                            else { return 0; }
                                        }
                                        else { return 0; }
                                    }
                                    else { return 0; }
                                }
                                else { return 0; }
                            }
                            else { return 0; }
                        }
                        else { return 0; }
                    }
                    else { return 0; }
                }
                else { return 0; }
            }
            else if (P() == 1)
            {
                if (tk == TK8)
                {// eof
                    //getToken();
                    return 1;
                }
                else { return 0; }
            }
            else { return 0; }
        }

        //END -> tkn_dedent | eof 
        int END()
        {
            if (tk == TK9)
            {// tkn_dedent
                getToken();
                return 1;
            }
            else if (tk == TK8)
            {// eof
                getToken();
                return 1;
            }
            else { return 0; }
        }

        //P -> ATTRIBUTION P | IF_STATMENT P | WHILE P | FOR P | PRINT P | FUNCTION P | EMPTY_LINE P | ? 
        int P()
        {
            if (ATTRIBUTION() == 1)
            {
                if (P() == 1)
                {
                    return 1;
                }
                else { return 0; }
            }
            else if (IF_STATMENT() == 1)
            {
                if (P() == 1)
                {
                    return 1;
                }
                else { return 0; }
            }
            else if (WHILE() == 1)
            {
                if (P() == 1)
                {
                    return 1;
                }
                else { return 0; }
            }
            else if (FOR() == 1)
            {
                if (P() == 1)
                {
                    return 1;
                }
                else { return 0; }
            }
            else if (PRINT() == 1)
            {
                if (P() == 1)
                {
                    return 1;
                }
                else { return 0; }
            }
            else if (FUNCTION() == 1)
            {
                if (P() == 1)
                {
                    return 1;
                }
                else { return 0; }
            }
            else if (EMPTY_LINE() == 1)
            {
                if (P() == 1)
                {
                    return 1;
                }
                else { return 0; }
            }
            else { return 1; }
        }

        //EMPTY_LINE -> tkn_fim_linha 
        int EMPTY_LINE()
        {
            if (tk == TK6)
            {// tkn_fim_linha
                getToken();
                return 1;
            }
            else { return 0; }
        }

        //FUNCTION -> tkn_id tkn_a_par tkn_f_par tkn_fim_linha 
        int FUNCTION()
        {
            if (tk == TK2)
            {// tkn_id
                getToken();
                if (tk == TK3)
                {// tkn_a_par
                    getToken();
                    if (tk == TK4)
                    {// tkn_f_par
                        getToken();
                        if (tk == TK6)
                        {// tkn_fim_linha
                            getToken();
                            return 1;
                        }
                        else { return 0; }
                    }
                    else { return 0; }
                }
                else { return 0; }
            }
            else { return 0; }
        }

        //PRINT -> tkn_print tkn_a_par RPRINT tkn_f_par tkn_fim_linha 
        int PRINT()
        {
            if (tk == TK10)
            {// tkn_print
                getToken();
                if (tk == TK3)
                {// tkn_a_par
                    getToken();
                    if (RPRINT() == 1)
                    {
                        if (tk == TK4)
                        {// tkn_f_par
                            getToken();
                            if (tk == TK6)
                            {// tkn_fim_linha
                                getToken();
                                return 1;
                            }
                            else { return 0; }
                        }
                        else { return 0; }
                    }
                    else { return 0; }
                }
                else { return 0; }
            }
            else { return 0; }
        }

        //RPRINT -> PRINT_LIST | tipo_string | tkn_id 
        int RPRINT()
        {
            if (PRINT_LIST() == 1)
            {
                return 1;
            }
            else if (tk == TK11)
            {// tipo_string
                getToken();
                return 1;
            }
            else if (tk == TK2)
            {// tkn_id
                getToken();
                return 1;
            }
            else { return 0; }
        }

        //PRINT_LIST -> tipo_string ADD_PRINT | tkn_id ADD_PRINT 
        int PRINT_LIST()
        {
            if (tk == TK11)
            {// tipo_string
                getToken();
                if (ADD_PRINT() == 1)
                {
                    return 1;
                }
                else { return 0; }
            }
            else if (tk == TK2)
            {// tkn_id
                getToken();
                if (ADD_PRINT() == 1)
                {
                    return 1;
                }
                else { return 0; }
            }
            else { return 0; }
        }

        //ADD_PRINT -> tkn_soma tipo_string ADD_PRINT | tkn_soma tkn_id ADD_PRINT | ? 
        int ADD_PRINT()
        {
            if (tk == TK12)
            {// tkn_soma
                getToken();
                if (tk == TK11)
                {// tipo_string
                    getToken();
                    if (ADD_PRINT() == 1)
                    {
                        return 1;
                    }
                    else { return 0; }
                }
                else { return 0; }
            }
            else if (tk == TK12)
            {// tkn_soma
                getToken();
                if (tk == TK2)
                {// tkn_id
                    getToken();
                    if (ADD_PRINT() == 1)
                    {
                        return 1;
                    }
                    else { return 0; }
                }
                else { return 0; }
            }
            else { return 1; }
        }

        //FOR -> tkn_for tkn_id tkn_in tkn_range tkn_a_par COMP_FOR tkn_f_par tkn_dois_pontos tkn_fim_linha tkn_indent P tkn_dedent 
        int FOR()
        {
            if (tk == TK13)
            {// tkn_for
                getToken();
                if (tk == TK2)
                {// tkn_id
                    getToken();
                    if (tk == TK14)
                    {// tkn_in
                        getToken();
                        if (tk == TK15)
                        {// tkn_range
                            getToken();
                            if (tk == TK3)
                            {// tkn_a_par
                                getToken();
                                if (COMP_FOR() == 1)
                                {
                                    if (tk == TK4)
                                    {// tkn_f_par
                                        getToken();
                                        if (tk == TK5)
                                        {// tkn_dois_pontos
                                            getToken();
                                            if (tk == TK6)
                                            {// tkn_fim_linha
                                                getToken();
                                                if (tk == TK7)
                                                {// tkn_indent
                                                    getToken();
                                                    if (P() == 1)
                                                    {
                                                        if (tk == TK9)
                                                        {// tkn_dedent
                                                            getToken();
                                                            return 1;
                                                        }
                                                        else { return 0; }
                                                    }
                                                    else { return 0; }
                                                }
                                                else { return 0; }
                                            }
                                            else { return 0; }
                                        }
                                        else { return 0; }
                                    }
                                    else { return 0; }
                                }
                                else { return 0; }
                            }
                            else { return 0; }
                        }
                        else { return 0; }
                    }
                    else { return 0; }
                }
                else { return 0; }
            }
            else { return 0; }
        }

        //COMP_FOR -> tkn_id | tipo_int 
        int COMP_FOR()
        {
            if (tk == TK2)
            {// tkn_id
                getToken();
                return 1;
            }
            else if (tk == TK16)
            {// tipo_int
                getToken();
                return 1;
            }
            else { return 0; }
        }

        //WHILE -> tkn_while tkn_a_par COMP_WHILE tkn_f_par tkn_dois_pontos tkn_fim_linha tkn_indent P tkn_dedent 
        int WHILE()
        {
            if (tk == TK17)
            {// tkn_while
                getToken();
                if (tk == TK3)
                {// tkn_a_par
                    getToken();
                    if (COMP_WHILE() == 1)
                    {
                        if (tk == TK4)
                        {// tkn_f_par
                            getToken();
                            if (tk == TK5)
                            {// tkn_dois_pontos
                                getToken();
                                if (tk == TK6)
                                {// tkn_fim_linha
                                    getToken();
                                    if (tk == TK7)
                                    {// tkn_indent
                                        getToken();
                                        if (P() == 1)
                                        {
                                            if (tk == TK9)
                                            {// tkn_dedent
                                                getToken();
                                                return 1;
                                            }
                                            else { return 0; }
                                        }
                                        else { return 0; }
                                    }
                                    else { return 0; }
                                }
                                else { return 0; }
                            }
                            else { return 0; }
                        }
                        else { return 0; }
                    }
                    else { return 0; }
                }
                else { return 0; }
            }
            else { return 0; }
        }

        //COMP_WHILE -> EXP_C | tkn_id 
        int COMP_WHILE()
        {
            int tkret = tk;
            int indexret = index;
            if (EXP_C() == 1)
            {
                return 1;
            }
            else
            {
                tk = tkret;
                index = indexret;
                if (tk == TK2)
                {// tkn_id
                    getToken();
                    return 1;
                }
                else { return 0; }
            }
        }

        //IF_STATMENT -> tkn_if tkn_a_par EXP_C tkn_f_par tkn_dois_pontos tkn_fim_linha tkn_indent P tkn_dedent ELSE_ELIF 
        int IF_STATMENT()
        {
            if (tk == TK18)
            {// tkn_if
                getToken();
                if (tk == TK3)
                {// tkn_a_par
                    getToken();
                    if (EXP_C() == 1)
                    {
                        if (tk == TK4)
                        {// tkn_f_par
                            getToken();
                            if (tk == TK5)
                            {// tkn_dois_pontos
                                getToken();
                                if (tk == TK6)
                                {// tkn_fim_linha
                                    getToken();
                                    if (tk == TK7)
                                    {// tkn_indent
                                        getToken();
                                        if (P() == 1)
                                        {
                                            if (tk == TK9)
                                            {// tkn_dedent
                                                getToken();
                                                if (ELSE_ELIF() == 1)
                                                {
                                                    return 1;
                                                }
                                                else { return 0; }
                                            }
                                            else { return 0; }
                                        }
                                        else { return 0; }
                                    }
                                    else { return 0; }
                                }
                                else { return 0; }
                            }
                            else { return 0; }
                        }
                        else { return 0; }
                    }
                    else { return 0; }
                }
                else { return 0; }
            }
            else { return 0; }
        }

        //ELSE_ELIF -> tkn_else tkn_dois_pontos tkn_fim_linha tkn_indent P tkn_dedent | tkn_elif tkn_dois_pontos IF_STATMENT | ? 
        int ELSE_ELIF()
        {
            if (tk == TK19)
            {// tkn_else
                getToken();
                if (tk == TK5)
                {// tkn_dois_pontos
                    getToken();
                    if (tk == TK6)
                    {// tkn_fim_linha
                        getToken();
                        if (tk == TK7)
                        {// tkn_indent
                            getToken();
                            if (P() == 1)
                            {
                                if (tk == TK9)
                                {// tkn_dedent
                                    getToken();
                                    return 1;
                                }
                                else { return 0; }
                            }
                            else { return 0; }
                        }
                        else { return 0; }
                    }
                    else { return 0; }
                }
                else { return 0; }
            }
            else if (tk == TK20)
            {// tkn_elif
                getToken();
                if (tk == TK5)
                {// tkn_dois_pontos
                    getToken();
                    if (IF_STATMENT() == 1)
                    {
                        return 1;
                    }
                    else { return 0; }
                }
                else { return 0; }
            }
            else { return 1; }
        }

        //EXP_C -> EXP COMP EXP 
        int EXP_C()
        {
            if (EXP() == 1)
            {
                if (COMP() == 1)
                {
                    if (EXP() == 1)
                    {
                        return 1;
                    }
                    else { return 0; }
                }
                else { return 0; }
            }
            else { return 0; }
        }

        //COMP -> tkn_comp_igual | tkn_comp_diferente | tkn_comp_maior | tkn_comp_menor | tkn_comp_maior_igual | tkn_comp_menor_igual 
        int COMP()
        {
            if (tk == TK21)
            {// tkn_comp_igual
                getToken();
                return 1;
            }
            else if (tk == TK22)
            {// tkn_comp_diferente
                getToken();
                return 1;
            }
            else if (tk == TK23)
            {// tkn_comp_maior
                getToken();
                return 1;
            }
            else if (tk == TK24)
            {// tkn_comp_menor
                getToken();
                return 1;
            }
            else if (tk == TK25)
            {// tkn_comp_maior_igual
                getToken();
                return 1;
            }
            else if (tk == TK26)
            {// tkn_comp_menor_igual
                getToken();
                return 1;
            }
            else { return 0; }
        }

        //EXP -> tkn_id EXP1Hash | tkn_a_par EXP tkn_f_par EXP1Hash | TYPE EXP1Hash 
        int EXP()
        {
            if (tk == TK2)
            {// tkn_id
                getToken();
                if (EXP1Hash() == 1)
                {
                    return 1;
                }
                else { return 0; }
            }
            else if (tk == TK3)
            {// tkn_a_par
                getToken();
                if (EXP() == 1)
                {
                    if (tk == TK4)
                    {// tkn_f_par
                        getToken();
                        if (EXP1Hash() == 1)
                        {
                            return 1;
                        }
                        else { return 0; }
                    }
                    else { return 0; }
                }
                else { return 0; }
            }
            else if (TYPE() == 1)
            {
                if (EXP1Hash() == 1)
                {
                    return 1;
                }
                else { return 0; }
            }
            else { return 0; }
        }

        //EXP1Hash -> REXP EXP1Hash | ? 
        int EXP1Hash()
        {
            if (REXP() == 1)
            {
                if (EXP1Hash() == 1)
                {
                    return 1;
                }
                else { return 0; }
            }
            else { return 1; }
        }

        //REXP -> tkn_soma EXP | tkn_dimin EXP | tkn_mult EXP | tkn_div EXP | tkn_and EXP | tkn_or EXP 
        int REXP()
        {
            if (tk == TK12)
            {// tkn_soma
                getToken();
                if (EXP() == 1)
                {
                    return 1;
                }
                else { return 0; }
            }
            else if (tk == TK27)
            {// tkn_dimin
                getToken();
                if (EXP() == 1)
                {
                    return 1;
                }
                else { return 0; }
            }
            else if (tk == TK28)
            {// tkn_mult
                getToken();
                if (EXP() == 1)
                {
                    return 1;
                }
                else { return 0; }
            }
            else if (tk == TK29)
            {// tkn_div
                getToken();
                if (EXP() == 1)
                {
                    return 1;
                }
                else { return 0; }
            }
            else if (tk == TK30)
            {// tkn_and
                getToken();
                if (EXP() == 1)
                {
                    return 1;
                }
                else { return 0; }
            }
            else if (tk == TK31)
            {// tkn_or
                getToken();
                if (EXP() == 1)
                {
                    return 1;
                }
                else { return 0; }
            }
            else { return 0; }
        }

        //ATTRIBUTION -> tkn_id tkn_atribuicao EXP tkn_fim_linha 
        int ATTRIBUTION()
        {
            if (tk == TK2)
            {// tkn_id
                getToken();
                if (tk == TK32)
                {// tkn_atribuicao
                    getToken();
                    if (EXP() == 1)
                    {
                        if (tk == TK6)
                        {// tkn_fim_linha
                            getToken();
                            return 1;
                        }
                        else { return 0; }
                    }
                    else { return 0; }
                }
                else { return 0; }
            }
            else { return 0; }
        }

        //TYPE -> tipo_string | tipo_int | tipo_float 
        int TYPE()
        {
            if (tk == TK11)
            {// tipo_string
                getToken();
                return 1;
            }
            else if (tk == TK16)
            {// tipo_int
                getToken();
                return 1;
            }
            else if (tk == TK33)
            {// tipo_float
                getToken();
                return 1;
            }
            else { return 0; }
        }
    }
}
