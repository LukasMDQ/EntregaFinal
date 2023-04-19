using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class enemy_Control : MonoBehaviour
{
    //herencia
    public STATS stats;
    //Stats
    public int hp1 = 100;
    public float topHp;
    public float mExp = 0.02f;
    public float speed = 0.5f;
    

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
    public float attackDistance;
    public float visionRange;
    //Physics
    public Rigidbody rb;
    //targets
    public GameObject target;
    //-----HUD
    public Image HP;
    private void Start()
    {
        //stats = gameObject.GetComponent<STATS>();
        topHp = hp1;
        anim = GetComponent<Animator>();
        target = GameObject.Find("Personaje");//cambiar a tag  "player".
    }
    public void death()
    {

        HP.fillAmount = topHp / hp1;//la barra de vida bajara en funcion al daño recibido.

        if (topHp <= 0)
        {
            stats.maxEXP += 0.1f;
            speed = 0;
            anim.SetBool("deadM",true);
            anim.SetBool("walk", false);
            anim.SetBool("run", false);
            anim.SetBool("attackM", false);
            
          
            //AudioSound(death_Clip);
            
            // GameObject enemyDestroy = Instantiate(deathEffect, transform.position, transform.rotation);
            // Destroy(enemyDestroy, 0.2f);
            Destroy(gameObject,2);
        }
        
    }
      
    void AudioSound(AudioClip _Clip_Test)//Audio
    {
        _audSource.clip = _Clip_Test;
        _audSource.Play();
    }
    private void OnCollisionEnter(Collision other)
    {   //si colisiona un objeto con el tag "PlayerDamage" su vida baja en funcion al daño del Jugador.
        if (other.gameObject.CompareTag("PlayerDamage"))                                               
        {
            //GameObject efectoGolpe = Instantiate(efectoMuerte, transform.position, transform.rotation);
            //Destroy(efectoGolpe, 0.2f);
            AudioSound (hit_Clip);
            Debug.Log("HIT");
            topHp -= stats.Damage;
            

        }
    }
    public virtual void Enemy_Status()//"virtual" permite sobreescribir el metodo.
    {
        if (Vector3.Distance(transform.position, target.transform.position) > visionRange)//si el objetivo se encuentra a mas de 10 metros se movera erraticamente.
        {
            if (topHp <= 90)//si la vida baja al valor establecido seguira al objetivo. 
            {
                navAgent.enabled= false;
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

                    anim.SetBool("attackM", true);
                    onAttack = true;
                }

            }//---------------------------------------------------------------------------------------------------------
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
                    rutine++;
                    break;
                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                    transform.Translate(Vector3.forward * speed * Time.deltaTime);
                    anim.SetBool("walk", true);
                    break;
            }
        }
            else//ve al objetivo y lo persigue.-------------------------------------------------------------------------
            {
             //si esta mas de un metro y no esta atacando lo perseguira .
           
                Debug.Log("CARNEEE ! ");
                var lookPos = target.transform.position - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);

                navAgent.enabled = true;
                navAgent.SetDestination(target.transform.position);

                if(Vector3.Distance(transform.position,target.transform.position) > attackDistance && !onAttack)
                {
                    anim.SetBool("walk", false);
                    anim.SetBool("run", true);
                }
                              
                else
                {
                    if(!onAttack)
                    {
                        transform.rotation = Quaternion.RotateTowards(transform.rotation,rotation, 1);
                        anim.SetBool("walk", false);
                         anim.SetBool("run", false);
                    }
                    

                     anim.SetBool("attackM", true);
                     onAttack = true;
                }
            }
            if(onAttack) 
            {
                navAgent.enabled = true;
            }
    }
    public void Final_Ani()
    {
        if(Vector3.Distance(transform.position,target.transform.position) > attackDistance +0.2f)
        {
            anim.SetBool("attackM", false);
        }
        
        onAttack = false;
    }


}
/* else//ve al objetivo y lo persigue.-------------------------------------------------------------------------
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
                onAttack = true;
            }

        }*/
