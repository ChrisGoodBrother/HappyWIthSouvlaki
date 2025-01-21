using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] public float maxHealth;
    [SerializeField] private float currentHealth;
    private HealthBarController healthBarController;
    private bool isAlive;

    public bool getIsAlive() {
        return isAlive;
    }

    private void Awake() {
        maxHealth = 100f;
        currentHealth = 100f;
        isAlive = true;
        healthBarController = GameObject.FindGameObjectWithTag("GameController").GetComponent<HealthBarController>();
    }

    private void Start() {
        healthBarController.setEnemyHealthBarActive(true);
        healthBarController.UpdateHealthBar(currentHealth, maxHealth, "enemy");
    }

    //Damage Player
    //If Enemy has no health left, do a death animation
    public void take_damage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) {
            ;
            //MAKE PARTICLE EXPLOSION ANIMATION FOR DEATH ANIMATION
            //Destroy(gameObject);
        }

        healthBarController.UpdateHealthBar(currentHealth, maxHealth, "enemy");
    }
}

