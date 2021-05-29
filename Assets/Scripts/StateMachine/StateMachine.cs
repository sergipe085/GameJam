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
    private Action[] fixedTickActions;
    private Action[] enterStateActions;
    private Action[] exitStateActions;
    private StatesTypes currentState = StatesTypes.Idle;

    protected virtual void Start() {

    }

    protected virtual void Awake() {
        InitializeStates();

        foreach(Action action in initiActions) {
            if (action != null) {
                action.Invoke();
            }
        }
    }

    protected virtual void Update() {
        int currentStateIndex = (int) GetCurrentState();

        if (tickActions[currentStateIndex] != null) {
            tickActions[currentStateIndex].Invoke();
        }

        if (CheckIfStateChanged()) {
            enterStateActions[currentStateIndex].Invoke();
        }
    }
     
    private void FixedUpdate() {
        int currentStateIndex = (int)GetCurrentState();

        if (fixedTickActions[currentStateIndex] != null) {
            fixedTickActions[currentStateIndex].Invoke();
        }
    }

    private void InitializeStates() {
        int len1 = Enum.GetNames(typeof(StatesTypes)).Length;
        int len2 = stateActions.Length;
        initiActions        = new Action[len2];
        tickActions         = new Action[len2];
        enterStateActions   = new Action[len2];
        exitStateActions    = new Action[len2];
        fixedTickActions    = new Action[len2];

        for (int i = 0; i < len1 && i < len2; i++) {
            initiActions        [(int)stateActions[i].stateType] = stateActions[i].state.Init;
            tickActions         [(int)stateActions[i].stateType] = stateActions[i].state.Tick;
            fixedTickActions    [(int)stateActions[i].stateType] = stateActions[i].state.FixedTick;
            enterStateActions   [(int)stateActions[i].stateType] = stateActions[i].state.EnterState;
            exitStateActions    [(int)stateActions[i].stateType] = stateActions[i].state.ExitState;
        }
    }

    protected virtual StatesTypes GetCurrentState() {
        return StatesTypes.Idle;
    }

    private bool CheckIfStateChanged() {
        if (currentState != GetCurrentState()) {
            exitStateActions[(int)currentState].Invoke();
            currentState = GetCurrentState();
            return true;
        } 

        currentState = GetCurrentState();
        return false;
    }
}
