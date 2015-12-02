#if UNITY_EDITOR
using System.IO;
using UnityEditor;
using UnityEngine;

namespace TheLastArcher.Tools
{
	public static class FoldersCreator 
	{
		[MenuItem("JK Tools / Create Project Folders")]
		public static void CreateProjectFolders()
		{
			string[] folderNames = 
			{ 
				"Animations", 
				"Animators", 
				"Audio", "Audio/Music", "Audio/SoundEffects", 
				"Fonts", 
				"Gizmos",
				"Materials", 
				"Models", 
				"Prefabs", 
				"Resources", 
				"Scenes", 
				"Scripts", "Scripts/Components", "Scripts/Editor", 
				"Shaders", 
				"Textures",
				"WebPlayerTemplates"
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
#endif