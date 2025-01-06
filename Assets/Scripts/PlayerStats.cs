using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] public float maxHealth;
    [SerializeField] private float currentHealth;
    private Image healthBarFill;

    private void Awake()
    {
        maxHealth = 100f;
    }

    private void Start()
    {
        currentHealth = 10f; //Starting health
    }

    private void Update()
    {
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        //healthBarFill.fillAmount = currentHealth / maxHealth;
    }

    //Damage Player
    //If Player has no health left, do a death animation
    public void take_damage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            ;
            //Destroy(gameObject);
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

//using UnityEngine;

//public class PlayerStats : MonoBehaviour
//{
//    [SerializeField] private float maxHealth = 100f; // Μέγιστη Υγεία
//    [SerializeField] private float currentHealth = 50f; // Αρχική Υγεία
//    [SerializeField] private HealthBar healthBar; // Αναφορά στη HealthBar

//    private void Start()
//    {
//        UpdateHealthBar(); // Ενημέρωσε την HealthBar κατά την εκκίνηση
//    }

//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        // Αν ο παίκτης ακουμπήσει "σουβλάκι", αυξάνει την υγεία
//        if (collision.CompareTag("Souvlaki"))
//        {
//            AddHealth(20f); // Αυξάνει την υγεία κατά 20
//            Destroy(collision.gameObject); // Καταστρέφει το αντικείμενο
//        }

//        // Αν ο παίκτης ακουμπήσει "Knife", μειώνεται η υγεία
//        if (collision.CompareTag("Knife"))
//        {
//            TakeDamage(10f); // Μειώνει την υγεία κατά 10
//            Destroy(collision.gameObject); // Καταστρέφει το αντικείμενο
//        }
//    }

//    // Μειώνει την υγεία
//    public void TakeDamage(float damage)
//    {
//        currentHealth -= damage;
//        if (currentHealth < 0)
//            currentHealth = 0;

//        UpdateHealthBar(); // Ενημέρωση της HealthBar
//    }

//    // Αυξάνει την υγεία
//    public void AddHealth(float healthAmount)
//    {
//        currentHealth += healthAmount;
//        if (currentHealth > maxHealth)
//            currentHealth = maxHealth;

//        UpdateHealthBar(); // Ενημέρωση της HealthBar
//    }

//    // Ενημερώνει την HealthBar
//    private void UpdateHealthBar()
//    {
//        if (healthBar != null)
//        {
//            healthBar.UpdateHealthBar(maxHealth, currentHealth);
//        }
//    }
//}


