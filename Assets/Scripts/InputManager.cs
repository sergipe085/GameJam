using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    //Non-Static Variables
    public float sensitivity = 10.0f;

    //Static Variables
    public static InputManager instance;
    private static InputStruct inputStruct = new InputStruct();
    private static bool enabled = true;

    private void Awake() {
        instance = this;
    }

    public static InputStruct CaptureInput() {
        if (enabled) {
            inputStruct.move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            inputStruct.look.x = Input.GetAxis("Mouse X");
            inputStruct.look.y = Input.GetAxis("Mouse Y");
            inputStruct.look.y = Mathf.Clamp(inputStruct.look.y, -90, 90);
            inputStruct.jump = Input.GetButtonDown("Jump");
            inputStruct.attack = Input.GetMouseButtonDown(0);
            inputStruct.rewind = Input.GetKeyDown(KeyCode.LeftShift);
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
        enabled = _enabled;
    }
}
