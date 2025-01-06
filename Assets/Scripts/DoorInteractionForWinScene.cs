using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteractionForWinScene : MonoBehaviour
{
    public string targetScene = "WinScene"; // Το όνομα της σκηνής

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(targetScene); // Φόρτωση της WinScene
        }
    }
}

