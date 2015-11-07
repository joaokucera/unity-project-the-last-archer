using UnityEngine;
using System.Collections;

public class HeroineController : MonoBehaviour 
{
	private AnimationController m_animation;

	void Start()
	{
		m_animation = GetComponentInChildren<AnimationController> ();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.A))
			m_animation.SetAnimation (AnimationController.AnimationParameter.Idle);
		if (Input.GetKeyDown(KeyCode.S))
			m_animation.SetAnimation (AnimationController.AnimationParameter.Walk);
		if (Input.GetKeyDown(KeyCode.D))
			m_animation.SetAnimation (AnimationController.AnimationParameter.Shoot);
		if (Input.GetKeyDown(KeyCode.F))
			m_animation.SetAnimation (AnimationController.AnimationParameter.Hit);
		if (Input.GetKeyDown(KeyCode.G))
			m_animation.SetAnimation (AnimationController.AnimationParameter.Die);
	}
}