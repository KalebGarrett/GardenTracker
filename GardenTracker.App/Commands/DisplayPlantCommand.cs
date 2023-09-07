using GardenTracker.App.Interfaces;
using GardenTracker.App.Models;

namespace GardenTracker.App.Commands;

public class DisplayPlantCommand : ICommand
{
    private readonly List<IPlant> _plants;
    private readonly List<IPlant> _fruitPlants;
    private readonly List<IPlant> _vegetablePlants;

    public DisplayPlantCommand(List<IPlant> plants, List<IPlant> fruitPlants, List<IPlant> vegetablePlants)
    {
        _plants = plants;
        _fruitPlants = fruitPlants;
        _vegetablePlants = vegetablePlants;
    }

    public void Execute()
    {
        if (_plants.Count != 0)
        {
            Console.WriteLine("Your list of plants: ");
            foreach (var plant in _plants)
            {
                if (plant is Fruit fruit)
                {
                    Console.WriteLine($"\nPlant Type: {fruit.PlantType}\n" +
                                      $"*******************************\n" +
                                      $"Id: {fruit.Id}\n" +
                                      $"Common Name: {fruit.CommonName}\n" +
                                      $"Scientific Name: {fruit.ScientificName}\n" +
                                      $"Description: {fruit.Description}\n" +
                                      $"Planting Date: {fruit.PlantingDate}\n" +
                                      $"Watering Schedule: Every {fruit.WateringSchedule} day/s\n" +
                                      $"Ripening Time: {fruit.RipeningTime} day/s");
                }
                
                else if (plant is Vegetable vegetable)
                {
                    Console.WriteLine($"\nPlant Type: {vegetable.PlantType}\n" +
                                      $"*******************************\n" +
                                      $"Id: {vegetable.Id}\n" +
                                      $"Common Name: {vegetable.CommonName}\n" +
                                      $"Scientific Name: {vegetable.ScientificName}\n" +
                                      $"Description: {vegetable.Description}\n" +
                                      $"Planting Date: {vegetable.PlantingDate}\n" +
                                      $"Watering Schedule: Every {vegetable.WateringSchedule} day/s\n" +
                                      $"Sowing Depth: {vegetable.SowingDepth} in.");
                }
            }

            Console.WriteLine($"\nNumber of fruit plants: {_fruitPlants.Count}" +
                              $"\nNumber of vegetable plants: {_vegetablePlants.Count}" +
                              $"\nNumber of total plants: {_plants.Count}");

            Console.ReadKey();
        }

        else
        {
            Console.WriteLine("There are no plants in your garden.");
        }

        Console.WriteLine("--------------------------------------");
    }
}