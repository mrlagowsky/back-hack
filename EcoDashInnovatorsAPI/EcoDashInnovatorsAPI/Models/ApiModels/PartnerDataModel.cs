using System.Runtime.Serialization;

namespace EcoDashInnovatorsAPI.Models.ApiModels;

[DataContract]
public class PartnerDataModel
{
    [DataMember(Name = "Id")]
    public int Id { get; set; }

    [DataMember(Name = "InventoryManagementScore")]
    public int InventoryManagementScore { get; set; }

    [DataMember(Name = "SustainablePracticesScore")]
    public int SustainablePracticesScore { get; set; }

    [DataMember(Name = "CertificationScore")]
    public int CertificationScore { get; set; }

    [DataMember(Name = "ProductScore")]
    public int ProductScore { get; set; }

    [DataMember(Name = "Badges")]
    public List<int>? Badges { get; set; }
    
    [DataMember(Name = "TotalScore")]
    public int TotalScore { get; set; }

}