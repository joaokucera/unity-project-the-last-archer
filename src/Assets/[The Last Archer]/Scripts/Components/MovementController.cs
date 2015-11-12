using System;
using System.Collections;
using UnityEngine;

namespace TheLastArcher
{
	[Serializable]
	public class MovementController : IMovementController
	{
		[Range(1f, 10f)] [SerializeField] private float moveSpeed = 1f;

		private IMotorController m_controller;
		private Transform m_tranform;

		#region IMovementController implementation

		public void Setup (IMotorController controller, Transform transform)
		{
			m_controller = controller;
			m_tranform = transform;
		}

		public IEnumerator MoveVerticaly (Vector2 moveTowards)
		{
			Vector2 currentPosition = m_tranform.position;
			Vector2 moveDirection = moveTowards - currentPosition;
			moveDirection.Normalize ();
			Vector2 target = moveDirection + currentPosition;

			m_controller.SetAnimationState (AnimationParameter.Walk);

			while (true)
			{
				target = moveDirection + currentPosition;
				m_tranform.position = Vector2.Lerp(m_tranform.position, target, moveSpeed * Time.fixedDeltaTime);
				currentPosition = m_tranform.position;

				if (currentPosition == target) yield break;

				yield return null;
			}

			m_controller.SetAnimationState (AnimationParameter.Idle);
		}

		#endregion
	}
}