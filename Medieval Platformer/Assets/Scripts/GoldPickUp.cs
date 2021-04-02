using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPickUp : MonoBehaviour
{
    [SerializeField] int goldCoinValue = 1;
    [SerializeField] int diamondValue = 5;
    [SerializeField] bool isGoldCoin = false;
    [SerializeField] bool isDiamond = false;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (isGoldCoin = true  && col.isTrigger) // be sure to check this if the players collider triggers are ever changed.
        {
            Destroy(gameObject);
            FindObjectOfType<GameSession>().AddToScore(goldCoinValue);
        }
        else if(isDiamond = true && col.isTrigger)
        {
            Destroy(gameObject);
            FindObjectOfType<GameSession>().AddToScore(diamondValue);
        }
    }


}
