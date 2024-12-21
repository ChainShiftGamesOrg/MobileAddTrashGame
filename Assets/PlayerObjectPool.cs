using System;
using UnityEngine;
using UnityEngine.Pool;

public class PlayerObjectPool : MonoBehaviour
{
    private static IObjectPool<GameObject> objectPool;

    [SerializeField] private GameObject playerPrefab;

    private bool _collectionCheck = false;
    [SerializeField] private int _defaultPoolSize = 50;
    [SerializeField] private int _maxPoolSize = 500;

    private void Awake()
    {
        objectPool = new ObjectPool<GameObject>(CreatePlayer, OnGetFromPool, OnReleaseToPool, OnDestroyPooledObject,
            _collectionCheck, _defaultPoolSize, _maxPoolSize);
    }

    private void Start()
    {
        for (int i = 0; i < 80; i++)
        {
            objectPool.Get();
        }
    }

    private void OnDestroyPooledObject(GameObject player)
    {
        Destroy(player.gameObject);
    }

    private void OnReleaseToPool(GameObject player)
    {
        player.gameObject.SetActive(false);
    }

    private void OnGetFromPool(GameObject player)
    {
        player.gameObject.SetActive(true);
    }

    private GameObject CreatePlayer()
    {
        GameObject player = Instantiate(playerPrefab);
        UnitHealth unitHealth = player.GetComponent<UnitHealth>();
        unitHealth.ObjectPool = objectPool;
        return player;
    }
}
