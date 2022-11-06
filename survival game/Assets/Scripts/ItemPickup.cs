using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public GameObject item;
    public bool destroyed = false;
    public Inventory inv;
    public string itemName;
    
    void Start()
    {
    	item = this.gameObject;
    }

    public void DropItem(string name)
    {
        Inventory inv = (Inventory)GameObject.Find("Player").GetComponent(typeof(Inventory));

        inv.inventory.Remove(name);
    }

    void Update ()
    {
        if(destroyed)
        {
            Inventory inv = (Inventory)GameObject.Find("Player").GetComponent(typeof(Inventory));
            Destroy(item);
            print("Item Picked up");
            inv.inventory.Add(itemName);

            string result = "List contents: ";

            foreach(var i in inv.inventory)
            {
                result += i.ToString() + ", ";
            }
            print(result);
        }
    }
}