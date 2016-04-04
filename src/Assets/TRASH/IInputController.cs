using UnityEngine;

namespace TheLastArcher
{
	public interface IInputController 
	{
		bool IsClicked();

		Vector2 GetPosition();
	}
}