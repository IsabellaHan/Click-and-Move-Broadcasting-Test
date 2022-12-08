using UnityEngine;
using UnityEngine.EventSystems;

public class ClickMoveBroadCaster : MonoBehaviour
{
    public EventChannel ClickAndMoveChannel;
    void OnMouseDown()
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        else
        {
            ClickAndMoveChannel?.RaiseEvent();
        }
    }
}
