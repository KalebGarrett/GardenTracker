using GardenTracker.App.Interfaces;

namespace GardenTracker.App;

public class Vegetable : IPlant
{
    public Vegetable(string plantType, string commonName, string scientificName, string description, string plantingDate, string wateringSchedule, double sowingDepth)
    {
        PlantType = plantType;
        CommonName = commonName;
        ScientificName = scientificName;
        Description = description;
        PlantingDate = plantingDate;
        WateringSchedule = wateringSchedule;
        SowingDepth = sowingDepth;
    }

    public string PlantType { get; set; }
    public string CommonName { get; set; }
    public string ScientificName { get; set; }
    public string Description { get; set; }
    public string PlantingDate { get; set; }
    public string WateringSchedule { get; set; }
    public double SowingDepth { get; set; }
}