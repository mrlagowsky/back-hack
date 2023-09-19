using EcoDashInnovatorsAPI.Data.Helpers;
using EcoDashInnovatorsAPI.Data.Services;
using EcoDashInnovatorsAPI.Models;
using EcoDashInnovatorsAPI.Models.ApiModels;
using Microsoft.AspNetCore.Mvc;

namespace EcoDashInnovatorsAPI.Controllers;

[ApiController]
[Route("api/partners")] 
public class PartnerController : ControllerBase
{
    private readonly IPartnerDataService _partnerDataService;

    public PartnerController(IPartnerDataService partnerDataService)
    {
        _partnerDataService = partnerDataService;
    }

    [HttpGet("{partnerId}", Name = "GetPartnerScore")]
    public IActionResult GetPartnerScore(int partnerId)
    {
        try
        {
            var basePartner = GetPartnerData(partnerId);
            basePartner.AssignScores();
            
            var returnModel = new PartnerDataModel();
            DataMapper.MapPartnerData(basePartner, returnModel);

            return Ok(returnModel);
        }
        catch (Exception ex)
        {
            // Log the exception for debugging purposes
            // You can also return a more specific error message
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }

    private PartnerModel GetPartnerData(int partnerId)
    {
        switch (partnerId)
        {
            case 1:
                return _partnerDataService.GetNonEcoPartner();
            case 2:
                return _partnerDataService.GetAveragePartner();
            case 3:
                return _partnerDataService.GetEcoPartner();
            default:
                throw new Exception($"Partner with ID {partnerId} not found.");
        }
    }
}
