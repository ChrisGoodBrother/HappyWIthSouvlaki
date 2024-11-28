using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    private Rigidbody2D playerBody;
    private Animator animator;
    private bool isGrounded;

    private void Awake() {
        playerBody = GetComponent<Rigidbody2D>();
        playerSpeed = 5;
        animator = GetComponent<Animator>();
    }

    private void Update() {

        float horizontalMovement = Input.GetAxis("Horizontal"); //Horizontal "direction"

        playerBody.velocity = new Vector2(horizontalMovement * playerSpeed, playerBody.velocity.y); //Move player left and right

        //Flip Player Model
        if(horizontalMovement >= 0.01f)
            transform.localScale = Vector3.one;
        else if(horizontalMovement <= - 0.01f)
            transform.localScale = new Vector3(-1,1,1);

        if(Input.GetKey(KeyCode.Space)) {
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
    }

    private void Jumping() {
        
        //Make player jump
        playerBody.velocity = new Vector2(playerBody.velocity.x, playerSpeed);
        animator.SetTrigger("jump");
    }
}
