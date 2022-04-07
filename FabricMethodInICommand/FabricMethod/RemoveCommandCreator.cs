namespace FabricMethodInICommand.FabricMethod
{
    public class RemoveCommandCreator : CommandCreator
    {
        public override RelayCommand FactoryMethod()
        {
            return new RemoveFirstPhone(obj =>
            {
                var allPhones = ApplicationViewModel.Phones;
                if (allPhones != null && allPhones.Count > 0)
                {
                    ApplicationViewModel.Phones.RemoveAt(0);
                }
            });
        }
    }
}
