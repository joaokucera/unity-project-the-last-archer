using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheLastArcher
{
	[Serializable]
	public class AnimationController : IAnimationController
	{
		private Dictionary<AnimationParameter, int> m_parametersDictionary = new Dictionary<AnimationParameter, int> ();
		private IMotorController m_controller;
		private Animator m_animator;

		#region IAnimationController implementation

		public void Setup (IMotorController controller, Animator animator)
		{
			m_controller = controller;
			m_animator = animator;
			
			SetParameters ();
		}

		public void DoAnimation (AnimationParameter parameter)
		{
			int id;

			if (m_parametersDictionary.TryGetValue (parameter, out id))
			{
				m_animator.SetTrigger (id);
			}
		}

		#endregion

		private void SetParameters()
		{
			for (int i = 0; i < m_animator.parameters.Length; i++)
			{
				var key = (AnimationParameter)Enum.Parse(typeof(AnimationParameter), m_animator.parameters[i].name);
				
				m_parametersDictionary.Add(key, m_animator.parameters[i].nameHash);
			}
		}
	}
}