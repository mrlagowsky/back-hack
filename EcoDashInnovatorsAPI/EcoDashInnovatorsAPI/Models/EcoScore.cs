namespace EcoDashInnovatorsAPI.Models;

public class EcoScore
{
    /// <summary>
    /// Score based on AvoidsOverstocking
    /// </summary>
    public int InventoryManagementScore { get; set; } 
    
    /// <summary>
    /// Combined score based on UsesEcoFriendlyShipping & UsesEcoFriendlyPackaging
    /// </summary>
    public int SustainablePracticesScore { get; set; } 
    
    /// <summary>
    /// Score based on the number and type of Certifications
    /// </summary>
    public int CertificationsScore { get; set; }
    
    /// <summary>
    /// Score calculated from ProductModel
    /// </summary>
    public int ProductScore { get; set; }
    
    /// <summary>
    /// Score calculated from ClientModel
    /// </summary>
    public int ClientScore { get; set; } 
    
    // Total Eco Score is the sum of the above scores (might need normalization)
    public int TotalEcoScore => InventoryManagementScore + SustainablePracticesScore + CertificationsScore + ProductScore + ClientScore;
}