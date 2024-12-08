using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] public float maxHealth;
    [SerializeField] private float currentHealth;
    private Image healthBarFill;

    private void Awake() {
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
        if (currentHealth < 0) {
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

