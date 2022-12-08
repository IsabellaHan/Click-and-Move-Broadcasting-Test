using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Event Channel")]
public class EventChannel : ScriptableObject
{
    public UnityAction OnEventRaised;
    public UnityAction<Collectible> OnEventRaisedWithCollectible;
    public void RaiseEvent()
    {
        OnEventRaised?.Invoke();
    }

    public void RaiseEventWithCollectible(Collectible col)
    {
        OnEventRaisedWithCollectible?.Invoke(col);
    }

}
