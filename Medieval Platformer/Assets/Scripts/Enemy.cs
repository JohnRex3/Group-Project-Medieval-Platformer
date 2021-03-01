using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float enemyMoveSpeed = 1f;

    Rigidbody2D myRigidBody;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isFacingRight())
        {
            myRigidBody.velocity = new Vector2(enemyMoveSpeed, 0);
        }
        else
        {
            myRigidBody.velocity = new Vector2(-enemyMoveSpeed, 0);
        }

    }

    bool isFacingRight()
    {
        return transform.localScale.x > 0;
    }

    private void OnTriggerExit2D(Collider2D collision) 
    // make sure to set enemy box collider slightly in the ground for this to work.
    {
        transform.localScale = new Vector2(-(Mathf.Sign(myRigidBody.velocity.x)), 1f);
    }
}
