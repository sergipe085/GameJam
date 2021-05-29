using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [Header("CORE")]
    protected InputStruct input;

    [Header("CAMERA")]
    [SerializeField] private float cameraSpeed = 10.0f;
    private Transform cameraHandler = null;

    #region MonoBehaviour

    private void Awake() {
        instance = this;
    }

    private void Start() {
        //camera handler reference
        cameraHandler = Camera.main.transform.parent;

        //setup cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        //increase gravity force
        //Physics.gravity = Vector3.down * 40.0f;
    }

    private void Update() {
        input = InputManager.CaptureInput();

        LookAtCamera();
    }

    #endregion

    #region GameplayMethods

    private void LookAtCamera() {
        transform.rotation = Quaternion.Euler(0f, input.look.x, 0f);
        cameraHandler.transform.localRotation = Quaternion.Euler(-input.look.y, input.look.x, 0f);
        cameraHandler.transform.position = Vector3.Lerp(cameraHandler.transform.position, transform.position + Vector3.up * 2, cameraSpeed * Time.deltaTime);
    }

    #endregion
}
