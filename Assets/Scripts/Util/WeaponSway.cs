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
        float horizontal = -Input.GetAxis("Mouse X") * 0.5f;
        float vertical   = -Input.GetAxis("Mouse Y") * 0.5f;

        Vector3 targetPosition = new Vector3(horizontal, vertical, 0f);
        transform.localPosition = Vector3.Lerp(transform.localPosition,  initialPosition + targetPosition, 5f * Time.deltaTime);    
    }
}
