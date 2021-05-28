using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [Header("CORE")]
    [SerializeField] private StateAction[] stateActions;
    //Actions
    private Action[] initiActions;
    private Action[] tickActions;

    private void Awake() {
        InitializeStates();

        initiActions[(int)GetCurrentState()].Invoke();
    }

    private void Update() {
        
    }

    private StatesTypes GetCurrentState() {
        return StatesTypes.Walk;
    }

    private void InitializeStates() {
        int len1 = Enum.GetNames(typeof(StatesTypes)).Length;
        int len2 = stateActions.Length;
        initiActions = new Action[len2];

        for (int i = 0; i < len1 && i < len2; i++) {
            initiActions[(int)stateActions[i].stateType] = stateActions[i].state.Init;
            tickActions[(int)stateActions[i].stateType] = stateActions[i].state.Tick;
        }
    }
}
