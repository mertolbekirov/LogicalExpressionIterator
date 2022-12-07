using LogicalExpressionIterator.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicalExpressionIterator.Models
{
    public class OperatorNode : BaseNode
    {
        private char @operator;

        public char Operator { 
            get 
            {
                return @operator;
            }
            set
            {
                if (value == '&' || value == '|' || value == '!')
                {
                    @operator = value;
                }

                throw new ArgumentException("Invalid operand type.");
            }
        }

        public CustomList<BaseNode> Operands { get; set; } = new CustomList<BaseNode>();

        public override bool Value { get
            {
                var length = Operands.Count;
                var lastVal = Operands.GetAt(0).Value;

                for (int i = 0; i < length - 1; i++)
                {
                    switch (Operator)
                    {
                        case '&':
                            lastVal = lastVal & Operands.GetAt(i+1).Value;
                            break;
                        case '|':
                            lastVal = lastVal | Operands.GetAt(i + 1).Value;
                            break;
                        case '!':
                            lastVal = !lastVal;
                            break;
                    }
                }

                return lastVal;
            }
        }
    }
}
