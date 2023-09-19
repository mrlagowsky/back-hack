using EcoDashInnovatorsAPI.Models;
using EcoDashInnovatorsAPI.Models.Enums;
using Newtonsoft.Json;

namespace EcoDashInnovatorsAPI.Data.Services;

public static class DataService
{
    public static List<ProductModel> LoadAllProducts()
    {
        string fileName = "Data\\ProductBlob.json";
        string jsonString = File.ReadAllText(fileName);
        var products = JsonConvert.DeserializeObject<List<ProductModel>>(jsonString);
        return products;
    }

    /// <summary>
    /// Method to calculate the product score based on a given list
    /// </summary>
    /// <returns></returns>
    public static int CalculateProductScore(List<ProductModel> products)
    {
        if (products == null || products.Count == 0)
        {
            return 0;  // Return 0 if there are no products or null is passed.
        }
    
        int totalScore = 0;

        foreach (var product in products)
        {
            int productScore = 0;

            // 1. Calculate average score for materials
            double materialScore = 0;
            materialScore += MaterialExtensions.CalculateAverageScore(product.Materials);
            materialScore = product.Materials.Count > 0 ? materialScore / product.Materials.Count : 0;

            // Adjust scores to align with the 300-1000 range.
            // 2. Incorporate other ecological factors.
            if (product.UsesRenewableEnergy) productScore += 150;
            if (product.MinimalPackaging) productScore += 80;
            if (product.RecyclablePackaging) productScore += 80;
            if (product.IsBiodegradable) productScore += 150;
            if (product.CanBeRecycled) productScore += 100;

            // 3. Adjust based on supply chain distance and transport mode.
            if (product.SupplyChainDistance > 5000) productScore -= 100;
            else if (product.SupplyChainDistance > 1000) productScore -= 50;

            if (product.TransportMode == "Air") productScore -= 70;
            else if (product.TransportMode == "Sea") productScore -= 40;

            // Incorporate material score into the product score.
            productScore += (int)materialScore;

            // Clamp the individual product score between 300 and 1000
            productScore = Math.Max(300, Math.Min(1000, productScore));

            totalScore += productScore;
        }

        // 4. Calculate average score for all products
        int averageScore = totalScore / products.Count;

        return averageScore;
    }

}