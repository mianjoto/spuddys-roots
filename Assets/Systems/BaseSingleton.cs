using UnityEngine;

public class BaseSingleton : MonoBehaviour
{
    private static BaseSingleton _instance;

    public static BaseSingleton Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = GameObject.FindObjectOfType<BaseSingleton>();
            }

            return _instance;
        }
    }

    protected virtual void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
