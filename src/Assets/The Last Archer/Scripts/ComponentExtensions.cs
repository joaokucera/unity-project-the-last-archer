using UnityEngine;

namespace TheLastArcher
{
	public static class ComponentExtensions 
	{
		public static T GetOrAddComponent<T>(this Component component) where T : Component
		{
			T result = component.GetComponent<T>();
			
			if (result == null)
			{
				result = component.gameObject.AddComponent<T>();
			}
			
			return result;
		}

		public static T FindComponentInHierarchy<T>(this Component component) where T : Component
		{
			T result = component.GetComponent<T>();

			if (result == null)
			{
				result = component.GetComponentInChildren<T>();
			}

			return result;
		}
	}
}