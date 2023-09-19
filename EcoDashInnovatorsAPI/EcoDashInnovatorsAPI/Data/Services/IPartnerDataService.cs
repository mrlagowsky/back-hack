using EcoDashInnovatorsAPI.Models;

namespace EcoDashInnovatorsAPI.Data.Services;

public interface IPartnerDataService
{
    List<PartnerModel>? LoadAllPartners();

    PartnerModel GetNonEcoPartner();

    PartnerModel GetAveragePartner();

    PartnerModel GetEcoPartner();
}