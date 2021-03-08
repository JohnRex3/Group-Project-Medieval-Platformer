using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDataBase : MonoBehaviour
{
    public List<Weapons> weapons = new List<Weapons>();

    private void Awake()
    {
        BuildDatabase();
    }

    public Weapons GetWeapons(int id)
    {
        return weapons.Find(Weapons => Weapons.id == id);
    }

    void BuildDatabase()
    {
        weapons = new List<Weapons>()
        {
            new Weapons(0, "Basic Sword"),
            new Weapons(1, "Another Weapon Name"),
            new Weapons(2, "Another Weapon Name"),
            new Weapons(3, "Another Weapon Name"),
            new Weapons(4, "Another Weapon Name"),
        };             
    } 
}
