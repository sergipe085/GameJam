using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("CORE")]
    private Transform cameraHandler = null;

    [Header("FOLLOW PLAYER")]
    [SerializeField] private float speed = 5.0f;

    private void Awake() {
        cameraHandler = transform.parent;
    }
}
