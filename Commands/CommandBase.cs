using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ToolBox.MVVM.Commands
{
    public class CommandBase : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action action;
        private Func<bool> canActivate;

        public CommandBase(Action action, Func<bool> canActivate = null)
        {
            if (action is null) throw new ArgumentException();
            this.action = action;
            this.canActivate = canActivate;
        }

        public bool CanExecute(object parameter)
        {
            if(canActivate is null)
            {
                return true;
            }
            return canActivate.Invoke(); 
        }

        public void Execute(object parameter)
        {
            action?.Invoke();
        }

        public void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, null);
        }
    }
}
