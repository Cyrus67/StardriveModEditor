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
        public ModBrowser()
        {
            InitializeComponent();
            DirectoryInfo dirInfo = new DirectoryInfo("C:/Program Files/Steam/steamapps/common/StarDrive/Content/Buildings");

            Console.WriteLine("\n\n");

            string testPath = dirInfo.GetFiles()[0].FullName;
            string testPath2 = dirInfo.GetFiles()[1].FullName;

            Building testBuilding = XMLSerializer.Deserialize<Building>(testPath);

            Console.WriteLine(testBuilding.Name);
            Console.WriteLine(testBuilding.Cost);
            Console.WriteLine(testBuilding.Scrappable);
            Console.WriteLine(testBuilding.Desc);


            Building testBuilding2 = XMLSerializer.Deserialize<Building>(testPath2);

            Console.WriteLine(testBuilding2.Name);
            Console.WriteLine(testBuilding2.Cost);
            Console.WriteLine(testBuilding2.Scrappable);
            Console.WriteLine(testBuilding2.Desc);

            Console.WriteLine("\n\n\n");

            XMLSerializer.Serialize<Building>(testBuilding, @"C:\Users\Nick\Desktop\tb.xml");
            XMLSerializer.Serialize<Building>(testBuilding2, @"C:\Users\Nick\Desktop\tb2.xml");
        }
    }
}
