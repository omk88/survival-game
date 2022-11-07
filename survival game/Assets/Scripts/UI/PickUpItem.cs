using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour //https://www.youtube.com/watch?v=AoD_F1fSFFg , Solo Game Dev ,acessed 11/22 
{
    public SItem SItem;

    void Pickup()
    {
        InventoryManager.Instance.Add(SItem);
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        Pickup();
    }
}
