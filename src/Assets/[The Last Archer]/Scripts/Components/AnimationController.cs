using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Animator))]
public class AnimationController : MonoBehaviour 
{
	public enum AnimationParameter { Idle, Walk, Shoot, Hit, Die }

	private Animator m_animator;
	private Dictionary<AnimationParameter, int> m_parameters;

	void Start()
	{
		m_animator = GetComponent<Animator> ();

		CreateParameters ();
	}

	private void CreateParameters()
	{
		m_parameters = new Dictionary<AnimationParameter, int> ()
		{
			{ AnimationParameter.Idle, Animator.StringToHash ("idle") },
			{ AnimationParameter.Walk, Animator.StringToHash ("walk") },
			{ AnimationParameter.Shoot, Animator.StringToHash ("shoot") },
			{ AnimationParameter.Hit, Animator.StringToHash ("hit") },
			{ AnimationParameter.Die, Animator.StringToHash ("die") },
		};
	}

	public void SetAnimation(AnimationParameter parameter)
	{
		int id;
		if (m_parameters.TryGetValue (parameter, out id)) 
		{
			m_animator.SetTrigger (id);
		}
	}
}