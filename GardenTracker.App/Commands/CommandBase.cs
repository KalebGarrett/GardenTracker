using GardenTracker.App.Interfaces;
using GardenTracker.App.Models;

namespace GardenTracker.App.Commands;

public class CommandBase
{
    private readonly List<IPlant> _plants;
    private readonly List<IPlant> _fruitPlants;
    private readonly List<IPlant> _vegetablePlants;
    
    public CommandBase(List<IPlant> plants, List<IPlant> fruitPlants, List<IPlant> vegetablePlants)
    {
        _plants = plants;
        _fruitPlants = fruitPlants;
        _vegetablePlants = vegetablePlants;
    }

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
    }
}