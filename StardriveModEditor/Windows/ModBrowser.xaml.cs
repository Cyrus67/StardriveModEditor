using System;
using System.Windows;

using StardriveModEditor.ViewModels;

namespace StardriveModEditor
{
    /// <summary>
    /// Interaction logic for ModBrowser.xaml
    /// </summary>
    public partial class ModBrowser : Window
    {
        public static ModBrowser Instance;

        public ModBrowser()
        {
            Instance = this;

            InitializeComponent();

            this.DataContext = new ModBrowserViewModel();
        }
    }
}
