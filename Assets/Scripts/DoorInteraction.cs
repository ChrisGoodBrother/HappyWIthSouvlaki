
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteraction : MonoBehaviour
{
    private Transform spawnPoint; // Σημείο εκκίνησης για τον παίκτη στο Level_2

    void Start()
    {
        // Χειροκίνητη τοποθέτηση του spawnPoint
        spawnPoint = new GameObject("SpawnPoint").transform;  // Δημιουργεί νέο αντικείμενο ως spawn point
        spawnPoint.position = new Vector3(-10, 0, 0);  // Ρυθμίζει τις συντεταγμένες του spawn point 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Φορτώνει το Level_2
            SceneManager.LoadScene("Level_2", LoadSceneMode.Additive);

            // Τοποθετούμε τον παίκτη στο spawn point
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                Vector3 spawnPosition = spawnPoint.position;
                spawnPosition.z = player.transform.position.z; // Διατηρεί το ίδιο z
                player.transform.position = spawnPosition;
            }
        }
    }
}
























