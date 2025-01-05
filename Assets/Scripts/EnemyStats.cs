using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] public float maxHealth;
    [SerializeField] private float currentHealth;

    private void Awake() {
        maxHealth = 300f;
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
    }
}

