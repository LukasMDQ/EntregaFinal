using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Admin_Mat : MonoBehaviour
{
    Material mat;
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }
    

    
    void Update()
    {
        
    }
    public void InvisibleON ()
    {
        Color C = mat.color;
        C.a = 0.1f;
        mat .color= C;
    }
    public void InvisibleOFF()
    {
        Color C = mat.color;
        C.a = 1;
        mat.color = C;
    }



}
