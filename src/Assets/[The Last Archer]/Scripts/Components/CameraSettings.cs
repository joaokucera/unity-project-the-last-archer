using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class CameraSettings : MonoBehaviour 
{
	private Camera m_camera;

	void Start()
	{
		m_camera = GetComponent<Camera> ();

		if (m_camera == null) m_camera = Camera.main;
	}
}