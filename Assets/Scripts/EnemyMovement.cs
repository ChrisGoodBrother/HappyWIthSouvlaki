using Unity.VisualScripting;
using UnityEngine;

public class EnemeyMovement : MonoBehaviour
{
    [SerializeField] private float enemySpeed;
    [SerializeField] private float enemyJumpHeight;
    [SerializeField] private LayerMask groundLayer;
    private Rigidbody2D enemyBody;
    private Animator animator;
    private BoxCollider2D boxCollider2D;

    private void Awake() {
        enemyBody = GetComponent<Rigidbody2D>();
        enemySpeed = 7;
        enemyJumpHeight = 13;
        animator = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Update() {

        float horizontalMovement = Input.GetAxis("Horizontal"); //Horizontal "direction"

        enemyBody.velocity = new Vector2(horizontalMovement * enemySpeed, enemyBody.velocity.y); 

        //Flip Enemy Model
        if(horizontalMovement >= 0.01f)
            transform.localScale = Vector3.one;
        else if(horizontalMovement <= - 0.01f)
            transform.localScale = new Vector3(-1,1,1);

        if(Input.GetKey(KeyCode.Space) && isGrounded()) {
            Jumping();
        }

        //Setting Animation Parameters
        animator.SetBool("run", horizontalMovement != 0);
        animator.SetBool("isgrounded", isGrounded());
    }

    private void Jumping() {
        enemyBody.velocity = new Vector2(enemyBody.velocity.x, enemyJumpHeight);
        animator.SetTrigger("jump");
    }

    private bool isGrounded() {

        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0, Vector2.down, 0.1f, groundLayer);

        return raycastHit.collider != null;
    }
}
