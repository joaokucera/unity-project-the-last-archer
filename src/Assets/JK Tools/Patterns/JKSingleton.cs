using UnityEngine;

namespace JK.Patterns
{
	public class JKSingleton<T> : MonoBehaviour where T : MonoBehaviour
	{
		private static T m_instance;

		[SerializeField] public bool m_dontDestroyOnLoad;

		protected static T Instance
		{
			get
			{
				if (m_instance == null)
				{
					m_instance = FindObjectOfType<T>();
				}

				if (m_instance == null)
				{
					string error = string.Format("An instance of {0} is needed in the scene, but there is none.", typeof(T));

					Debug.LogError(error);
				}

				return m_instance;
			}
		}

		void Awake()
		{
			if (m_dontDestroyOnLoad)
			{
				if (m_instance == null)
				{
					m_instance = FindObjectOfType<T>();

					DontDestroyOnLoad(gameObject);
				}
				else
				{
					Destroy(gameObject);
				}
			}
		}
	}
}