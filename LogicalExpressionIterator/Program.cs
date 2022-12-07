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
            var commandArr = inputArr = inputArr[1].CustomSplitOnlyOnce(':');

            var functionSignature = commandArr[0];
            var function = commandArr[1];

            var functionNameVariablesArr = functionSignature.CustomSplitOnlyOnce('(');
            var functionName = functionNameVariablesArr[0];
            var functionVariables = functionNameVariablesArr[1].CustomSplitOnlyOnce(')')[0].CustomSplitOnlyOnce(' ', true);

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

            ReadFunction(function);

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

void ReadFunction(string function)
{
    bool didQuoatationsPass = false;
    foreach (var ch in function)
    {
        if ((ch != '"' || ch == ' ') && !didQuoatationsPass)
        {
            continue;
        }
        else
        {
            if (ch == '"')
            {
                break;
            }
            didQuoatationsPass = true;

            if (char.IsLetter(ch))
            {
                
            }else if (ch == '(')
            {

            }
        }
    }
}

OperatorNode ReadBracketsFuncRecursive(string function)
{
    return null;
}