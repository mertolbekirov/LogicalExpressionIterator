Console.WriteLine("COMMANDS:");
Console.WriteLine("QUIT: to exit");
Console.WriteLine("DEFINE: to define a function");
Console.WriteLine("SOLVE: to solve a function with given parameters");
Console.WriteLine("ALL: to print a table with all possible outcomes");
Console.WriteLine("FIND: to find a function with given outcomes");

while (true)
{
    var input = Console.ReadLine();

    var inputArr = input?.Split(new char[] { ' ' }, 2);
    var command = inputArr[0];

    switch (command)
    {
        case "DEFINE":
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