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

        public List<BaseNode> Operands { get; set; }

        public override bool Value { get
            {
                var length = Operands.Count;
                var lastVal = Operands[0].Value;

                for (int i = 0; i < length - 1; i++)
                {
                    switch (Operator)
                    {
                        case '&':
                            lastVal = lastVal & Operands[i + 1].Value;
                            break;
                        case '|':
                            lastVal = lastVal | Operands[i + 1].Value;
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
