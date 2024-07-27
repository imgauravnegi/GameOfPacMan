using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{ 
    public float speed=1.0f ;
    public Vector3 movedirection;
    public Animator anim;
    public Rigidbody rb;
    public AudioSource aS;
     public AudioSource ab;
     public AudioSource coinCollect;
      public AudioSource chrWalkSound;
       
       public Vector3 StartPostition;
       
    

    // Start is called before the first frame update
    void Start()
    {
        StartPostition=transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MoveMent(); 
       FaceRotation();
       WalkSound();
    
     }
     void MoveMent()
     {
        float  horizontalInput = Input.GetAxis("Horizontal");
       float  verticalInput = Input.GetAxis("Vertical");
        movedirection= new Vector3(verticalInput,0f,horizontalInput);
        rb.velocity=new Vector3(movedirection.x*speed,0,movedirection.z*speed);
     }
     void FaceRotation()
     {
        Quaternion currentRotation=transform.rotation;
       Vector3 currentPosition;
       currentPosition.x=movedirection.x;
       currentPosition.y=0;
       currentPosition.z=movedirection.z;
       if(movedirection!=Vector3.zero)
       {
         Quaternion targetRotation= Quaternion.LookRotation(currentPosition);
       transform.rotation=Quaternion.Slerp(currentRotation,targetRotation,10.0f*Time.deltaTime);

       }
      

     }
     public void PlayerReset()
     {
      transform.position = StartPostition;
     }
     private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Coin")) 
        { 
             other.gameObject.SetActive(false);
             coinCollect.Play();
         }
          if (other.gameObject.CompareTag("Door")) 
        { 
            other.GetComponent<Animator>().Play("DoorOpen");
            aS.Play();
         }
      
}
   private void OnTriggerExit(Collider other) {
            if (other.gameObject.CompareTag("Door")){
                other.GetComponent<Animator>().Play("Doorclose");
                ab.Play();
            }
         }
         private void WalkSound()
         {
            if (Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.D))
            {
               chrWalkSound.enabled =true;
            }
            else{
                chrWalkSound.enabled =false;
            }
         }


   
}