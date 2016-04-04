using System;
using System.Collections.Generic;
using UnityEngine;

namespace TheLastArcher
{
	public enum AnimationParameter { Idle, Walk, Shoot, Hit, Die }

	public class AnimationStrategy
	{
		private Dictionary<AnimationParameter, int> m_parametersDictionary = new Dictionary<AnimationParameter, int> ();
		private Animator m_animator;
	
		public AnimationStrategy (Animator animator)
		{
			m_animator = animator;

			CreateParametersDictionary ();
		}
	
		public void SetParameter (AnimationParameter parameter)
		{
			int id;
			
			if (m_parametersDictionary.TryGetValue (parameter, out id))
			{
				m_animator.SetTrigger (id);
			}
		}
		
		private void CreateParametersDictionary()
		{
			for (int i = 0; i < m_animator.parameters.Length; i++)
			{
				var key = (AnimationParameter)Enum.Parse(typeof(AnimationParameter), m_animator.parameters[i].name);
				
				m_parametersDictionary.Add(key, m_animator.parameters[i].nameHash);
			}
		}
	}
}