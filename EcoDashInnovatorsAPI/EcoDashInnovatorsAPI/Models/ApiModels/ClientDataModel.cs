using System.Runtime.Serialization;

namespace EcoDashInnovatorsAPI.Models.ApiModels;

[DataContract]
public class ClientDataModel
{
    [DataMember(Name = "Id")]
    public int Id { get; set; }

    [DataMember(Name = "PurchasePatternsScore")]
    public int PurchasePatternsScore { get; set; }

    [DataMember(Name = "ReturnPatternsScore")]
    public int ReturnPatternsScore { get; set; }

    [DataMember(Name = "FeedbackScore")]
    public int FeedbackScore { get; set; }

    [DataMember(Name = "ProductScore")]
    public int ProductScore { get; set; }

    [DataMember(Name = "Badges")]
    public List<int>? Badges { get; set; }
    
    [DataMember(Name = "TotalScore")]
    public int TotalScore { get; set; }
    
}