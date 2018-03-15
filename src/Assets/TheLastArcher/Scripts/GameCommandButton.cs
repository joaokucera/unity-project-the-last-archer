using UnityEngine;
using UnityEngine.EventSystems;

public delegate void CommandEvent();

public class GameCommandButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public event CommandEvent OnDownEvent = delegate { };
    public event CommandEvent OnUpEvent = delegate { };

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDownEvent();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnUpEvent();
    }
}