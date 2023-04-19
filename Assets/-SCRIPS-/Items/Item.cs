using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int ID;
    public string type;
    public string description;
    public Sprite icon;

    [HideInInspector]
    public bool pickedUp;

    [HideInInspector]
    public bool equiped;

    [HideInInspector]
    public GameObject weaponManager;

    [HideInInspector]
    public GameObject weapon;

    public bool playersWeapon;

    void Start()
    {
        weaponManager = GameObject.FindGameObjectWithTag("WeaponManager");//FindGameObjectWithTag
        if (!playersWeapon)
        {
            int allWeapons = weaponManager.transform.childCount;
            for (int i = 0; i < allWeapons; i++)
            {
                if(weaponManager.transform.GetChild(i).gameObject.GetComponent<Item>().ID==ID)
                {
                    weapon = weaponManager.transform.GetChild(i).gameObject;
                }
                    
            }
        }
    }

    
    void Update()
    {
        if (equiped)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                equiped = false;
            }
            if (equiped==false)
            {
                gameObject.SetActive(false);
            }
        }
        itemUsage();
    }
   public void itemUsage()
   {
        if (type == "Weapon")
        {
            //equiped= true;
            weapon.SetActive(true);
            weapon.GetComponent<Item>().equiped=true;

        }
   }
}
