using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheLastArcher
{
	[Serializable]
	public class AttackMediator
	{
		[SerializeField] private Transform parent;
		[SerializeField] private GameObject prefab;

		private IMotorController m_controller;
		private Dictionary<AttackState, IAttackController> m_attacksDictionary = new Dictionary<AttackState, IAttackController> ();
		private IAttackController m_currentAttack;

		public void Setup(IMotorController controller, params AttackState[] states)
		{
			m_controller = controller;

			SetAttacks(states);
		}

		public void SetState(AttackState state)
		{
			IAttackController controller;

			if (m_attacksDictionary.TryGetValue (state, out controller)) 
			{
				m_currentAttack = controller;
			}
		}

		private void SetAttacks(AttackState[] states)
		{
			for (int i = 0; i < states.Length; i++) 
			{
				m_attacksDictionary.Add(states[i], GetAttack(states[i]));
			}

			foreach (var item in m_attacksDictionary) 
			{
				m_currentAttack = item.Value;

				break;
			}
		}

		private IAttackController GetAttack(AttackState state)
		{
			switch (state) 
			{
				case AttackState.Shot:
					return new ShotController(m_controller, parent, prefab);
				case AttackState.Special:
					return new SpecialController(m_controller, parent, prefab);
				case AttackState.Overwatch:
					return new OverwatchController(m_controller, parent, prefab);
				default:
					throw new ArgumentException("Invalid attack state: " + state);
			}
		}
	}
}