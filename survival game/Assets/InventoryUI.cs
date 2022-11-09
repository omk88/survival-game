using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    Dictionary<Item, int> inventory;
    // Start is called before the first frame update
    void Start()
    {
        var player = Player.instance;
        inventory = player.inventory;
        player.OnInvChangeCall += UpdateUI;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateUI()
    {
        Debug.Log("Ui Update");
    }
}
