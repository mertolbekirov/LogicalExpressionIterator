using LogicalExpressionIterator.Infrastructure;
using LogicalExpressionIterator.Models;

Console.WriteLine("COMMANDS:");
Console.WriteLine("QUIT: to exit");
Console.WriteLine("DEFINE: to define a function");
Console.WriteLine("SOLVE: to solve a function with given parameters");
Console.WriteLine("ALL: to print a table with all possible outcomes");
Console.WriteLine("FIND: to find a function with given outcomes");

while (true)
{
    Dictionary<string, OperatorNode> treeDict = new Dictionary<string, OperatorNode>();
    Dictionary<string, Function> functionDict = new Dictionary<string, Function>();

    var input = Console.ReadLine();

    var inputArr = input?.CustomSplitOnlyOnce(' ');
    var command = inputArr[0];

    switch (command)
    {
        case "DEFINE":
            var commandArr = inputArr[1].CustomSplitOnlyOnce(':');

            var functionSignature = commandArr[0];
            var function = commandArr[1];
            function = function.CustomReplace("\"", "");


            var functionNameVariablesArr = functionSignature.CustomSplitOnlyOnce('(');
            var functionVariables = functionNameVariablesArr[1].CustomReplace(" ", "").CustomReplace(")", "").CustomSplit(',');

            if (!functionDict.ContainsKey(functionSignature))
            {
                Function functionObj = new Function
                {
                    Name = functionSignature,
                };

                foreach (var variable in functionVariables)
                {
                    functionObj.Variables.Add(variable[0]);
                }

                functionDict.Add(functionSignature, functionObj);
            }

            var functionArr = function.CustomSplit(' ');

            foreach (var item in functionArr)
            {
                if (true)
                {

                }
            }

            Console.WriteLine(RPNConvert(function)); 

            break;
        case "SOLVE":
            break;
        case "ALL":
            break;
        case "FIND":
            break;
        default:
            throw new ArgumentException("Invalid Command.");
    }


    string ReadFunctionFromOperatorNode(string functionName)
    {
        if (!treeDict.ContainsKey(functionName))
        {
            throw new ArgumentException("No such key");
        }

        return "";
    }
}

static string RPNConvert(string str)
{
    CustomStack<char> stack = new CustomStack<char>();
    SimpleStringBuilder formula = new SimpleStringBuilder();
    for (int i = 0; i < str.Length; i++)
    {
        char x = str[i];
        if (x == '(')
            stack.Push(x);
        else if (x == ')')
        {
            while (stack.Count > 0 && stack.Peek() != '(')
                formula.Append(stack.Pop());
            stack.Pop();
        }
        else if (IsOperand(x))
        {
            formula.Append(x);
        }
        else if (IsOperator(x))
        {
            while (stack.Count > 0 && stack.Peek() != '(')
                formula.Append(stack.Pop());
            stack.Push(x);
        }
        else
        {
            char y = stack.Pop();
            if (y != '(')
                formula.Append(y);
        }
    }   
    while (stack.Count > 0)
    {
        formula.Append(stack.Pop());
    }
    return formula.ToString();
}

static bool EvaluateRpn(string expression)
{
    // Create a stack to hold the numbers
    var stack = new CustomStack<int>();

    // Evaluate the expression
    foreach (var token in expression)
    {
        // If the token is a number, push it onto the stack
        if (int.TryParse(token.ToString(), out var number))
        {
            stack.Push(number);
        }
        else
        {
            // Otherwise, the token must be an operator
            // So pop the last two numbers from the stack
            var right = stack.Pop();
            var left = stack.Pop();

            // Perform the operation and push the result back onto the stack
            switch (token)
            {
                case '*':
                    stack.Push(left & right);
                    break;
                case '|':
                    stack.Push(left | right);
                    break;
            }
        }
    }

    // The final result should be the only remaining number on the stack
    return stack.Pop() == 1 ? true : false;
}

static bool IsOperator(char c)
{
    return (c == '&' || c == '|');
}
static bool IsOperand(char c)
{
    return (c >= 'a' && c <= 'z');
}
