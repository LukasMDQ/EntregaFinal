
using System;
using UnityEngine;
using UnityEngine.Events;

public class Eventos : MonoBehaviour
{
    [SerializeField] private UnityEvent TriggerEvent;
   
    public int rotSpeed=5;
   
    void Update()
    {
        transform.Rotate(rotSpeed * Time.deltaTime, 0,0);        
                
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("piso"))
        {
            TriggerEvent.Invoke();
        }
    }
}
