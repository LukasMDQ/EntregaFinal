using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovCamara : MonoBehaviour
{
    public float sensibilidadMouse = 200f;
    public float xRotacion;
    public float yRotacion;
    public float RotationSpeed;
    void Start()
    {
        
    }

   
    void Update()
    {
        MouseLook();
    }
    void MouseLook()

    {

        float mouseX = Input.GetAxis("Mouse X") * sensibilidadMouse * Time.deltaTime;

        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadMouse * Time.deltaTime;



        xRotacion -= mouseY;

        xRotacion = Mathf.Clamp(xRotacion, -70, 70);



        yRotacion += mouseX;



        transform.localRotation = Quaternion.Euler(xRotacion, yRotacion, 0);

    }
}
