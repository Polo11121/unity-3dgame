using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zad6_2 : MonoBehaviour
{
  private Vector3 openPosition;
  private Vector3 closePosition;
  private Transform playerPosition;

  private bool isOpen;

  void Start()
  {
    playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
    closePosition = transform.position;
    closePosition.x += transform.localScale.x;
  }

  void Update()
  {
    if (Vector3.Distance(transform.position, playerPosition.position) >= 1.5f && isOpen == true)
    {
      isOpen = false;

      transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
    }

    if (Vector3.Distance(transform.position, playerPosition.position) < 1.5f && isOpen == false)
    {
      transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);

      isOpen = true;
    }
  }
}
