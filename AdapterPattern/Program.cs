
using AdapterPattern;

using System.Text.Json;

var resultUnitOfTrade = new List<ClientUnitOfTrade>();

var jsonInfoExternalModels = new List<JsonInfoExternalModel>();

foreach (var jsonInfoExternalModel in jsonInfoExternalModels)
{
    DeserealizeExternalJson(jsonInfoExternalModel);
}

Console.ReadLine();

ClientUnitOfTrade DeserealizeExternalJson(JsonInfoExternalModel item)
{
    var jsonModel = item.ExternalModel;
    var model = JsonSerializer.Deserialize<typeof(jsonModel) >(item.ExternalJson);
    return null;
}
