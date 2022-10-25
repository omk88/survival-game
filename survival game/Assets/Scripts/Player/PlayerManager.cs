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
