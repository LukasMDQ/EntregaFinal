
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour,IPointerClickHandler
{
    public GameObject item;
    public int ID;
    public string type;
    public string description;

    public Sprite icon;
    public bool empty;

    public Transform slotIconGameObject;
    

    void Start()
    {
        slotIconGameObject = transform.GetChild(0);
    }
       
    public void updateSlot()
    {
        slotIconGameObject.GetComponent<Image>().sprite = icon;
       
    }
    public void useItem()
    {
        item.GetComponent<Item>().itemUsage();
    }
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        useItem();
    }
}
