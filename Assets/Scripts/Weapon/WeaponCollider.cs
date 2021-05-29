using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollider : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.GetComponent<Rigidbody>()) {
            foreach(ContactPoint point in other.contacts) {
                other.gameObject.GetComponent<Rigidbody>().AddForceAtPosition(-point.normal * Time.deltaTime, point.point, ForceMode.Force);
            }
        }
    }

    private void OnEnable() {
        GetComponent<Collider>().enabled = true;
    }

    private void OnDisable() {
        GetComponent<Collider>().enabled = false;
    }
}
