using GardenTracker.App;

var gardenTrackerCommands = new GardenTrackerCommands();

gardenTrackerCommands.Greeting();

while (true)
{
   switch (gardenTrackerCommands.PickCommand())
    {
        case 1:
            gardenTrackerCommands.AddPlant();
            break;
        case 2:
            gardenTrackerCommands.RemovePlant();
            break;
        case 3:
            gardenTrackerCommands.DisplayPlant();
            break;
        case 4:
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Invalid input. You must enter numbers 1, 2, 3, or 4.");
            break;
    }
}