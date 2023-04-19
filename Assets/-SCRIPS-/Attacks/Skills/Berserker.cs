using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Berserker : MonoBehaviour
{
    [HideInInspector]
    public ComboMele ComboMele;
    [HideInInspector]
    public MoveToClick toClick;
    [HideInInspector]
    public STATS stats;

    public int time = 1;
    public float currentTime;
    public GameObject skillEffect;
    public GameObject Aura;
    public Animator anim;
    public Image CoolDown;
    public Rigidbody rb;
    

    
    void Start()
    {
        currentTime = time;
        stats = gameObject.GetComponent<STATS>();
        toClick = gameObject.GetComponent<MoveToClick>();
        ComboMele = gameObject.GetComponent<ComboMele>();
    }      

    void Update()
    {
        SkillLaunch();
        CoolDown.fillAmount = currentTime / time;
        StartTemp();
    }
    public void StartTemp()
    {
        currentTime += 1 * Time.deltaTime;
    }

    public void SkillLaunch()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3) && currentTime >= time && stats.maxMP >= 30 && toClick.Running == false)
        {
            
            
            Aura.SetActive(true);
            currentTime = 0f;
            anim.SetTrigger("Berserker");
            //Mientras el Aura este activa el power Up tendra efect.
            if(Aura)
            {
                stats.maxHP += 40f;
                stats.maxMP -= 20f;
                stats.Damage += 20f;
            }          
                        
        }
        if (currentTime >= 20)
        {
            Aura.SetActive(false);
        }
    }
    public void berserkerEffectStart()
    {
        ComboMele.onAttack = true;
        skillEffect.SetActive(true);
    }
    public void berserkerEffectEnd()
    {
        ComboMele.onAttack = false;
        skillEffect.SetActive(false);
    }
    
}
