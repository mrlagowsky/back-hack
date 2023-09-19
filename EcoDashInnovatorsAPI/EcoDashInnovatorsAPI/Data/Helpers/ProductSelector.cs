using EcoDashInnovatorsAPI.Models;

namespace EcoDashInnovatorsAPI.Data.Helpers;

public static class ProductSelector
{
    private static Random _random = new Random();

    public static List<ProductModel> SelectRandomProducts(List<ProductModel> products)
    {
        if (products == null || products.Count == 0)
            throw new ArgumentException("The product list is empty.");

        // Step 1: Get a random number between 1 and the number of products (35 in this case).
        int numberOfProductsToSelect = _random.Next(1, products.Count + 1);

        // Step 2: Shuffle the list and take the desired number of products.
        return products.OrderBy(p => _random.Next()).Take(numberOfProductsToSelect).ToList();
    }
}