using UnityEngine;
using System.Collections;

namespace TheLastArcher
{
	[RequireComponent(typeof(RectTransform))]
	public class ObjectRescale : MonoBehaviour 
	{
		void Start()
		{
			var camera = Camera.main;
			var width = camera.orthographicSize * camera.aspect;
			var height = camera.orthographicSize;
			var sizeDelta = camera.WorldToScreenPoint (new Vector3 (width, height, 0));

			var rectTransform = transform as RectTransform;
			rectTransform.sizeDelta = sizeDelta;

		}
	}
}