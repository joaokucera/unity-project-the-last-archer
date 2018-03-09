using System.IO;
using UnityEditor;
using UnityEngine;

namespace TheLastArcher
{
	public static class FoldersCreator 
	{
		[MenuItem("Tools / Create Project Folders")]
		public static void CreateProjectFolders()
		{
			string[] folderNames = 
			{ 
				"Animations", 
				"Animators", 
				"Audios", 
                "Editor",
                "Fonts", 
				"Gizmos",
				"Materials", 
				"Models", 
				"Prefabs", 
				"Resources", 
				"Scenes", 
				"Scripts", 
				"Shaders", 
				"Textures"
			};

			for (int i = 0; i < folderNames.Length; i++) 
			{
				CreateFolder(Application.dataPath, "[Project Name]", folderNames[i]);
			}

			CreateFolder(Application.dataPath, "Community Assets");
			CreateFolder(Application.dataPath, "Standard Assets");

			AssetDatabase.Refresh ();
		}

		private static void CreateFolder(params string[] paths)
		{
			string path = string.Join ("/", paths);

			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
		}
	}
}