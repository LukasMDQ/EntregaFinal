
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class MoveToClick : MonoBehaviour
{
    private NavMeshAgent agent;
    private Ray myray;
    public Camera playerCamera;
    public Animator anim;
    public bool Running;

    public ComboMele comboMele;     
        
    void Start()
    {
       Running = true;
       comboMele = gameObject.GetComponent<ComboMele>();
       agent = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
       if(Input.GetMouseButton(0) && comboMele.onAttack == false) 
       {
            
            Ray myRay = playerCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if ( Physics.Raycast(myRay, out hit) ) 
            {
                 agent.SetDestination(hit.point);
            }
       }
       else
       {
            Running = false;
       }
       if (agent.remainingDistance <= agent.stoppingDistance)
       {
           Running = false;
       }
       else
       {
           Running = true;
       }
        anim.SetBool("Running", Running);
    }
    public void StopRun()
    {
        Running = false;
    }
    public void StartRun()
    {
        Running = true;
    }
    
}

