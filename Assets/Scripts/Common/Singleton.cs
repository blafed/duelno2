using UnityEngine;

/// A base of a script that has one instance in the globe
/// </summary>
/// <typeparam name="T">Should be the same as sub-class</typeparam>
[DefaultExecutionOrder(-100)]
[DisallowMultipleComponent]
public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    /// <summary>
    /// The instance of the object, it is being assigned at Awake() call
    /// </summary>
    public static T instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType<T>();
                if (!_instance)
                {
                    Debug.LogError("No Singelton<T> of " + typeof(T) + " found in the globe");
                }
            }
            return _instance;
        }
    }
    static T _instance;

    private void Reset()
    {
        name = typeof(T).Name;
    }

    /// <summary>
    /// An option to be overriden to control if singleton should be destroyed or not
    /// </summary>

    protected void Awake()
    {
        if (_instance && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        _instance = (T)this;
        OnAwake();
    }

    protected virtual void OnAwake() { }
}