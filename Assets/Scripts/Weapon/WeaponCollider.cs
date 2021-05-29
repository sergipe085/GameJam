using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollider : MonoBehaviour
{
    public GameObject cube;

    private void OnCollisionEnter(Collision other) {
        EnemyController enemy = other.transform.GetComponentInParent<EnemyController>();
        if (enemy) {
            enemy.TakeDamage(other.contacts[0].point, other.contacts[0].normal, 10.0f);
        }
    }

    private void OnTriggerEnter(Collider other) {
        EnemyController enemy = other.transform.GetComponentInParent<EnemyController>();
        if (enemy) {
            enemy.TakeDamage(Vector3.zero, transform.forward, 10.0f);
        }
    }

    private void OnEnable() {
        GetComponent<Collider>().enabled = true;
    }

    private void OnDisable() {
        GetComponent<Collider>().enabled = false;
    }
}
