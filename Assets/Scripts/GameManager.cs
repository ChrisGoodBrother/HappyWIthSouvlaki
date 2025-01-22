using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemy;
    private GameObject bossBorder;
    private Vector2 enemySpawnPosition;
    private bool bossSpawned;
    private BoxCollider2D houseDoor; 

    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        enemySpawnPosition = new Vector2(158.5f, -2.2f);
        bossBorder = GameObject.FindWithTag("BossBorder");
        bossSpawned = false;
        houseDoor = GameObject.FindWithTag("House").GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (player.transform.position.x >= 150) {
            bossBorder.SetActive(true);

            if(!bossSpawned) {
                Instantiate(enemy, enemySpawnPosition, Quaternion.identity);
                bossSpawned = true;
            }
            else {
                enemy = GameObject.FindWithTag("Enemy");
                if(enemy == null) {
                    houseDoor.enabled = true;
                }
                
            }
        }
    }
}
