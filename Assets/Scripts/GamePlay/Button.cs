using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    [SerializeField] private Transform buttonUp = null;
    private Vector3 initialPos = Vector3.zero;
    private Vector3 pressedPos = Vector3.zero;
    
    private Action buttonActions;
    private bool clicked = false;

    private void Awake() {
        foreach(ButtonAction action in GetComponentsInChildren<ButtonAction>()) {
            buttonActions += action.DoAction;
        }
    }

    private void Start() {
        initialPos = buttonUp.position;
        pressedPos = initialPos + Vector3.down * 0.15f;
    }

    private void Update() {
        Vector3 pos = clicked ? pressedPos : initialPos;
        buttonUp.position = Vector3.Lerp(buttonUp.position, pos, Time.deltaTime);
    }

    public void Click() {
        if (clicked) return;
        
        clicked = true;
        buttonActions();
    }
}
