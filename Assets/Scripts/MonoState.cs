using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoState<T> : MonoBehaviour
    where T : MonoBehaviour
{
    static MonoState<T> _instance;

    protected static object _lock = new object();

    protected virtual void Awake()
    {
        //destruyame 
        bool destroyMe = true;

        //instance es null?
        if (_instance == null)
        {
            //si, instance es null, entonces ponga un candado
            lock (_lock)
            {
                //instance es null?
                if (_instance == null)
                {
                    //si, instance es null, entonces ponga un candado
                    //entonces no me destruya
                    destroyMe = false;

                    //y ahora la instancia soy yo
                    _instance = this;

                }
            }
        }

        if (destroyMe) {
            Destroy(gameObject);
            return;
        }
    }

    public static T Instance
    {
        get
        {
            return _instance as T;
        }
    }

}


