using UnityEngine;
using System.Collections;

namespace TheLastArcher
{
	public abstract class AttackController
	{
		protected IMotorController m_controller;
		protected Transform m_parent;
		protected GameObject m_prefab;

		public AttackController (IMotorController controller, Transform parent, GameObject prefab)
		{
			m_controller = controller;
			m_parent = parent;
			m_prefab = prefab;
		}
	}
}