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
        // Εγγραφή στη σκηνή όταν φορτώνεται
        SceneManager.sceneLoaded += OnSceneLoaded;

        currentHealth = 5f; // Στην αρχή της κάθε σκηνής
        UpdateHealthBar(); // Ενημέρωση μπάρας υγείας
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Ελέγχουμε αν είμαστε στη σκηνή "Level_2"
        if (scene.name == "Level_2")
        {
            // Επαναφορά της υγείας στο Level_2
            currentHealth = 5f;
        }
        UpdateHealthBar();
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
        if (!isAlive) return; // Εξασφαλίζουμε ότι δεν εκτελείται αν ο παίκτης είναι ήδη νεκρός

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            currentHealth = 0; // Εξασφάλιση ότι δεν θα είναι αρνητική

            if (explosionEffect != null && isAlive) // Έλεγχος για το εφέ της έκρηξης
            {
                Instantiate(explosionEffect,
                    transform.position + new Vector3(0, 0, -1),
                    Quaternion.identity);
                //Vector3 explosionPosition = transform.position + new Vector3(0, 0, -1); 
                //Instantiate(explosionEffect, explosionPosition, Quaternion.identity);
            }

            // Παίζουμε το animation του θανάτου
            animator.SetTrigger("dead");
            animator.SetBool("alive", false);
            isAlive = false; // Ο παίκτης θεωρείται πλέον νεκρός

            GetComponent<PlayerMovement>().enabled = false;
            Destroy(gameObject); // Καταστρέφει το αντικείμενο (τον χαρακτήρα)

            SceneManager.LoadScene("RestartScene");

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

    // Αν ο παίκτης ακουμπήσει το μαχαίρι (knife)
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Knife"))
        {
            take_damage(20f); // Μείωση υγείας κατά 20 όταν ακουμπάει το μαχαίρι
        }

        if (other.CompareTag("Souvlaki"))
        {
            add_health(10f); // Αύξηση υγείας κατά 10
            Destroy(other.gameObject); // Καταστροφή του αντικειμένου Souvlaki
        }
    }
}
