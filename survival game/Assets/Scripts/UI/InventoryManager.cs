using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour ////https://www.youtube.com/watch?v=AoD_F1fSFFg , Solo Game Dev ,acessed 11/22 
{
    public static InventoryManager Instance;
    public List<SItem> SItems = new List<SItem>();

    public Transform ItemContent;
    public GameObject InventoryItem;

    private void Awake()
    {
        Instance=this;
    }

    public void Add (SItem sitem)
    {
        SItems.Add(sitem);
    }

    public void Remove(SItem sitem)
    {
        SItems.Remove(sitem);
    }

    public void ListItems()
    {

        //foreach (Transform item in ItemContent)
        //{
            //Destroy(item.gameObject)
        //}

        foreach(var Sitem in SItems){
            GameObject obj = Instantiate(InventoryItem, ItemContent);

            var itemName = obj.transform.Find("itemName").GetComponent<Text>();

            var itemIcon= obj.transform.Find("icon").GetComponent<Image>();

            itemName.text = Sitem.itemName;
            itemIcon.sprite = Sitem.icon;

        }

    }

}
