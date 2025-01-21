using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] public float maxHealth;
    [SerializeField] private float currentHealth;
    [SerializeField] private ParticleSystem explosionEffect;

    private void Awake() {
        maxHealth = 300f;
        currentHealth = 10f;
    }

    //Damage Player
    //If Enemy has no health left, do a death animation
    public void take_damage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0) {
            if (explosionEffect != null) // Έλεγχος για το εφέ της έκρηξης
            {
                Instantiate(explosionEffect, transform.position + new Vector3(0, 0, -1), Quaternion.identity);
            }

            Destroy(gameObject);
        }
    }
}

