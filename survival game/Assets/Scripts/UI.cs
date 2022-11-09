using UnityEngine;
using TMPro;
using System;

public class UI : MonoBehaviour
{
    public GameObject playerObject;
    private PlayerManager playerManager;
    public GameObject HP;
    public GameObject Weap;
    public GameObject AmmoCount;

    void Start()
    {
        playerManager = playerObject.GetComponent<PlayerManager>();
    }

    void Update()
    {
        try
        {
            Weap.GetComponent<TMP_Text>().SetText(playerManager.weapon.Name);
            HP.GetComponent<TMP_Text>().SetText(playerManager.player.maxHealth + "/" + playerManager.player.health);
            AmmoCount.GetComponent<TMP_Text>().SetText(playerManager.player.getItemCount(playerManager.weapon.Ammo) + "/" + playerManager.weapon.AmmoCount);
        }
        catch(Exception) { }
    }
}
