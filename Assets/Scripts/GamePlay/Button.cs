using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    private Action buttonActions;
    private bool clicked = false;

    private void Awake() {
        foreach(ButtonAction action in GetComponentsInChildren<ButtonAction>()) {
            buttonActions += action.DoAction;
        }
    }

    public void Click() {
        if (clicked) return;
        
        clicked = true;
        buttonActions();
    }
}
