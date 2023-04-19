using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChangeMat : MonoBehaviour
{
    Vector3 directionCam;
    public Transform player;
    public LayerMask FloorMask;
    public List<Transform> obstacle;
    List<Admin_Mat> admin_Mats;
    List<bool> PlayerCovered;
    List<bool> PlayerDiscovered;
    void Start()
    {
        admin_Mats = new List<Admin_Mat>();
        PlayerCovered = new List<bool>();
        PlayerDiscovered = new List<bool>();
        for (int i = 0; i < obstacle.Count; i++)
        {
            admin_Mats.Add(obstacle[i].GetComponent<Admin_Mat>());
            PlayerCovered.Add(false);
            PlayerDiscovered.Add(false);

        }
    }

    void Update()
    {
        directionCam = new Vector3 (player.position.x - transform.position.x,player.position.y - transform.position.y,player.position.z - transform.position.z);
        //Lanza un rayo desde la camara al jugador.
        RaycastHit[] hits = Physics.RaycastAll (transform.position, directionCam,Vector3.Distance ( transform.position,player.transform.position ),FloorMask);
        for (int i = 0; i < obstacle.Count; i++)
        {
            PlayerCovered[i] = false;
        }
        //Revisa si el rayo golpea alguno de los transform de la lista "obstacle".
        for(int i = 0; i < hits.Length; i++)
        {
            if(obstacle.Contains(hits[i].transform))
            {
                int index = obstacle.IndexOf(hits[i].transform);
                PlayerCovered[index] = true;
            }
        }
        for (int i = 0; i < obstacle.Count; i++)
        {
            if (PlayerDiscovered[i] != PlayerCovered[i])
            {
                if (PlayerCovered[i])
                {
                    admin_Mats[i].InvisibleON();
                }
                else
                {
                    admin_Mats[i].InvisibleOFF();
                }
            }
        }
        //Guarda el valor de si estuvo o no el personaje detras en este frame , para el siguiente.
        for (int i = 0; i < obstacle.Count; i++)
        {
            PlayerDiscovered[i] = PlayerCovered[i];
        }
    }

}
