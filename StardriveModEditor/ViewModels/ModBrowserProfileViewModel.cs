using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using StardriveModEditor.Models;
using StardriveModEditor.Windows;

namespace StardriveModEditor.ViewModels
{
    class ModBrowserProfileViewModel
    {
        public ModProfile Profile { get; set; }

        public ICommand EditModCommand { get; set; }

        public ModBrowserProfileViewModel(ModProfile myProfile)
        {
            Profile = myProfile;
            EditModCommand = new ActionCommand(EditMod);
        }

        /// <summary>
        /// Selects and loads up the editor for the mod selected. Might explode if things are missing.
        /// </summary>
        private void EditMod()
        {
            Console.WriteLine("User selected to edit mod: " + Profile.Configuration.ModName);
            Console.WriteLine(Profile.Configuration.ModDescription);
            Console.WriteLine("Mod config path: " + Profile.Configuration.Path);
            Console.WriteLine("Mod directory path: " + Profile.DirectoryPath);

            //Create the mainEditorView, then 
            MainEditorView mainEditorView = new MainEditorView(Profile);
            mainEditorView.Show();
            ModBrowser.Instance.Close();
        }
    }
}
