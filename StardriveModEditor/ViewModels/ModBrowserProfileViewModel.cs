using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using StardriveModEditor.Models;

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

        private void EditMod()
        {
            Console.WriteLine("User selected to edit mod: " + Profile.Configuration.ModName);
            Console.WriteLine(Profile.Configuration.ModDescription);
            string basePath = "C:/Program Files/Steam/steamapps/common/StarDrive/Mods";
            ModBrowserViewModel.instance.ModProfiles.Add(new ModBrowserProfileViewModel(new ModProfile(basePath + "/Combined Arms.xml", basePath + "/Combined Arms")));
        }
    }
}
