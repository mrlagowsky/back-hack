using EcoDashInnovatorsAPI.Data.Helpers;
using EcoDashInnovatorsAPI.Data.Services;
using EcoDashInnovatorsAPI.Models;
using EcoDashInnovatorsAPI.Models.ApiModels;
using Microsoft.AspNetCore.Mvc;

namespace EcoDashInnovatorsAPI.Controllers;

[ApiController]
[Route("api/clients")] 
public class ClientController : ControllerBase
{
    private readonly IClientDataService _clientDataService;

    public ClientController(IClientDataService clientDataService)
    {
        _clientDataService = clientDataService;
    }

    [HttpGet("{clientId}", Name = "GetClientScore")]
    public IActionResult GetClientScore(int clientId)
    {
        try
        {
            var baseClient = GetClientData(clientId);
            baseClient.AssignScores();
            
            var returnModel = new ClientDataModel();
            DataMapper.MapClientData(baseClient, returnModel);

            return Ok(returnModel);
        }
        catch (Exception ex)
        {
            // Log the exception for debugging purposes
            // You can also return a more specific error message
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }

    private ClientModel GetClientData(int clientId)
    {
        switch (clientId)
        {
            case 1:
                return _clientDataService.GetNonEcoClient();
            case 2:
                return _clientDataService.GetAverageClient();
            case 3:
                return _clientDataService.GetEcoClient();
            default:
                throw new Exception($"Client with ID {clientId} not found.");
        }
    }
}