using System;
using TheLastArcher.Wizards;

namespace TheLastArcher.Common
{
	public class AnimationController
	{
		private IAnimationController m_controller;

		public void Setup (IAnimationController controller)
		{
			m_controller = controller;
		}

		public void SetAnimation (AnimationParameter parameter)
		{
			m_controller.OnAnimation (parameter);
		}
	}
}