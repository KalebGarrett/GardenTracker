using GardenTracker.App.Interfaces;

namespace GardenTracker.App.Models;

public class Vegetable : IPlant
{
    public Vegetable(int id, string plantType, string commonName, string scientificName, 
        string description, string plantingDate, int wateringSchedule, double sowingDepth)
    {
        Id = id;
        PlantType = plantType;
        CommonName = commonName;
        ScientificName = scientificName;
        Description = description;
        PlantingDate = plantingDate;
        WateringSchedule = wateringSchedule;
        SowingDepth = sowingDepth;
    }

    public int Id { get; set; }
    public string PlantType { get; set; }
    public string CommonName { get; set; }
    public string ScientificName { get; set; }
    public string Description { get; set; }
    public string PlantingDate { get; set; }
    public int WateringSchedule { get; set; }
    public double SowingDepth { get; set; }
}