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
    public float horizontal = 0.0f, vertical = 0.0f;

    #region MonoBehaviour

    private void Awake() {
        instance = this;
    }

    private void Start() {
        //camera handler reference
        cameraHandler = Camera.main.transform.parent;

        //setup cursor
        LockCursor(true);

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

    private void OnCollisionEnter(Collision other) {
        if (other.transform.CompareTag("Finish")) {
            DisableController();
            StartCoroutine(GameController.instance.GameOver(true, 1.0f));
        }
    }

    #endregion

    #region GameplayMethods

    private void LookAtCamera() {
        horizontal += input.look.x * Time.deltaTime * InputManager.instance.sensitivity;
        vertical   += input.look.y * Time.deltaTime * InputManager.instance.sensitivity;
        vertical    = Mathf.Clamp(vertical, -90, 90);

        cameraHandler.transform.position = Vector3.Lerp(cameraHandler.transform.position, transform.position + Vector3.up * 2, cameraSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0f, horizontal, 0f);
        cameraHandler.transform.localRotation = Quaternion.Euler(-vertical, horizontal, 0f);
    }

    public void LockCursor(bool locked) {
        Cursor.lockState = locked ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !locked;
    }

    public void DisableController() {
        GetComponent<PlayerStateMachine>().enabled = false;
        GetComponent<PlayerController>().enabled = false;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        InputManager.EnableInput(false);
    }

    #endregion
}
