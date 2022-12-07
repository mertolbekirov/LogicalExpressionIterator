using LogicalExpressionIterator.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicalExpressionIterator.Models
{
    public class Function
    {
        public string Name { get; set; }

        public CustomList<char> Variables { get; set; } = new CustomList<char>();
    }
}
