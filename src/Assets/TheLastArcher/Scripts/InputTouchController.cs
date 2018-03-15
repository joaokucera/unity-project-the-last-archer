using UnityEngine;

public class InputTouchController : InputController, IInputController
{
    public bool IsClicked()
    {
        return Input.touchCount == 1;
    }

    public Vector2 GetPosition()
    {
        Touch touch = Input.GetTouch(0);

        return _camera.ScreenToWorldPoint(touch.position);
    }
}