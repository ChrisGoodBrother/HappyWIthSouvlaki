using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private Animator animator;
    [SerializeField] private GameObject attackPoint;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask enemyMask;
    private EnemyStats enemyStats;
    private PlayerStats playerStats;
    private float damage;

    void Awake()
    {
        animator = GetComponent<Animator>();
        playerStats = GetComponent<PlayerStats>();
        damage = 10f;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K) && playerStats.isGrounded() && !animator.GetBool("stabbed")) {
            animator.SetTrigger("fight");
            attack();
        }
    }

    public void attack() {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(attackPoint.transform.position, radius, enemyMask);

        foreach(Collider2D enemyObject in enemy) {
            EnemyStats enemyStats = enemyObject.GetComponent<EnemyStats>();
            Debug.Log("Hurt");
            enemyStats.take_damage(damage);
        }
    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(attackPoint.transform.position, radius);
    }
}
