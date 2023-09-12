namespace GardenTracker.App.Interfaces;

public interface IPlant
{
    int Id { get; set; }
    string PlantType { get; set; }
    string CommonName { get; set; }
    string ScientificName { get; set; }
    string Description { get; set; }
    string PlantingDate { get; set; }
    int WateringSchedule { get; set; }
}