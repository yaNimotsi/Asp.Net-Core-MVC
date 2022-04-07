namespace FabricMethodInICommand.FabricMethod
{
    public class AddNewCommandCreator : CommandCreator
    {
        public override RelayCommand FactoryMethod()
        {
            return new AddNewPhone(obj =>
            {
                Phone phone = new Phone();
                ApplicationViewModel.Phones.Insert(0, phone);
            });
        }
    }
}
