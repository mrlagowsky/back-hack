using EcoDashInnovatorsAPI.Models;
using EcoDashInnovatorsAPI.Models.ApiModels;

namespace EcoDashInnovatorsAPI.Data.Helpers;

public static class DataMapper
{
    public static void MapPartnerData(PartnerModel model, PartnerDataModel returnObject)
    {
        returnObject.Id = model.Id;
        returnObject.CertificationScore = model.CertificationScore;
        returnObject.SustainablePracticesScore = model.SustainablePracticesScore;
        returnObject.ProductScore = model.ProductScore;
        returnObject.InventoryManagementScore = model.InventoryManagementScore;
        returnObject.TotalScore = model.TotalEcoScore;
        returnObject.Badges = BadgeAssigner.GetBadges(EntityType.Partner, model.TotalEcoScore, model.ProductScore);
    }
    
    public static void MapClientData(ClientModel model, ClientDataModel returnObject)
    {
        returnObject.Id = model.Id;
        returnObject.PurchasePatternsScore = model.PurchasePatternsScore;
        returnObject.FeedbackScore = model.FeedbackScore;
        returnObject.ProductScore = model.ProductScore;
        returnObject.ReturnPatternsScore = model.ReturnPatternsScore;
        returnObject.TotalScore = model.TotalEcoScore;
        returnObject.Badges = BadgeAssigner.GetBadges(EntityType.Client, model.TotalEcoScore, model.ProductScore);
    }
}