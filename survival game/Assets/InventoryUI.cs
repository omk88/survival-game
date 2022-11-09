using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    InventorySlot[] slots;
    Dictionary<Item, int> inventory;
    // Start is called before the first frame update
    void Start()
    {
        inventory = Player.instance.inventory;
        Player.instance.OnInvChangeCall += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("i"))
        {
            Time.timeScale = 0;
            Player.instance.isPaused = true;
            itemsParent.gameObject.SetActive(true);
        }

        if (Input.GetKeyDown("escape"))
        {
            Time.timeScale = 1;
            Player.instance.isPaused = false;
            itemsParent.gameObject.SetActive(false);
        }
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.Count)
            {
                slots[i].addItem(inventory.ElementAt(i).Key, inventory.ElementAt(i).Value);
            }
            else
            {
                slots[i].removeItem();
            }
        }
    }
}
