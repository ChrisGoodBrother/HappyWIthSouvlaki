using UnityEngine;

public class Souvlaki : MonoBehaviour
{
    [SerializeField] private float healthAddition;
    private PlayerStats playerStats;

    private void Awake()
    {
        playerStats = GetComponent<PlayerStats>();
        healthAddition = 10f;
    }

    //When player goes on the item, the item is deleted from the game
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (playerStats != null)
            {
                playerStats.add_health(healthAddition);
            }
            Destroy(gameObject);
        }
    }
}
//using UnityEngine;

//public class Souvlaki : MonoBehaviour
//{
//    [SerializeField] private float healthAddition = 10f; // Ποσότητα υγείας που δίνει το σουβλάκι

//    private void OnTriggerEnter2D(Collider2D other)
//    {
//        if (other.CompareTag("Player"))
//        {
//            PlayerStats playerStats = other.GetComponent<PlayerStats>();
//            if (playerStats != null)
//            {
//                playerStats.AddHealth(healthAddition); // Καλεί τη μέθοδο AddHealth
//            }
//            Destroy(gameObject); // Καταστρέφει το σουβλάκι
//        }
//    }
//}

