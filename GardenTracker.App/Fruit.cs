using GardenTracker.App.Interfaces;

namespace GardenTracker.App;

public class Fruit : IPlant
{
    public Fruit(string plantType, string commonName, string scientificName, string description, string plantingDate, string wateringSchedule, string ripeningTime)
    {
        PlantType = plantType;
        CommonName = commonName;
        ScientificName = scientificName;
        Description = description;
        PlantingDate = plantingDate;
        WateringSchedule = wateringSchedule;
        RipeningTime = ripeningTime;
    }

    public string PlantType { get; set; }
    public string CommonName { get; set; }
    public string ScientificName { get; set; }
    public string Description { get; set; }
    public string PlantingDate { get; set; }
    public string WateringSchedule { get; set; }
    public string RipeningTime { get; set; }
}