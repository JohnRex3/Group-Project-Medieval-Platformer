using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] float playerRunSpeed = 5f;
    [SerializeField] float playerJumpSpeed = 10f;

    public bool isAlive = true;

    Rigidbody2D myRigidBody;
    Animator myAnimator;
    CapsuleCollider2D myCapsuleCollider2D;
    BoxCollider2D myFeet;
    CapsuleCollider2D myWeapon; // make sure to set this on its own layer //
    

    public void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myCapsuleCollider2D = GetComponent<CapsuleCollider2D>();
        myFeet = GetComponent<BoxCollider2D>();
        myWeapon = GetComponent<CapsuleCollider2D>();
    }

    public void Update()
    {
        if (!isAlive) { return; }
        Run();
        Jump();
        Attack();
        TakeDamage();
        TurnAround();
    }

    private void Run()
    {
        float controlThrow = Input.GetAxis("Horizontal"); 
        Vector2 playerVelocity = new Vector2(controlThrow * playerRunSpeed, myRigidBody.velocity.y);
        myRigidBody.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        //myAnimator.SetBool("Running", playerHasHorizontalSpeed); put back in when we have a running animation

    }

    private void Jump()
    {
       if (!myFeet.IsTouchingLayers(LayerMask.GetMask("Foreground"))) { return; } 

        if (Input.GetButtonDown("Jump"))
        {
            Vector2 jumpVelocityToAdd = new Vector2(0f, playerJumpSpeed);
            myRigidBody.velocity += jumpVelocityToAdd;
        }
    }

    private void Attack()
    {
        if (Input.GetButtonDown("Attack1")) //Sword Attack
        {
            StartCoroutine(AttackWithWeapon()); 
        }
        else if(Input.GetButtonDown("Attack2")) //Bow Attack
        {
            //put the code to instansiate an arrow here when we have an arrow projectile
        }

    }

    public void TakeDamage()
    {
        if (myCapsuleCollider2D.IsTouchingLayers(LayerMask.GetMask("Enemies", "Hazards")))
        {
            Die();
        }
    }

    public void Die()
    { 
        isAlive = false;
        FindObjectOfType<GameSession>().ProcessPlayerDeath();

    }

    private void TurnAround()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
        }
    }

    private IEnumerator AttackWithWeapon()
    {
        myWeapon.enabled = true;
        yield return new WaitForSecondsRealtime(1);
        //probably need to have the animation call here but I don't remeber at this moment //
        myWeapon.enabled = false;

    }


}
