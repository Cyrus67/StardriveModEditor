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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.Windows.Interop;
using Ookii.Dialogs.Wpf;

namespace StardriveModEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class FolderSelectionWindow : Window
    {
        public FolderSelectionWindow()
        {
            InitializeComponent();
            //
            var dialog = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog
            {
                Description = "Choose mod directory:",
                UseDescriptionForTitle = true
            };
            //This call is blocking. Will have to use a thread to change that.
            //string dialogResult;
            //if ((bool)dialog.ShowDialog())
            //{
            //    dialogResult = dialog.SelectedPath;
            //    Console.WriteLine(dialogResult);
            //}
            //else
            //{
            //    Console.WriteLine("Folder Selection Cancelled!");
            //}
        }
    }
}
