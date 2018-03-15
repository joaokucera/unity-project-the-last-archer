using UnityEngine;

public class InputMouseController : InputController, IInputController
{
    public bool IsClicked()
    {
        return Input.GetMouseButtonDown(0);
    }

    public Vector2 GetPosition()
    {
        return _camera.ScreenToWorldPoint(Input.mousePosition);
    }
}