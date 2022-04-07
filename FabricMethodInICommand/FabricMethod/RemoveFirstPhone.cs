using System;

namespace FabricMethodInICommand.FabricMethod
{
    public class RemoveFirstPhone : RelayCommand
    {
        public RemoveFirstPhone(Action<object> execute, Func<object, bool> canExecute = null) : base(execute, canExecute)
        {
        }
    }
}
