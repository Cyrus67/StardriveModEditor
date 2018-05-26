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
        public ModBrowser()
        {
            InitializeComponent();


            ModViewer.DataContext = new ModBrowserViewModel();
        }
    }
}
