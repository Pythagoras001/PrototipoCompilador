
using com.calitha.commons;
using com.calitha.goldparser.lalr;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Text;

namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF                 =  0, // (EOF)
        SYMBOL_ERROR               =  1, // (Error)
        SYMBOL_WHITESPACE          =  2, // Whitespace
        SYMBOL_MINUS               =  3, // '-'
        SYMBOL_AMP                 =  4, // '&'
        SYMBOL_LPAREN              =  5, // '('
        SYMBOL_RPAREN              =  6, // ')'
        SYMBOL_TIMES               =  7, // '*'
        SYMBOL_COMMA               =  8, // ','
        SYMBOL_DIV                 =  9, // '/'
        SYMBOL_COLON               = 10, // ':'
        SYMBOL_SEMI                = 11, // ';'
        SYMBOL_LBRACE              = 12, // '{'
        SYMBOL_PIPE                = 13, // '|'
        SYMBOL_RBRACE              = 14, // '}'
        SYMBOL_PLUS                = 15, // '+'
        SYMBOL_LT                  = 16, // '<'
        SYMBOL_LTEQ                = 17, // '<='
        SYMBOL_EQ                  = 18, // '='
        SYMBOL_EQEQ                = 19, // '=='
        SYMBOL_GT                  = 20, // '>'
        SYMBOL_GTEQ                = 21, // '>='
        SYMBOL_BOOL                = 22, // Bool
        SYMBOL_BOOLEAN             = 23, // boolean
        SYMBOL_BREAK               = 24, // break
        SYMBOL_BYTE                = 25, // byte
        SYMBOL_CASE                = 26, // case
        SYMBOL_CHAR                = 27, // char
        SYMBOL_DEC                 = 28, // dec
        SYMBOL_DEFAULT             = 29, // default
        SYMBOL_DO                  = 30, // do
        SYMBOL_DOUBLE              = 31, // double
        SYMBOL_ELSE                = 32, // else
        SYMBOL_FOR                 = 33, // for
        SYMBOL_ID                  = 34, // id
        SYMBOL_IF                  = 35, // if
        SYMBOL_INT                 = 36, // int
        SYMBOL_MAIN                = 37, // main
        SYMBOL_NUM                 = 38, // num
        SYMBOL_SWITCH              = 39, // switch
        SYMBOL_VOID                = 40, // void
        SYMBOL_WHILE               = 41, // while
        SYMBOL_CASO                = 42, // <Caso>
        SYMBOL_CONDICION           = 43, // <Condicion>
        SYMBOL_CONDICIONSIMPLE     = 44, // <CondicionSimple>
        SYMBOL_DECREMENTO          = 45, // <Decremento>
        SYMBOL_EXPRESION           = 46, // <Expresion>
        SYMBOL_FACTOR              = 47, // <Factor>
        SYMBOL_FUNCION             = 48, // <Funcion>
        SYMBOL_INCREMENTO          = 49, // <Incremento>
        SYMBOL_LISTACASOS          = 50, // <ListaCasos>
        SYMBOL_LISTADECLARACIONES  = 51, // <ListaDeclaraciones>
        SYMBOL_LISTAFUNCIONES      = 52, // <ListaFunciones>
        SYMBOL_LISTAPARAMETROS     = 53, // <ListaParametros>
        SYMBOL_LISTASENTENCIAS     = 54, // <ListaSentencias>
        SYMBOL_LLAMADAFUNCION      = 55, // <LlamadaFuncion>
        SYMBOL_PARAMETRO           = 56, // <Parametro>
        SYMBOL_PROGRAMA            = 57, // <Programa>
        SYMBOL_SENTENCIA           = 58, // <Sentencia>
        SYMBOL_SENTENCIAASIGNACION = 59, // <SentenciaAsignacion>
        SYMBOL_SENTENCIADOWHILE    = 60, // <SentenciaDoWhile>
        SYMBOL_SENTENCIAFOR        = 61, // <SentenciaFor>
        SYMBOL_SENTENCIAFOREACH    = 62, // <SentenciaForEach>
        SYMBOL_SENTENCIAIF         = 63, // <SentenciaIf>
        SYMBOL_SENTENCIASWITCH     = 64, // <SentenciaSwitch>
        SYMBOL_SENTENCIAWHILE      = 65, // <SentenciaWhile>
        SYMBOL_TERMINO             = 66, // <Termino>
        SYMBOL_TIPO                = 67  // <Tipo>
    };

    enum RuleConstants : int
    {
        RULE_PROGRAMA_MAIN_LPAREN_RPAREN_LBRACE_RBRACE                     =  0, // <Programa> ::= main '(' ')' '{' <ListaSentencias> '}'
        RULE_PROGRAMA_MAIN_LPAREN_RPAREN_LBRACE_RBRACE2                    =  1, // <Programa> ::= main '(' ')' '{' <ListaSentencias> '}' <ListaFunciones>
        RULE_LISTASENTENCIAS                                               =  2, // <ListaSentencias> ::= <Sentencia>
        RULE_LISTASENTENCIAS2                                              =  3, // <ListaSentencias> ::= <Sentencia> <ListaSentencias>
        RULE_LISTAFUNCIONES                                                =  4, // <ListaFunciones> ::= <Funcion>
        RULE_LISTAFUNCIONES2                                               =  5, // <ListaFunciones> ::= <Funcion> <ListaFunciones>
        RULE_LISTAPARAMETROS                                               =  6, // <ListaParametros> ::= <Parametro>
        RULE_LISTAPARAMETROS2                                              =  7, // <ListaParametros> ::= <Parametro> <ListaParametros>
        RULE_LISTADECLARACIONES_ID                                         =  8, // <ListaDeclaraciones> ::= <Tipo> id
        RULE_LISTADECLARACIONES                                            =  9, // <ListaDeclaraciones> ::= 
        RULE_LISTADECLARACIONES_ID_COMMA                                   = 10, // <ListaDeclaraciones> ::= <Tipo> id ',' <ListaDeclaraciones>
        RULE_SENTENCIA_SEMI                                                = 11, // <Sentencia> ::= <SentenciaAsignacion> ';'
        RULE_SENTENCIA                                                     = 12, // <Sentencia> ::= <SentenciaIf>
        RULE_SENTENCIA2                                                    = 13, // <Sentencia> ::= <SentenciaFor>
        RULE_SENTENCIA3                                                    = 14, // <Sentencia> ::= <SentenciaWhile>
        RULE_SENTENCIA4                                                    = 15, // <Sentencia> ::= <SentenciaDoWhile>
        RULE_SENTENCIA_SEMI2                                               = 16, // <Sentencia> ::= <LlamadaFuncion> ';'
        RULE_SENTENCIA5                                                    = 17, // <Sentencia> ::= <SentenciaSwitch>
        RULE_SENTENCIA6                                                    = 18, // <Sentencia> ::= <SentenciaForEach>
        RULE_SENTENCIA_SEMI3                                               = 19, // <Sentencia> ::= <Incremento> ';'
        RULE_SENTENCIA_SEMI4                                               = 20, // <Sentencia> ::= <Decremento> ';'
        RULE_SENTENCIA_SEMI5                                               = 21, // <Sentencia> ::= <ListaDeclaraciones> ';'
        RULE_SENTENCIASWITCH_SWITCH_LPAREN_ID_RPAREN_LBRACE_RBRACE         = 22, // <SentenciaSwitch> ::= switch '(' id ')' '{' <ListaCasos> '}'
        RULE_LISTACASOS                                                    = 23, // <ListaCasos> ::= <Caso>
        RULE_LISTACASOS2                                                   = 24, // <ListaCasos> ::= <Caso> <ListaCasos>
        RULE_CASO_CASE_NUM_COLON_BREAK_SEMI                                = 25, // <Caso> ::= case num ':' <ListaSentencias> break ';'
        RULE_CASO_DEFAULT_COLON_BREAK_SEMI                                 = 26, // <Caso> ::= default ':' <ListaSentencias> break ';'
        RULE_SENTENCIAFOREACH_FOR_LPAREN_ID_COLON_ID_RPAREN_LBRACE_RBRACE  = 27, // <SentenciaForEach> ::= for '(' <Tipo> id ':' id ')' '{' <ListaSentencias> '}'
        RULE_SENTENCIAFOREACH_FOR_LPAREN_ID_COLON_RPAREN_LBRACE_RBRACE     = 28, // <SentenciaForEach> ::= for '(' <Tipo> id ':' <LlamadaFuncion> ')' '{' <ListaSentencias> '}'
        RULE_SENTENCIAASIGNACION_ID_EQ                                     = 29, // <SentenciaAsignacion> ::= id '=' <Expresion>
        RULE_SENTENCIAASIGNACION_ID_EQ2                                    = 30, // <SentenciaAsignacion> ::= <Tipo> id '=' <Expresion>
        RULE_SENTENCIAASIGNACION_ID_EQ_BOOLEAN                             = 31, // <SentenciaAsignacion> ::= id '=' boolean
        RULE_SENTENCIAASIGNACION_ID_EQ_BOOLEAN2                            = 32, // <SentenciaAsignacion> ::= <Tipo> id '=' boolean
        RULE_SENTENCIAIF_IF_LPAREN_RPAREN_LBRACE_RBRACE                    = 33, // <SentenciaIf> ::= if '(' <Condicion> ')' '{' <ListaSentencias> '}'
        RULE_SENTENCIAIF_IF_LPAREN_RPAREN_LBRACE_RBRACE_ELSE_LBRACE_RBRACE = 34, // <SentenciaIf> ::= if '(' <Condicion> ')' '{' <ListaSentencias> '}' else '{' <ListaSentencias> '}'
        RULE_SENTENCIAFOR_FOR_LPAREN_SEMI_SEMI_RPAREN_LBRACE_RBRACE        = 35, // <SentenciaFor> ::= for '(' <SentenciaAsignacion> ';' <Condicion> ';' <Incremento> ')' '{' <ListaSentencias> '}'
        RULE_SENTENCIAFOR_FOR_LPAREN_SEMI_SEMI_RPAREN_LBRACE_RBRACE2       = 36, // <SentenciaFor> ::= for '(' <SentenciaAsignacion> ';' <Condicion> ';' <Decremento> ')' '{' <ListaSentencias> '}'
        RULE_INCREMENTO_ID_PLUS_PLUS                                       = 37, // <Incremento> ::= id '+' '+'
        RULE_DECREMENTO_ID_MINUS_MINUS                                     = 38, // <Decremento> ::= id '-' '-'
        RULE_SENTENCIAWHILE_WHILE_LPAREN_RPAREN_LBRACE_RBRACE              = 39, // <SentenciaWhile> ::= while '(' <Condicion> ')' '{' <ListaSentencias> '}'
        RULE_SENTENCIADOWHILE_DO_LBRACE_RBRACE_WHILE_LPAREN_RPAREN_SEMI    = 40, // <SentenciaDoWhile> ::= do '{' <ListaSentencias> '}' while '(' <Condicion> ')' ';'
        RULE_LLAMADAFUNCION_ID_LPAREN_RPAREN                               = 41, // <LlamadaFuncion> ::= id '(' ')'
        RULE_LLAMADAFUNCION_ID_LPAREN_RPAREN2                              = 42, // <LlamadaFuncion> ::= id '(' <ListaParametros> ')'
        RULE_TIPO_BOOL                                                     = 43, // <Tipo> ::= Bool
        RULE_TIPO_CHAR                                                     = 44, // <Tipo> ::= char
        RULE_TIPO_INT                                                      = 45, // <Tipo> ::= int
        RULE_TIPO_DOUBLE                                                   = 46, // <Tipo> ::= double
        RULE_TIPO_BYTE                                                     = 47, // <Tipo> ::= byte
        RULE_TIPO_VOID                                                     = 48, // <Tipo> ::= void
        RULE_FUNCION_ID_LPAREN_RPAREN_LBRACE_RBRACE                        = 49, // <Funcion> ::= <Tipo> id '(' <ListaDeclaraciones> ')' '{' <ListaSentencias> '}'
        RULE_PARAMETRO_ID_COMMA                                            = 50, // <Parametro> ::= id ',' <Parametro>
        RULE_PARAMETRO_ID                                                  = 51, // <Parametro> ::= id
        RULE_EXPRESION_PLUS                                                = 52, // <Expresion> ::= <Expresion> '+' <Termino>
        RULE_EXPRESION_MINUS                                               = 53, // <Expresion> ::= <Expresion> '-' <Termino>
        RULE_EXPRESION                                                     = 54, // <Expresion> ::= <Termino>
        RULE_TERMINO_TIMES                                                 = 55, // <Termino> ::= <Termino> '*' <Factor>
        RULE_TERMINO_DIV                                                   = 56, // <Termino> ::= <Termino> '/' <Factor>
        RULE_TERMINO                                                       = 57, // <Termino> ::= <Factor>
        RULE_FACTOR_LPAREN_RPAREN                                          = 58, // <Factor> ::= '(' <Expresion> ')'
        RULE_FACTOR_ID                                                     = 59, // <Factor> ::= id
        RULE_FACTOR_NUM                                                    = 60, // <Factor> ::= num
        RULE_FACTOR_DEC                                                    = 61, // <Factor> ::= dec
        RULE_FACTOR                                                        = 62, // <Factor> ::= <LlamadaFuncion>
        RULE_CONDICION_AMP_AMP                                             = 63, // <Condicion> ::= <Condicion> '&' '&' <CondicionSimple>
        RULE_CONDICION_PIPE_PIPE                                           = 64, // <Condicion> ::= <Condicion> '|' '|' <CondicionSimple>
        RULE_CONDICION                                                     = 65, // <Condicion> ::= <CondicionSimple>
        RULE_CONDICIONSIMPLE_GT                                            = 66, // <CondicionSimple> ::= <Expresion> '>' <Expresion>
        RULE_CONDICIONSIMPLE_LT                                            = 67, // <CondicionSimple> ::= <Expresion> '<' <Expresion>
        RULE_CONDICIONSIMPLE_GTEQ                                          = 68, // <CondicionSimple> ::= <Expresion> '>=' <Expresion>
        RULE_CONDICIONSIMPLE_LTEQ                                          = 69, // <CondicionSimple> ::= <Expresion> '<=' <Expresion>
        RULE_CONDICIONSIMPLE_EQEQ                                          = 70, // <CondicionSimple> ::= <Expresion> '==' <Expresion>
        RULE_CONDICIONSIMPLE_LPAREN_RPAREN                                 = 71, // <CondicionSimple> ::= '(' <Condicion> ')'
        RULE_CONDICIONSIMPLE_BOOLEAN                                       = 72  // <CondicionSimple> ::= boolean
    };

    public class MyParser
    {
        private LALRParser parser;

        public MyParser(string filename)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open, 
                                               FileAccess.Read, 
                                               FileShare.Read);
            Init(stream);
            stream.Close();
        }

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnReduce += new LALRParser.ReduceHandler(ReduceEvent);
            parser.OnTokenRead += new LALRParser.TokenReadHandler(TokenReadEvent);
            parser.OnAccept += new LALRParser.AcceptHandler(AcceptEvent);
            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
        }

        public void Parse(string source)
        {
            parser.Parse(source);

        }

        private void TokenReadEvent(LALRParser parser, TokenReadEventArgs args)
        {
            try
            {
                args.Token.UserObject = CreateObject(args.Token);
            }
            catch (Exception e)
            {
                args.Continue = false;
                //todo: Report message to UI?
            }
        }

        private Object CreateObject(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //Whitespace
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUS :
                //'-'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_AMP :
                //'&'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LPAREN :
                //'('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RPAREN :
                //')'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMES :
                //'*'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMMA :
                //','
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COLON :
                //':'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SEMI :
                //';'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LBRACE :
                //'{'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PIPE :
                //'|'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACE :
                //'}'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUS :
                //'+'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LT :
                //'<'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LTEQ :
                //'<='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQ :
                //'='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQEQ :
                //'=='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GT :
                //'>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GTEQ :
                //'>='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BOOL :
                //Bool
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BOOLEAN :
                //boolean
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BREAK :
                //break
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BYTE :
                //byte
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CASE :
                //case
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CHAR :
                //char
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DEC :
                //dec
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DEFAULT :
                //default
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DO :
                //do
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DOUBLE :
                //double
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSE :
                //else
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR :
                //for
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID :
                //id
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF :
                //if
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INT :
                //int
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MAIN :
                //main
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NUM :
                //num
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SWITCH :
                //switch
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VOID :
                //void
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE :
                //while
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CASO :
                //<Caso>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONDICION :
                //<Condicion>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONDICIONSIMPLE :
                //<CondicionSimple>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DECREMENTO :
                //<Decremento>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPRESION :
                //<Expresion>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FACTOR :
                //<Factor>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNCION :
                //<Funcion>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INCREMENTO :
                //<Incremento>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LISTACASOS :
                //<ListaCasos>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LISTADECLARACIONES :
                //<ListaDeclaraciones>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LISTAFUNCIONES :
                //<ListaFunciones>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LISTAPARAMETROS :
                //<ListaParametros>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LISTASENTENCIAS :
                //<ListaSentencias>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LLAMADAFUNCION :
                //<LlamadaFuncion>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PARAMETRO :
                //<Parametro>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROGRAMA :
                //<Programa>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SENTENCIA :
                //<Sentencia>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SENTENCIAASIGNACION :
                //<SentenciaAsignacion>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SENTENCIADOWHILE :
                //<SentenciaDoWhile>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SENTENCIAFOR :
                //<SentenciaFor>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SENTENCIAFOREACH :
                //<SentenciaForEach>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SENTENCIAIF :
                //<SentenciaIf>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SENTENCIASWITCH :
                //<SentenciaSwitch>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SENTENCIAWHILE :
                //<SentenciaWhile>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TERMINO :
                //<Termino>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIPO :
                //<Tipo>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        private void ReduceEvent(LALRParser parser, ReduceEventArgs args)
        {
            try
            {
                args.Token.UserObject = CreateObject(args.Token);
            }
            catch (Exception e)
            {
                args.Continue = false;
                //todo: Report message to UI?
            }
        }

        public static Object CreateObject(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_PROGRAMA_MAIN_LPAREN_RPAREN_LBRACE_RBRACE :
                //<Programa> ::= main '(' ')' '{' <ListaSentencias> '}'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_PROGRAMA_MAIN_LPAREN_RPAREN_LBRACE_RBRACE2 :
                //<Programa> ::= main '(' ')' '{' <ListaSentencias> '}' <ListaFunciones>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LISTASENTENCIAS :
                //<ListaSentencias> ::= <Sentencia>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LISTASENTENCIAS2 :
                //<ListaSentencias> ::= <Sentencia> <ListaSentencias>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LISTAFUNCIONES :
                //<ListaFunciones> ::= <Funcion>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LISTAFUNCIONES2 :
                //<ListaFunciones> ::= <Funcion> <ListaFunciones>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LISTAPARAMETROS :
                //<ListaParametros> ::= <Parametro>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LISTAPARAMETROS2 :
                //<ListaParametros> ::= <Parametro> <ListaParametros>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LISTADECLARACIONES_ID :
                //<ListaDeclaraciones> ::= <Tipo> id
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LISTADECLARACIONES :
                //<ListaDeclaraciones> ::= 
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LISTADECLARACIONES_ID_COMMA :
                //<ListaDeclaraciones> ::= <Tipo> id ',' <ListaDeclaraciones>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIA_SEMI :
                //<Sentencia> ::= <SentenciaAsignacion> ';'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIA :
                //<Sentencia> ::= <SentenciaIf>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIA2 :
                //<Sentencia> ::= <SentenciaFor>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIA3 :
                //<Sentencia> ::= <SentenciaWhile>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIA4 :
                //<Sentencia> ::= <SentenciaDoWhile>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIA_SEMI2 :
                //<Sentencia> ::= <LlamadaFuncion> ';'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIA5 :
                //<Sentencia> ::= <SentenciaSwitch>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIA6 :
                //<Sentencia> ::= <SentenciaForEach>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIA_SEMI3 :
                //<Sentencia> ::= <Incremento> ';'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIA_SEMI4 :
                //<Sentencia> ::= <Decremento> ';'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIA_SEMI5 :
                //<Sentencia> ::= <ListaDeclaraciones> ';'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIASWITCH_SWITCH_LPAREN_ID_RPAREN_LBRACE_RBRACE :
                //<SentenciaSwitch> ::= switch '(' id ')' '{' <ListaCasos> '}'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LISTACASOS :
                //<ListaCasos> ::= <Caso>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LISTACASOS2 :
                //<ListaCasos> ::= <Caso> <ListaCasos>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CASO_CASE_NUM_COLON_BREAK_SEMI :
                //<Caso> ::= case num ':' <ListaSentencias> break ';'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CASO_DEFAULT_COLON_BREAK_SEMI :
                //<Caso> ::= default ':' <ListaSentencias> break ';'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIAFOREACH_FOR_LPAREN_ID_COLON_ID_RPAREN_LBRACE_RBRACE :
                //<SentenciaForEach> ::= for '(' <Tipo> id ':' id ')' '{' <ListaSentencias> '}'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIAFOREACH_FOR_LPAREN_ID_COLON_RPAREN_LBRACE_RBRACE :
                //<SentenciaForEach> ::= for '(' <Tipo> id ':' <LlamadaFuncion> ')' '{' <ListaSentencias> '}'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIAASIGNACION_ID_EQ :
                //<SentenciaAsignacion> ::= id '=' <Expresion>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIAASIGNACION_ID_EQ2 :
                //<SentenciaAsignacion> ::= <Tipo> id '=' <Expresion>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIAASIGNACION_ID_EQ_BOOLEAN :
                //<SentenciaAsignacion> ::= id '=' boolean
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIAASIGNACION_ID_EQ_BOOLEAN2 :
                //<SentenciaAsignacion> ::= <Tipo> id '=' boolean
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIAIF_IF_LPAREN_RPAREN_LBRACE_RBRACE :
                //<SentenciaIf> ::= if '(' <Condicion> ')' '{' <ListaSentencias> '}'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIAIF_IF_LPAREN_RPAREN_LBRACE_RBRACE_ELSE_LBRACE_RBRACE :
                //<SentenciaIf> ::= if '(' <Condicion> ')' '{' <ListaSentencias> '}' else '{' <ListaSentencias> '}'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIAFOR_FOR_LPAREN_SEMI_SEMI_RPAREN_LBRACE_RBRACE :
                //<SentenciaFor> ::= for '(' <SentenciaAsignacion> ';' <Condicion> ';' <Incremento> ')' '{' <ListaSentencias> '}'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIAFOR_FOR_LPAREN_SEMI_SEMI_RPAREN_LBRACE_RBRACE2 :
                //<SentenciaFor> ::= for '(' <SentenciaAsignacion> ';' <Condicion> ';' <Decremento> ')' '{' <ListaSentencias> '}'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_INCREMENTO_ID_PLUS_PLUS :
                //<Incremento> ::= id '+' '+'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_DECREMENTO_ID_MINUS_MINUS :
                //<Decremento> ::= id '-' '-'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIAWHILE_WHILE_LPAREN_RPAREN_LBRACE_RBRACE :
                //<SentenciaWhile> ::= while '(' <Condicion> ')' '{' <ListaSentencias> '}'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIADOWHILE_DO_LBRACE_RBRACE_WHILE_LPAREN_RPAREN_SEMI :
                //<SentenciaDoWhile> ::= do '{' <ListaSentencias> '}' while '(' <Condicion> ')' ';'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LLAMADAFUNCION_ID_LPAREN_RPAREN :
                //<LlamadaFuncion> ::= id '(' ')'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LLAMADAFUNCION_ID_LPAREN_RPAREN2 :
                //<LlamadaFuncion> ::= id '(' <ListaParametros> ')'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_TIPO_BOOL :
                //<Tipo> ::= Bool
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_TIPO_CHAR :
                //<Tipo> ::= char
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_TIPO_INT :
                //<Tipo> ::= int
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_TIPO_DOUBLE :
                //<Tipo> ::= double
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_TIPO_BYTE :
                //<Tipo> ::= byte
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_TIPO_VOID :
                //<Tipo> ::= void
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_FUNCION_ID_LPAREN_RPAREN_LBRACE_RBRACE :
                //<Funcion> ::= <Tipo> id '(' <ListaDeclaraciones> ')' '{' <ListaSentencias> '}'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_PARAMETRO_ID_COMMA :
                //<Parametro> ::= id ',' <Parametro>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_PARAMETRO_ID :
                //<Parametro> ::= id
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_EXPRESION_PLUS :
                //<Expresion> ::= <Expresion> '+' <Termino>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_EXPRESION_MINUS :
                //<Expresion> ::= <Expresion> '-' <Termino>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_EXPRESION :
                //<Expresion> ::= <Termino>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_TERMINO_TIMES :
                //<Termino> ::= <Termino> '*' <Factor>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_TERMINO_DIV :
                //<Termino> ::= <Termino> '/' <Factor>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_TERMINO :
                //<Termino> ::= <Factor>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_FACTOR_LPAREN_RPAREN :
                //<Factor> ::= '(' <Expresion> ')'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_FACTOR_ID :
                //<Factor> ::= id
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_FACTOR_NUM :
                //<Factor> ::= num
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_FACTOR_DEC :
                //<Factor> ::= dec
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_FACTOR :
                //<Factor> ::= <LlamadaFuncion>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CONDICION_AMP_AMP :
                //<Condicion> ::= <Condicion> '&' '&' <CondicionSimple>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CONDICION_PIPE_PIPE :
                //<Condicion> ::= <Condicion> '|' '|' <CondicionSimple>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CONDICION :
                //<Condicion> ::= <CondicionSimple>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CONDICIONSIMPLE_GT :
                //<CondicionSimple> ::= <Expresion> '>' <Expresion>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CONDICIONSIMPLE_LT :
                //<CondicionSimple> ::= <Expresion> '<' <Expresion>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CONDICIONSIMPLE_GTEQ :
                //<CondicionSimple> ::= <Expresion> '>=' <Expresion>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CONDICIONSIMPLE_LTEQ :
                //<CondicionSimple> ::= <Expresion> '<=' <Expresion>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CONDICIONSIMPLE_EQEQ :
                //<CondicionSimple> ::= <Expresion> '==' <Expresion>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CONDICIONSIMPLE_LPAREN_RPAREN :
                //<CondicionSimple> ::= '(' <Condicion> ')'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CONDICIONSIMPLE_BOOLEAN :
                //<CondicionSimple> ::= boolean
                //todo: Create a new object using the stored user objects.
                return null;

            }
            throw new RuleException("Unknown rule");
        }

        // ====== Campos de la clase ======
        private readonly StringBuilder _sb = new StringBuilder();
        private bool _huboLexico = false;
        private bool _huboSintactico = false;
        private bool _aceptado = false;

        // ====== Método para preparar una nueva corrida ======
        private void PrepararNuevaCorrida()
        {
            _sb.Clear();
            _huboLexico = false;
            _huboSintactico = false;
            _aceptado = false;
        }

        // ====== Eventos del parser/scanner ======
        private void AcceptEvent(LALRParser parser, AcceptEventArgs args)
        {
            _aceptado = true;
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            _huboLexico = true;

            int linea = args.Token.Location.LineNr + 1; 
            int columna = args.Token.Location.ColumnNr + 1;

            _sb.AppendLine($"[LEX] Caracter no reconocido '{args.Token}' en línea {linea}, col {columna}.");

            // Encontrar más errores léxicos:
            args.Continue = true;
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            _huboSintactico = true;

            int linea = args.UnexpectedToken.Location.LineNr + 1;
            int columna = args.UnexpectedToken.Location.ColumnNr + 1;

            _sb.AppendLine($"[SYN] Token inesperado '{args.UnexpectedToken}' en línea {linea}, col {columna}.");

            // Encontrar más errores de sintaxis:
            args.Continue = ContinueMode.Stop; 
        }

        // ====== Exponer el resultado ======
        public string getCadenaErrores()
        {
            // Si no hubo errores y el parser aceptó, devolvemos el OK
            if (_aceptado && !_huboLexico && !_huboSintactico)
                return "Todo salio Bien";

            // Si hubo errores, devolvemos el acumulado
            return _sb.ToString();
        }

    }
}
