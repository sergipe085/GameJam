using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ExtraGravity : MonoBehaviour
{
    private Rigidbody rig;
    [SerializeField] private float force = 10.0f;

    private void Awake() {
        rig = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        rig.AddForce(Vector3.down * force * Time.deltaTime, ForceMode.Acceleration);
    }
}
