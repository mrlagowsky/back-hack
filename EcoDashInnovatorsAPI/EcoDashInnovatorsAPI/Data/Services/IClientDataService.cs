using EcoDashInnovatorsAPI.Models;

namespace EcoDashInnovatorsAPI.Data.Services;

public interface IClientDataService
{
    List<ClientModel>? LoadAllClients();

    ClientModel GetNonEcoClient();

    ClientModel GetAverageClient();

    ClientModel GetEcoClient();
}