using GardenTracker.App.Interfaces;

namespace GardenTracker.App.Models;

public class Fruit : IPlant
{
    public Fruit(int id, string plantType, string commonName, string scientificName, 
        string description, string plantingDate, int wateringSchedule, int ripeningTime)
    {
        Id = id;
        PlantType = plantType;
        CommonName = commonName;
        ScientificName = scientificName;
        Description = description;
        PlantingDate = plantingDate;
        WateringSchedule = wateringSchedule;
        RipeningTime = ripeningTime;
    }

    public int Id { get; set; }
    public string PlantType { get; set; }
    public string CommonName { get; set; }
    public string ScientificName { get; set; }
    public string Description { get; set; }
    public string PlantingDate { get; set; }
    public int WateringSchedule { get; set; }
    public int RipeningTime { get; set; }
}