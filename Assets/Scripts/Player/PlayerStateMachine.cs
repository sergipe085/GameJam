using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    protected override void Update() {
        print(CaptureInput().xMove);
    }

    protected override StatesTypes GetCurrentState()
    {
        return base.GetCurrentState();
    }

    private InputStruct CaptureInput() {
        return InputManager.CaptureInput();
    }
}
