using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    // Config
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;

    // State
    bool isAlive = true;
    bool isJumping = false;

    // Cached component references
    Rigidbody2D myRigidBody;
    Animator myAnimator;
    Collider2D myCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myCollider2D = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        Jump();
        FlipSprite();
    }

    private void Run()
    {
        float controlThrow = Input.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, myRigidBody.velocity.y);
        myRigidBody.velocity = playerVelocity;
        
        bool playerMoveLeftRight = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("Run", playerMoveLeftRight);
    }

    private void Jump()
    {
        if (!myCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }

        if (Input.GetButton("Jump"))
        {
            //Vector2 jumpVelocity = new Vector2(0f, jumpSpeed);
            //myRigidBody.velocity += jumpVelocity;
            myRigidBody.velocity = Vector2.zero;
            Vector2 jumpVelocity = new Vector2(0, jumpSpeed);
            myRigidBody.AddForce(jumpVelocity, ForceMode2D.Impulse);
        }
    }
    private void FlipSprite()
    {
        bool playerMoveLeftRight = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        if (playerMoveLeftRight)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
        }
    }

}
