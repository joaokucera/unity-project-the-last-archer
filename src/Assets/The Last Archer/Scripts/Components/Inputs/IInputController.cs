using UnityEngine;

namespace TheLastArcher.Inputs
{
	public interface IInputController 
	{
		bool IsClicked();

		Vector2 GetPosition();
	}
}