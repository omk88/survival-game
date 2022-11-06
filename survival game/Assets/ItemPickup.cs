using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public GameObject item;
    public bool destroyed = false;
    
    void Start()
    {
    	item = this.gameObject;
    }

    void Update ()
    {
        if(destroyed)
        {
            Destroy(item);
            print("12444");
        }
    }
}