using DG.Tweening;
using UnityEngine;

namespace TheLastArcher
{
	public enum HeroineState { Idle, Walk, Shoot, Special, Overwatch }

	public class HeroineMotor : MonoBehaviour, IMovementController, IAnimationController, IAttackController
	{
		private HeroineState m_currentState;
		private IInputController m_inputController;
		private AnimationStrategy m_animationStrategy;
		private AnimationController m_animationController;
		private AttackStrategy m_attackStrategy;

		[SerializeField] private MovementController m_movementController;

		void Start()
		{
			m_currentState = HeroineState.Idle;
			m_inputController = InputFactory.GetCurrentInput ();
			m_animationStrategy = new AnimationStrategy (GetComponentInChildren<Animator> ());
			m_animationController.Setup (this);
			m_attackStrategy.Setup (this);
			m_movementController.Setup (this);
		}

		void Update()
		{
			if (m_currentState == HeroineState.Idle && m_inputController.IsClicked ()) 
			{
				m_movementController.SetMovement ();
			}
		}

		#region IMovementController implementation

		public void OnMovement (float speed)
		{
			var position = m_inputController.GetPosition();

			transform.DOMove (position, speed)
				.OnStart(() => m_animationController.SetAnimation(AnimationParameter.Walk))
				.OnComplete(() => m_animationController.SetAnimation(AnimationParameter.Idle));
		}

		#endregion

		#region IAnimationController implementation

		public void OnAnimation (AnimationParameter parameter)
		{
			m_animationStrategy.SetParameter (parameter);

			switch (parameter) 
			{
				case AnimationParameter.Idle:
					m_currentState = HeroineState.Idle;
					break;
				case AnimationParameter.Walk:
					m_currentState = HeroineState.Walk;
					break;
				default:
					break;
			}

			print ("OnAnimation: " + m_currentState);
		}

		#endregion

		#region IAttackController implementation

		public void OnAttack ()
		{
			print (" - OnAttack - ");
		}

		#endregion
	}
}