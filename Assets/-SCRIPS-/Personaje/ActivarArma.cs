using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivarArma : MonoBehaviour
{
    public PickUp pickUp;
    public int numeroArma;
    public GameObject textPick;
    void Start()
    {
        pickUp = GameObject.FindGameObjectWithTag("Personaje").GetComponent<PickUp>();
    }     
  
    private void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.name == "Personaje")
        {
            textPick.SetActive(true);
            if (Input.GetKeyDown(KeyCode.G))
            {               
                pickUp.ActivarArma(numeroArma);
                textPick.SetActive(false);
                Destroy(gameObject);
            }
                     
        }
        else
        {
            textPick.SetActive(false);
        }
        
    }
   
}
