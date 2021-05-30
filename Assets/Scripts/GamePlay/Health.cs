using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100.0f;
    private float currentHealth = 0.0f;
    private bool isDead = false;

    private void Start() {
        currentHealth = maxHealth;
    }

    public virtual void TakeDamage(float damage, GameObject damageCauser) {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, maxHealth);
        if (currentHealth == 0) {
            Die(damageCauser);;
        }
    }

    public virtual void Die(GameObject deathCauser) {
        isDead = true;
    }

    public bool IsDead() {
        return isDead;
    }
}
