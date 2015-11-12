using UnityEngine;
using System.Collections;

namespace TheLastArcher
{
	public class MouseInputController : IInputController
	{
		#region IInputController implementation

		public bool IsDown ()
		{
			return Input.GetMouseButtonDown(0);
		}

		public Vector2 GetPosition (Camera camera)
		{
			return camera.ScreenToWorldPoint(Input.mousePosition);
		}

		#endregion
	}
}