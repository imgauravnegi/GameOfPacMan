using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyMovement : MonoBehaviour
{  public NavMeshAgent nvAgent;
public int currentWayPoint;
  public Transform[] targets;
  public Transform playerTarget;
   public AudioSource gameOverSound;
   
    
    // Start is called before the first frame update
    void Start()
    {
        nvAgent.SetDestination(targets[currentWayPoint].position);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log((Vector3.Distance(transform.position,targets[currentWayPoint].position)  ));
        if(playerTarget!=null)
        {
            nvAgent.SetDestination(playerTarget.position);
        }
        else
        {
              
        if(Vector3.Distance(transform.position,targets[currentWayPoint].position)<1.0f)
        {
            
             currentWayPoint=(currentWayPoint+1)%targets.Length;
             nvAgent.SetDestination(targets[currentWayPoint].position);
           

        }

        }
      
    }

     public void SetPlayerFollow(Transform target)
     {
        playerTarget=target;

     }
     public void SetWayPointFollow()
     {
        playerTarget=null;
         nvAgent.SetDestination(targets[currentWayPoint].position);

     }
   private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Player") 
        {
            Debug.Log("Player is hit");
            other.gameObject.SetActive(false);
            gameOverSound.Play();
             GameManager.gameManager.OnGameOver();
        }

}

}
