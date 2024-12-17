using UnityEngine;
using UnityEngine.Events;
public class GameEventListener<T> : MonoBehaviour, IGameEventListener<T>
{
    [Tooltip("Event to register with")]
    public BaseGameEvent<T> gameEvent;

    [Tooltip("Response to invoke when event is raised")]
    public UnityEvent<T> response;

    private void OnEnable()
    {
        gameEvent.RegisterListener(this);
    }

    private void OnDisable()
    {
        gameEvent.UnregisterListener(this);
    }

    public void OnEventRaised(T eventData)
    {
        response.Invoke(eventData);
    }
}
