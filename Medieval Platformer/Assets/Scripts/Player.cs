using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] float playerRunSpeed = 1f;
    [SerializeField] float playerJumpSpeed = 1f;
    [SerializeField] float timer = 360f;

    [SerializeField] Text timerText; // If possible I want to move this to the game section script but as of this moment I can't call the Die Function from anywhere but here.

    bool isAlive = true;

    public List<Weapons> characterWeapons = new List<Weapons>();
    public List<Weapons> weapons = new List<Weapons>();
    public WeaponDataBase weaponDataBase;

    Rigidbody2D myRigidBody;
    Animator myAnimator;
    CapsuleCollider2D myCapsuleCollider2D;
    BoxCollider2D myFeet;
    CapsuleCollider2D myWeapon; // make sure to set this on its own layer //
    

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myCapsuleCollider2D = GetComponent<CapsuleCollider2D>();
        myWeapon = GetComponent<CapsuleCollider2D>();
        myWeapon.enabled = false;
        timerText.text = timer.ToString();
        giveStartingWeapon(0);
    }

    void Update()
    {
        if (!isAlive) { return; }
        Run();
        Jump();
        Attack();
        Die();
        TurnAround();

        timer -= Time.deltaTime;
        timerText.text = timer.ToString();
        if (timer <= 0)
        {
            Die();
        }
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
        if (Input.GetKeyDown("left click"))
        {
            StartCoroutine(AttackWithWeapon());
        }

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

    private IEnumerator AttackWithWeapon()
    {
        myWeapon.enabled = true;
        yield return new WaitForSecondsRealtime(1);
        //probably need to have the animation call here but I don't remeber at this moment //
        myWeapon.enabled = false;

    }


    public void giveStartingWeapon(int id)
    {
        Weapons weaponToAdd = weaponDataBase.GetWeapons(id);
        characterWeapons.Add(weaponToAdd);
        var weaponToRemoveLater = weaponToAdd;
        Debug.Log("Add weapon" + weaponToAdd.name);
    }

}
