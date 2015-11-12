using UnityEngine;
using System.Collections;

namespace TheLastArcher
{
	public interface IAnimationController
	{
		void Setup(IMotorController controller, Animator animator);

		void DoAnimation(AnimationParameter parameter);
	}
}