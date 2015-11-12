using UnityEngine;
using System.Collections;

namespace TheLastArcher
{
	[RequireComponent(typeof(Camera))]
	public class CameraSettings : MonoBehaviour 
	{
		private Camera m_camera;

		void Start()
		{
			m_camera = GetComponent<Camera> ();
		}
	}
}