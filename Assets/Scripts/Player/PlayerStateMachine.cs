using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    [Header("STATES CHECKERS")]
    public bool isAttacking = false;

    protected override StatesTypes GetCurrentState() {
        InputStruct input = InputManager.CaptureInput();

        if (input.jump) {
            return StatesTypes.Jump;
        }

        if (input.attack) {
            isAttacking = true;
            return StatesTypes.Attack;
        }

        if (input.move.magnitude != 0) {
            return StatesTypes.Walk;
        }

        return StatesTypes.Idle;
    }
}
