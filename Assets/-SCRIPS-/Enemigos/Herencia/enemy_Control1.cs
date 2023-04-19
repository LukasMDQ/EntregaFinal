using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class enemy_Contro1 : MonoBehaviour
{
    //Stats
    public int hp = 100;
    public float maxHp;
    public float damage = 5f;
    public float speed = 2f;
   
    public int deaths=0;
    //Info
    public string Name;
    public string lvl;
    //Animations
    public bool onAttack;
    public bool attack;
    public Animator anim;
    //Effects
    public GameObject deathEffect;
    public GameObject hitEffect;
    public GameObject hitEffect2;
    //audio
    public AudioSource _audSource;
    public AudioClip death_Clip;
    public AudioClip hit_Clip;
    //Navegation
    public NavMeshAgent navAgent;
    public Quaternion angulo;
    public float grade;
    public int rutine;
    public float crono;
    //Physics
    public Rigidbody rb;
    //targets
    public GameObject target;
    //-----HUD
    public Image HP;
    private void Start()
    {
       
        maxHp= hp;
        anim = GetComponent<Animator>();
        target = GameObject.Find("Personaje");          //cambiar a tag  "player".
    }
       
   
    public virtual void  Enemy_Status1()//"virtual" permite sobreescribir el metodo.
    {
        if (Vector3.Distance(transform.position, target.transform.position) > 10)//si el objetivo se encuentra a mas de 10 metros se movera erraticamente.
        {
            if (maxHp <= 90)//si la vida baja al valor establecido seguira al objetivo. 
            {
                Debug.Log("CARNEEE ! ");
                var lookPos = target.transform.position - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                anim.SetBool("walk", false);
                anim.SetBool("run", true);
                transform.Translate(Vector3.forward * speed * 2 * Time.deltaTime);
                if (Vector3.Distance(transform.position, target.transform.position) <= 1)//si el objetivo se encuentra a menos de 1 metros lo atacara.
                {
                    anim.SetBool("walk", false);
                    anim.SetBool("run", false);

                    anim.SetBool("attackM",true);
                    onAttack = true;
                }
                
            }
            anim.SetBool("run", false);//Movimiento erratico
            crono += 1 * Time.deltaTime;
            if (crono >= 4)
            {
                rutine = Random.Range(0, 2);
                crono = 0;
            }
            switch (rutine)
            {
                case 0:
                    anim.SetBool("walk", false);
                    break;
                case 1:
                    grade = Random.Range(0, 360);
                    angulo = Quaternion.Euler(0, grade, 0);
                    rutine ++;
                    break;
                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                    transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                    anim.SetBool("walk", true);
                    break;
            }
        }
        else//persigue al objetivo.
        {
            if (Vector3.Distance(transform.position, target.transform.position) > 1 && !onAttack)//si esta mas de un metro y no esta atacando lo perseguira .
            {
                Debug.Log("CARNEEE ! ");
                var lookPos = target.transform.position - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                anim.SetBool("walk", false);
                anim.SetBool("run", true);
                transform.Translate(Vector3.forward * speed * 2 * Time.deltaTime);
                anim.SetBool("attackM", false);
            }
            else
            {
                anim.SetBool("walk", false);
                anim.SetBool("run", false);

                anim.SetBool("attackM", true);
                onAttack= true;
            }           
               
        }
    }
    public void death1()
    {
        HP.fillAmount = maxHp / hp;//la barra de vida bajara en funcion al daño recibido.
       
        if (maxHp <= 0)
        {
           // Debug.Log(maxExp);            
            speed = 0;
            deaths += 1;
           // maxExp +=1;
            //AudioSound(death_Clip);
            anim.SetTrigger("deadZ");
           // GameObject enemyDestroy = Instantiate(deathEffect, transform.position, transform.rotation);
           // Destroy(enemyDestroy, 0.2f);
            Destroy(gameObject,5);
        }
        
    }
    public void End_Anim()
    {
        anim.SetBool("attackM", true);
        onAttack= false;
    }
      
    void AudioSound(AudioClip _Clip_Test)//Audio
    {
        _audSource.clip = _Clip_Test;
        _audSource.Play();
    }
    private void OnCollisionEnter(Collision other)//si colisiona un objeto con el tag "sword" o "arrow" su vida baja 30 puntos.
    {
        if (other.gameObject.CompareTag("espada")) //&& other.gameObject.CompareTag("hand"))                                                            //camiar tag  a "sword"
        {
            //GameObject efectoGolpe = Instantiate(efectoMuerte, transform.position, transform.rotation);
            //Destroy(efectoGolpe, 0.2f);
            AudioSound (hit_Clip);
            Debug.Log("HIT");
            maxHp -= 30;

        }
    }


}
