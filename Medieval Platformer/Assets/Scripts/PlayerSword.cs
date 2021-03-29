using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSword : MonoBehaviour
{
    CapsuleCollider2D myWeapon;
    void Start()
    {
        myWeapon = GetComponent<CapsuleCollider2D>();
        myWeapon.enabled = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            myWeapon.enabled = true;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            
        }
    }
}
