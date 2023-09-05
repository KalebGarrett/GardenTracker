namespace GardenTracker.App.Interfaces;

public interface IPlant
{
    string PlantType { get; set; }
    string CommonName { get; set; }
    string ScientificName { get; set; }
    string Description { get; set; }
    string PlantingDate { get; set; }
    string WateringSchedule { get; set; }
}