using System;
using System.Collections.Generic;
using System.IO;

using StardriveModEditor.Models;

namespace StardriveModEditor.Services
{
    public static class DirectoryExplorer
    {




        /// <summary>
        /// Runs through the given mod folder and collects mod profiles from the directory where
        /// a mod profile consists of a configuration xml file and directory sharing it's name.
        /// </summary>
        /// <param name="modDirectoryPath"></param>
        /// <returns></returns>
        public static List<ModProfile> DetectMods(string modDirectoryPath)
        {
            List<ModProfile> modProfiles = new List<ModProfile>();

            //Make sure mod folder exists!
            DirectoryInfo dirInfo = new DirectoryInfo(modDirectoryPath);
            if (!dirInfo.Exists)
                return null;

            foreach (FileInfo fileInfo in dirInfo.GetFiles())
            {
                //The mod configuration will be an xml file.
                if (!fileInfo.Name.EndsWith(".xml"))
                    continue;

                //Cut the extension out.
                string fileName = fileInfo.Name.Substring(0, fileInfo.Name.Length - 4);

                //Loop through the directories in the mod folder, and match it with the configuration.
                foreach(DirectoryInfo childDirInfo in dirInfo.GetDirectories())
                {
                    if(childDirInfo.Name == fileName)
                    {
                        modProfiles.Add(new ModProfile(fileInfo.FullName, childDirInfo.FullName));
                        break;
                    }
                }

            }

            return modProfiles;
        }



    }
}
