using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    protected override void Update() {
        base.Update();
    }

    protected override StatesTypes GetCurrentState() {
        InputStruct input = CaptureInput();

        if (input.move.magnitude != 0) {
            return StatesTypes.Walk;
        }

        return StatesTypes.Idle;
    }

    private InputStruct CaptureInput() {
        return InputManager.CaptureInput();
    }
}
