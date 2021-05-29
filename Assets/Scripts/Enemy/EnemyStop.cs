using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStop : MonoBehaviour
{
    public Rigidbody hipsRig = null;
    public float stopForce = 15.0f;

    private void FixedUpdate() {
        hipsRig.velocity = Vector3.Lerp(hipsRig.velocity, Vector3.zero, stopForce * Time.deltaTime);
    }
}
