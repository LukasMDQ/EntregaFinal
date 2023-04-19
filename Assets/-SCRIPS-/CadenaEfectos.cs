using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class CadenaEfectos : MonoBehaviour
{
    public GameObject Rain;
    public GameObject Escalable;
    public GameObject rayos;
    public GameObject sonido;
    public GameObject luz;
    public GameObject CamColor;




    public void Lluvia()
    {
        Instantiate(Rain);
        Debug.Log("Comenzo a Llover, deberia refugiarme ...");
    }

   /* public void escalar()
    {
       
        Escalable.transform.localScale += new Vector3(0.2f, 2f, 0.1f);
    }*/

    public void InstaRayos()
    {
        Instantiate(rayos);
        
    }

    public void encender()
    {
        sonido.SetActive(true);
        

    }

    /*public void encenderLuz()
    {
        luz.SetActive(true);
        
    }
    public void cambiarcolor()
    {
        CamColor.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
        
    }*/

    


}
