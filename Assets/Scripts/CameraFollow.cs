using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
     public Transform target2;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(target != null)
        {
            transform.position=target.position+offset;
            
           
            transform.rotation=Quaternion.Slerp(transform.rotation,target.rotation,10.0f*Time.deltaTime);
            
        }
        if(target2 != null)
        {
           float newPosition= Mathf.Clamp(target.position.z,-3.63f,6.34f);
            target2.position=new Vector3(-0.56f,26.287f,newPosition);
        }
    }
}
