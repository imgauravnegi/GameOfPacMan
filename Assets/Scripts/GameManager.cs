using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{ 
    public static GameManager gameManager;
    public GameObject Screan1;
  public GameObject Screan2;
  public GameObject Envrt;
  public GameObject Player;
  private void Awake() {
    gameManager=this;
  }
   public void ClickOn_StartBtn()
   {
     Screan1.SetActive(false);
     Envrt.SetActive(true);

   }
   public void ClickOn_RestartBtn()
   {
     
     Envrt.SetActive(true);
     Player.SetActive(true);
     Screan2.SetActive(false);
    Player.GetComponent<PlayerMovement> ().PlayerReset();


   }
   public void OnGameOver()
   {
    Screan2.SetActive(true);
    Screan1.SetActive(false);
   
   }

   
}
