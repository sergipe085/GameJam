using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStop : MonoBehaviour
{
    public Rigidbody hipsRig = null;
    public float stopForce = 15.0f;

    private void FixedUpdate() {
        hipsRig.velocity = Vector3.Lerp(hipsRig.velocity, new Vector3(0f, hipsRig.velocity.y, 0f), stopForce * Time.deltaTime);
    }
}
