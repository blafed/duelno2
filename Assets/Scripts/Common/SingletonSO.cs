using UnityEngine;
/// <summary>
/// A base of scriptable object, where it can have one instance located at the top of Resources folder
/// </summary>
/// <typeparam name="T">Should be the same sub-class</typeparam>
public abstract class SingletonSO<T> : ScriptableObject where T : SingletonSO<T>
{
    /// <summary>
    /// The instance located at the resources folder
    /// </summary>
    public static T instance
    {
        get
        {
            if (!_instance)
            {
                var name = typeof(T).Name;
                _instance = Resources.Load<T>(name);
                if (!_instance)
                {
                    Debug.LogError($"You haven't created scriptable object of type {name}");
                }
            }
            return _instance;
        }
    }
    static T _instance;
}