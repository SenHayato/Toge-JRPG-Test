using UnityEngine;

public abstract class Singleton<Class> : MonoBehaviour where Class : Component
{
    public static Class Instance { get; protected set; }

    public virtual void Awake()
    {
        if (Instance != this && Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this as Class;
        }
    }
}

public abstract class SingletonPersistant<Class> : MonoBehaviour where Class : Component
{
    public static Class Instance { get; protected set; }

    public virtual void Awake()
    {
        if (Instance != this && Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this as Class;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}

