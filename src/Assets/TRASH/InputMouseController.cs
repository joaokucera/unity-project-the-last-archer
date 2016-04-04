using UnityEngine;

namespace TheLastArcher
{
	public class InputMouseController : IInputController
	{
		#region IInputController implementation

		public bool IsClicked ()
		{
			return Input.GetMouseButtonDown(0);
		}

		public Vector2 GetPosition ()
		{
			return GlobalVariables.MainCamera.ScreenToWorldPoint(Input.mousePosition);
		}

		#endregion
	}
}