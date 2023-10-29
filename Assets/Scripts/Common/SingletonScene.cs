using UnityEngine;

/// <summary>
/// A base of a script that has one instance in the scene
/// It is being referenced even if it is not active
/// </summary>
/// <typeparam name="T">Should be the same as sub-class</typeparam>
[DefaultExecutionOrder(-101)]
[DisallowMultipleComponent]
public abstract class SingletonScene<T> : MonoBehaviour where T : SingletonScene<T>
{
    public static bool CheckInstanceExist()
    {
        _silentError = true;
        var instance = SingletonScene<T>.instance;
        _silentError = false;
        return instance;
    }
    /// <summary>
    /// The instance of the object, it is being assigned at Awake() call
    /// </summary>
    public static T instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType<T>(true);
                if (!_instance)
                {
                    if (!_silentError)
                        Debug.LogError("No SingeltonScene<T> of " + typeof(T) + " found in the scene");
                }
            }
            return _instance;
        }
    }
    static T _instance;
    static bool _silentError;

    /// <summary>
    /// An option to be overriden to control if singleton should be destroyed or not
    /// </summary>
    /// 
    protected void Awake()
    {
        if (_instance && _instance != this)
        {
            Debug.LogError("There are more than one instance of " + typeof(T) + " in the scene");
            Destroy(gameObject);
            return;
        }
        _instance = (T)this;
        OnAwake();
    }


    protected virtual void OnAwake() { }

}