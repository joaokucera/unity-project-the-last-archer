using UnityEngine;
using System.Collections;

namespace TheLastArcher
{
	public interface IMovementController 
	{
		void Setup (IMotorController controller, Transform transform);

		IEnumerator MoveVerticaly(Vector2 moveTowards);
	}
}