using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    //Non-Static Variables
    [Header("INPUTS KEYS")]
    [SerializeField] private KeyCode jumpKey = KeyCode.None;
    [SerializeField] private KeyCode rewindKey = KeyCode.None;
    [SerializeField] private KeyCode attackKey = KeyCode.None;
    [SerializeField] private KeyCode interactKey = KeyCode.None;
    public float sensitivity = 10.0f;

    //Static Variables
    public static InputManager instance;
    private static InputStruct inputStruct = new InputStruct();
    private static bool inputEnabled = true;

    [Header("INPUTS KEYS STATIC")]
    private static KeyCode jumpKeyStatic = KeyCode.None;
    private static KeyCode rewindKeyStatic = KeyCode.None;
    private static KeyCode attackKeyStatic = KeyCode.None;
    private static KeyCode interactKeyStatic = KeyCode.None;

    private void Awake() {
        instance = this;
    }

    private void Update() {
        jumpKeyStatic = jumpKey;
        rewindKeyStatic = rewindKey;
        attackKeyStatic = attackKey;
        interactKeyStatic = interactKey;
    }

    public static InputStruct CaptureInput() {
        if (inputEnabled) {
            inputStruct.move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            inputStruct.look.x = Input.GetAxis("Mouse X");
            inputStruct.look.y = Input.GetAxis("Mouse Y");
            inputStruct.look.y = Mathf.Clamp(inputStruct.look.y, -90, 90);
            inputStruct.jump = Input.GetKeyDown(jumpKeyStatic);
            inputStruct.attack = Input.GetMouseButtonDown(0);
            inputStruct.rewind = Input.GetKeyDown(rewindKeyStatic);
            inputStruct.interact = Input.GetKeyDown(interactKeyStatic);
        }
        else {
            inputStruct.move = Vector2.zero;
            inputStruct.look.x = 0;
            inputStruct.look.y = 0;
            inputStruct.look.y = 0;
            inputStruct.jump = false;
            inputStruct.attack = false;
            inputStruct.rewind = false;
        }

        return inputStruct;
    }

    public static void EnableInput(bool _enabled) {
        inputEnabled = _enabled;
    }
}
