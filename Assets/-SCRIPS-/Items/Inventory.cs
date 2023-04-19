using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private bool inventoryEnabled;

    public GameObject inventory;

    private int allSlots;

    private int enabledSlots;

    private GameObject[] slot;

    public GameObject slotPanel;
    
    void Start()//guarda cada slot numerado en un array.
    {
        allSlots = slotPanel.transform.childCount;//pregunta la cantidad de slots
        slot = new GameObject[allSlots];//guarda la cantidad de slots 
        for (int i = 0; i < allSlots; i++)//mete cada slot en una posicion 
        {
            slot[i] = slotPanel.transform.GetChild(i).gameObject;

            if (slot[i].GetComponent<Slot>().item==null)
            {
                slot[i].GetComponent<Slot>().empty= true;
            }
        }
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryEnabled = !inventoryEnabled;//si el inventario esta abierto lo  cierra y de lo contrario se abre.
        }
        if (inventoryEnabled)
        {
            inventory.SetActive(true);
        }
        else
        {
            inventory.SetActive(false);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "item")
        {
            GameObject itemPickedUp = other.gameObject;

            Item item = itemPickedUp.GetComponent<Item>();

            AddItem(itemPickedUp,item.ID,item.type,item.description,item.icon);
        }
    }
    public void AddItem(GameObject itemObject,int itemID,string itemType,string itemDescription,Sprite itemIcon)
    {
        for (int i = 0; i < allSlots; i++)
        {
            if (slot[i].GetComponent<Slot>().empty)// si el slot se ecnuentra vacio permitira añadir un objeto.
            {
                itemObject.GetComponent<Item>().pickedUp = true;

                slot[i].GetComponent<Slot>().item = itemObject;
                slot[i].GetComponent<Slot>().ID = itemID;
                slot[i].GetComponent<Slot>().type = itemType;
                slot[i].GetComponent<Slot>().description = itemDescription;
                slot[i].GetComponent<Slot>().icon = itemIcon; 

                itemObject.transform.parent = slot[i].transform;
                itemObject.SetActive(false);



                slot[i].GetComponent<Slot>().updateSlot();

                slot[i].GetComponent <Slot>().empty = false;

                return;
            }
            
        }
    }
}
