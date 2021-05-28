using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    [Header("CORE")]
    protected InputStruct input;

    [Header("CAMERA")]
    private Transform cameraHandler = null;

    protected override void Start() {
        //camera handler reference
        cameraHandler = Camera.main.transform.parent;

        //setup cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible   = false;
    }

    protected override void Update() {
        base.Update();
        input = InputManager.CaptureInput();

        LookAtCamera();
    }

    protected override StatesTypes GetCurrentState() {
        if (input.move.magnitude != 0)
        {
            return StatesTypes.Walk;
        }

        return StatesTypes.Idle;
    }

    #region GameplayMethods

    private void LookAtCamera() {
        transform.rotation = Quaternion.Euler(0f, input.look.x, 0f);
        cameraHandler.transform.localRotation = Quaternion.Euler(-input.look.y, 0f, 0f);
    }

    #endregion
}
