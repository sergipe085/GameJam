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

    private void Awake() {
        instance = this;
    }

    public static InputStruct CaptureInput() {
        inputStruct.move   = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        inputStruct.look.x = Input.GetAxis("Mouse X");
        inputStruct.look.y = Input.GetAxis("Mouse Y");
        inputStruct.look.y = Mathf.Clamp(inputStruct.look.y, -90, 90);
        inputStruct.jump   = Input.GetButtonDown("Jump");
        inputStruct.attack = Input.GetMouseButtonDown(0);

        return inputStruct;
    }
}
