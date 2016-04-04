using UnityEngine;

namespace TheLastArcher
{
	public class InputTouchController : IInputController
	{
		#region IInputController implementation
		
		public bool IsClicked ()
		{
			return Input.touchCount == 1;
		}

		public Vector2 GetPosition ()
		{
			Touch touch = Input.GetTouch(0);

			return GlobalVariables.MainCamera.ScreenToWorldPoint(touch.position);
		}

		#endregion
	}
}