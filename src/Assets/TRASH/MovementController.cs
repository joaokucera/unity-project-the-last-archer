using System;
using UnityEngine;

namespace TheLastArcher
{
	[Serializable]
	public class MovementController
	{
		private IMovementController m_controller;

		[Range(1f, 10f)] [SerializeField] private float m_moveSpeed = 1f;

		public void Setup (IMovementController controller)
		{
			m_controller = controller;
		}

		public void SetMovement()
		{
			m_controller.OnMovement (m_moveSpeed);
		}
	}
}