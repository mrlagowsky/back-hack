using EcoDashInnovatorsAPI.Data.Helpers;
using EcoDashInnovatorsAPI.Models.Enums;
using Newtonsoft.Json;

namespace EcoDashInnovatorsAPI.Models;

public class ProductModel
{
    /// <summary>
    /// Unique Identifier
    /// </summary>
    public int Id { get; set; } 
    
    /// <summary>
    /// e.g. ["Recycled Plastic", "Organic Cotton"]
    /// </summary>
    [JsonConverter(typeof(MaterialConverter))]
    public List<Material> Materials { get; set; } 
    
    /// <summary>
    /// True if it uses renewable energy in production, False otherwise
    /// </summary>
    public bool UsesRenewableEnergy { get; set; } 
    
    /// <summary>
    /// Distance in miles/kilometers the product has traveled
    /// </summary>
    public int SupplyChainDistance { get; set; } 
    
    /// <summary>
    /// e.g. "Air", "Sea", "Land"
    /// </summary>
    public string TransportMode { get; set; } 
    
    /// <summary>
    /// True if it has minimal packaging, False otherwise
    /// </summary>
    public bool MinimalPackaging { get; set; } 
    
    /// <summary>
    /// True if packaging is recyclable, False otherwise
    /// </summary>
    public bool RecyclablePackaging { get; set; } 
    
    /// <summary>
    /// Expected life of the product in years
    /// </summary>
    public int ProductLifeCycleInYears { get; set; } 
    
    /// <summary>
    /// True if the product is biodegradable, False otherwise
    /// </summary>
    public bool IsBiodegradable { get; set; } 
    
    /// <summary>
    /// True if the product can be recycled, False otherwise
    /// </summary>
    public bool CanBeRecycled { get; set; } 
    
    public int ComputeScore()
    {
        int score = 0;

        score += (int)MaterialExtensions.CalculateAverageScore(Materials);
        if (UsesRenewableEnergy) score += 70;
        if (SupplyChainDistance <= 200) score += 30;
        if (TransportMode == "Land") score += 50;
        if (MinimalPackaging) score += 20;
        if (RecyclablePackaging) score += 10;
        score += (IsBiodegradable ? 30 : 0);
        score += (CanBeRecycled ? 20 : 0);
        score -= ProductLifeCycleInYears;

        return score;
    }
    
    public int ComputeScore2()
    {
        int score = 300; // base score

        score += (int)(2.5 * MaterialExtensions.CalculateAverageScore(Materials)); // assuming max of 100, now max of 250
        if (UsesRenewableEnergy) score += 140; // double the previous score
        if (SupplyChainDistance <= 200) score += 60; // double the previous score
        if (TransportMode == "Land") score += 100; // double the previous score
        if (MinimalPackaging) score += 40; // double the previous score
        if (RecyclablePackaging) score += 20; // double the previous score
        score += (IsBiodegradable ? 60 : 0); // double the previous score
        score += (CanBeRecycled ? 40 : 0); // double the previous score
        score -= (int)(1.5 * ProductLifeCycleInYears); // increase the negative impact a bit

        return Math.Min(1000, score); // ensure score doesn't exceed 1000
    }
}