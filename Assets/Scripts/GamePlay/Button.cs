using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    public UnityEvent onClickButtonEvent = null;

    public void Click() {
        onClickButtonEvent?.Invoke();
    }
}
