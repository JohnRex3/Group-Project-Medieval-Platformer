using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPickUp : MonoBehaviour
{
    [SerializeField] int goldCoinValue = 1;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.isTrigger) // be sure to check this if the players collider triggers are ever changed.
        {
        Destroy(gameObject);
        FindObjectOfType<GameSession>().AddToScore(goldCoinValue);
        }
    }


}
