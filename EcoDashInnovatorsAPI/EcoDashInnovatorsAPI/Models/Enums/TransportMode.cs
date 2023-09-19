namespace EcoDashInnovatorsAPI.Models.Enums;

public enum TransportMode
{
    /// <summary>
    /// High carbon emissions per mile
    /// </summary>
    Air = 40,          
    /// <summary>
    /// More efficient for bulk transport
    /// </summary>
    Sea = 75,           
    /// <summary>
    /// Typically efficient and lower emissions
    /// </summary>
    Rail = 90,          
    /// <summary>
    /// Can vary depending on efficiency and distance
    /// </summary>
    Truck = 70,         
    /// <summary>
    /// Low to zero emissions, especially if charged with renewable energy
    /// </summary>
    ElectricVehicle = 95
}
