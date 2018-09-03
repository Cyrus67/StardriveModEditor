using System;
using System.Windows;

using StardriveModEditor.Models;
using StardriveModEditor.ViewModels;

namespace StardriveModEditor.Windows
{
    public partial class MainEditorView : Window
    {
        public MainEditorView(ModProfile modToEdit)
        {
            InitializeComponent();

            this.DataContext = new MainEditorViewModel(modToEdit);
        }
    }
}
