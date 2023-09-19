using EcoDashInnovatorsAPI.Models;
using Newtonsoft.Json;

namespace EcoDashInnovatorsAPI.Data.Services;

public class PartnerDataService : IPartnerDataService
{
    public List<PartnerModel>? LoadAllPartners()
    {
        string fileName = "Data\\PartnerBlob.json";
        string jsonString = File.ReadAllText(fileName);
        var partners = JsonConvert.DeserializeObject<List<PartnerModel>>(jsonString);
        return partners;
    }

    public PartnerModel GetNonEcoPartner()
    {
        return LoadAllPartners().SingleOrDefault(p => p.Id == 1);
    }
    
    public PartnerModel GetAveragePartner()
    {
        return LoadAllPartners().SingleOrDefault(p => p.Id == 2);
    }
    
    public PartnerModel GetEcoPartner()
    {
        return LoadAllPartners().SingleOrDefault(p => p.Id == 3);
    }
}