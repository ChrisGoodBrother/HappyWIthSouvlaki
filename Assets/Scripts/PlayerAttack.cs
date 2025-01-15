using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private Animator animator;
    private GameObject playerObject;
    private EnemyStats enemyStats;
    [SerializeField] private GameObject punchObject;
    private PlayerStats playerStats;
    private Transform punchPos;
    private float damage;

    void Awake()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        animator = playerObject.GetComponent<Animator>();
        playerStats = playerObject.GetComponent<PlayerStats>();
        punchPos = transform;
        damage = 10f;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.K) && playerStats.isGrounded() && !animator.GetBool("stabbed"))
        {
            animator.SetTrigger("fight");

            Instantiate(punchObject, punchPos.position, Quaternion.identity);

            Destroy(punchObject, 0.1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (enemyStats != null)
            {
                enemyStats.take_damage(damage);
            }
        }
    }
}
