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
using System.ComponentModel;

namespace StardriveModEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class FolderSelectionWindow : Window
    {
        private VistaFolderBrowserDialog openModDialog;

        public string _selectedModPath = "Test";
        public string SelectedModPath { get => _selectedModPath; set { _selectedModPath = value; } }


        public FolderSelectionWindow()
        {
            InitializeComponent();

            //Init the dialog.
            openModDialog = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog
            {
                Description = "Choose mod directory:",
                UseDescriptionForTitle = true
            };
        }

        private void OnBrowseButtonClicked(object sender, RoutedEventArgs e)
        {
            //This call is blocking. Will have to use a thread to change that.
            if ((bool)openModDialog.ShowDialog())
            {
                SelectedModPath = openModDialog.SelectedPath;
                this.directoryTextBox.Text = SelectedModPath;
                Console.WriteLine(SelectedModPath);
            }
            else
            {
                Console.WriteLine("Folder Selection Cancelled!");
            }
        }

        private void OnOpenModButtonClicked(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Chosen Path: " + SelectedModPath);
        }
    }
}
