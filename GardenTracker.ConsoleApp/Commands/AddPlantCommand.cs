using GardenTracker.App.Interfaces;
using GardenTracker.App.Models;

namespace GardenTracker.App.Commands;

public class AddPlantCommand : ICommand
{
    private readonly List<IPlant> _plants;
    private readonly List<IPlant> _fruitPlants;
    private readonly List<IPlant> _vegetablePlants;

    public AddPlantCommand(List<IPlant> plants, List<IPlant> fruitPlants, List<IPlant> vegetablePlants)
    {
        _plants = plants;
        _fruitPlants = fruitPlants;
        _vegetablePlants = vegetablePlants;
    }

    public void Execute()
    {
        while (true)
        {
            try
            {
                Console.WriteLine("Plant Types: " +
                                  "\n1. Fruit" +
                                  "\n2. Vegetable");
                Console.Write("\nEnter the name of the plant type (or enter 0 to cancel): ");
                var plantType = Console.ReadLine()?.ToUpper();

                if (plantType == "FRUIT")
                {
                    Console.Write("Enter common name: ");
                    var commonName = Console.ReadLine();
                    Console.Write("Enter scientific name: ");
                    var scientificName = Console.ReadLine();
                    Console.Write("Enter description: ");
                    var description = Console.ReadLine();
                    Console.Write("Enter planting date: ");
                    var plantingDate = Console.ReadLine();

                    int wateringSchedule;

                    while (true)
                    {
                        try
                        {
                            Console.Write("Enter watering schedule in days: ");
                            wateringSchedule = Convert.ToInt32(Console.ReadLine());
                            break;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid input. You must enter a whole number.");
                        }
                    }

                    int ripeningTime;

                    while (true)
                    {
                        try
                        {
                            Console.Write("Enter ripening time in days: ");
                            ripeningTime = Convert.ToInt32(Console.ReadLine());
                            break;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid input. You must enter a whole number.");
                        }
                    }

                    var fruit = new Fruit(_plants.Count + 1, plantType, commonName, scientificName, description,
                        plantingDate, wateringSchedule, ripeningTime);

                    _plants.Add(fruit);
                    _fruitPlants.Add(fruit);

                    Console.WriteLine($"{commonName} added to list.");
                    Console.WriteLine("--------------------------------------");
                    break;
                }

                if (plantType == "VEGETABLE")
                {
                    Console.Write("Enter common name: ");
                    var commonName = Console.ReadLine();
                    Console.Write("Enter scientific name: ");
                    var scientificName = Console.ReadLine();
                    Console.Write("Enter description: ");
                    var description = Console.ReadLine();
                    Console.Write("Enter planting date: ");
                    var plantingDate = Console.ReadLine();

                    int wateringSchedule;

                    while (true)
                    {
                        try
                        {
                            Console.Write("Enter watering schedule in days: ");
                            wateringSchedule = Convert.ToInt32(Console.ReadLine());
                            break;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid input. You must enter a whole number.");
                        }
                    }

                    double sowingDepth;

                    while (true)
                    {
                        try
                        {
                            Console.Write("Enter sowing depth in inches: ");
                            sowingDepth = Convert.ToDouble(Console.ReadLine());
                            break;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid input. You must enter a whole number or decimal value.");
                        }
                    }

                    var vegetable = new Vegetable(_plants.Count + 1, plantType, commonName, scientificName, description,
                        plantingDate, wateringSchedule, sowingDepth);

                    _plants.Add(vegetable);
                    _vegetablePlants.Add(vegetable);

                    Console.WriteLine($"{commonName} added to list.");
                    Console.WriteLine("--------------------------------------");
                    break;
                }

                if (plantType != null && int.Parse(plantType) == 0)
                {
                    Console.WriteLine("Operation canceled.");
                    break;
                }

                Console.WriteLine("Invalid input. You must enter fruit, vegetable, or 0.\n");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. You must enter numbers fruit, vegetable, or (0).\n");
            }
        }
    }
}