using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float enemySpeed;
    [SerializeField] private float enemyJumpHeight;
    [SerializeField] private LayerMask groundLayer;
    private Rigidbody2D enemyBody;
    private Animator animator;
    private BoxCollider2D boxCollider2D;
    private bool goingRight;
    private bool goingLeft;
    [SerializeField] private float switchDirectionChance;
    [SerializeField] private float jumpChance;

    private void Awake() {
        enemyBody = GetComponent<Rigidbody2D>();
        enemySpeed = 9;
        enemyJumpHeight = 15;
        animator = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        goingLeft = true;
        goingRight = false;
        switchDirectionChance = 0.2f;
        jumpChance = 0.2f;
    }

    private void Update() {

        //Move enemy left and right and change sprite direction
        if(goingRight) {
            enemyBody.velocity = new Vector2(enemySpeed, enemyBody.velocity.y);
            transform.localScale = Vector3.one;
        }
        else {
            enemyBody.velocity = new Vector2(-enemySpeed, enemyBody.velocity.y);
            transform.localScale = new Vector3(-1,1,1);
        }

        //Randomly make enemy switch direction
        if (Random.value < switchDirectionChance * Time.deltaTime)
        {
            goingLeft = !goingLeft;
            goingRight = !goingRight;
        }

        //Randomly make enemy jump
        if(isGrounded() && Random.value < jumpChance * Time.deltaTime) {
            Jumping();
        }

        //Setting Animation Parameters
        animator.SetBool("run", goingLeft || goingRight);
        animator.SetBool("isgrounded", isGrounded());
    }

    //Make enemy jump
    private void Jumping() {
        enemyBody.velocity = new Vector2(enemyBody.velocity.x, enemyJumpHeight);
        animator.SetTrigger("jump");
    }

    //Check if enemy is on the ground and not already jumping
    private bool isGrounded() {

        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0, Vector2.down, 0.1f, groundLayer);

        return raycastHit.collider != null;
    }

    //Check if enemy has reached a wall or a player
    //If so change direction
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("BossBorder") || collision.gameObject.CompareTag("Player")) {
            goingLeft = !goingLeft;
            goingRight = !goingRight;
        }
    }
}
