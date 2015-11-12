using System.Collections;
using UnityEngine;

namespace TheLastArcher
{
	public class TouchInputController : IInputController
	{
		#region IInputController implementation
		
		public bool IsDown ()
		{
			return Input.touchCount == 1;
		}

		public Vector2 GetPosition (Camera camera)
		{
			Touch touch = Input.GetTouch(0);

			return camera.ScreenToWorldPoint(touch.position);
		}

		#endregion
	}
}