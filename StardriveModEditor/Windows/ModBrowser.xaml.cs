using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using System.IO;
using System.Xml;
using System.Xml.Linq;

using StardriveModEditor.Services;
using StardriveModEditor.Models;

namespace StardriveModEditor
{
    /// <summary>
    /// Interaction logic for ModBrowser.xaml
    /// </summary>
    public partial class ModBrowser : Window
    {
        private List<ModProfile> modProfiles;

        public ModBrowser()
        {
            InitializeComponent();

            //Fetch the mod profiles.
            modProfiles = DirectoryExplorer.DetectMods("C:/Program Files/Steam/steamapps/common/StarDrive/Mods");
            foreach (ModProfile profile in modProfiles)
            {
                Console.WriteLine(profile.configuration.ModName + ": " + profile.configuration.ModDescription);
                Console.WriteLine(profile.configuration.Version);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
