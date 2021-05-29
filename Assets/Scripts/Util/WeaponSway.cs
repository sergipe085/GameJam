using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSway : MonoBehaviour
{
    private Vector3 initialPosition;

    private void Start() {
        initialPosition = transform.localPosition;
    }

    private void Update() {
        InputStruct input = InputManager.CaptureInput();

        float lookX = -input.look.x * 0.2f;
        float lookY = -input.look.y * 0.2f;
        float moveX = -input.move.x * 0.14f;
        float moveY = -input.move.y * 0.14f;

        Vector3 targetPosition = new Vector3(lookX + moveX, lookY, moveY);
        transform.localPosition = Vector3.Lerp(transform.localPosition,  initialPosition + targetPosition, 5f * Time.deltaTime);    
    }
}
