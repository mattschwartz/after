/*using System.IO;
using UnityEngine;

namespace After.Audio 
{
	public class AudioManager
	{
		public static readonly string AudioDirectoryRoot = "Assets/Sound/";
		public static Dictionary<string, AudioSource> AudioSources;

		// Implement this as a button
		public static void RefreshSources() 
		{
			string[] directories = Directory.GetDirectories(AudioDirectoryRoot);

			foreach (var dir in directories) {
				foreach (var file in dir.Files) {

				}
				AssetDatabase.ImportAsset(dir, ImportAssetOptions.Default);
			}


			foreach (FileInfo fInfo in dir.GetFiles("*.mp3")) {
				
				AssetDatabase.ImportAsset(fInfo, ImportAssetOptions.Default);
			}
		}
	}

static List<FileInfo> files = new List<FileInfo>();  // List that will hold the files and subfiles in path
static List<DirectoryInfo> folders = new List<DirectoryInfo>(); // List that hold direcotries that cannot be accessed
static void FullDirList(DirectoryInfo dir, string searchPattern)
{
    // Console.WriteLine("Directory {0}", dir.FullName);
    // list the files
    try
    {
        foreach (FileInfo f in dir.GetFiles(searchPattern))
        {
            //Console.WriteLine("File {0}", f.FullName);
            files.Add(f);                    
        }
    }
    catch
    {
        Console.WriteLine("Directory {0}  \n could not be accessed!!!!", dir.FullName);                
        return;  // We alredy got an error trying to access dir so dont try to access it again
    }

    // process each directory
    // If I have been able to see the files in the directory I should also be able 
    // to look at its directories so I dont think I should place this in a try catch block
    foreach (DirectoryInfo d in dir.GetDirectories())
    {
        folders.Add(d);
        FullDirList(d, searchPattern);                    
    }

}


}
*/