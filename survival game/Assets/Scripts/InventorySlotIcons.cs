using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlotIcons : MonoBehaviour
{
    public GameObject AxeIcon;
    public GameObject PickaxeIcon;
    public GameObject RockIcon;
    public GameObject LogIcon;
    public GameObject BerriesIcon;

    public Inventory inv;

    public bool full;

    public List<string> inventoryItems;

    void Start()
    {
        inventoryItems = inv.inventory;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setIconActive()
    {
        print(inventoryItems.Count);
        for(int i = 0; i < inventoryItems.Count; i++)
        {
            if(inventoryItems[i] == "AxeItem" && !full)
            {
                AxeIcon.SetActive(true);
                full = true;
            }
            if(inventoryItems[i] == "PickaxeItem" && !full)
            {
                PickaxeIcon.SetActive(true);
                full = true;
            }
        }



    }
}
