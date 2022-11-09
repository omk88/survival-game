using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour //based on online tutorial-add link
{
    public static InventoryManager Instance;
    public List<SItem> Items = new List<SItem>();

    private void Awake()
    {
        Instance=this;
    }

    public void Add (SItem item)
    {
        Items.Add(item);
    }

    public void Remove(SItem item)
    {
        Items.Remove(item);
    }

}
