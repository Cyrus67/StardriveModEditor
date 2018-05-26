using System;
using System.Windows.Input;

namespace StardriveModEditor.ViewModels
{
    /// <summary>
    /// A class to save simple actions as commands.
    /// </summary>
    class ActionCommand : ICommand
    {
        private readonly Action mAction;

        public event EventHandler CanExecuteChanged = (sender, e) => { };

        public ActionCommand(Action action)
        {
            mAction = action;
        }

        /// <summary>
        /// Simple action commands should always execute
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Runs the action.
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            mAction();
        }
    }
}
