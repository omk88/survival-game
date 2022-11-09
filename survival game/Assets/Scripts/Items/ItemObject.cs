using UnityEngine;
using System;
using System.Collections.Generic;

public class ItemObject : MonoBehaviour
{
    public string ID;
    public string Name;
    public string Description;
    public Tuple<string, string>[] Tags;
    public string[] _Tags;
    public int Count;
    public Item item;
    // Start is called before the first frame update
    void Start()
    {
        List<Tuple<string, string>> tempTags = new List<Tuple<string, string>>();
        if (_Tags != null)
        {
            foreach (var a in _Tags)
            {
                string[] newStr = a.Split(":");
                tempTags.Add(new Tuple<string, string>(newStr[0], newStr[1]));
            }
        }

        Tags = tempTags.ToArray();

        foreach (var a in Tags)
        {
            Debug.Log(a.Item1 + ":" + a.Item2);
        }

        item = new Item(ID, Name, Description, Tags);
    }
}
