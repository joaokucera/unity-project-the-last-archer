using UnityEditor;
using UnityEngine;

namespace TheLastArcher
{
	public class MissingScripts : EditorWindow
	{
        private static int obj_count = 0, components_count = 0, missing_count = 0;
	
		private void OnGUI()
		{
			if (GUILayout.Button("Find Missing Scripts in selected GameObjects"))
			{
				FindInSelected();
			}
		}

		[MenuItem("Tools / Find Missing Scripts Recursively")]
		public static void ShowWindow()
		{
			EditorWindow.GetWindow(typeof(MissingScripts));
		}

		private static void FindInSelected()
		{
            obj_count = 0;
			components_count = 0;
			missing_count = 0;

            GameObject[] objs = Selection.gameObjects;

            foreach (GameObject obj in objs)
			{
				FindInGameObject(obj);
			}

			Debug.Log(string.Format("Searched {0} GameObjects, {1} components, found {2} missing", obj_count, components_count, missing_count));
		}
		
        private static void FindInGameObject(GameObject obj)
		{
			obj_count++;

			Component[] components = obj.GetComponents<Component>();

			for (int i = 0; i < components.Length; i++)
			{
				components_count++;

				if (components[i] == null)
				{
					missing_count++;
					string s = obj.name;
					Transform t = obj.transform;

					while (t.parent != null) 
					{
						s = t.parent.name +"/"+s;
						t = t.parent;
					}

					Debug.Log (s + " has an empty script attached in position: " + i, obj);
				}
			}

            foreach (Transform child in obj.transform)
			{
				FindInGameObject(child.gameObject);
			}
		}
	}
}