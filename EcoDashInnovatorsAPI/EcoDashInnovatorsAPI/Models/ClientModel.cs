using EcoDashInnovatorsAPI.Data.Helpers;
using EcoDashInnovatorsAPI.Data.Services;

namespace EcoDashInnovatorsAPI.Models;

public class ClientModel
{
    /// <summary>
    /// Individual client Id
    /// </summary>
    public int Id { get; set; }  
    
    /// <summary>
    /// Number of eco-friendly products purchased
    /// </summary>
    public int EcoFriendlyPurchases { get; set; }

    /// <summary>
    /// Total number of products purchased
    /// </summary>
    public int TotalPurchases { get; set; } 
    
    /// <summary>
    /// Score for individual purchase patterns, combination (ratio) of EcoFriendlyPurchases and TotalPurchases
    /// </summary>
    public int PurchasePatternsScore { get; set; }
    
    /// <summary>
    /// Number of products returned
    /// </summary>
    public int Returns { get; set; } 
    
    /// <summary>
    /// Number of products recycled, for example bottles returned
    /// </summary>
    public int ProductsRecycled { get; set; } 
    
    /// <summary>
    /// Score for individual purchase patterns, combination of Returns and ProductsRecycled
    /// </summary>
    public int ReturnPatternsScore { get; set; }
    
    /// <summary>
    /// Count of feedbacks given related to ecological aspects
    /// </summary>
    public int FeedbacksGiven { get; set; }

    /// <summary>
    /// Measure of how many ecological events the individual has attended
    /// </summary>
    public int EcoEventsAttended { get; set; }
    
    /// <summary>
    /// Score for individual eco feedback patterns, combination of FeedbacksGiven and EcoEventsAttended
    /// </summary>
    public int FeedbackScore { get; set; }

    /// <summary>
    /// Score for individual purchase history
    /// </summary>
    public int ProductScore { get; set; }
    
    /// <summary>
    /// Total measure of ecological score for a Client
    /// </summary>
    public int TotalEcoScore =>
        (FeedbackScore + ReturnPatternsScore + PurchasePatternsScore + ProductScore) / 4;

    public void AssignScores()
    {
        PurchasePatternsScore = CalculatePurchasePatternsScore();
        ReturnPatternsScore = CalculateReturnPatternsScore();
        FeedbackScore = CalculateFeedbackScore();
        var allProducts = DataService.LoadAllProducts();
        var sampleProductScore = DataService.CalculateProductScore(ProductSelector.SelectRandomProducts(allProducts));
        ProductScore = sampleProductScore;
    }

    private int CalculatePurchasePatternsScore()
    {
        if (TotalPurchases == 0) return 300; // handle division by zero
        double ratio = (double)EcoFriendlyPurchases / TotalPurchases;
        return MapToScore(ratio);
    }

    private int CalculateReturnPatternsScore()
    {
        if (Returns == 0) return 300; // handle division by zero
        double ratio = (double)ProductsRecycled / Returns;
        return MapToScore(ratio);
    }

    private int CalculateFeedbackScore()
    {
        // Assuming attending one event is equivalent to giving one feedback.
        int totalFeedbackPoints = FeedbacksGiven + EcoEventsAttended;
        double ratio = totalFeedbackPoints / (double)(FeedbacksGiven + EcoEventsAttended + 10); // Adding 10 to prevent 1:1 mapping
        return MapToScore(ratio);
    }

    private int MapToScore(double ratio)
    {
        // Ensure the score is between 300 and 1000 based on the ratio.
        int score = 300 + (int)(ratio * 700);
        return Math.Max(300, Math.Min(score, 1000));
    }
}