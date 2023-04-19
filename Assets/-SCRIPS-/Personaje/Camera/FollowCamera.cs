using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FollowCamera : MonoBehaviour
{     
    public Transform followTarget;
    public float followSpeed = 5f;
    private Vector3 offset;
    //zoom
    CinemachineVirtualCamera cameraVirtual;
    CinemachineComponentBase componentBase;

    [SerializeField] float Sens;
    [SerializeField] float zoomMin;
    [SerializeField] float zoomMax;
    private void Awake()
    {
        cameraVirtual= GetComponent<CinemachineVirtualCamera>();
        componentBase = cameraVirtual.GetCinemachineComponent(CinemachineCore.Stage.Body);
    }

    void Start()
    {                
        offset = followTarget.position - transform.position;
    }
   


    private void  LateUpdate()
    {        
        if (followTarget)
        {
            transform.position = followTarget.position - offset;
        }  
        if (Input.GetAxis("Mouse ScrollWheel")!= 0)
        {
            float cameraDist = Input.GetAxis("Mouse ScrollWheel") * Sens;
            if (componentBase is CinemachineFramingTransposer)
            {
                (componentBase as CinemachineFramingTransposer). m_CameraDistance -= cameraDist;
                (componentBase as CinemachineFramingTransposer).m_CameraDistance = Mathf.Clamp((componentBase as CinemachineFramingTransposer).m_CameraDistance, zoomMin, zoomMax);
            }
        }
    }
}
