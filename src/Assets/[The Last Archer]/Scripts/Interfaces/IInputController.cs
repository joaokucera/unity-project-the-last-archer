using UnityEngine;
using System.Collections;

public interface IInputController 
{
	bool IsDown();

	Vector2 GetPosition(Camera camera);
}