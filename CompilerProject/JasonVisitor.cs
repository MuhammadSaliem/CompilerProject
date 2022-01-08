using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Text;
using static CompilerProject.JasonParser;

namespace CompilerProject
{
    class JasonVisitor : JasonBaseVisitor<object>
    {
        public List<DataCLS> Lines = new List<DataCLS>();
        public override object VisitStatment(JasonParser.StatmentContext context)
        {
            Declare_statementContext Declarestatment = context.declare_statement();
            Call_statementContext CallStatement = context.call_statement();
            Assignment_statementContext AssignmentStatement = context.assignment_statement();
            Read_statementContext ReadStatement = context.read_statement();
            Write_statementContext WriteStatement = context.write_statement();
            While_statementContext WhileStatement = context.while_statement();
            If_statementContext IfStatement = context.if_statement();
            Declare_functionContext DeclareFunction = context.declare_function();


            DataCLS line = null;

            if (Declarestatment != null && Declarestatment.Stop.Text == ";")
            {
                if (Declarestatment.GetText().Substring(Declarestatment.GetText().Length - 1) == ";")
                {
                    if (Declarestatment.ChildCount == 3)
                    {
                        line = new DataCLS() { Text = Declarestatment.GetText(), Rule = "declare_statement", Grammer= "data_type IDENTIFIER SIMICOLON" };

                    }
                    else
                    {
                        line = new DataCLS() { Text = Declarestatment.GetText(), Rule = "declare_statement", Grammer = "data_type IDENTIFIER ASSIGNMENT_OPERATOR input SIMICOLON" };

                    }
                }
            }


            if (CallStatement != null && CallStatement.Stop.Text == ";")
            {
                if (CallStatement.ChildCount == 3)
                {
                    line = new DataCLS() { Text = CallStatement.GetText(), Rule = "Call_statement", Grammer = "CALL IDENTIFIER SIMICOLON" };

                }
                else
                {
                    line = new DataCLS() { Text = CallStatement.GetText(), Rule = "Call_statement", Grammer = "CALL IDENTIFIER OPEN_PAREN parameter CLOSE_PAREN SIMICOLON" };

                }
            }

            if (AssignmentStatement != null && AssignmentStatement.Stop.Text == ";")
            {
                line = new DataCLS() { Text = AssignmentStatement.GetText(), Rule = "Assignment_statement", Grammer = "IDENTIFIER ASSIGNMENT_OPERATOR input SIMICOLON" };
            }

            if (ReadStatement != null && ReadStatement.Stop.Text == ";")
            {
                line = new DataCLS() { Text = ReadStatement.GetText(), Rule = "Read_statement", Grammer = "READ IDENTIFIER SIMICOLON" };
            }

            if (WriteStatement != null && WriteStatement.Stop.Text == ";")
            {
                line = new DataCLS() { Text = WriteStatement.GetText(), Rule = "Write_statement", Grammer = "WRITE IDENTIFIER SIMICOLON" };
            }

            if (WhileStatement != null && WriteStatement.Stop.Text == "}")
            {
                line = new DataCLS() { Text = WhileStatement.GetText(), Rule = "While_statement", Grammer = "WHILE OPEN_PAREN logical_expression CLOSE_PAREN OBRACE  statment_sequence CBRACE" };
            }

            if (IfStatement != null && IfStatement.Stop.Text == "}")
            {
                line = new DataCLS() { Text = IfStatement.GetText(), Rule = "IF_statement", Grammer = "IF OPEN_PAREN logical_expression CLOSE_PAREN OBRACE  statment_sequence CBRACE else_part?" };
            }
            if (DeclareFunction != null && DeclareFunction.Stop.Text == "}")
            {
                line = new DataCLS() { Text = DeclareFunction.GetText(), Rule = "Declare_Function", Grammer = "FUNC IDENTIFIER OPEN_PAREN parameter? CLOSE_PAREN OBRACE statment_sequence function_return? CBRACE" };
            }
            Lines.Add(line);
            return Lines;
        }

    }
}
