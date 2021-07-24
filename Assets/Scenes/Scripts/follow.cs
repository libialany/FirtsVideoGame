using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    public Vector3 offset;
    public Transform target;
    [SerializeField]
    float smooth=0.125f;
    void LateUpdate(){
        Vector3 newPosition=target.position+offset;
        Vector3 smoothedPos=Vector3.Lerp(transform.position,newPosition,smooth);
        transform.position=smoothedPos;
        
    }
}
