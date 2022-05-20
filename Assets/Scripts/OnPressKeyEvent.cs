using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnPressKeyEvent : MonoBehaviour
{
    public KeyCode key;
    public UnityEvent onPress;
    void Update()
    {

        if (Input.GetKeyDown(key))
        {
            onPress?.Invoke();
        }

    }
}
