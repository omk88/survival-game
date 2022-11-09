using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Singleton
    public static Player instance;
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one player");
            return;
        }

        instance = this;
    }
    #endregion

    public bool isPaused;
    Vector3 pos;
    public Dictionary<Item, int> inventory = new Dictionary<Item, int>();

    public int health = 100;
    public int maxHealth = 100;

    public Item equippedItem;

    public delegate void OnInvChange();
    public OnInvChange OnInvChangeCall;

    public int getItemCount(string item)
    {
        foreach (var a in inventory.Keys)
        {
            if (a.Name == item)
            {
                return inventory[a];
            }
        }
        return 0;
    }

    public void addItem(Item item, int count)
    {
        foreach (var a in inventory.Keys)
        {
            if (a.Name == item.Name)
            {
                inventory[a] += count;
                OnInvChangeCall();
                return;
            }
        }

        inventory.Add(item, count);
        OnInvChangeCall();
    }

    public void removeItem(Item item)
    {
        foreach (var a in inventory.Keys)
        {
            if (a.Name.Equals(item.Name))
            {
                inventory.Remove(a);
                OnInvChangeCall();

                return;
            }
        }
    }

    public void removeItem(Item item, int count)
    {
        foreach (var a in inventory.Keys)
        {
            if (a.Name.Equals(item.Name))
            {
                if (inventory[a] - count <= 0)
                {
                    inventory.Remove(a);
                    OnInvChangeCall();
                }
                else
                {
                    inventory[a] -= count;
                    OnInvChangeCall();
                }
                return;
            }
        }
    }

    public void removeItem(string item, int count)
    {
        foreach (var a in inventory.Keys)
        {
            if (a.Name.Equals(item))
            {
                if (inventory[a] - count <= 0)
                {
                    inventory.Remove(a);
                    OnInvChangeCall();
                }
                else
                {
                    inventory[a] -= count;
                    OnInvChangeCall();
                }
                return;
            }
        }
    }

    public bool hasItem(Item item, int count)
    {
        foreach (var a in inventory.Keys)
        {
            if (a.Name.Equals(item.Name))
            {
                if (inventory[a] - count >= 0)
                {
                    return true;
                }
                break;
            }
        }
        return false;
    }

    public bool hasItem(string item, int count)
    {
        foreach (var a in inventory.Keys)
        {
            if (a.Name.Equals(item))
            {
                if (inventory[a] - count >= 0)
                {
                    return true;
                }
                break;
            }
        }
        return false;
    }

    public string invToStr()
    {
        string output = "";
        foreach (var a in inventory)
        {
            output += a.Key.Name + " " + a.Key.Description + " " + a.Value.ToString() + "\n";
        }
        return output;
    }
}
