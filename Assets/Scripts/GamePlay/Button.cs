using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    [SerializeField] private UnityEvent onClickButtonEvent = null;

    public void Click() {
        print("Click");
        onClickButtonEvent?.Invoke();
    }
}
