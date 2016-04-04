using System;
using System.Collections.Generic;

namespace TheLastArcher
{
	[Serializable]
	public class AttackStrategy
	{
		private IAttackController m_controller;
		private Dictionary<HeroineState, AttackAction> m_attacksDictionary = new Dictionary<HeroineState, AttackAction> ();
		private AttackAction m_currentAction;

		public AttackAction CurrentAction { get { return m_currentAction; } }

		public void Setup (IAttackController controller)
		{
			m_controller = controller;

			CreateAttackDictionary();
		}

		public void SetState (HeroineState state)
		{
			AttackAction action;

			if (m_attacksDictionary.TryGetValue (state, out action)) 
			{
				m_currentAction = action;
			}
		}

		private void CreateAttackDictionary()
		{
			m_attacksDictionary.Add(HeroineState.Shoot, new ShootAction(m_controller));
			m_attacksDictionary.Add(HeroineState.Special, new SpecialAction(m_controller));
			m_attacksDictionary.Add(HeroineState.Overwatch, new OverwatchAction(m_controller));

			m_currentAction = m_attacksDictionary [HeroineState.Shoot];
		}
	}
}