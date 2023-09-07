using GardenTracker.App.Interfaces;
using GardenTracker.App.Models;

namespace GardenTracker.App;

public class GardenTrackerCommands
{
    private List<IPlant> plants = new List<IPlant>();
    private List<IPlant> fruitPlants = new List<IPlant>();
    private List<IPlant> vegetablePlants = new List<IPlant>();

    public void Greeting()
    {
        Console.WriteLine("Welcome to Garden Tracker!\n" +
                          "You can store information about " +
                          "fruits or vegetables.");
        Console.WriteLine("--------------------------------------");
    }

    public int PickCommand()
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

    public void AddPlant()
    {
        while (true)
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

                var fruit = new Fruit(plants.Count + 1, plantType, commonName, scientificName, description,
                    plantingDate, wateringSchedule, ripeningTime);

                plants.Add(fruit);
                fruitPlants.Add(fruit);

                Console.WriteLine($"{commonName} added to list.");
                Console.WriteLine("--------------------------------------");
                break;
            }

            if (plantType == "VEGETABLE") //add try and catch
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

                var vegetable = new Vegetable(plants.Count + 1, plantType, commonName, scientificName, description,
                    plantingDate, wateringSchedule, sowingDepth);

                plants.Add(vegetable);
                vegetablePlants.Add(vegetable);

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
    }
    
    public void RemovePlant()
    {
        var plantsRemoved = false;

        if (plants.Count >= 1)
        {
            Console.WriteLine("Current plants in garden: ");

            foreach (var plant in plants)
            {
                Console.WriteLine($"\nId: {plant.Id}" +
                                  $"\nCommon Name: {plant.CommonName}\n");
            }

            int inputId;

            while (true)
            {
                try
                {
                    Console.Write("Enter an Id to remove a plant (or enter 0 to cancel): ");
                    inputId = Convert.ToInt32(Console.ReadLine());

                    if (inputId == 0)
                    {
                        Console.WriteLine("Operation canceled.");
                        break;
                    }

                    var plantToRemove = plants.FirstOrDefault(p => p.Id == inputId);

                    if (plantToRemove != null)
                    {
                        plants.Remove(plantToRemove);
                        Console.WriteLine($"Plant with ID {inputId} removed.");
                        plantsRemoved = true;
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

    public void DisplayPlant()
    {
        if (plants.Count != 0)
        {
            Console.WriteLine("Your list of plants: ");
            foreach (var plant in plants)
            {
                if (plant is Fruit fruit)
                {
                    Console.WriteLine($"\nPlant Type: {fruit.PlantType}\n" +
                                      $"*******************************\n" +
                                      $"Common Name: {fruit.CommonName}\n" +
                                      $"Scientific Name: {fruit.ScientificName}\n" +
                                      $"Description: {fruit.Description}\n" +
                                      $"Planting Date: {fruit.PlantingDate}\n" +
                                      $"Watering Schedule: Every {fruit.WateringSchedule} day/s\n" +
                                      $"Ripening Time: Every {fruit.RipeningTime} day/s");
                }
                else if (plant is Vegetable vegetable)
                {
                    Console.WriteLine($"\nPlant Type: {vegetable.PlantType}\n" +
                                      $"*******************************\n" +
                                      $"Common Name: {vegetable.CommonName}\n" +
                                      $"Scientific Name: {vegetable.ScientificName}\n" +
                                      $"Description: {vegetable.Description}\n" +
                                      $"Planting Date: {vegetable.PlantingDate}\n" +
                                      $"Watering Schedule: Every {vegetable.WateringSchedule} day/s\n" +
                                      $"Sowing Depth: {vegetable.SowingDepth} in.");
                }
            }

            Console.WriteLine($"\nNumber of fruit plants: {fruitPlants.Count}" +
                              $"\nNumber of vegetable plants: {vegetablePlants.Count}" +
                              $"\nNumber of total plants: {plants.Count}");

            Console.ReadKey();
        }

        else
        {
            Console.WriteLine("There are no plants in your garden.");
        }

        Console.WriteLine("--------------------------------------");
    }
}