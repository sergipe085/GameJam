using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    protected override StatesTypes GetCurrentState() {
        InputStruct input = InputManager.CaptureInput();

        if (input.jump) {
            return StatesTypes.Jump;
        }

        if (input.move.magnitude != 0)
        {
            return StatesTypes.Walk;
        }

        return StatesTypes.Idle;
    }
}
