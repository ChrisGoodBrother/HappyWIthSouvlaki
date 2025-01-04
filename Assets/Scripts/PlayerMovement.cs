using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    [SerializeField] private float playerJumpHeight;
    [SerializeField] private LayerMask groundLayer;
    private Rigidbody2D playerBody;
    private Animator animator;
    private CapsuleCollider2D capsuleCollider2D;

    private void Awake() {
        playerBody = GetComponent<Rigidbody2D>();
        playerSpeed = 5f;
        playerJumpHeight = 14f;
        animator = GetComponent<Animator>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }

    private void Update() {

        //Move player left or right according to the input
        float horizontalMovement = Input.GetAxis("Horizontal"); 
        playerBody.velocity = new Vector2(horizontalMovement * playerSpeed, playerBody.velocity.y);

        //Flip Player Model
        if(horizontalMovement >= 0.01f)
            transform.localScale = Vector3.one;
        else if(horizontalMovement <= - 0.01f)
            transform.localScale = new Vector3(-1,1,1);

        //Make player jump if player is on the ground and not already jumping
        if(Input.GetKey(KeyCode.Space) && isGrounded()) {
            Jumping();
        }

        //Make player run if ShiftKey is pressed
        if(Input.GetKey(KeyCode.LeftShift) && horizontalMovement != 0) {
            playerBody.velocity = new Vector2(horizontalMovement * playerSpeed * 1.7f, playerBody.velocity.y); //Move player left and right but faster
            animator.SetBool("walk", false);
            animator.SetBool("run", true);
        } 
        else {
            animator.SetBool("run", false);
            animator.SetBool("walk", horizontalMovement != 0);
        }

        animator.SetBool("isgrounded", isGrounded());
    }

    //Make player jump
    private void Jumping() {
        playerBody.velocity = new Vector2(playerBody.velocity.x, playerJumpHeight);
        animator.SetTrigger("jump");
    }

    //Check if player is on the ground and not in the air
    private bool isGrounded() {
        RaycastHit2D raycastHit = Physics2D.CapsuleCast(capsuleCollider2D.bounds.center, new Vector2(0.6f, 2), CapsuleDirection2D.Vertical, 0f, Vector2.down , 0.1f, groundLayer);
  
        return raycastHit.collider != null;
    }
}
