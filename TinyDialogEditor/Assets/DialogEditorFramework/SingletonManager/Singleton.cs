﻿using UnityEngine;

[RequireComponent(typeof(SingletonManager))]
public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T _instance;

    public static T GetInstance()
    {
        return _instance;
    }

    public void SetInstance(T t)
    {
        if (_instance == null)
        {
            _instance = t;
        }
    }

    public virtual void Init()
    {
        return;
    }

    public virtual void Release()
    {
        return;
    }
}


