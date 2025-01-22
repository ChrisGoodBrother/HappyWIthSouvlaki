using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private PlayerStats playerStats;
    [SerializeField] private GameObject enemy;
    private GameObject spawnedEnemy;
    public Vector3 spawnPointPosition = new Vector3(-10, 0, 0);
    private GameObject bossBorder;
    private Vector2 enemySpawnPosition;
    private bool bossSpawned;
    private BoxCollider2D houseDoor; 

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        player = GameObject.FindWithTag("Player");
        playerStats = player.GetComponent<PlayerStats>();
        enemySpawnPosition = new Vector2(158.5f, -2.2f);
        bossBorder = GameObject.FindWithTag("BossBorder");
        houseDoor = GameObject.FindWithTag("House").GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if(player != null) {
            if (player.transform.position.x >= 150) {
                if(bossBorder != null)
                    bossBorder.SetActive(true);

                if(!bossSpawned) {
                    spawnedEnemy = Instantiate(enemy, enemySpawnPosition, Quaternion.identity);
                    bossSpawned = true;                        
                }
                else {
                    if(spawnedEnemy == null) {
                        if(houseDoor != null)
                            houseDoor.enabled = true;
                    }
                    
                }
            }
        }
        
        SceneManager.sceneLoaded += OnSceneLoaded;   
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        bossSpawned = false;
        if (scene.name == "Level_1")
        {
            playerStats.setHealth(10f);
            playerStats.setMaxHealth(100f);
            playerStats.setPosition(spawnPointPosition);
            playerStats.add_health(0);
            if(bossBorder != null)
                bossBorder.SetActive(false);
        }
        else if (scene.name == "Level_2")
        {
            playerStats.setHealth(10f);
            playerStats.setMaxHealth(150f);
            playerStats.setPosition(spawnPointPosition);
            playerStats.add_health(0);
            houseDoor = GameObject.FindWithTag("House").GetComponent<BoxCollider2D>();
            if(bossBorder != null)
                bossBorder.SetActive(false);
        }
    }

    public void TransitionToNextLevel(string nextScene)
    {
        SceneManager.LoadScene(nextScene);
    }

    public void TransitionToRestartMenu()
    {
        SceneManager.LoadScene("RestartScene");
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}