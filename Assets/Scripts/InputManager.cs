using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputStruct CaptureInput() {
        InputStruct inputStruct = new InputStruct();

        inputStruct.move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        return inputStruct;
    }
}
