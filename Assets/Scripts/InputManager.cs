using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputStruct CaptureInput() {
        InputStruct inputStruct = new InputStruct();

        inputStruct.xMove = Input.GetAxis("Horizontal");
        inputStruct.zMove = Input.GetAxis("Vertical");

        return inputStruct;
    }
}
