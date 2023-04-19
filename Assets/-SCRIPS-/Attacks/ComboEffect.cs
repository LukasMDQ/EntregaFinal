using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboEffect : MonoBehaviour
{
    public GameObject effect;
    public GameObject blurEffect;
    public GameObject Slasheffect;

    //FinalBlurEffect
    public void ActivePower()
    {
        effect.SetActive(true);
    }
    public void desactivePower()
    {
        effect.SetActive(false);
    }
    //SlashSword Effect
    public void activeEffect()
    {
        Slasheffect.SetActive(true);
    }
    public void desactiveEffect()
    {
        Slasheffect.SetActive(false);
    }
}
