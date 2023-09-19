using EcoDashInnovatorsAPI.Data.Helpers;
using EcoDashInnovatorsAPI.Data.Services;
using EcoDashInnovatorsAPI.Models.Enums;

namespace EcoDashInnovatorsAPI.Models;

public class PartnerModel
{
    /// <summary>
    /// Partner's individual Id number
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// True if they avoid overstocking, False otherwise
    /// </summary>
    public bool AvoidsOverstocking { get; set; }
    
    /// <summary>
    /// True if they implement practices that lower energy consumption
    /// </summary>
    public bool LowersEnergyUsage { get; set; }
    
    /// <summary>
    /// True if they use new technologies like RFID or IoT to manage stock 
    /// </summary>
    public bool AdaptsTechnologically { get; set; }

    /// <summary>
    /// Overall score for inventory management for a partner
    /// </summary>
    public int InventoryManagementScore { get; set; }
    
    /// <summary>
    /// True if they use eco-friendly shipping, False otherwise
    /// </summary>
    public bool UsesEcoFriendlyShipping { get; set; }
    
    /// <summary>
    /// True if they use eco-friendly packaging, False otherwise
    /// </summary>
    public bool UsesEcoFriendlyPackaging { get; set; } 
    
    /// <summary>
    /// True if they stock items sourced from local vendors which is good for eco aspects
    /// </summary>
    public bool UsesLocalSourcing { get; set; } 
    
    /// <summary>
    /// True if they have long-lasting items in stock which is better for lowering waste
    /// </summary>
    public bool StocksLongLastingProducts { get; set; } 
    
    /// <summary>
    /// Overall score for having sustainable practices for a partner
    /// </summary>
    public int SustainablePracticesScore { get; set; }
    
    /// <summary>
    /// Overall score for having ecological certifications for a partner
    /// </summary>
    public int CertificationScore { get; set; }

    /// <summary>
    /// Partner's score for products they stock
    /// </summary>
    public int ProductScore { get; set; }
    
    /// <summary>
    /// List of certifications e.g. ["Green Seal", "Fair Trade"]
    /// </summary>
    public List<EcoCertification> Certifications { get; set; }

    /// <summary>
    /// Total measure of ecological score for a Partner
    /// </summary>
    public int TotalEcoScore =>
        (InventoryManagementScore + CertificationScore + SustainablePracticesScore + ProductScore) / 4;

    public void AssignScores()
    {
        // Inventory Management Score
        InventoryManagementScore = 300; // Base score
        if (AvoidsOverstocking) InventoryManagementScore += 233;
        if (LowersEnergyUsage) InventoryManagementScore += 233;
        if (AdaptsTechnologically) InventoryManagementScore += 234;

        // Ensure score doesn't exceed 1000
        InventoryManagementScore = Math.Min(InventoryManagementScore, 1000);

        // Sustainable Practices Score
        SustainablePracticesScore = 300; // Base score
        if (UsesEcoFriendlyShipping) SustainablePracticesScore += 175;
        if (UsesEcoFriendlyPackaging) SustainablePracticesScore += 175;
        if (UsesLocalSourcing) SustainablePracticesScore += 175;
        if (StocksLongLastingProducts) SustainablePracticesScore += 175;

        // Ensure score doesn't exceed 1000
        SustainablePracticesScore = Math.Min(SustainablePracticesScore, 1000);

        // Certification Score
        CertificationScore = 300; // Base score
        if (Certifications.Count > 0)
        {
            // Sum all the certifications values, then normalize by the number of certifications to get an average.
            CertificationScore += Certifications.Sum(cert => (int)cert) / Certifications.Count;

            // Ensure score doesn't exceed 1000
            CertificationScore = Math.Min(CertificationScore, 1000);
        }
        
        var allProducts = DataService.LoadAllProducts();
        var sampleProductScore = DataService.CalculateProductScore(ProductSelector.SelectRandomProducts(allProducts));
        ProductScore = sampleProductScore;
    }

}