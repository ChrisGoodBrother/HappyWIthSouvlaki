using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] GameObject knifeObject;
    [SerializeField] private float spawnOffset;
    [SerializeField] private Transform knifePos;
    private Animator animate;
    private float cooldownTimer;

    private void Awake() {
        animate = GetComponent<Animator>();
        attackCooldown = 0.3f;
        cooldownTimer = 1000;
        spawnOffset = 1f;
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.K) && cooldownTimer > attackCooldown)
            Attack();
        
        cooldownTimer += Time.deltaTime;
    }

    private void Attack() {
        animate.SetTrigger("attack");
        Vector2 spawnPosition = transform.position + transform.up * spawnOffset;
        Instantiate(knifeObject, knifePos.position, Quaternion.identity);
        cooldownTimer = 0;
    }
}
