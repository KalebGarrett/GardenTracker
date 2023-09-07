using GardenTracker.App.Commands;
using GardenTracker.App.Interfaces;

namespace GardenTracker.App;

public abstract class App
{
    public static void RunProgram()
    {
        var plants = new List<IPlant>();
        var fruitPlants = new List<IPlant>();
        var vegetablePlants = new List<IPlant>();

        var commandBase = new CommandBase(plants, fruitPlants, vegetablePlants);

        Greeting();

        while (true)
        {
            switch (PickCommand())
            {
                case 1:
                    commandBase.ExecuteCommand(new AddPlantCommand(plants, fruitPlants, vegetablePlants));
                    break;
                case 2:
                    commandBase.ExecuteCommand(new RemovePlantCommand(plants, fruitPlants, vegetablePlants));
                    break;
                case 3:
                    commandBase.ExecuteCommand(new DisplayPlantCommand(plants, fruitPlants, vegetablePlants));
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid input. You must enter numbers 1, 2, 3, or 4.");
                    break;
            }
        }
    }

    private static int PickCommand()
    {
        int commandInput;

        while (true)
        {
            try
            {
                Console.WriteLine("Commands:\n" +
                                  "1. Add a plant\n" +
                                  "2. Remove a plant\n" +
                                  "3. Display plants\n" +
                                  "4. Quit program\n");

                Console.Write("Select an option: ");
                commandInput = Convert.ToInt32(Console.ReadLine());
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. You must enter numbers 1, 2, 3, or 4.\n");
            }
        }

        Console.WriteLine("--------------------------------------");
        return commandInput;
    }

    private static void Greeting()
    {
        Console.WriteLine("Welcome to Garden Tracker!\n" +
                          "You can store information " +
                          "\nabout fruits or vegetables.");
        Console.WriteLine("--------------------------------------");
    }
}