using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("CORE")]
    private bool canTakeDamage = true;
    
    [Header("EFFECTS")]
    [SerializeField] private GameObject bloodParticle = null;

    public void TakeDamage(Vector3 impactPoint, Vector3 impactDirection, float damage) {
        if (canTakeDamage) {
            canTakeDamage = false;
            Invoke(nameof(CanTakeDamage), 0.5f);
            Instantiate(bloodParticle, impactPoint, Quaternion.LookRotation(impactDirection));
        }
    }

    private void CanTakeDamage() {
        canTakeDamage = true;
    }
}
