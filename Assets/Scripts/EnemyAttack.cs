using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    private Animator animate;
    private float cooldownTimer;

    private void Awake() {
        animate = GetComponent<Animator>();
        attackCooldown = 0.3f;
        cooldownTimer = 1000;
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.K) && cooldownTimer > attackCooldown)
            Attack();
        
        cooldownTimer += Time.deltaTime;
    }

    private void Attack() {
        animate.SetTrigger("attack");
        cooldownTimer = 0;
    }
    
}
