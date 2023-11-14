 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySingleton<T> : MonoBehaviour where T : MySingleton<T>
{
    public static T Instance {  get; private set; }

    // Start is called before the first frame update
    protected virtual void Awake()
    {
        if (Instance == null)
        {
            Instance = (T)this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
