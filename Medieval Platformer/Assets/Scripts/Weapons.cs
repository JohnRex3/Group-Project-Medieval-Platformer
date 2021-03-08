using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons
{
    [SerializeField] public int id;
    public BoxCollider2D weaponCollider2D;
    public string name;
 
    public Weapons(int id, string name)
    {
        this.id = id;
        this.name = name;
    }
}
