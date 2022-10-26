using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Player player;
    public Weapon weapon;
    void Start()
    {
        player = new Player(transform.position);
        string[] tags = { "Type:Weapon", "ShotType:Single", "ShotCount:1", "Size:1", "Speed:50", "Magazine:30", "Ammo:Rifle Ammo" };
        int Damage = 0;
        string Ammo = "";
        int MagSize = 0;

        List<Tuple<string, string>> tempTags = new List<Tuple<string, string>>();
        if (tags != null)
        {
            foreach (var a in tags)
            {
                string[] newStr = a.Split(":");
                tempTags.Add(new Tuple<string, string>(newStr[0], newStr[1]));
            }
        }

        var Tags = tempTags.ToArray();

        foreach (var a in Tags)
        {
            if (a.Item1.Equals("Damage")) { Damage = int.Parse(a.Item2); }
            else if (a.Item1.Equals("Ammo")) { Ammo = a.Item2; }
            else if (a.Item1.Equals("Magazine")) { MagSize = int.Parse(a.Item2); }
        }

        player.addWeapon(new Weapon("Assault Rifle", "Assault Rifle", "Assault Rifle", Tags, Damage, Ammo, MagSize));
        player.addItem(new Item("Rifle Ammo", "Rifle Ammo", "Rifle Ammo"), 500);
    }

    private void Update()
    {
        if (player.weapons.Count >= 1)
        {
            foreach (var a in player.weapons)
            {
                weapon = a;
            }
        }
    }
}
