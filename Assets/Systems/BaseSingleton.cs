using UnityEngine;

public class BaseSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();
                if (_instance == null)
                {
                    Debug.LogError("An _instance of " + typeof(T) + " is needed in the scene, but there is none.");
                }
            }
            return _instance;
        }
    }

    protected virtual void Awake()
    {
        Debug.Log("in awake function for " + typeof(T));
        if (_instance == null)
        {
            _instance = this as T;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Debug.LogError("Another instance of " + typeof(T) + " already exists in the scene.");
            Destroy(this.gameObject);
        }
    }
}