using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteraction : MonoBehaviour
{
    public string targetSceneForLevel2 = "Level_2"; 
    public string targetSceneForWin = "WinScene"; 
    public Vector3 spawnPointPosition = new Vector3(-10, 0, 0); // Σημείο εκκίνησης στο Level 2

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            string currentSceneName = SceneManager.GetActiveScene().name;

            if (currentSceneName == targetSceneForLevel2)
            {
                // Αν βρίσκομαι ήδη στο Level_2, φόρτωσε την WinScene
                SceneManager.LoadScene(targetSceneForWin);
            }
            else if (targetSceneForLevel2 != "")
            {
                // Αν δεν βρίσκομαι στο Level_2, μεταφέρομαι σε αυτό
                DontDestroyOnLoad(other.gameObject); // Διατήρηση του παίκτη
                SceneManager.sceneLoaded += OnSceneLoadedForLevel2; // Προσθήκη event για μετακίνηση
                SceneManager.LoadScene(targetSceneForLevel2); // Φόρτωση του Level 2
            }
        }
    }

    void OnSceneLoadedForLevel2(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == targetSceneForLevel2)
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                player.transform.position = spawnPointPosition; // Μετακίνηση του παίκτη
            }

            SceneManager.sceneLoaded -= OnSceneLoadedForLevel2; // Αφαίρεση event
        }
    }
}









