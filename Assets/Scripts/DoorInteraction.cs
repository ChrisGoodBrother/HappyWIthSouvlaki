
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteraction : MonoBehaviour
{
    public string targetScene = "Level_2"; // Το όνομα της σκηνής
    public Vector3 spawnPointPosition = new Vector3(-10, 0, 0); // Σημείο εκκίνησης στο Level 2

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DontDestroyOnLoad(other.gameObject); // Διατήρηση του παίκτη
            SceneManager.sceneLoaded += OnSceneLoaded; // Προσθήκη event για μετακίνηση
            SceneManager.LoadScene(targetScene); // Φόρτωση νέας σκηνής
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == targetScene)
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                player.transform.position = spawnPointPosition; // Μετακίνηση του παίκτη
            }

            SceneManager.sceneLoaded -= OnSceneLoaded; // Αφαίρεση event
        }
    }
}

//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class DoorInteraction : MonoBehaviour
//{
//    private Transform spawnPoint; // Σημείο εκκίνησης για τον παίκτη στο Level_2
//    private string targetScene = "Level_2"; // Το όνομα της σκηνής που φορτώνεις

//    void Start()
//    {
//        // Δημιουργεί νέο αντικείμενο ως spawn point
//        spawnPoint = new GameObject("SpawnPoint").transform;

//        // Χρησιμοποιούμε raycast για να βρούμε το έδαφος
//        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity);

//        if (hit.collider != null && hit.collider.CompareTag("Ground"))
//        {
//            spawnPoint.position = hit.point; // Τοποθετούμε το spawn point ακριβώς πάνω στο έδαφος
//            Debug.Log("Spawn point placed at: " + spawnPoint.position);
//        }
//        else
//        {
//            Debug.LogError("No ground found for spawn point");
//        }
//    }

//    void OnTriggerEnter2D(Collider2D other)
//    {
//        if (other.CompareTag("Player"))
//        {
//            DontDestroyOnLoad(other.gameObject); // Διατήρηση του παίκτη

//            // Φορτώνει το Level_2 και αντικαθιστά το Level_1
//            SceneManager.LoadScene(targetScene, LoadSceneMode.Single);

//            // Διαγραφή του Level_1 αν είναι φορτωμένο
//            SceneManager.UnloadSceneAsync("Level_1");

//            // Τοποθετούμε τον παίκτη στο spawn point του Level_2
//            GameObject player = GameObject.FindWithTag("Player");
//            if (player != null)
//            {
//                Vector3 spawnPosition = spawnPoint.position;
//                spawnPosition.z = player.transform.position.z; // Διατηρεί το ίδιο z
//                player.transform.position = spawnPosition;
//            }
//        }
//    }
//}







