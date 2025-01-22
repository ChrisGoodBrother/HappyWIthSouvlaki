
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteraction : MonoBehaviour
{
    private string winScene = "WinScene";
    private string level2Scene = "Level_2"; // Το όνομα της σκηνής
    private Vector3 spawnPointPosition = new Vector3(-10, 0, 0); // Σημείο εκκίνησης
    private string sceneName;

    void Update() {
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(sceneName == "Level_1") {
                DontDestroyOnLoad(other.gameObject); // Διατήρηση του παίκτη
                SceneManager.sceneLoaded += OnSceneLoaded; // Προσθήκη event για μετακίνηση
                SceneManager.LoadScene(level2Scene); // Φόρτωση νέας σκηνής
            }
            //else if(sceneName == "Level_2") {
            //    SceneManager.sceneLoaded += OnSceneLoaded; // Προσθήκη event για μετακίνηση
            //    SceneManager.LoadScene(winScene); // Φόρτωση νέας σκηνής
            //}
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == level2Scene)
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