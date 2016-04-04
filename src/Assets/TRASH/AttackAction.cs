using UnityEngine;

namespace TheLastArcher
{
	public abstract class AttackAction
	{
		protected IAttackController m_controller;

		public AttackAction (IAttackController controller)
		{
			m_controller = controller;
		}
	}
}