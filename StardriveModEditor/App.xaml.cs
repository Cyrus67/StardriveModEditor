using System;
using System.Windows;

using StardriveModEditor.Models;
using StardriveModEditor.Services;

namespace StardriveModEditor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static App Instance;

        public App()
        {
            Instance = this;
        }

        private void OnStart(object sender, StartupEventArgs e)
        {
            Window startingWindow = new ModBrowser();
            startingWindow.Show();
            
        }
    }
}
