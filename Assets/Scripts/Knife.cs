using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Knife : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D knifeBody;
    [SerializeField] private float throwSpeed;

    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
        knifeBody = GetComponent<Rigidbody2D>();
        throwSpeed = 10f;
    }

    private void Start() {
        Vector3 direction = player.transform.position - transform.position;
        knifeBody.velocity = new Vector2(direction.x, direction.y - 1).normalized * throwSpeed;

        float rotate = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,rotate + 180);
    }

    private void Update() {

    }
}
