using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    [SerializeField] private float playerJumpHeight;
    [SerializeField] private LayerMask groundLayer;
    private Rigidbody2D playerBody;
    private Animator animator;
    private BoxCollider2D boxCollider2D;

    private void Awake() {
        playerBody = GetComponent<Rigidbody2D>();
        playerSpeed = 5;
        playerJumpHeight = 13;
        animator = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Update() {

        float horizontalMovement = Input.GetAxis("Horizontal"); //Horizontal "direction"

        playerBody.velocity = new Vector2(horizontalMovement * playerSpeed, playerBody.velocity.y); //Move player left and right

        //Flip Player Model
        if(horizontalMovement >= 0.01f)
            transform.localScale = Vector3.one;
        else if(horizontalMovement <= - 0.01f)
            transform.localScale = new Vector3(-1,1,1);

        if(Input.GetKey(KeyCode.Space) && isGrounded()) {
            Jumping();
        }

        //Setting Animation Parameters
        if(Input.GetKey(KeyCode.LeftShift)) {
            playerBody.velocity = new Vector2(horizontalMovement * playerSpeed * 2, playerBody.velocity.y); //Move player left and right but faster
            animator.SetBool("walk", false);
            animator.SetBool("run", true);
        } 
        else {
            animator.SetBool("run", false);
            animator.SetBool("walk", horizontalMovement != 0);
        }

        animator.SetBool("isgrounded", isGrounded());
    }

    private void Jumping() {
        
        //Make player jump
        playerBody.velocity = new Vector2(playerBody.velocity.x, playerJumpHeight);
        animator.SetTrigger("jump");
    }

    private bool isGrounded() {

        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0, Vector2.down, 0.1f, groundLayer);

        return raycastHit.collider != null;
    }
}
