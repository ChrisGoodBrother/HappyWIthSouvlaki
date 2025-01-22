using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallToDeath : MonoBehaviour
{
    private PlayerStats playerStats;

    void Awake() {
        playerStats = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerStats.setIsAlive(false);
        }
    }
}
