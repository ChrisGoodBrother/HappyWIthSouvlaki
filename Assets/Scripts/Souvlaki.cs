using UnityEngine;

public class Souvlaki : MonoBehaviour
{
    [SerializeField] private float healthAddition;
    private PlayerStats playerStats;
    private GameObject player;

    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
        playerStats = player.GetComponent<PlayerStats>();
        healthAddition = 10f;
    }

    //When player goes on the item, the item is deleted from the game
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(playerStats != null) {
                playerStats.add_health(healthAddition);
            }
            
            Destroy(gameObject);
        }
    }
}
