grammar Jason;


//Not finished --> Function, If-statement and Expressions

/*
 * Parser Rules
 */

//Lower letters id for CFG
//Upper case letters id for tokens

//Reserved Keywords must be decalared first before identifiers

program: 'begin' statment_sequence 'end';

statment_sequence: statment+ ;

statment: call_statement
          |assignment_statement
          |write_statement
          |read_statement
          |while_statement
          |if_statement
          |declare_statement
          |declare_function
          |COMMENT ;

declare_statement: data_type IDENTIFIER ASSIGNMENT_OPERATOR input SIMICOLON
                 | data_type IDENTIFIER SIMICOLON;

write_statement: 'write' IDENTIFIER SIMICOLON;
read_statement: 'read' IDENTIFIER SIMICOLON;

assignment_statement: IDENTIFIER ASSIGNMENT_OPERATOR input SIMICOLON;

declare_function: 'func' IDENTIFIER OPEN_PAREN parameter? CLOSE_PAREN OBRACE statment_sequence function_return? CBRACE;
function_return: 'return' (exp | IDENTIFIER) SIMICOLON;

while_statement: 'while' OPEN_PAREN logical_expression CLOSE_PAREN OBRACE  statment_sequence CBRACE;

if_statement:'if' OPEN_PAREN logical_expression CLOSE_PAREN OBRACE  statment_sequence CBRACE else_part?;

else_part: ELSE OBRACE statment_sequence CBRACE;

call_statement: 'call' IDENTIFIER SIMICOLON
             | 'call' IDENTIFIER OPEN_PAREN parameter CLOSE_PAREN SIMICOLON;

parameter: IDENTIFIER (COMMA IDENTIFIER)*;

input: exp | STRING ;

exp:|exp (PLUS | SUB) exp
    |exp (MUL | DIV) exp
    | OPEN_PAREN exp CLOSE_PAREN
    | INTEGER
    | FLOAT
    | IDENTIFIER;

logical_expression: logical_expression LOGICAL_OPERATOR logical_expression
                   | relational_expression;

relational_expression: (IDENTIFIER | INTEGER | FLOAT) RELATIONAL_OPERATOR (IDENTIFIER | INTEGER | FLOAT)
    | NOT_EQUAL_OPERATOR IDENTIFIER;

data_type: 'string' | 'int' | 'float';

/*
 * Lexer Rules
 */


COMMENT: '//' .*? '//';

//ARITHMETIC_OPERATOR: PLUS | MINUS | MUL | DIV;
PLUS: '+';
SUB: '-';
MUL: '*';
DIV: '/';
ASSIGNMENT_OPERATOR: '=' | '+=' | '-=' | '*=' | '/=';
RELATIONAL_OPERATOR: '<'|'>'|'<='|'>=' | '!=' | '==';
NOT_EQUAL_OPERATOR: '!';
LOGICAL_OPERATOR: '&&' | '|';
OPEN_PAREN: '(';
CLOSE_PAREN: ')';
OBRACE : '{';
CBRACE : '}';

TRUE: 'true';
FALSE: 'false';
IF: 'if';
ELSE: 'else';
/*WHILE: 'while';
WRITE: 'write';
READ: 'read';*/
SIMICOLON: ';';
BEGIN: B E G I N;
END: E N D;

COMMA: ',';
INTEGER             : [0-9]+;
FLOAT               : [0-9]+ '.' [0-9]+ | '.' [0-9]+;
STRING              : '"' [0-9a-zA-Z]* '"';
IDENTIFIER          : [a-zA-Z_] [a-zA-Z_0-9]*;
WHITESPACE          : (' '|'t')+ -> skip ; //ignore white spaces
NEWLINE				: ('\r\n'|'\n'|'\r') -> skip; //skip new line and mark end of line with ';'

fragment A:('a'|'A');
fragment B:('b'|'B');
fragment C:('c'|'C');
fragment D:('d'|'D');
fragment E:('e'|'E');
fragment F:('f'|'F');
fragment G:('g'|'G');
fragment H:('h'|'H');
fragment I:('i'|'I');
fragment J:('j'|'J');
fragment K:('k'|'K');
fragment L:('l'|'L');
fragment M:('m'|'M');
fragment N:('n'|'N');
fragment O:('o'|'O');
fragment P:('p'|'P');
fragment Q:('q'|'Q');
fragment R:('r'|'R');
fragment S:('s'|'S');
fragment T:('t'|'T');
fragment U:('u'|'U');
fragment V:('v'|'V');
fragment W:('w'|'W');
fragment X:('x'|'X');
fragment Y:('y'|'Y');
fragment Z:('z'|'Z');