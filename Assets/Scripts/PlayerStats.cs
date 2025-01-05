using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] public float maxHealth;
    [SerializeField] private float currentHealth;
    private Image healthBarFill;
    private Animator animator;
    private bool isAlive;

    private void Awake() {
        maxHealth = 100f;
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        isAlive = true;
        animator.SetBool("alive", true);
        currentHealth = 10f; //Starting health
    }

    //Damage Player
    //If Player has no health left, do a death animation
    public void take_damage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) {
            animator.SetTrigger("dead");
            animator.SetBool("alive", false);
        }
    }

    //Add health to Player
    public void add_health(float healthAmount)
    {
        currentHealth += healthAmount;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
    }
}