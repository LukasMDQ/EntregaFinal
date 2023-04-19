using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Active_Item : MonoBehaviour
{
    public GameObject Sword;
    public GameObject GreatSword;

    private Item item;
    
    public void activateItem()
    {
        if (item.ID == 2)
        {
            GreatSword.SetActive(false);
            Sword.SetActive(true);
        }
        if (item.ID == 1)
        {
            Sword.SetActive(false);
            GreatSword.SetActive(true);
        }

        /*if (Item) 
        {
            Item.SetActive(false);
        }
        else
        {
            Item.SetActive(true);
        }*/


    }

    
}
