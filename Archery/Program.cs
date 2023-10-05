using Archery;

Console.WriteLine("Witam w programie XYZ do dodawania punktów łucznikom.");
Console.WriteLine("===========================================");
Console.WriteLine();

ArcherInFile archer = new ("Raf", "Kal");

while (true)
{
    Console.WriteLine("Podaj kolejne punkty łucznika: ");
    string? input = Console.ReadLine();

    if (input == "q")
    {
        break;
    }
    try
    {
        archer.AddPoint(input);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Exception Catched: {ex.Message}");
    }
}
archer.AddPoint(0.6f);
Statistics statistics = archer.GetStatistics();

Console.WriteLine($"Min: {statistics.Min}");
Console.WriteLine($"Max: {statistics.Max}");
Console.WriteLine($"Average: {statistics.Average}");

