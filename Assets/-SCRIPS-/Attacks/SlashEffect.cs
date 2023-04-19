using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashEffect : MonoBehaviour
{
    public GameObject Slasheffect;
    
    private void Update()
    {
    }
    public void activeEffect()
    {
        Slasheffect.SetActive(true);
    }
    public void desactiveEffect()
    {
        Slasheffect.SetActive(false);
    }
}

    
    
