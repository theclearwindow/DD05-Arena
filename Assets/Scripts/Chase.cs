using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.UI;
 public class AIController : MonoBehaviour
 {
 
     public Transform Player;
     int MoveSpeed = 4;
     int MaxDist = 10;
     int MinDist = 5;
 
 
 
 
     void Start()
     {
 
     }
 
     void Update()
     {
         transform.LookAt(Player);
 
         if (Vector3.Distance(transform.position, Player.position) >= MinDist)
         {
 
             transform.position += transform.forward * MoveSpeed * Time.deltaTime;
 
 
 
             if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
             {
                 //Here call any function for actions, like shoot or something
             }
 
         }
     }
 }
