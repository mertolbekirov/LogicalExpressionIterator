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

            var functionNameVariablesArr = functionSignature.CustomSplitOnlyOnce('(');
            var functionName = functionNameVariablesArr[0];
            var functionVariables = functionNameVariablesArr[1].CustomReplace(" ", "").CustomReplace(")", "").CustomSplit(',');

            if (functionName == functionSignature)
            {
                throw new ArgumentException("Invalid Syntax.");
            }

            Function functionObj = new Function
            {
                Name = functionName,
            };

            foreach (var variable in functionVariables)
            {
                functionObj.Variables.Add(variable[0]);
            }

            functionDict.Add(functionName, functionObj);

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
}

static string RPNConvert(string input)
{
    CustomStack<char> stack = new CustomStack<char>();
    string str = input.CustomReplace(" ", string.Empty);
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
            while (stack.Count > 0 && stack.Peek() != '(' && Prior(x) <= Prior(stack.Peek()))
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

static bool IsOperator(char c)
{
    return (c == '&' || c == '|');
}
static bool IsOperand(char c)
{
    return (c >= 'a' && c <= 'z');
}
static int Prior(char c)
{
    switch (c)
    {
        case '=':
            return 1;
        case '+':
            return 2;
        case '-':
            return 2;
        case '*':
            return 3;
        case '/':
            return 3;
        case '^':
            return 4;
        default:
            throw new ArgumentException("Rossz parameter");
    }
}