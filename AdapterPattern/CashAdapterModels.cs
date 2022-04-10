using System.Text.Json;

namespace AdapterPattern
{
    internal class CashAdapterModels
    {
        private List<JsonInfoExternalModel> _jsonInfoExternalModels;

        private List<ExternalModelToClientUnitOfTradeAdaptre>? modelsAfterConvert;
        public List<ExternalModelToClientUnitOfTradeAdaptre>? ModelsAfterConver => modelsAfterConvert;

        public CashAdapterModels(List<JsonInfoExternalModel> jsonInfoList)
        {
            _jsonInfoExternalModels = jsonInfoList;
            ProccessingJson();
        }

        private void ProccessingJson()
        {
            if (_jsonInfoExternalModels == null || _jsonInfoExternalModels.Count == 0) return;

            modelsAfterConvert = new();

            foreach (var jsonInfoExternalModel in _jsonInfoExternalModels)
            {
                switch (jsonInfoExternalModel.ExternalModel)
                {
                    case ExternalModelEnum.Model1:
                        modelsAfterConvert.Add(ConvertModel1ToClientModel(jsonInfoExternalModel.ExternalJson));
                        break;
                    case ExternalModelEnum.Model2:
                        modelsAfterConvert.Add(ConvertModel1ToClientModel(jsonInfoExternalModel.ExternalJson));
                        break;
                    default:
                        Console.WriteLine("Не уадлось распознать модель");
                        break;

                }
            }
        }

        private ExternalModelToClientUnitOfTradeAdaptre? ConvertModel1ToClientModel(string jsonString)
        {
            try
            {
                var model = JsonSerializer.Deserialize<Model1>(jsonString);

                if (model == null) return null;

                return new ExternalModelToClientUnitOfTradeAdaptre()
                {
                    Id = model.ItemId,
                    ProducingCompany = model.Company,
                    Name = model.Name,
                    RetailPrice = model.Price,
                    Unit = model.Unit,
                    ManufacturesArticle = model.Article
                };
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private ExternalModelToClientUnitOfTradeAdaptre? ConvertModel2ToClientModel(string jsonString)
        {
            try
            {
                var model = JsonSerializer.Deserialize<Model2>(jsonString);

                if (model == null) return null;

                return new ExternalModelToClientUnitOfTradeAdaptre()
                {
                    Id = model.Id,
                    ProducingCompany = model.ProducingCompany,
                    Name = model.Name,
                    RetailPrice = model.RetailPrice,
                    WholesalePrice = model.WholesalePrice,
                    ManufacturesArticle = model.BarCode
                };
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
