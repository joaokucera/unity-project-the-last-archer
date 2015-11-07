using UnityEngine;

namespace JK.Extensions
{
	public static class JKExtensionMethods 
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