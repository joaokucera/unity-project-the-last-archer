using UnityEngine;

namespace TheLastArcher
{
	public static class GlobalVariables
	{
		private static Camera m_mainCamera;
		public static Camera MainCamera 
		{
			get 
			{
				if (m_mainCamera == null)
				{
					m_mainCamera = Camera.main;
				}

				return m_mainCamera;
			}
		}
	}
}