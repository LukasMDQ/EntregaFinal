using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class BarraHpFollow : MonoBehaviour
{
    public GameObject target;
    public GameObject BarraHP;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       transform.forward = target.transform.forward;
    }
}
