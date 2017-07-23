using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T sInstance = default(T);

    public static T Instance
    {
        get
        {
            if (sInstance == null)
            {
                sInstance = GameObject.FindObjectOfType(typeof(T)) as T;

                if (sInstance == null)
                    Debug.Log("NULL Instance " + typeof(T).ToString());
            }
            return sInstance;
        }
    }

    private void Awake()
    {
        if (sInstance == null)
        {
            sInstance = this as T;
            sInstance.Init();
        }
    }

    public virtual void Init() { }

    private void OnApplicationQuit()
    {
        sInstance = null;
    }
}
