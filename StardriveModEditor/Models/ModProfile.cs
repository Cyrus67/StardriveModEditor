using System;

using StardriveModEditor.Services;

namespace StardriveModEditor.Models
{
    public class ModProfile
    {
        public ModConfiguration configuration;

        public readonly string DirectoryPath;

        public ModProfile(string configurationPath, string directoryPath)
        {
            configuration = XMLSerializer.Deserialize<ModConfiguration>(configurationPath);
            configuration.Path = configurationPath;
            DirectoryPath = directoryPath;
        }
    }
}
