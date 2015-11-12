using UnityEngine;
using System.Collections;

namespace TheLastArcher
{
	public class HeroineMotor : MonoBehaviour, IMotorController
	{
		private Camera m_camera;
		private HeroineAction m_currentAction;
		private IInputController m_inputController;

		[SerializeField] private MovementController m_movementController;
		[SerializeField] private AnimationController m_animationController;
		[SerializeField] private AttackMediator m_attackMediator;

		void Start()
		{
			m_camera = Camera.main;
			m_currentAction = HeroineAction.None;
			m_inputController = InputFactory.GetCurrentInput ();

			m_movementController.Setup (this, transform);
			m_animationController.Setup (this, GetComponentInChildren<Animator> ());
			m_attackMediator.Setup(this, AttackState.Shot, AttackState.Special, AttackState.Overwatch);
		}

		void FixedUpdate()
		{
			if (m_inputController.IsDown ()) Move ();
		}

		#region IMotorController implementation

		public void SetAnimationState (AnimationParameter parameter)
		{
			m_animationController.DoAnimation (parameter);
		}

		#endregion

		private void Move()
		{
			Vector2 position = m_inputController.GetPosition(m_camera);
			
			StartCoroutine(m_movementController.MoveVerticaly(position));
		}
	}
}