using GardenTracker.App.Interfaces;
using GardenTracker.App.Models;

namespace GardenTracker.App.Commands;

public class RemovePlantCommand : ICommand
{
    private readonly List<IPlant> _plants;
    private readonly List<IPlant> _fruitPlants;
    private readonly List<IPlant> _vegetablePlants;

    public RemovePlantCommand(List<IPlant> plants, List<IPlant> fruitPlants, List<IPlant> vegetablePlants)
    {
        _plants = plants;
        _fruitPlants = fruitPlants;
        _vegetablePlants = vegetablePlants;
    }

    public void Execute()
    {
        var plantsRemoved = false;

        if (_plants.Count >= 1)
        {
            Console.WriteLine("Current plants in garden: ");

            foreach (var plant in _plants)
            {
                Console.WriteLine($"\nId: {plant.Id}" +
                                  $"\nPlant Type: {plant.PlantType}" +
                                  $"\nCommon Name: {plant.CommonName}");
            }

            int inputId;

            while (true)
            {
                try
                {
                    Console.Write("\nEnter an Id to remove a plant (or enter 0 to cancel): ");
                    inputId = Convert.ToInt32(Console.ReadLine());

                    if (inputId == 0)
                    {
                        Console.WriteLine("Operation canceled.");
                        plantsRemoved = true;
                        break;
                    }

                    var plantToRemove = _plants.FirstOrDefault(p => p.Id == inputId);

                    if (plantToRemove != null)
                    {
                        _plants.Remove(plantToRemove);
                        Console.WriteLine($"Plant with ID {inputId} removed.");

                        if (plantToRemove is Fruit fruitPlant)
                        {
                            var fruitPlantToRemove = _fruitPlants.FirstOrDefault(p => p.Id == fruitPlant.Id);
                            if (fruitPlantToRemove != null)
                            {
                                _fruitPlants.Remove(fruitPlant);
                            }
                        }
                        else if (plantToRemove is Vegetable vegetablePlant)
                        {
                            var vegetablePlantToRemove =
                                _vegetablePlants.FirstOrDefault(p => p.Id == vegetablePlant.Id);
                            if (vegetablePlantToRemove != null)
                            {
                                _vegetablePlants.Remove(vegetablePlant);
                            }
                        }
                    }

                    else
                    {
                        Console.WriteLine("There is no plant found with the specified ID.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. You must enter a valid number.");
                }
            }
        }

        if (!plantsRemoved)
        {
            Console.WriteLine("There are no plants in your garden.");
        }

        Console.WriteLine("--------------------------------------");
    }
}