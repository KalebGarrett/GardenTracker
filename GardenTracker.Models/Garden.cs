namespace GardenTracker.Models;

public class Garden
{
    public int Id { get; set; }
    public string PlantType { get; set; }
    public string CommonName { get; set; }
    public string ScientificName { get; set; }
    public string Description { get; set; }
    public string PlantingDate { get; set; }
    public int WateringSchedule { get; set; }
}