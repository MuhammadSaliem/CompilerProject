using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerProject
{
    public class ParserCLS
    {
        public DataCLS Parse(string input)
        {
            ParserCLS row = new ParserCLS() {};
            try
            {
                StringBuilder text = new StringBuilder();
                text.AppendLine(input);
                AntlrInputStream inputStream = new AntlrInputStream(text.ToString());
                JasonLexer JasonLexer = new JasonLexer(inputStream);
                CommonTokenStream commonTokenStream = new CommonTokenStream(JasonLexer);
                JasonParser JasonParser = new JasonParser(commonTokenStream);

                JasonParser.StatmentContext statementContext = JasonParser.statment();
                JasonVisitor visitor = new JasonVisitor();
                visitor.Visit(statementContext);

                foreach (var line in visitor.Lines)
                {
                    return line;
                }
            }
            catch (Exception ex)
            {
                return new DataCLS() { Text = input, Rule = "Error", Grammer = "Error" };
            }
            return new DataCLS() { Text = input, Rule = "Error", Grammer = "Error" };
        }
    }
}
