using System;

namespace Millioner.Utilities
{
    class Command : System.Windows.Input.ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly Action<object> execute;
        private readonly Predicate<object> can_execute;

        public Command(Action<object> execute, Predicate<object> can_execute = null)
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this.can_execute = can_execute;
        }

        public bool CanExecute(object parameter)
        {
            return can_execute?.Invoke(parameter) ?? true;
        }

        public void Execute(object parameter)
        {
            execute.Invoke(parameter);
        }
    }
}
