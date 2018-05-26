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
        public static ModBrowserViewModel instance;

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
            instance = this;

            //Load directory path from settings.
            GameDirectoryPath = Properties.Settings.Default.GameDirectoryPath;

            //Init the dialog.
            openModDialog = new VistaFolderBrowserDialog
            {
                Description = "Choose game directory:",
                UseDescriptionForTitle = true
            };

            //Add open dialog command.
            OpenDirectoryExplorerCommand = new ActionCommand(OpenDirectoryExplorer);

            //Fetch the mod profiles. If the directory is a thing.
            string targetDirPath = GameDirectoryPath + @"\Mods";
            Console.WriteLine(targetDirPath);
            if (Directory.Exists(targetDirPath))
            {
                ModProfiles = new ObservableCollection<ModBrowserProfileViewModel>(DirectoryExplorer.DetectMods(targetDirPath)
                                                                                    .Select(profile => { return new ModBrowserProfileViewModel(profile); }));
            }
            

        }

        private void OpenDirectoryExplorer()
        {
            //Shows dialog, will be true if path selected.
            if (openModDialog.ShowDialog() == true)
            {
                GameDirectoryPath = openModDialog.SelectedPath;
            }
        }
        

        private void LoadModProfiles()
        {
            ModProfiles = new ObservableCollection<ModBrowserProfileViewModel>(DirectoryExplorer.DetectMods(GameDirectoryPath + @"\Mods\")
                                                                                .Select(profile => { return new ModBrowserProfileViewModel(profile); }));
        }
    }
}
