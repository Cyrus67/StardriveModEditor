using System;

using StardriveModEditor.Services;

namespace StardriveModEditor.Models
{
    public class ModProfile
    {
        public ModConfiguration Configuration { get; set; }

        public string DirectoryPath { get; private set; }

        public ModProfile(string configurationPath, string directoryPath)
        {
            Configuration = XMLSerializer.Deserialize<ModConfiguration>(configurationPath);
            Configuration.Path = configurationPath;
            DirectoryPath = directoryPath;
        }
    }
}
