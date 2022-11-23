using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zad6_5 : MonoBehaviour
{
  private Zadanie2_3 player;

  private void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("Player"))
    {
      player = other.GetComponent<Zadanie2_3>();
      
      player.velocity.y = Mathf.Sqrt(player.jumpHeight * -3.0f * player.gravity) * 3;
    }
  }
}
