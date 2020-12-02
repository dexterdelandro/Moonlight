using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    Inventory inventory;
    UI_InventoryS uiInventory;
    string itemName;

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.Find("FPSController").GetComponent<Inventory>() as Inventory;
        uiInventory = GameObject.Find("UI_Inventory").GetComponent<UI_InventoryS>() as UI_InventoryS;
        itemName = this.gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter()
    {
        Debug.Log("hit " + itemName);
        inventory.AddItem(itemName);
        uiInventory.RefreshInventoryItems();
        Destroy(this.gameObject);
    }
}
