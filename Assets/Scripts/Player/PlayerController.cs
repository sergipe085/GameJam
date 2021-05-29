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
    private float horizontal = 0.0f, vertical = 0.0f;

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

        //Ignore collision with weapons
        WeaponCollider[] weapons = cameraHandler.GetComponentsInChildren<WeaponCollider>();
        for (int i = 0; i < weapons.Length; i++) {
            Physics.IgnoreCollision(GetComponent<Collider>(), weapons[i].GetComponent<Collider>(), true);
        }
    }

    private void Update() {
        input = InputManager.CaptureInput();

        LookAtCamera();
    }

    #endregion

    #region GameplayMethods

    private void LookAtCamera() {
        horizontal += input.look.x * Time.deltaTime * InputManager.instance.sensitivity;
        vertical   += input.look.y * Time.deltaTime * InputManager.instance.sensitivity;

        transform.rotation = Quaternion.Euler(0f, horizontal, 0f);
        cameraHandler.transform.localRotation = Quaternion.Euler(-vertical, horizontal, 0f);
        cameraHandler.transform.position = Vector3.Lerp(cameraHandler.transform.position, transform.position + Vector3.up * 2, cameraSpeed * Time.deltaTime);
    }

    #endregion
}
