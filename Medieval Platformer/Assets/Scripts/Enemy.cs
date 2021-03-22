using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    [SerializeField] float enemyMoveSpeed = 2f;


    Rigidbody2D myRigidBody;
    CircleCollider2D myCircleCollider2D;

    Vector3 enemyScale;
    float enemyScaleX;


    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        enemyScale = transform.localScale;
        enemyScaleX = enemyScale.x;
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
        //transform.localScale = new Vector2(-(Mathf.Sign(myRigidBody.velocity.x)), 2.1f);
        if (isFacingRight())
        {
            enemyScale.x = -enemyScaleX;
        }
        else
        {
            enemyScale.x = enemyScaleX;
        }
        transform.localScale = enemyScale;
    }

    private void Die()
    {
        if (myCircleCollider2D.IsTouchingLayers(LayerMask.GetMask("Player", "Place Holder For Player Weapon Mask"))) // add mask for player weapons later
        {
            Destroy(gameObject);
        }
    }
}
