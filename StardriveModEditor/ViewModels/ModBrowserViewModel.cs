using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using System.IO;
using Ookii.Dialogs.Wpf;

using StardriveModEditor.Models;
using StardriveModEditor.Services;

namespace StardriveModEditor.ViewModels
{
    class ModBrowserViewModel : BaseViewModel
    {
        public static ModBrowserViewModel Instance;

        #region Public Properties

        public ObservableCollection<ModBrowserProfileViewModel> ModProfiles { get; set; }

        public ICommand OpenDirectoryExplorerCommand { get; set; }

        private string gameDirectoryPath;
        public string GameDirectoryPath
        {
            get => gameDirectoryPath;
            set
            {
                if (gameDirectoryPath == value)
                    return;
                gameDirectoryPath = value;
                Properties.Settings.Default.GameDirectoryPath = value;
                Properties.Settings.Default.Save();
            }
        }

        #endregion

        private readonly VistaFolderBrowserDialog openModDialog;

        public ModBrowserViewModel()
        {
            Instance = this;

            //Load directory path from settings.
            gameDirectoryPath = Properties.Settings.Default.GameDirectoryPath;

            //Init the dialog.
            openModDialog = new VistaFolderBrowserDialog
            {
                Description = "Choose game mod directory:",
                UseDescriptionForTitle = true
            };

            //Add open dialog command. So it actually links and does it.
            OpenDirectoryExplorerCommand = new ActionCommand(OpenDirectoryExplorer);

            //Loads any mod profiles from the default path.
            LoadModProfiles(GameDirectoryPath);
        }

        /// <summary>
        /// Opens the vista folder dialog so folks can find and select their game directory.
        /// </summary>
        private void OpenDirectoryExplorer()
        {
            //Shows dialog, will be true if path selected. Blocking call.
            if (openModDialog.ShowDialog() == true)
            {
                //Save the choice as the new default, then reload mods.
                GameDirectoryPath = openModDialog.SelectedPath;
                LoadModProfiles(GameDirectoryPath);
            }
        }
        
        /// <summary>
        /// Opens all mod profiles that are valid inside the directory given. Doesn't add the \Mods folder for you.
        /// </summary>
        /// <param name="directoryPath">Directory to load from...</param>
        private void LoadModProfiles(string directoryPath)
        {
            //Fetch the mod profiles. If the directory is a thing.
            if (Directory.Exists(directoryPath))
            {
                ModProfiles = new ObservableCollection<ModBrowserProfileViewModel>(DirectoryExplorer.DetectMods(directoryPath)
                                                                                .Select(profile => { return new ModBrowserProfileViewModel(profile); }));
            }
            else
            {
                //Get the empty profile list.
                ModProfiles = new ObservableCollection<ModBrowserProfileViewModel>();
            }
        }
    }
}
