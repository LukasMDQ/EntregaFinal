using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Vector3 PosInicial;
    void Start()
    {
        PosInicial=transform.position;
    }
    void Update()
    {
        if (transform.position.y <= -15)
        {
            Respawnear();
        }
        

    }
   public void Respawnear ()
   {
        transform.position = PosInicial;
       
   }
    private void OnTriggerEnter(Collider other)
    {
        if (other .CompareTag("End"))
        {
            Debug.Log("Posicion Restaurada");
            Respawnear();
        }
    }

}

