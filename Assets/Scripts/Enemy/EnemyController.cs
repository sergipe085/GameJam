using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Rigidbody hips;

    public void TakeDamage(Vector3 impactPoint, Vector3 impactDirection, float damage) {
        hips.AddForceAtPosition (hips.transform.position, impactDirection * 10000f * Time.fixedDeltaTime);
        print("aa");
    }
}
