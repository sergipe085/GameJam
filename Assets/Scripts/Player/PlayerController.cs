using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("CORE")]
    protected InputStruct input;

    [Header("CAMERA")]
    private Transform cameraHandler = null;

    #region MonoBehaviour

    private void Start() {
        //camera handler reference
        cameraHandler = Camera.main.transform.parent;

        //setup cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update() {
        input = InputManager.CaptureInput();

        LookAtCamera();
    }

    #endregion

    #region GameplayMethods

    private void LookAtCamera() {
        transform.rotation = Quaternion.Euler(0f, input.look.x, 0f);
        cameraHandler.transform.localRotation = Quaternion.Euler(-input.look.y, 0f, 0f);
    }

    #endregion
}
