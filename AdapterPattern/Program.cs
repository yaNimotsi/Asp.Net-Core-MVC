
using AdapterPattern;

var resultUnitOfTrade = new List<ClientUnitOfTrade>();

var jsonInfoExternalModels = new List<JsonInfoExternalModel>();

var cashAdapterModels = new CashingAdapterModels(jsonInfoExternalModels);


resultUnitOfTrade.AddRange(cashAdapterModels.ModelsAfterConver);

Console.ReadLine();


