using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDetection : MonoBehaviour
{
    public enemyMovement enemy ;
    
private void OnTriggerEnter(Collider other)
 {
    if(other.gameObject.CompareTag("Player"))
    {
        Debug.Log("Player Enter In THe Room");
        enemy.SetPlayerFollow(other.transform);

    }
}
private void OnTriggerExit(Collider other) {
    if(other.gameObject.CompareTag("Player"))
    {
         Debug.Log("Player Exit In THe Room");
        enemy.SetWayPointFollow();
        }
}

    
}
