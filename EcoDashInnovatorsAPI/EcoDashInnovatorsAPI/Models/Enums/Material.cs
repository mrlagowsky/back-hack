using System.ComponentModel;

namespace EcoDashInnovatorsAPI.Models.Enums;

public enum Material
{
    [Description("Recycled Plastic")]
    RecycledPlastic,
    [Description("Organic Cotton")]
    OrganicCotton,
    [Description("Bamboo")]
    Bamboo,
    [Description("Polyester")]
    Polyester,
    [Description("Wool")]
    Wool,
    [Description("Wood")]
    Wood,
    [Description("Cork")]
    Cork,
    [Description("Glass")]
    Glass,
    [Description("Natural Fiber")]
    NaturalFiber,
    [Description("Rubber")]
    Rubber,
    [Description("Linen")]
    Linen,
    [Description("Ceramic")]
    Ceramic,
    [Description("Jute")]
    Jute,
    [Description("Synthetic Fiber")]
    SyntheticFiber,
    [Description("Stone")]
    Stone,
    [Description("Flax")]
    Flax,
    [Description("Cashmere")]
    Cashmere,
    [Description("Coconut Shell")]
    CoconutShell,
    [Description("Silk")]
    Silk,
    [Description("Recycled Leather")]
    RecycledLeather,
    [Description("NaturalRubber")]
    NaturalRubber,
    [Description("Recycled Metal")]
    RecycledMetal,
    [Description("Recycled Aluminum")]
    RecycledAluminum,
    [Description("Recycled Glass")]
    RecycledGlass,
    [Description("Recycled Cardboard")]
    RecycledCardboard,
    [Description("Recycled Rubber")]
    RecycledRubber,
    [Description("Metal")]
    Metal,
    [Description("Regular Cotton")]
    RegularCotton,
    [Description("Biodegradable Polymers")]
    BiodegradablePolymers,
    [Description("Cotton")]
    Cotton,
    [Description("Plastic")]
    Plastic
}

public static class MaterialExtensions
{
    
    public static double CalculateAverageScore(IList<Material> materials)
    {
        if (materials == null || !materials.Any())
        {
            return 0.0;
        }

        double totalScore = materials.Sum(material => material.GetEcologicalScore());
        return totalScore / materials.Count;
    }
    
    public static int GetEcologicalScore(this Material material)
    {
        switch (material)
        {
            case Material.RecycledPlastic:
                return 900;
            case Material.OrganicCotton:
                return 950;
            case Material.Bamboo:
                return 850;
            case Material.Polyester:
                return 450;
            case Material.Wool:
                return 800;
            case Material.RecycledLeather:
                return 750;
            case Material.Wood:
                return 900;
            case Material.Cork:
                return 880;
            case Material.Glass:
                return 700;
            case Material.NaturalFiber:
                return 900;
            case Material.Rubber:
                return 700;
            case Material.Linen:
                return 850;
            case Material.Ceramic:
                return 800;
            case Material.Jute:
                return 920;
            case Material.SyntheticFiber:
                return 400;
            case Material.Stone:
                return 850;
            case Material.Flax:
                return 920;
            case Material.Cashmere:
                return 750;
            case Material.CoconutShell:
                return 900;
            case Material.Silk:
                return 800;
            case Material.NaturalRubber:
                return 910;
            case Material.RecycledMetal:
                return 850;
            case Material.RecycledAluminum:
                return 880;
            case Material.RecycledGlass:
                return 850;
            case Material.RecycledCardboard:
                return 800;
            case Material.RecycledRubber:
                return 700;
            case Material.Metal:
                return 650;
            case Material.RegularCotton:
                return 600;
            case Material.BiodegradablePolymers:
                return 900;
            case Material.Cotton:
                return 700;
            case Material.Plastic:
                return 300;
            default:
                return 0;
        }
    }
}
