using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceUtil : MonoBehaviour
{
    public T GetInterface<T>(GameObject obj) where T : class
    {
        foreach (var component in obj.GetComponents<MonoBehaviour>())
        {
            if (component is T t)
                return t;
        }
        return null;
    }
}
