//If/Else
int number = 10;

if (number > 10)
{
    Console.WriteLine("Greater than 10");
}
else if (number == 10)
{
    Console.WriteLine("Exactly 10");
}
else
{
    Console.WriteLine("Less than 10");
}

//Switch
string color = "blue";

switch (color)
{
    case "red":
        Console.WriteLine("You picked red.");
        break;
    case "blue":
        Console.WriteLine("You picked blue.");
        break;
    case "green":
        Console.WriteLine("You picked green.");
        break;
    default:
        Console.WriteLine("Unknown color.");
        break;
}

//For
for (int i = 0; i < 5; i++)
{
    Console.WriteLine($"Index: {i}");
}

//ForEach
var items = new[] { 1, 2, 3, 4, 5 };

foreach (var item in items)
{
    Console.WriteLine($"Item: {item}");
}

//While
int i = 0;
while (i < 3)
{
    Console.WriteLine($"While Count: {i}");
    i++;
}

//DoWhile
int i = 0;
do
{
    Console.WriteLine($"Do Count: {i}");
    i++;
} while (i < 3);

//Break
for (int i = 1; i <= 5; i++)
{
    if (i == 3) continue;
    if (i == 5) break;
    Console.WriteLine($"Looping {i}");
}

//EnumerableRange
using System.Linq;

foreach (var i in Enumerable.Range(1, 5))
{
    Console.WriteLine(i);
}