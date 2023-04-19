using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboMele : MonoBehaviour
{
    public MoveToClick toClick;
    public Camera playerCam;
    public AudioSource audio_com;
    public AudioClip[] sound;
    Animator anima;
    int clickCount;
    bool moreClick;
    public bool onAttack;
    public float focusPosition = 90f;
   
    
    void Start()
    {
        audio_com = GetComponent<AudioSource>();
        anima = GetComponent<Animator>();
        clickCount = 0;
        moreClick = true;
        onAttack = false;
    }


    void Update()
    {
       
        if (Input.GetMouseButtonDown(1) && toClick.Running == false )
        {
            Focus();
            onAttack = true;
            StartCombo(); 
        }             
    }
    public void Focus()
    {      
            Vector3 positionOnScreen = playerCam.WorldToViewportPoint(transform.position);
            Vector3 mouseOnScreen = (Vector2)playerCam.ScreenToViewportPoint(Input.mousePosition);

            Vector3 direction = mouseOnScreen - positionOnScreen;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - focusPosition;
            transform.rotation = Quaternion.Euler(new Vector3(0, -angle, 0));      

    }
    void StartCombo()
    {
       
        //audio_com.clip = sound[clickCount];
        // audio_com.Play();
        if (moreClick)
        {
            clickCount++;
        }
        if(clickCount == 1) 
        {
            anima.SetInteger("Combo", 1);
        }
    }
    void ComboScan()
    {
        moreClick = false;
        if (anima.GetCurrentAnimatorStateInfo(0).IsName("Combo1") && clickCount == 1 && toClick.Running == false)
        {
           onAttack= false;
            anima.SetInteger("Combo", 0);
            moreClick = true;
            clickCount = 0;
        }
        else if (anima.GetCurrentAnimatorStateInfo(0).IsName("Combo1") && clickCount >= 2 && toClick.Running == false)
        {
            anima.SetInteger("Combo", 2);
            moreClick = true;
        }
        else if (anima.GetCurrentAnimatorStateInfo(0).IsName("Combo2") && clickCount == 2 && toClick.Running == false)
        {
            onAttack = false;
            anima.SetInteger("Combo", 0);
            moreClick = true;
            clickCount = 0;
        }
        else if (anima.GetCurrentAnimatorStateInfo(0).IsName("Combo2") && clickCount >= 3 && toClick.Running == false)
        {
            anima.SetInteger("Combo", 3);
            moreClick = true;
        }
        else if (anima.GetCurrentAnimatorStateInfo(0).IsName("Combo3") && clickCount == 3 && toClick.Running == false)
        {
            onAttack = false;
            anima.SetInteger("Combo", 0);
            moreClick = true;
            clickCount = 0;
        }
        else if (anima.GetCurrentAnimatorStateInfo(0).IsName("Combo3") && clickCount >= 4 && toClick.Running == false)
        {
            anima.SetInteger("Combo", 4);
            moreClick = true;
            
        }
        else if (anima.GetCurrentAnimatorStateInfo(0).IsName("Combo4") && toClick.Running == false)
        {
            onAttack = false;
            anima.SetInteger("Combo", 0);
            moreClick = true;
            clickCount = 0;
        }
       

    }
}
