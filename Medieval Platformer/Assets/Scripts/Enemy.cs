using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    [SerializeField] float enemyMoveSpeed = 1.25f;
    [SerializeField] public int enemyMaxHealth = 2;
    int currentHealth;

    Animator enemyAnimator;

    Rigidbody2D myRigidBody;
    CircleCollider2D myCircleCollider2D;

    Vector3 enemyScale;
    float enemyScaleX;


    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        enemyScale = transform.localScale;
        enemyScaleX = enemyScale.x;
        currentHealth = enemyMaxHealth;
        enemyAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        Die();
        if (isFacingRight())
        {
            myRigidBody.velocity = new Vector2(-enemyMoveSpeed, 0);
        }
        else
        {
            myRigidBody.velocity = new Vector2(enemyMoveSpeed, 0);
        }
        
    }

    bool isFacingRight()
    {
        return transform.localScale.x > 0;
    }

    private void OnTriggerExit2D(Collider2D collision) 
    // make sure to set enemy box collider slightly in the ground for this to work.
    {
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

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }


    }
    private void Die()
    {
        if(currentHealth <= 0)
        {
            enemyAnimator.SetBool("Dying", true);   
            Destroy(gameObject);
        }
    }
}
