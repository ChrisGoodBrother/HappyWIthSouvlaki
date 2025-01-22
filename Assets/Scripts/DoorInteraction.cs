
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