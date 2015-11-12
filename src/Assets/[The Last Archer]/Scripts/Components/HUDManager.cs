using UnityEngine;
using System.Collections;

namespace TheLastArcher
{
	public class HUDManager : MonoBehaviour 
	{
		IHealthController m_healthController;

		void Start()
		{
			m_healthController = GetComponent<HealthController> ();
		}

	}
}