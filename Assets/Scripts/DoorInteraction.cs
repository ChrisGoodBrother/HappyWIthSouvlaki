
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteraction : MonoBehaviour
{
    private string sceneName;
    private GameManager gameManager;

    void Awake() {
        gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Scene currentScene = SceneManager.GetActiveScene();
            if(currentScene.name == "Level_1") {
                Debug.Log("Transition to Level 2");
                gameManager.TransitionToNextLevel("Level_2");
            }
            else if(currentScene.name == "Level_2") {
                Debug.Log("Transition to Win Scene");
                gameManager.TransitionToNextLevel("WinScene");
            }
        }
    }

    
}