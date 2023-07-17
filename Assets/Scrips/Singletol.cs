using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singletol<T> : MonoBehaviour where T : Component
{
    private static T _instance;
    public static T instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<T>();
            }
            if(_instance == null)
            {
                GameObject obj = new GameObject();
                _instance = obj.AddComponent<T>();
            }
            return _instance;
        }
    }
}
