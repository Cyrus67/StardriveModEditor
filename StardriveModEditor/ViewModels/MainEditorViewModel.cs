using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using StardriveModEditor.Models;
using StardriveModEditor.Windows;
using StardriveModEditor.Services;

namespace StardriveModEditor.ViewModels
{
    class MainEditorViewModel : BaseViewModel
    {
        public static MainEditorViewModel Instance;

        #region Public Properties
        public ModProfile ActiveMod { get; private set; }

        public string WindowTitle
        {
            get
            {
                return ActiveMod.Configuration.ModName;
            }
        }

        public ICommand TestCommand { get; set; }
        #endregion



        public MainEditorViewModel(ModProfile modToEdit)
        {
            Instance = this;
            ActiveMod = modToEdit;

            TestCommand = new ActionCommand(TestCommandFunction);
        }

        private void TestCommandFunction()
        {
            Console.WriteLine("Test command fired!");
        }


    }
}
