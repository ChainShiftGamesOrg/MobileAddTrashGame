using UnityEngine;

using UnityEngine;

/// <summary>
/// Generic abstract singleton class for Unity.
/// Ensures that only one instance of the class exists.
/// </summary>
/// <typeparam name="T">The type of the singleton class.</typeparam>
public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                // Try to find an existing instance in the scene
                _instance = FindFirstObjectByType<T>();

                // If no instance exists, create a new one
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(T).Name);
                    _instance = singletonObject.AddComponent<T>();

                    DontDestroyOnLoad(singletonObject);
                }
            }

            return _instance;
        }
    }

    public static bool IsInitialized => _instance != null;

    protected virtual void OnDestroy()
    {
        if (_instance == this)
        {
            _instance = null;
        }
    }

    protected virtual void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Debug.LogWarning($"[Singleton] Attempt to create a second instance of singleton class {typeof(T)}. Destroying the new instance.");
            Destroy(gameObject);
        }
        else
        {
            _instance = (T)this;
        }
    }
}