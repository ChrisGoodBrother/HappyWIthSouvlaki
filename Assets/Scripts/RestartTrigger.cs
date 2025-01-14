using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Ελέγχουμε αν το αντικείμενο που μπήκε στο trigger έχει το tag "Player"
        if (collision.CompareTag("Player"))
        {
         
            SceneManager.LoadScene("RestartScene");
        }
    }
}

