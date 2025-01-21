using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] public float maxHealth;
    [SerializeField] private float currentHealth;
    private CapsuleCollider2D capsuleCollider2D;
    [SerializeField] private LayerMask groundLayer;
    private HealthBarController healthBarController;
    private Animator animator;
    private bool isAlive;

    private void Awake() {
        maxHealth = 100f;
        animator = GetComponent<Animator>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        healthBarController = GameObject.FindGameObjectWithTag("GameController").GetComponent<HealthBarController>();
    }

    private void Start()
    {
        isAlive = true;
        animator.SetBool("alive", true);
        currentHealth = 10f; //Starting health
        healthBarController.UpdateHealthBar(currentHealth, maxHealth, "player");
    }

    //Damage Player
    //If Player has no health left, do a death animation
    public void take_damage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0) {
            if(isAlive)
                animator.SetTrigger("dead");
            animator.SetBool("alive", false);
            isAlive = false;
        }
        healthBarController.UpdateHealthBar(currentHealth, maxHealth, "player");
    }

    //Add health to Player
    public void add_health(float healthAmount)
    {
        currentHealth += healthAmount;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
        healthBarController.UpdateHealthBar(currentHealth, maxHealth, "player");
    }

    //Check if player is on the ground and not in the air
    public bool isGrounded() {
        RaycastHit2D raycastHit = Physics2D.CapsuleCast(capsuleCollider2D.bounds.center, new Vector2(0.6f, 2), CapsuleDirection2D.Vertical, 0f, Vector2.down , 0.1f, groundLayer);
  
        return raycastHit.collider != null;
    }
}