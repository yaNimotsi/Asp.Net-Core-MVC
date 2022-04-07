using System;

namespace FabricMethodInICommand.FabricMethod
{
    public class AddNewPhone : RelayCommand
    {
        public AddNewPhone(Action<object> execute, Func<object, bool> canExecute = null) : base(execute, canExecute)
        {
        }
    }
}
