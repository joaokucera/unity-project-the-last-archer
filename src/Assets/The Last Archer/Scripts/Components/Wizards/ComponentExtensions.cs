using UnityEngine;

namespace TheLastArcher.Wizards
{
	public static class ComponentExtensions 
	{
		public static T GetOrAddComponent<T>(this Component child) where T : Component
		{
			T result = child.GetComponent<T>();
			
			if (result == null)
			{
				result = child.gameObject.AddComponent<T>();
			}
			
			return result;
		}
	}
}