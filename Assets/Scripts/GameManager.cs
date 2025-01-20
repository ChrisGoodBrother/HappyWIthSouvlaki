using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private GameObject enemy;
    private GameObject bossBorder;
    private Vector2 enemySpawnPosition;
    private bool bossSpawned;

    void Awake()
    {
        enemySpawnPosition = new Vector2(158.5f, -2.2f);
        player = GameObject.FindWithTag("Player");
        bossBorder = GameObject.FindWithTag("BossBorder");
        bossSpawned = false;
    }

    void Update()
    {
        if (player.transform.position.x >= 150) { 
            bossBorder.SetActive(true);

            if(!bossSpawned) {
                Instantiate(enemy, enemySpawnPosition, Quaternion.identity);
                bossSpawned = true;
            }
        }
    }
}
