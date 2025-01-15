using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] public float maxHealth;
    [SerializeField] private float currentHealth;
    private CapsuleCollider2D capsuleCollider2D;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Image foregroundImage; // Το κόκκινο image που αυξομειώνεται
    private Animator animator;
    private bool isAlive;

    [SerializeField] private ParticleSystem explosionEffect; // Αναφορά στο εφέ της έκρηξης

    private void Awake()
    {
        maxHealth = 100f;
        animator = GetComponent<Animator>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }

    private void Start()
    {
        isAlive = true;
        animator.SetBool("alive", true);
        currentHealth = 5f; // Αρχική υγεία
        UpdateHealthBar(); // Ενημέρωση μπάρας
    }

    // Ενημέρωση μπάρας υγείας
    private void UpdateHealthBar()
    {
        if (foregroundImage != null)
        {
            foregroundImage.fillAmount = currentHealth / maxHealth; // Υπολογισμός ποσοστού
        }
    }

    // Ζημιά στον παίκτη
    public void take_damage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0; // Εξασφάλιση ότι δεν θα είναι αρνητική
            if (explosionEffect != null)
            {
                //var explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);
                //Debug.Log("Explosion created at: " + transform.position);
                //explosion.Play();  // Ενεργοποιεί το εφέ χειροκίνητα
                // Δημιουργία του εφέ της έκρηξης στην ίδια θέση με τον παίκτη
                Instantiate(explosionEffect, transform.position, Quaternion.identity);
            }

            // Παίζουμε το animation του θανάτου
            animator.SetTrigger("dead");
            animator.SetBool("alive", false);
            isAlive = false;

            // Φορτώνουμε τη σκηνή RestartScene με καθυστέρηση 4 δευτερολέπτων
            Invoke("RestartGame", 4f);
        }

        UpdateHealthBar(); // Ενημέρωση μπάρας μετά την αλλαγή υγείας
    }

    // Αύξηση υγείας
    public void add_health(float healthAmount)
    {
        currentHealth += healthAmount;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth; // Περιορισμός στο maxHealth
        UpdateHealthBar(); // Ενημέρωση μπάρας
    }

    // Έλεγχος αν ο παίκτης είναι στο έδαφος
    public bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.CapsuleCast(capsuleCollider2D.bounds.center, new Vector2(0.6f, 2), CapsuleDirection2D.Vertical, 0f, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    private void RestartGame()
    {
        // Φόρτωση της σκηνής RestartScene
        SceneManager.LoadScene("RestartScene");
    }

    // Αν ο παίκτης ακουμπήσει το μαχαίρι (knife)
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Knife"))
        {
            take_damage(10f); // Μείωση υγείας κατά 10 όταν ακουμπάει το μαχαίρι
        }

        if (other.CompareTag("Souvlaki"))
        {
            add_health(5f); // Αύξηση υγείας κατά 5
            Destroy(other.gameObject); // Καταστροφή του αντικειμένου Souvlaki
        }
    }
}


/////////////////////////////////////////////

//using Unity.VisualScripting;
//using UnityEngine;
//using UnityEngine.UI;

//public class PlayerStats : MonoBehaviour
//{
//    [SerializeField] public float maxHealth;
//    [SerializeField] private float currentHealth;
//    private CapsuleCollider2D capsuleCollider2D;
//    [SerializeField] private LayerMask groundLayer;
//    private Image healthBarFill;
//    private Animator animator;
//    private bool isAlive;

//    private void Awake()
//    {
//        maxHealth = 100f;
//        animator = GetComponent<Animator>();
//        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
//    }

//    private void Start()
//    {
//        isAlive = true;
//        animator.SetBool("alive", true);
//        currentHealth = 10f; //Starting health
//    }

//    //Damage Player
//    //If Player has no health left, do a death animation
//    public void take_damage(float damage)
//    {
//        currentHealth -= damage;
//        if (currentHealth <= 0)
//        {
//            if (isAlive)
//                animator.SetTrigger("dead");
//            animator.SetBool("alive", false);
//            isAlive = false;
//        }
//    }

//    //Add health to Player
//    public void add_health(float healthAmount)
//    {
//        currentHealth += healthAmount;
//        if (currentHealth > maxHealth)
//            currentHealth = maxHealth;
//    }

//    //Check if player is on the ground and not in the air
//    public bool isGrounded()
//    {
//        RaycastHit2D raycastHit = Physics2D.CapsuleCast(capsuleCollider2D.bounds.center, new Vector2(0.6f, 2), CapsuleDirection2D.Vertical, 0f, Vector2.down, 0.1f, groundLayer);

//        return raycastHit.collider != null;
//    }
//}