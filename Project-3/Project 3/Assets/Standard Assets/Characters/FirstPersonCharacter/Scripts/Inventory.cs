using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<Item> itemList;
    private UI_InventoryS uiInventory;

    void Start()
    {
        uiInventory = GameObject.Find("UI_Inventory").GetComponent<UI_InventoryS>() as UI_InventoryS;
    }

    public Inventory()
    {
        itemList = new List<Item>();

        /*AddItem(new Item { itemType = Item.ItemType.Note, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Potion1, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Potion2, amount = 1 });*/
    }

    public void AddItem(Item item)
    {
        itemList.Add(item);
        Debug.Log("Added item. " + itemList.Count);
    }
    public void AddItem(string itemType)
    {
        switch(itemType)
        {
            case "note":
                AddItem(new Item { itemType = Item.ItemType.Note, amount = 1 });
                break;
            case "potion1":
                AddItem(new Item { itemType = Item.ItemType.Potion1, amount = 1});
                break;
            case "potion2":
                AddItem(new Item { itemType = Item.ItemType.Potion2, amount = 1 });
                break;
            case "potion3":
                AddItem(new Item { itemType = Item.ItemType.Potion3, amount = 1 });
                break;
            default:
                break;
        }
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }

    public void RemoveItem(Item.ItemType type)
    {
        foreach(Item item in itemList)
        {
            if(item.itemType == type)
            {
                item.amount -= 1;
                itemList.Remove(item);
                uiInventory.RefreshInventoryItems();
            }
        }
    }
}
