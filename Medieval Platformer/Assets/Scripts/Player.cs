using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float playerRunSpeed = 1f;
    [SerializeField] float playerJumpSpeed = 1f;

    bool isAlive = true;

    Rigidbody2D myRigidBody;
    Animator myAnimator;
    CapsuleCollider2D myCapsuleCollider2D;
    BoxCollider2D myFeet;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myCapsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }

    
    void Update()
    {
        if (!isAlive) { return; }
        Run();
        Jump();
        Attack();
        Die();
        TurnAround();

        
    }

    private void Run()
    {
        float controlThrow = Input.GetAxis("Horizontal"); 
        Vector2 playerVelocity = new Vector2(controlThrow * playerRunSpeed, myRigidBody.velocity.y);
        myRigidBody.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("Running", playerHasHorizontalSpeed);

    }


    private void Jump()
    {
       if (!myFeet.IsTouchingLayers(LayerMask.GetMask("Forground"))) { return; } // make sure the ground tiles are set to the Forground tag //

        if (Input.GetButtonDown("Jump"))
        {
            Vector2 jumpVelocityToAdd = new Vector2(0f, playerJumpSpeed);
            myRigidBody.velocity += jumpVelocityToAdd;
        }
    }

    private void Attack()
    {


    }

    private void Die()
    {
        if (myCapsuleCollider2D.IsTouchingLayers(LayerMask.GetMask("Enemies", "Hazards")))
        {
            isAlive = false;
            FindObjectOfType<GameSession>().ProcessPlayerDeath();
        }

    }

    private void TurnAround()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
        }
    }
}
