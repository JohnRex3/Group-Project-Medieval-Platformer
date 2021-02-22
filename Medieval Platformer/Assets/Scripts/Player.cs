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


    }


    private void Jump()
    {


    }

    private void Attack()
    {


    }

    private void Die()
    {


    }

    private void TurnAround()
    {


    }
}
