using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    Item item;
    public Button removeButton;
    public TMP_Text itemCount;

    public void addItem (Item _item, int count)
    {
        Debug.Log(count);
        item = _item;
        icon.sprite = _item.Icon;
        icon.enabled = true;
        removeButton.interactable = true;
        itemCount.SetText(count.ToString());
    }

    public void removeItem()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    public void onRemoveButton()
    {
        Player.instance.removeItem(item);

    }

    public void onItemButton()
    {
        Player.instance.equippedItem = item;
    }
}
