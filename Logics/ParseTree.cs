using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logics
{
    public class Node
    {
        public int val;
        public char op;
        public Node(int v) { val = v; op = ' '; }
        public Node(char c) { val = 0; op = c; }
        public Node Left = null;
        public Node Right = null;

        public int Compute()
        {
            if (op == ' ')
                return val;
            int a = Left.Compute();
            int b = Right.Compute();
            int Result = 0;
            switch (op)
            {
                case ('+'):
                    {
                        Result = a + b;
                        break;
                    }
                case ('-'):
                    {
                        Result = a - b;
                        break;
                    }
                case ('*'):
                    {
                        Result = a * b;
                        break;
                    }
            }
            return Result;
        }
    }

    public class Tree
    {
        private Node top = null;
        public void Parse(string text)
        {
            int pos = text.Length - 1;
            top = ParseExpression(text, ref pos);
        }

        private Node ParseExpression(string text, ref int pos)
        {
            Node A;
            A = ParseTerm(text, ref pos);
            if (pos <= 0)
                return A;
            char s = text[pos];
            if (s != '+' && s != '-')
                return A;
            pos--;
            Node B = ParseExpression(text, ref pos);
            Node C = new Node(s);
            C.Left = B;
            C.Right = A;
            return C;
        }

        private Node ParseTerm(string text, ref int pos)
        {
            Node A = ParseElement(text, ref pos);
            if (pos <= 0)
                return A;
            char s = text[pos];
            if (s != '*')
                return A;
            pos--;
            Node B = ParseTerm(text, ref pos);
            Node C = new Node(s);
            C.Left = B;
            C.Right = A;
            return C;
        }

        private Node ParseElement(string text, ref int pos)
        {
            Node A;
            if (text[pos] == ')')
            {
                pos--;
                A = ParseExpression(text, ref pos);
                if (text[pos] != '(')
                    throw new Exception();
                else
                    pos--;
            }
            else
                A = ParseNum(text, ref pos);
            return A;
        }

        private Node ParseNum(string text, ref int pos)
        {
            Node A;
            string s;
            if (pos == 0)
            {
                s = text.Substring(0, 1);
            }
            else
            {
                int position = pos;
                while (pos > 0 && text[pos] != '+' && text[pos] != '-' && text[pos] != '*' && text[pos] != '(' && text[pos] != '(')
                    pos--;
                int l = position - pos;
                s = text.Substring(pos + 1, l);
            }
            A = new Node(int.Parse(s));
            return A;
        }

        public int Compilation()
        {
            if (top == null)
                throw new Exception();
            return top.Compute();
        }

    }

}
