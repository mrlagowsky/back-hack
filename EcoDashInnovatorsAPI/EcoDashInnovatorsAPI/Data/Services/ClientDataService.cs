using EcoDashInnovatorsAPI.Models;
using Newtonsoft.Json;

namespace EcoDashInnovatorsAPI.Data.Services;

public class ClientDataService : IClientDataService
{
    public List<ClientModel>? LoadAllClients()
    {
        string fileName = "Data\\ClientBlob.json";
        string jsonString = File.ReadAllText(fileName);
        var clients = JsonConvert.DeserializeObject<List<ClientModel>>(jsonString);
        return clients;
    }

    public ClientModel GetNonEcoClient()
    {
        return LoadAllClients().SingleOrDefault(p => p.Id == 1);
    }
    
    public ClientModel GetAverageClient()
    {
        return LoadAllClients().SingleOrDefault(p => p.Id == 2);
    }
    
    public ClientModel GetEcoClient()
    {
        return LoadAllClients().SingleOrDefault(p => p.Id == 3);
    }
}