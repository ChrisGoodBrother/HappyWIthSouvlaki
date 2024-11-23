using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    private Rigidbody2D playerBody;

    private void Awake() {
        playerBody = GetComponent<Rigidbody2D>();
        playerSpeed = 5;
    }

    private void Update() {
        float horizontalMovement = Input.GetAxis("Horizontal");

        playerBody.velocity = new Vector2(horizontalMovement * playerSpeed, playerBody.velocity.y);

        if(Input.GetKey(KeyCode.Space)) {
            playerBody.velocity = new Vector2(playerBody.velocity.x, playerSpeed);
        }
    }
}
