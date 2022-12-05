using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicalExpressionIterator.Models
{
    public class OperandNode : BaseNode
    {
        public BaseNode Operator { get; set; }

        public bool Operand { get; set; }

        public override bool Value => Operand;
    }
}
