using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] public float maxHealth;
    [SerializeField] private float currentHealth;
    [SerializeField] private ParticleSystem explosionEffect;
    [SerializeField] private Image foregroundImage;
    private HealthBarController healthBarController;
    [SerializeField] private bool isAlive;

    private void Awake() {
        maxHealth = 100f;
        healthBarController = GameObject.FindGameObjectWithTag("GameController").GetComponent<HealthBarController>();
    }

    private void Start() {
        isAlive = true;
        currentHealth = 100f;
        healthBarController.setEnemyHealthBarActive(true);
        healthBarController.UpdateHealthBar(currentHealth, maxHealth, "enemy");
    }

    //Damage Player
    //If Enemy has no health left, do a death animation
    public void take_damage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) {
            isAlive = false;
            if (explosionEffect != null) // Έλεγχος για το εφέ της έκρηξης
            {
                Instantiate(explosionEffect, transform.position + new Vector3(0, 0, -1), Quaternion.identity);
            }
            Destroy(gameObject);
        }
        
    healthBarController.UpdateHealthBar(currentHealth, maxHealth, "enemy");
    }

    public bool getIsAlive() {
        return isAlive;
    }
}