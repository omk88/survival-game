using UnityEngine;
using TMPro;
using System;

public class UI : MonoBehaviour
{
    public GameObject HP;
    public GameObject Weap;
    public GameObject AmmoCount;
    private Player player;

    void Start()
    {
        player = Player.instance;
    }

    void Update()
    {
        try
        {
            Weap.GetComponent<TMP_Text>().SetText(player.equippedItem.Name);
            HP.GetComponent<TMP_Text>().SetText(player.maxHealth + "/" + player.health);
        }
        catch(Exception) { }
    }
}
