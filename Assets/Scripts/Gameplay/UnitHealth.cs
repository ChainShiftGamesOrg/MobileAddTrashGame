using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Pool;

public class UnitHealth : MonoBehaviour
{
    public UnityEvent DeathEvent;

    public IObjectPool<GameObject> ObjectPool;

    private void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        DamageDealer damage = other.gameObject.GetComponent<DamageDealer>();
        if (damage != null)
        {
            Die();
        }
    }

    private void Die()
    {
        ObjectPool.Release(gameObject);
        DeathEvent?.Invoke();
    }
}
