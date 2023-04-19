using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class STATS : MonoBehaviour
{
    //LVL
    public GameObject lvl_UP_Effect;
    public Transform PlayerPos;
    public int LVL;
    //EXP
    public TextMeshProUGUI textMesh;
    public int exp = 100;
    public float maxEXP;
    public Image expBar;
    //HP
    public int hp = 100;
    public float maxHP;
    public Image hpBar;
    //MP
    public int mp = 100;
    public float maxMP;
    public Image mpBar;
    //Damage
    public float Damage = 30f;
    //Herencias
   // public enemy_Control enemy_Control;
    public Respawn respawn;
    public ComboMele comboMele;
    public Berserker berserker;

    void Start()
    {
        respawn = gameObject.GetComponent<Respawn>();
        comboMele = gameObject.GetComponent<ComboMele>();
        berserker = gameObject.GetComponent<Berserker>();
       // textMesh = GetComponent<TextMeshProUGUI>();
       // enemy_Control.GetComponent<enemy_Control>();
       // maxHP = hp;
       // maxMP = mp;
       // maxEXP = exp;
    }
    void Update()
    {
        expBar.fillAmount = maxEXP / exp;
        mpBar.fillAmount = maxMP / mp;
        hpBar.fillAmount = maxHP / hp;
        Regeneration();
        Death();
        lvlUp();
        textMesh.text = LVL.ToString("0");
    }

    void Regeneration()//Recuperacion Automatica por segundo HP/MP.
    {
        if (maxHP <= 100 && maxHP >= 0)
        {
            maxHP += 0.005f;
        }
        if (maxMP <= 100)
        {
            maxMP += 0.01f;
        }
    }
    
    void Death()//Logica Muerte del personaje.
    {
        if (maxHP <=0)
        {
            Debug.Log("HAS MUERTO");
            respawn.Respawnear();
            maxHP = hp;
        }
    }
    private void lvlUp()//Logica aumento de nivel y estadisticas.
    {
       /* if (enemy_Control.topHp <=0 )
        {
            maxEXP += 20;
        }  */         
       
        if (maxEXP >= 100)
        {
            LVL += 1;
            Instantiate(lvl_UP_Effect, PlayerPos.transform.position,PlayerPos.transform.rotation);
            maxEXP = 0;
            hp += 10;
            mp += 10;
            Damage += 5;
            Debug.Log("Has subido al nivel:" + LVL);
           
        }

    }

    private  void OnTriggerEnter(Collider other)//Daño del enemigo y efectos.
    {
        if (other.gameObject.CompareTag("daño"))
        {            
            maxHP -= 1;
            
            //GameObject efectoGolpe = Instantiate(efectoMuerte, transform.position, transform.rotation);
            //Destroy(efectoGolpe, 0.2f);
            //AudioSound(_Clip_hit);
        }
        if (other.gameObject.CompareTag("dañoAlfa"))
        {           
            maxHP -= 3;
            //GameObject efectoGolpe = Instantiate(efectoMuerte, transform.position, transform.rotation);
            //Destroy(efectoGolpe, 0.2f);
            //AudioSound(_Clip_hit);
        }
    }
}
