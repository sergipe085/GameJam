using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    //Non-Static Variables
    [SerializeField] private float sensitivity = 10.0f;

    //Static Variables
    private static InputStruct inputStruct = new InputStruct();
    private static float staticSensitivity;

    private void Start() {
        
    }

    private void Update() {
        staticSensitivity = sensitivity;
    }

    public static InputStruct CaptureInput() {
        inputStruct.move    = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        inputStruct.look.x += Input.GetAxis("Mouse X") * Time.deltaTime * staticSensitivity;
        inputStruct.look.y += Input.GetAxis("Mouse Y") * Time.deltaTime * staticSensitivity;
        inputStruct.look.y  = Mathf.Clamp(inputStruct.look.y, -90, 90);
        inputStruct.jump    = Input.GetButtonDown("Jump");

        return inputStruct;
    }
}
