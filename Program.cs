namespace ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        Unit user = new Unit(15, 4, 3, "User");
        Unit ai = new Unit(20, 4, 3, "ai");

        GameEngine simulator = new GameEngine(ai, user);
        simulator.Simulation();

        Console.WriteLine("Enter any key to exit...");
        Console.ReadLine();
    }
}